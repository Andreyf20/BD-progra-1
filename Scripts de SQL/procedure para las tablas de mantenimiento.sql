use BBD1;
go
CREATE PROCEDURE sp_tabla_mantenimiento @idTipoEM int, @XMLAntes varchar(2000), @XMLDespues varchar(2000),
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EventosDeMantenimiento);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EventosDeMantenimiento(ID, IdTipoEM, XMLAntes, XMLDespues, PostIn, PostBy, PostDate)
	VALUES(@ID, @idTipoEM, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate);
END
go