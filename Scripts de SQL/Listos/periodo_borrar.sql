use BBD1;
go
CREATE PROCEDURE periodo_borrar @id
AS
BEGIN
	DELETE FROM dbo.Periodo as p WHERE p.id = @id;
END
go