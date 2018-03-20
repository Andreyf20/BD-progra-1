CREATE PROCEDURE crear_periodo_electivo @inicio date, @final date
AS
BEGIN
	INSERT INTO dbo.Periodo
	VALUES(@inicio, @final, 1); --SE INSERTA UN "1" PORQUE SE SUPONE QUE SI SE CREA ESTA ACTIVO
END