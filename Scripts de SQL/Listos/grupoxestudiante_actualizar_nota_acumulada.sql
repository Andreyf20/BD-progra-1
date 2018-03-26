use BDD1;
go
CREATE PROCEDURE grupoxestudiante_actualizar_nota_acumulada @id int, @nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.GrupoxEstudiante as ge 
	SET ge.NotaAcumulada = @nota 
	WHERE ge.id = @id
END
go
