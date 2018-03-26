use BBD1;
go
CREATE PROCEDURE grupo_crear @idEstado int, @idPeriodo int, @NombreCurso varchar(50), @CodigoGrupo varchar(50)
AS
BEGIN
	INSERT INTO dbo.Grupo(idEstado, idPeriodo, NombreCurso, CodigoGrupo)
	VALUES(@idEstado, @idPeriodo, @NombreCurso, @CodigoGrupo)
END
go