use BBD1;
go
CREATE PROCEDURE estadogrupo_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EstadoGrupo
	WHERE ID = @id
END
go