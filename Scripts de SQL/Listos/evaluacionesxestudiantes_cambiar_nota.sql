use BBD1;
go
CREATE PROCEDURE evaluacionesxestudiantes_cambiar_nota @id int, @Nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.EvaluacionesxEstudiantes
	SET Nota = @Nota
	WHERE id = @id
END
go