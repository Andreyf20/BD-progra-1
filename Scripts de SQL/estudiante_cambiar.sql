use BBD1;
go
CREATE PROCEDURE estudiante_cambiar @ID int, @Nombre varchar(50), @Apellido varchar(50), @Correo varchar(50),
@Carnet varchar(50), @Telefono varchar(50), @Contrase�a varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Carnet = @Carnet,
	Telefono = @Telefono, Contrase�a = @Contrase�a
	WHERE ID = @ID;
END
go