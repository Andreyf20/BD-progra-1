use BBD1;
go
CREATE PROCEDURE actualizar_nota_acumulada_estudiante @idGrupo int, @idEstudiante int
AS
BEGIN
	DECLARE @sumaNota Decimal(38, 4);
	DECLARE @filas int;
	DECLARE @idGrupoxEstudiante int;
	DECLARE @tablaNotas Table (ID int, idGrupoxEstudiante int, idEvaluacion int, Nota Decimal(7, 4), idGrupoxRubro int);
	DECLARE @tablaGrupoxRubro Table (ID int, idGrupo int, idRubro int, ValorPorcentual Decimal(7, 4), Esfijo varchar(6), Cantidad int);
	DECLARE @tablaDeSuma Table (idRubro int, Nota Decimal(7, 4), Cantidad int);

	-- SE BUSCA EL idGrupoxEstudiante
	SET @idGrupoxEstudiante = (SELECT ge.ID FROM dbo.GrupoxEstudiante AS ge WHERE ge.IdEstudiante = @idEstudiante
	AND ge.IdGrupo = @idGrupo AND ge.IdEstadoGxE != 3 AND ge.IdEstadoGxE != 4);

	-- SE BUSCAN LAS NOTAS DE LAS EVALUACIONES Y SE METEN EN UNA TABLA
	INSERT INTO @tablaNotas SELECT ee.ID, ee.IdGrupoxEstudiante, ee.IdEvaluacion, ee.Nota, e.IdGrupoxRubro
	FROM dbo.EvaluacionesxEstudiantes AS ee 
	INNER JOIN dbo.Evaluacion AS e ON e.ID = ee.IdEvaluacion
	WHERE ee.IdGrupoxEstudiante = @idGrupoxEstudiante;

	-- SE BUSCA EL GRUPOXRUBRO PARA VER CUALES SON QUIZES
	INSERT INTO @tablaGrupoxRubro SELECT * FROM dbo.GrupoxRubro AS gr WHERE gr.IdGrupo = @idGrupo;

	INSERT INTO @tablaDeSuma SELECT gr.idRubro, tb.Nota, gr.Cantidad FROM @tablaNotas AS tb INNER JOIN	
	@tablaGrupoxRubro AS gr 
	ON tb.idGrupoxRubro = gr.ID;

	SELECT * FROM @tablaDeSuma;
	SET @sumaNota = (SELECT SUM(Nota) FROM @tablaDeSuma);
	SET @filas = (SELECT COUNT(*) FROM @tablaDeSuma);
	SET @sumaNota = @sumaNota / @filas;
	SELECT @sumaNota;

	UPDATE dbo.GrupoxEstudiante
	SET NotaAcumulada = @sumaNota
	WHERE IdGrupo = @idGrupo
	AND IdEstudiante = @idEstudiante
	AND IdEstadoGxE != 3
	AND	IdEstadoGxE != 4;

END
go