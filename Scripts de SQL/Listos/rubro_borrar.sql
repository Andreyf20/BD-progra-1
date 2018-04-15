use BBD1;
go
CREATE PROCEDURE rubro_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.Rubro WHERE id = @id;
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go