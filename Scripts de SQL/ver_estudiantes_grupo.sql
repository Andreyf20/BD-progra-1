use BBD1;
go
CREATE PROCEDURE ver_estudiantes_grupo @idGrupo int
AS
BEGIN
	DECLARE @estudiantes_grupo Table (idGrupo int, Carnet varchar(50), Nombre varchar(50), Apellido varchar(50),
	Correo varchar(50));

	INSERT INTO @estudiantes_grupo SELECT GE.IdGrupo, E.Carnet, E.Nombre, E.Apellido, E.Correo
	FROM dbo.GrupoxEstudiante AS GE INNER JOIN
	dbo.Estudiante AS E ON GE.IdEstudiante = E.ID
	WHERE GE.IdGrupo = @idGrupo;

	SELECT * FROM @estudiantes_grupo;
END
go