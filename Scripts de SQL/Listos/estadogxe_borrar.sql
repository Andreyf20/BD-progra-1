use BBD1;
go
CREATE PROCEDURE estadogxe_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EstadoGxE
	WHERE ID = @id
END
go