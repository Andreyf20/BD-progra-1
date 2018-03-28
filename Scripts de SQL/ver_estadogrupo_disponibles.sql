use BBD1;
go
CREATE PROCEDURE ver_estadogrupo_disponibles
AS
BEGIN
	DECLARE @estadogrupo_disponibles Table (ID int, Nombre varchar(50));
	INSERT INTO @estadogrupo_disponibles SELECT * FROM dbo.EstadoGrupo;

	SELECT * FROM @estadogrupo_disponibles;
END
go