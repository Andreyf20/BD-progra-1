use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_apellido @ID int, @Apellido varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Apellido = @Apellido
	WHERE ID = @ID;
END
go