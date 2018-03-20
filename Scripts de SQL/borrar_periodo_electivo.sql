CREATE PROCEDURE borrar_periodo @id
AS
BEGIN
	DELETE FROM dbo.Periodo as p WHERE p.id = id;
END 