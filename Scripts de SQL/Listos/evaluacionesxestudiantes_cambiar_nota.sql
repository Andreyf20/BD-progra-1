use BBD1;
go
CREATE PROCEDURE evaluacionesxestudiantes_cambiar_nota @idEvauacionxEstudiante int, @Nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.EvaluacionesxEstudiantes
	SET Nota = @Nota
	WHERE id = @idEvauacionxEstudiante
END
go