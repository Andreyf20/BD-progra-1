use BBD1;
go
CREATE PROCEDURE prueba_tabla
AS
BEGIN
	DECLARE @tmp Table (Nombre varchar(50), Carnet varchar(50));
	INSERT INTO @tmp SELECT Nombre, Carnet FROM dbo.Estudiante;
	SELECT * FROM @tmp;
END
go