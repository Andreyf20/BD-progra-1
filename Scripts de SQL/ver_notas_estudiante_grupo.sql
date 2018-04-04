use BBD1;
go
CREATE PROCEDURE ver_notas_estudiante_grupo @idEstudiante int, @idGrupo int
AS
BEGIN
	DECLARE @tablaResultados Table (idEstudiante int, Carnet varchar(50), idGrupo int, NombreCurso varchar(50),
	NombreEvaluacion varchar(50), Nota Decimal(7, 4), ValorPorcentual Decimal(7, 4));
	INSERT INTO @tablaResultados SELECT e.ID, e.Carnet, g.ID, g.NombreCurso, eva.Nombre, ee.Nota, eva.ValorPorcentual
	FROM dbo.Estudiante AS e INNER JOIN 
	dbo.GrupoxEstudiante AS ge ON @idEstudiante = ge.IdEstudiante INNER JOIN
	dbo.Grupo AS g ON g.ID = ge.IdGrupo INNER JOIN
	dbo.EvaluacionesxEstudiantes AS ee ON ee.IdGrupoxEstudiante = ge.ID INNER JOIN
	dbo.Evaluacion AS eva ON eva.ID = ee.IdEvaluacion
	WHERE e.ID = @idEstudiante
	AND g.ID = @idGrupo;

	SELECT * FROM @tablaResultados ORDER BY idGrupo ASC;
END
go