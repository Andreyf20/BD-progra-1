use BBD1;
go
CREATE PROCEDURE estudiante_crear @Nombre varchar(50), @Apellido varchar(50), @Telefono varchar(50),
@Correo varchar(50), @Contraseña varchar(50)
AS
BEGIN
	INSERT INTO dbo.Estudiante(Nombre, Apellido, Telefono, Correo, Contraseña)
	VALUES(@Nombre, @Apellido, @Telefono, @Correo, @Contraseña)
END
go