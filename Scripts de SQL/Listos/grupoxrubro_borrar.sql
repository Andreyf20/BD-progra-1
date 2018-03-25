use BBD1;
go
CREATE PROCEDURE grupoxrubro_borrar @id
AS
BEGIN
	DELETE FROM dbo.GrupoxRubro as gr WHERE gr.id = @id;
END
go