use BBD1;
go
CREATE PROCEDURE grupoxestudiante_actualizar_nota_acumulada @id int, @nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.GrupoxEstudiante
	SET NotaAcumulada = @nota 
	WHERE id = @id
END
go
