use BBD1;
go
CREATE PROCEDURE grupoxrubro_cambiar_cantidad @id int, @cantidad int
AS
BEGIN
	UPDATE dbo.GrupoxRubro
	SET Cantidad = @cantidad
	WHERE id = @id
END
go