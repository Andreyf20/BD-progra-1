use BBD1;
go
CREATE PROCEDURE evaluacion_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Evaluacion
	WHERE ID = @id
END
go