use BBD1;
go
CREATE PROCEDURE ver_rubros_disponibles
AS
BEGIN
	DECLARE @rubros_disponibles Table (ID int, Nombre varchar(50));
	INSERT INTO @rubros_disponibles SELECT * FROM dbo.Rubro;

	SELECT * FROM @rubros_disponibles;
END
go