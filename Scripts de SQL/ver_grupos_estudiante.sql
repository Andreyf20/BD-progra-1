use BBD1;
go
CREATE PROCEDURE ver_grupos_estudiante @idEstudiante int
AS
BEGIN
	DECLARE @result Table (NombreEstado varchar(50) ,FechaInicio Date ,FechaFinal Date, NombreProfesor varchar(50), NombreCurso varchar(50), CodigoGrupo varchar(50));
	INSERT INTO @result SELECT EG.Nombre, P.FechaInicio, P.FechaFInal, PF.Nombre, G.NombreCurso, G.CodigoGrupo FROM dbo.Grupo AS G INNER JOIN
	dbo.GrupoxEstudiante AS GE ON GE.IdGrupo = G.ID INNER JOIN
	dbo.EstadoGrupo AS EG ON EG.ID = G.ID INNER JOIN
	dbo.Periodo AS P ON P.ID = G.ID INNER JOIN
	dbo.Profesor AS PF ON PF.id = G.idProfesor
	WHERE GE.IdEstudiante = @idEstudiante;

	SELECT * FROM @result;
END
go