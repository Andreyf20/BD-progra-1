use BBD1;
go
CREATE PROCEDURE estudiante_crear @Nombre varchar(50), @Apellido varchar(50), @Correo varchar(50),
@Carnet varchar(50), @Telefono varchar(50), @Contraseña varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Estudiante);
    SET @ID = @ID + 1;
	INSERT INTO dbo.Estudiante(ID, Nombre, Apellido, Correo, Carnet, Telefono, Contraseña)
	VALUES(@ID, @Nombre, @Apellido, @Correo, @Carnet, @Telefono, @Contraseña);
END
go