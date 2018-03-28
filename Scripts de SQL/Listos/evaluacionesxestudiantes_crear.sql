use BBD1;
go
CREATE PROCEDURE evaluacionxestudiante_crear @idGrupoxEstudiante int, @idEvaluacion int, @Nota decimal(7, 4)
AS
BEGIN
	INSERT INTO dbo.EvaluacionesxEstudiantes(idGrupoxEstudiante, idEvaluacion, Nota)
	VALUES(@idGrupoxEstudiante, @idEvaluacion, @Nota)
END
go