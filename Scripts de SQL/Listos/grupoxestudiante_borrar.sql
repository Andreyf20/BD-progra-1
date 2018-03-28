use BBD1;
go
CREATE PROCEDURE grupoxestudiante_borrar @id
AS
BEGIN
	DELETE FROM dbo.GrupoxEstudiante
	WHERE id = @id
END
go