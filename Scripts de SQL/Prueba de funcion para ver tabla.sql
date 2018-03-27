CREATE FUNCTION estudiantes_ver()
RETURNS @tmp TABLE (nombre varchar(50), carnet varchar(50))
AS
BEGIN
	INSERT INTO @tmp SELECT Nombre, Carnet FROM dbo.Estudiante;
RETURN
END

/*SELECT * FROM estudiantes_ver()*/
