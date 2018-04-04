use BBD1;
go
CREATE PROCEDURE ver_grupos_estudiante @idEstudiante int
AS
BEGIN
	DECLARE @result Table (ID int ,IdEstado int ,IdPeriodo int, IdProfesor int, NombreCurso varchar(50), CodigoGrupo varchar(50));
	INSERT INTO @result SELECT G.ID, G.IdEstado, G.IdPeriodo, G.idProfesor, G.NombreCurso, G.CodigoGrupo FROM dbo.Grupo AS G INNER JOIN dbo.GrupoxEstudiante AS GE ON GE.IdGrupo = G.ID
	WHERE GE.IdEstudiante = @idEstudiante;

	SELECT * FROM @result;
END
go