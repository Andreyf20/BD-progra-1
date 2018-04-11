use BBD1;
go
CREATE PROCEDURE grupoxrubro_crear @idGrupo int, @idRubro int, @valorPorcentual int, @esFijo varchar(6), @cantidad int
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.GrupoxRubro);
    SET @ID = @ID + 1;
	DECLARE @result int;
	INSERT INTO dbo.GrupoxRubro(ID, idGrupo, idRubro, ValorPorcentual, Esfijo, Cantidad)
	VALUES(@ID, @idGrupo, @idRubro, @valorPorcentual, @esFijo, @cantidad);
	SET @result = (SELECT SCOPE_IDENTITY());
	RETURN @result;
END
go