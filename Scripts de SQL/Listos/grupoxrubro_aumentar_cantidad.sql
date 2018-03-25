use BBD1;
go
CREATE PROCEDURE grupoxrubro_actualizar_cantidad @id int
AS
BEGIN
	--DECLARE @cantidad int
	--SET @cantidad = (SELECT gr.Cantidad FROM dbo.GrupoxRubro as gr WHERE gr.id = @id)
	UPDATE dbo.GrupoxRubro as gr 
	SET gr.Cantidad = gr.Cantidad + 1
	WHERE gr.id = @id
END
go