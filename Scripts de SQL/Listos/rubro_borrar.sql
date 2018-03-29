use BBD1;
go
CREATE PROCEDURE rubro_borrar @id int
AS
BEGIN
	DELETE FROM dbo.Rubro WHERE id = @id
END
go