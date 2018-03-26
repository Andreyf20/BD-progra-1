use BBD1;
go
CREATE PROCEDURE evaluacionxestudiante_cambiar_nota @id int, @Nota decimal(7, 4)
AS
BEGIN
	UPDATE FROM dbo.EvaluacionxEstudiante as ee 
	SET ee.Nota = @Nota
	WHERE ee.id = @id
END
go