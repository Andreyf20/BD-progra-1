CREATE PROCEDURE validar_login_estudiante @email nvarchar(MAX), @password nvarchar(MAX)
AS
BEGIN
	IF (SELECT COUNT(*) FROM dbo.Estudiante as E WHERE @email = E.Correo AND @password = E.Contraseña) = 0
		RETURN(-1) --NO EXISTE
	ELSE
		RETURN(0) --SI EXISTE UNA PERSONA CON ESTA CONFIGURACION
	RETURN;
END
