use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_telefono @ID int, @Telefono varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Telefono = @Telefono
	WHERE ID = @ID;
END
go