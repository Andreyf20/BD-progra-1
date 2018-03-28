use BBD1;
go
CREATE PROCEDURE periodo_CambiarActivo @id int, @activo varchar(6)
AS
BEGIN
	UPDATE dbo.Periodo
	SET Activo = @activo
	WHERE id = @id
END
go