use BBD1;
go
CREATE PROCEDURE ver_grupoxrubro_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table(ID int, idGrupo int, idRubro int, ValorPorcentual Decimal(7, 4), Esfijo varchar(6), Cantidad int);
	INSERT INTO @result SELECT * FROM dbo.GrupoxRubro WHERE IdGrupo = @idGrupo;

	SELECT * FROM @result;
END
go