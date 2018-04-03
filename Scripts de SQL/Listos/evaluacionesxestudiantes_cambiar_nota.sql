use BBD1;
go
CREATE PROCEDURE evaluacionesxestudiantes_cambiar_nota @idGrupoxEstudiante int, @idEvaluacion int, @Nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.EvaluacionesxEstudiantes
	SET Nota = @Nota
	WHERE  IdGrupoxEstudiante = @idGrupoxEstudiante	AND IdEvaluacion = @idEvaluacion;
END
go