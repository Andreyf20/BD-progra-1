use BBD1;
go
CREATE PROCEDURE grupoxestudiante_crear @idgrupo int, @idestadogxe int, @idestudiante int,
@NotaAcumulada decimal(7, 4)
AS
BEGIN
	INSERT INTO dbo.GrupoxEstudiante (idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada)
	VALUES(@idgrupo, @idestadogxe, @idestudiante, @NotaAcumulada)
END
go
