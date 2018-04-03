use BBD1;
go
CREATE PROCEDURE ver_grupos_profesor @idProfesor int
AS
BEGIN
	DECLARE @grupos_profesor Table (idGrupo int, FechaInicio Date, FechaFinal Date, NombreCurso varchar(50),
	CodigoGrupo varchar(50), Activo varchar(6));

	INSERT INTO @grupos_profesor SELECT G.ID, P.FechaInicio, P.FechaFinal, G.NombreCurso, G.CodigoGrupo, P.Activo
	FROM dbo.Grupo AS G INNER JOIN
	dbo.Periodo AS P ON G.IdPeriodo = P.ID
	WHERE G.idProfesor = @idProfesor;

	SELECT * FROM @grupos_profesor ORDER BY idGrupo ASC;
END
go