use BBD1;
go
CREATE PROCEDURE ver_evaluacionesxestudiantes @idGrupoxEstudiante int, @idEvaluacion int
AS
BEGIN
	DECLARE @result Table(Nota Decimal(7, 4))
	INSERT INTO @result SELECT Nota FROM dbo.EvaluacionesxEstudiantes WHERE IdGrupoxEstudiante = @idGrupoxEstudiante
	AND IdEvaluacion = @idEvaluacion;
	
	SELECT * FROM @result;
END
go