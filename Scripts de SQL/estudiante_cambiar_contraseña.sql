use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_contraseņa @ID int, @Contraseņa varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Contraseņa = @Contraseņa
	WHERE ID = @ID;
END
go