use BBD1;
go
CREATE PROCEDURE nombreProfesor @id int
AS
BEGIN
	DECLARE @result Table(Nombre varchar(50))
	INSERT INTO @result SELECT Nombre FROM dbo.Profesor WHERE id = @id
	SELECT * FROM @result;
END
go