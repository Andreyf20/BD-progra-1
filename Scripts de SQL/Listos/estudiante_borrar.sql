use BBD1;
go
CREATE PROCEDURE estudiante_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Estudiante as e 
	WHERE e.id = @id
END
go