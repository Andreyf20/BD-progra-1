use BBD1;
go
CREATE PROCEDURE evaluacionxestudiante_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EvaluacionesxEstudiantes
	WHERE id = @id
END
go