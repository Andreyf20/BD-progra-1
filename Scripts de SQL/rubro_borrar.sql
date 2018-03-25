use BBD1;
go
CREATE PROCEDURE rubro_borrar @id
AS
BEGIN
	DELETE FROM dbo.Rubro as r WHERE r.id = @id
END
go