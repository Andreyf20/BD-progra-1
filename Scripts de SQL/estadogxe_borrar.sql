use BBD1;
go
CREATE PROCEDURE estadogxe_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EstadoGxE as ege 
	WHERE ege.id = @id
END
go