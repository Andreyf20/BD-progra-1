use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_correo @ID int, @Correo varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Correo = @Correo
	WHERE ID = @ID;
END
go