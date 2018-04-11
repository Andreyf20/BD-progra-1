use BBD1;
go
CREATE PROCEDURE evaluacionxestudiante_crear @idGrupoxEstudiante int, @idEvaluacion int, @Nota decimal(7, 4)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EvaluacionesxEstudiantes);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EvaluacionesxEstudiantes(ID, idGrupoxEstudiante, idEvaluacion, Nota)
	VALUES(@ID, @idGrupoxEstudiante, @idEvaluacion, @Nota)
END
go