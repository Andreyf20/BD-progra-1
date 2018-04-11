use BBD1;
go
CREATE PROCEDURE grupo_crear @idEstado int, @idPeriodo int, @idProfesor int, @NombreCurso varchar(50),
@CodigoGrupo varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EstadoGrupo);
    SET @ID = @ID + 1;
	DECLARE @result int;
	INSERT INTO dbo.Grupo(ID, idEstado, idPeriodo,idProfesor ,NombreCurso, CodigoGrupo)
	VALUES(@ID, @idEstado, @idPeriodo,@idProfesor ,@NombreCurso, @CodigoGrupo);
	SET @result = (SELECT SCOPE_IDENTITY());
	RETURN @result;
END
go