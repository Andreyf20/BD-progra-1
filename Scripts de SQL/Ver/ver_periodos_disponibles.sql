use BBD1;
go
CREATE PROCEDURE ver_periodos_disponibles
AS
BEGIN
	DECLARE @periodos_disponibles Table (ID int, FechaInicio Date, FechaFinal Date, Activo varchar(6));
	INSERT INTO @periodos_disponibles SELECT * FROM dbo.Periodo AS P WHERE P.Activo = 'True';

	SELECT * FROM @periodos_disponibles;
END
go