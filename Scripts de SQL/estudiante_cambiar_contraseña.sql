use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_contraseña @ID int, @Contraseña varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Contraseña = @Contraseña
	WHERE ID = @ID;
END
go