use BBD1;
go
CREATE PROCEDURE grupo_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Grupo
	WHERE id = @id
END
go