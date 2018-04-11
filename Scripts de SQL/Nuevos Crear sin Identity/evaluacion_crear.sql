use BBD1;
go
CREATE PROCEDURE evaluacion_crear @idGrupoxRubro int, @Nombre varchar(50), @Fecha Date, 
@ValorPorcentual decimal(7, 4), @Descripcion varchar(100)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Evaluacion);
    SET @ID = @ID + 1;
	Declare @TablaValores Table (Cantidad int, esfijo varchar(6));
	INSERT INTO @TablaValores SELECT Cantidad, esfijo FROM dbo.GrupoxRubro WHERE ID = @idGrupoxRubro;
	SELECT * FROM @TablaValores
	IF (SELECT esfijo FROM @TablaValores) = 'False'
		BEGIN
		DECLARE @CantidadDeEvaluaciones int;
		SET @CantidadDeEvaluaciones = (SELECT Cantidad FROM @TablaValores);
		DECLARE @Porcentaje Decimal(7, 4);
		SET @Porcentaje = (SELECT TOP 1 ValorPorcentual FROM dbo.Evaluacion WHERE IdGrupoxRubro = @idGrupoxRubro);
		DECLARE @PorcentajeNuevo Decimal(7, 4);
		SET @PorcentajeNuevo = @Porcentaje / @CantidadDeEvaluaciones;
		INSERT INTO dbo.Evaluacion(ID, idGrupoxRubro, Nombre, Fecha, ValorPorcentual, Descripcion)
		VALUES(@ID, @idGrupoxRubro, @Nombre, @Fecha, @PorcentajeNuevo, @Descripcion);
		UPDATE dbo.Evaluacion SET ValorPorcentual = @PorcentajeNuevo WHERE IdGrupoxRubro = @idGrupoxRubro;
		EXEC grupoxrubro_aumentar_cantidad @idGrupoxRubro;
		END
	ELSE
		BEGIN
		INSERT INTO dbo.Evaluacion(ID, idGrupoxRubro, Nombre, Fecha, ValorPorcentual, Descripcion)
		VALUES(@ID, @idGrupoxRubro, @Nombre, @Fecha, @ValorPorcentual, @Descripcion)
		END
END
go