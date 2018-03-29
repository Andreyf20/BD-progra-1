use BBD1;
go
CREATE PROCEDURE grupoxrubro_crear @idGrupo int, @idRubro int, @valorPorcentual int, @esFijo varchar(6), @cantidad int
AS
BEGIN
	DECLARE @result int;
	INSERT INTO dbo.GrupoxRubro(idGrupo, idRubro, ValorPorcentual, Esfijo, Cantidad)
	VALUES(@idGrupo, @idRubro, @valorPorcentual, @esFijo, @cantidad);
	SET @result = (SELECT SCOPE_IDENTITY());
	RETURN @result;
END
go