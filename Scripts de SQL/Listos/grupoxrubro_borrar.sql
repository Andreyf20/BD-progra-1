use BBD1;
go
CREATE PROCEDURE grupoxrubro_borrar @id int
AS
BEGIN
	DELETE FROM dbo.GrupoxRubro WHERE id = @id;
END
go