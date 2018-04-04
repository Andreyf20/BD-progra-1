use BBD1;
go
CREATE PROCEDURE ver_grupoxrubro_grupo_nofijos @idGrupo int
AS
BEGIN
	DECLARE @result Table (ID INT, idGrupo int, idRubro int, ValorPorcentual Decimal(7, 4), Esfijo varchar(6), Cantidad int);

	INSERT INTO @result SELECT * FROM dbo.GrupoxRubro AS GR WHERE GR.IdGrupo = @idGrupo AND GR.Esfijo != 'True';
	
	SELECT * FROM @result; 
END
go