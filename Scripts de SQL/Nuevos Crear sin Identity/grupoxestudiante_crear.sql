use BBD1;
go
CREATE PROCEDURE grupoxestudiante_crear @idgrupo int, @idestadogxe int, @idestudiante int,
@NotaAcumulada decimal(7, 4)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.GrupoxEstudiante);
    SET @ID = @ID + 1;
	INSERT INTO dbo.GrupoxEstudiante (ID, idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada)
	VALUES(@ID, @idgrupo, @idestadogxe, @idestudiante, @NotaAcumulada)
END
go
