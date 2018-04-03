use BBD1;
go
CREATE PROCEDURE ver_evaluacion_estudiante_grupo @idGrupo int
AS
BEGIN
	DECLARE @evaluacion_estudiante_grupo Table (idEvaluacionxEstudiante int, idEstudiante int, NombreEstudiante varchar(50), ApellidoEstudiante varchar(50),
	CarnetEstudiante varchar(50), NombreEvaluacion varchar(50), NotaEvaluacion Decimal(7, 4));

	INSERT INTO @evaluacion_estudiante_grupo SELECT EE.ID, E.ID, E.Nombre, E.Apellido, E.Carnet, EVAL.Nombre, EE.Nota
	FROM dbo.Estudiante AS E
	INNER JOIN dbo.GrupoxEstudiante AS GE ON GE.IdEstudiante = E.ID
	INNER JOIN dbo.EvaluacionesxEstudiantes AS EE ON EE.IdGrupoxEstudiante = GE.ID
	INNER JOIN dbo.Evaluacion AS EVAL ON EVAL.ID = EE.IdEvaluacion
	WHERE GE.IdGrupo = @idGrupo;

	SELECT * FROM @evaluacion_estudiante_grupo ORDER BY idEstudiante ASC;
END
go