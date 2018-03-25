use BBD1;
go
CREATE PROCEDURE grupoxestudiante_crear @idgrupo int, @idestadogxe int, @idestudiante int
AS
BEGIN
	INSERT INTO dbo.GrupoxEstudiante (idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada)
	VALUES(@idgrupo, @idestadogxe, @idestudiante, 0)
END
go
