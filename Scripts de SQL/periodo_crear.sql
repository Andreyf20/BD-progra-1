use BBD1;
go
CREATE PROCEDURE periodo_crear @inicio date, @final date
AS
BEGIN
	INSERT INTO dbo.Periodo('FechaInicio', 'FechaFinal', 'Activo')
	VALUES(@inicio, @final, 1); --SE INSERTA UN "1" PORQUE SE SUPONE QUE SI SE CREA ESTA ACTIVO
END
go