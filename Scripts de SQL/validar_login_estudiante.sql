use BBD1;
go
CREATE PROCEDURE validar_login_estudiante @email varchar(50), @password varchar(50)
AS
BEGIN
Declare @result int
	IF (SELECT COUNT(*) FROM dbo.Estudiante as E WHERE @email = E.Correo AND @password = E.Contraseña) = 0
		SET @result=-1  --NO EXISTE
	ELSE
		SELECT @result = e.ID FROM dbo.Estudiante as e WHERE  @email = E.Correo AND @password = E.Contraseña;
		-- SI EXISTE Y SE DEVUELVE EL ID COMO RESULTADO
	RETURN @result
END
go
