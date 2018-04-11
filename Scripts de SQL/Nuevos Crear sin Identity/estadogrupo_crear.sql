use BBD1;
go
CREATE PROCEDURE estadogrupo_crear @Nombre varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EstadoGrupo);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EstadoGrupo(ID, Nombre)
	VALUES(@ID, @Nombre)
END
go
