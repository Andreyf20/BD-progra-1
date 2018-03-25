use BBD1;
go
CREATE PROCEDURE estadogrupo_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EstadoGrupo as eg 
	WHERE eg.id = @id
END
go