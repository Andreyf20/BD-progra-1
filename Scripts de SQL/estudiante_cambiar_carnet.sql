use BBD1;
go
CREATE PROCEDURE estudiante_cambiar_carnet @ID int, @Carnet varchar(50)
AS
BEGIN
	UPDATE dbo.Estudiante
	SET Carnet = @Carnet
	WHERE ID = @ID;
END
go