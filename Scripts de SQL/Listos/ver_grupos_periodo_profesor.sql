use BBD1;
go
CREATE PROCEDURE ver_grupos_periodo_profesor @idPeriodo int, @idProfesor int
AS
BEGIN
	DECLARE @result Table (idGrupo int, idEstado int, idPeriodo int, idProfesor int, NombreCurso varchar(50),
	CodigoGrupo varchar(50));

	INSERT INTO @result SELECT ID, idEstado, idPeriodo, idProfesor, NombreCurso, CodigoGrupo
	FROM dbo.Grupo WHERE idProfesor = @idProfesor AND IdPeriodo = @idPeriodo;

	SELECT * FROM @result;
END
go