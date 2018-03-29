use BBD1;
go
CREATE PROCEDURE ver_grupoxestudiante_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table(ID int, idGrupo int, idEstadoGxE int, idEstudiante int, Nota Decimal(7, 4));
	INSERT INTO @result SELECT * FROM dbo.GrupoxEstudiante WHERE IdGrupo = @idGrupo;

	SELECT * FROM @result ORDER BY ID ASC;
END
go