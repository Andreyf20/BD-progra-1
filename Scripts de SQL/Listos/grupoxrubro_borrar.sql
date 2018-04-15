use BBD1;
go
CREATE PROCEDURE grupoxrubro_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.GrupoxRubro WHERE id = @id;
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go