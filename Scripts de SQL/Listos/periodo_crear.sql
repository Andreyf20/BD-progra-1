use BBD1;
go
CREATE PROCEDURE periodo_crear @inicio date, @final date
AS
BEGIN
	IF (@inicio < convert(varchar, getdate(), 101)) AND (@final > convert(varchar, getdate(), 101))
		INSERT INTO dbo.Periodo(FechaInicio, FechaFinal, Activo)
		VALUES(@inicio, @final, 1); --SE INSERTA UN "1" PORQUE ESTA ACTIVO
	ELSE
		INSERT INTO dbo.Periodo(FechaInicio, FechaFinal, Activo)
		VALUES(@inicio, @final, 0); --SE INSERTA UN "0" PORQUE ESTA INACTIVO
END
go