use BBD1;
go
CREATE PROCEDURE estudiante_cambiar @ID int, @Nombre varchar(50), @Apellido varchar(50), @Correo varchar(50),
@Carnet varchar(50), @Telefono varchar(50), @Contraseña varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Carnet = @Carnet,
	Telefono = @Telefono, Contraseña = @Contraseña
	WHERE ID = @ID;
END
go