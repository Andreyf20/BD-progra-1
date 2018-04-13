use BBD1
go
CREATE PROCEDURE ver_cantidad_grupoxrubro @idGrupoxRubro int
AS
BEGIN
	DECLARE @Cantidad int;
	SELECT @Cantidad = Cantidad FROM dbo.GrupoxRubro WHERE @idGrupoxRubro = ID;
	RETURN @Cantidad;
END
go