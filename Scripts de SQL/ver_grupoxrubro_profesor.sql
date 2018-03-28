use BBD1;
go
CREATE PROCEDURE ver_grupoxrubro_profesor @idGrupo int
AS
BEGIN
	DECLARE @grupoxrubro_profesor Table (ID int, NombreRubro varchar(50));
	INSERT INTO @grupoxrubro_profesor SELECT GR.ID, R.Nombre
	FROM dbo.GrupoxRubro AS GR INNER JOIN
	dbo.Rubro AS R ON GR.IdRubro = R.ID
	WHERE GR.IdGrupo = @idGrupo;

	SELECT * FROM @grupoxrubro_profesor;
END
go