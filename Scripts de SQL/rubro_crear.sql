use BBD1;
go
CREATE PROCEDURE rubro_crear @nombre nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.Rubro('Nombre')
	VALUES(@nombre)
END
go