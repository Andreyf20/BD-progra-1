use BBD1;
go
CREATE PROCEDURE evaluacion_crear @idGrupoxRubro int, @Nombre varchar(50), @Fecha Date, 
@ValorPorcentual decimal(7, 4), @Descripcion varchar(100)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Evaluacion);
    SET @ID = @ID + 1;
	INSERT INTO dbo.Evaluacion(ID, idGrupoxRubro, Nombre, Fecha, ValorPorcentual, Descripcion)
	VALUES(@ID, @idGrupoxRubro, @Nombre, @Fecha, @ValorPorcentual, @Descripcion)
END
go