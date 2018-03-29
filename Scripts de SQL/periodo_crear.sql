use BBD1;
go
CREATE PROCEDURE periodo_crear @inicio date, @final date
AS
BEGIN
	DECLARE @result int
	IF (@inicio < convert(varchar, getdate(), 101)) AND (@final > convert(varchar, getdate(), 101))
	BEGIN
		INSERT INTO dbo.Periodo(FechaInicio, FechaFinal, Activo)
		VALUES(@inicio, @final, 'True'); --SE INSERTA UN "1" PORQUE ESTA ACTIVO
		SET @result = 1;
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Periodo(FechaInicio, FechaFinal, Activo)
		VALUES(@inicio, @final, 'False'); --SE INSERTA UN "0" PORQUE ESTA INACTIVO
		SET @result = 0;
	END
	RETURN @result;
END
go