use BBD1;
go
CREATE PROCEDURE grupo_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Grupo as g
	WHERE g.id = @id
END
go