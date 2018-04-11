use BBD1;
go
CREATE PROCEDURE rubro_crear @nombre nvarchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Rubro);
    SET @ID = @ID + 1;
	INSERT INTO dbo.Rubro(ID, Nombre)
	VALUES(@ID, @nombre)
END
go