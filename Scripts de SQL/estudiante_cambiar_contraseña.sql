use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_contrase�a @ID int, @Contrase�a varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Contrase�a = @Contrase�a
	WHERE ID = @ID;
END
go