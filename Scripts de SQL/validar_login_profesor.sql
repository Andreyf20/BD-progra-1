use BBD1;
go
CREATE PROCEDURE validar_login_profesor @email varchar(50), @password varchar(50)
AS
BEGIN
Declare @result int
	IF (SELECT COUNT(*) FROM dbo.Profesor as P WHERE @email = P.Correo AND @password = P.Contraseña) = 0
		SET @result=-1  --NO EXISTE
	ELSE
		SELECT @result = P.ID FROM dbo.Profesor as P WHERE  @email = P.Correo AND @password = P.Contraseña;
		-- SI EXISTE Y SE DEVUELVE EL ID COMO RESULTADO
	RETURN @result
END
go