use BBD1;
go
CREATE PROCEDURE evaluacion_crear @idGrupoxRubro int, @Nombre varchar(50), @Fecha Date, @ValorPorcentual int
AS
BEGIN
	INSERT INTO dbo.Evaluacion(idGrupoxRubroG, Nombre, Fecha, ValorPorcentual)
	VALUES(@idGrupoxRubrom @Nombre, @Fecha, @ValorPorcentual)
END
go