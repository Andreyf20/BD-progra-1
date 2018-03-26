use BBD1;
go
CREATE PROCEDURE estadogxe_crear @Nombre varchar(50)
AS
BEGIN
	INSERT INTO dbo.EstadoGxE(Nombre)
	VALUES(@Nombre)
END
go