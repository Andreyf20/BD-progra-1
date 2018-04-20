use BBD1;
go
CREATE PROCEDURE grupoxrubro_aumentar_cantidad @idGrupoxRubro int
AS
BEGIN
	UPDATE dbo.GrupoxRubro
	SET Cantidad = Cantidad + 1
	WHERE ID = @idGrupoxRubro;
END
go