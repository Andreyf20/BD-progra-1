use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_nombre @ID int, @Nombre varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Nombre = @Nombre
	WHERE ID = @ID;
END
go