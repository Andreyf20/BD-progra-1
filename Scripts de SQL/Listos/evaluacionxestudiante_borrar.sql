use BBD1;
go
CREATE PROCEDURE evaluacionxestudiante_borrar @id int
AS
BEGIN
	DELETE FROM dbo.EvaluacionxEstudiante as ee 
	WHERE ee.id = @id
END
go