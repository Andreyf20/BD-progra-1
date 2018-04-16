use BBD1;
go
CREATE PROCEDURE verEstudiantes
AS
BEGIN
	DECLARE @estudiantes Table (ID int, Nombre varchar(50), Apellido varchar(50), Correo varchar(50),Carnet varchar(50), Telefono varchar(50),Contraseña varchar(50));
	INSERT INTO @estudiantes SELECT * FROM dbo.Estudiante AS E;

	SELECT * FROM @estudiantes;
END
go