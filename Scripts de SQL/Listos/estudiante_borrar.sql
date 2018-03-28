use BBD1;
go
CREATE PROCEDURE estudiante_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Estudiante 
	WHERE ID = @id
END
go