use BBD1;
go
CREATE PROCEDURE estadogxe_crear @Nombre varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EstadoGxE);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EstadoGxE(ID, Nombre)
	VALUES(@ID, @Nombre);
END
go