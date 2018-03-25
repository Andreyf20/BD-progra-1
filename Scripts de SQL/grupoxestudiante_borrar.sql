use BBD1;
go
CREATE PROCEDURE grupoxestudiante_borrar @id
AS
BEGIN
	DELETE FROM dbo.GrupoxEstudiante as ge
	WHERE ge.id = @id
END
go