use BBD1;
go
CREATE PROCEDURE estudiante_crear @Nombre varchar(50), @Correo varchar(50), @Contraseña varchar(50)
AS
BEGIN
	INSERT INTO dbo.Estudiante(Nombre, Correo, Contraseña)
	VALUES(@Nombre, @Correo, @Contraseña)
END
go