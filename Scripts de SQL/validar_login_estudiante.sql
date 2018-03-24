use BBD1;
go
CREATE PROCEDURE validar_login_estudiante @email varchar(50), @password varchar(50)
AS
BEGIN
Declare @result int
	IF (SELECT COUNT(*) FROM dbo.Estudiante as E WHERE @email = E.Correo AND @password = E.Contraseña) = 0
		SET @result=-1  --NO EXISTE
	ELSE
		SET @result=0  -- --SI EXISTE UNA PERSONA CON ESTA CONFIGURACION
	RETURN @result
END
go
