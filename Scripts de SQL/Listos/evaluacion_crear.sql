use BBD1;
go
CREATE PROCEDURE evaluacion_crear @idGrupoxRubro int, @Nombre varchar(50), @Fecha Date, 
@ValorPorcentual decimal(7, 4), @Descripcion varchar(100)
AS
BEGIN
	INSERT INTO dbo.Evaluacion(idGrupoxRubroG, Nombre, Fecha, ValorPorcentual, Descripcion)
	VALUES(@idGrupoxRubro @Nombre, @Fecha, @ValorPorcentual, @Descripcion)
END
go