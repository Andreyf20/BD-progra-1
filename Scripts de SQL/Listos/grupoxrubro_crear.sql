use BBD1;
go
CREATE PROCEDURE grupoxrubro_crear @idGrupo int, @idRubro int, @valorPorcentual int, @esFijo int, @cantidad int
AS
BEGIN
	INSERT INTO dbo.GrupoxRubro('idGrupo', 'idRubro', 'ValorPorcentual', 'Esfijo', 'Cantidad')
	VALUES(@idGrupo, @idRubro, @valorPorcentual, @esFijo, @cantidad)
END
go