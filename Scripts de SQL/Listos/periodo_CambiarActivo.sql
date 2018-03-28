use BBD1;
go
CREATE PROCEDURE periodo_CambiarActivo @id int, @activo varchar(6)
AS
BEGIN
	UPDATE dbo.Periodo AS p
	SET p.Activo = @activo
	WHERE p.id = @id
END
go