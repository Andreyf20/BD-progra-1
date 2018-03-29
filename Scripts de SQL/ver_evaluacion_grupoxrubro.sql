use BBD1;
go
CREATE PROCEDURE ver_evaluacion_grupoxrubro @idGrupoxRubro int
AS
BEGIN
	DECLARE @result Table (ID int, idGrupoxRubro int, Nombre varchar(50), Fecha Date, ValorPorcentual Decimal(7, 4),
	Descripcion varchar(100));
	INSERT INTO @result SELECT * FROM dbo.Evaluacion WHERE IdGrupoxRubro = @idGrupoxRubro;

	SELECT * FROM @result;
END
go