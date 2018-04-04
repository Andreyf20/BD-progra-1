use BBD1;
go
CREATE PROCEDURE ver_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table (NombreCurso varchar(50), CodigoGrupo varchar(50));

	INSERT INTO @result SELECT NombreCurso, CodigoGrupo FROM dbo.Grupo WHERE ID = @idGrupo;

	SELECT * FROM @result;
END
go