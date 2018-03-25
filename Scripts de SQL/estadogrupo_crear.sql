use BBD1;
go
CREATE PROCEDURE estadogrupo_crear @Nombre varchar(50)
AS
BEGIN
	INSERT INTO dbo.EstadoGrupo(Nombre)
	VALUES(@Nombre)
END
go