use BBD1;
go
CREATE PROCEDURE ver_periodos
AS
BEGIN
	DECLARE @periodos_disponibles Table (ID int, FechaInicio Date, FechaFinal Date, Activo varchar(6));
	INSERT INTO @periodos_disponibles SELECT * FROM dbo.Periodo AS P;

	SELECT * FROM @periodos_disponibles;
END
go