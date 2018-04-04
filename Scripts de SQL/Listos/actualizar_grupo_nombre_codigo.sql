use BBD1;
go
CREATE PROCEDURE actualizar_grupo_nombre_codigo @idGrupo int, @NombreCurso varchar(50), @CodigoGrupo varchar(50)
AS
BEGIN
	UPDATE dbo.Grupo
	SET NombreCurso = @NombreCurso, CodigoGrupo = @CodigoGrupo
	WHERE ID = @idGrupo;
END
go