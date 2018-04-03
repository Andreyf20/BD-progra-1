use BBD1;
go
CREATE PROCEDURE grupo_crear @idEstado int, @idPeriodo int, @idProfesor int, @NombreCurso varchar(50),
@CodigoGrupo varchar(50)
AS
BEGIN
	DECLARE @result int;
	INSERT INTO dbo.Grupo(idEstado, idPeriodo,idProfesor ,NombreCurso, CodigoGrupo)
	VALUES(@idEstado, @idPeriodo,@idProfesor ,@NombreCurso, @CodigoGrupo);
	SET @result = (SELECT SCOPE_IDENTITY());
	RETURN @result;
END
go