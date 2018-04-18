use BBD1;
go
CREATE PROCEDURE sp_tabla_mantenimiento @idTipoEM int, @XMLAntes varchar(2000), @XMLDespues varchar(2000),
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EventosDeMantenimiento);
    SET @ID = @ID + 1;
	IF @ID IS NULL
		SET @ID = 0;
	INSERT INTO dbo.EventosDeMantenimiento(ID, IdTipoEM, XMLAntes, XMLDespues, PostIn, PostBy, PostDate)
	VALUES(@ID, @idTipoEM, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate);
END
go

go
INSERT INTO dbo.TipoEM Values(0, 'Crear Periodo');
INSERT INTO dbo.TipoEM Values(1, 'Anular Periodo');
INSERT INTO dbo.TipoEM Values(2, 'Terminar Periodo');
INSERT INTO dbo.TipoEM Values(3, 'Crear Grupo');
INSERT INTO dbo.TipoEM Values(4, 'Modificar Grupo');
INSERT INTO dbo.TipoEM Values(5, 'Agregar Estudiante a Grupo');
INSERT INTO dbo.TipoEM Values(6, 'Anular Grupo');
INSERT INTO dbo.TipoEM Values(7, 'Crear GrupoxRubro');
INSERT INTO dbo.TipoEM Values(8, 'Crear Evaluacion');
INSERT INTO dbo.TipoEM Values(9, 'Anular GrupoxRubro');
INSERT INTO dbo.TipoEM Values(10, 'Anular Evaluacion');
INSERT INTO dbo.TipoEM Values(11, 'Crear Estudiante');
INSERT INTO dbo.TipoEM Values(12, 'Modificar Estudiante');
INSERT INTO dbo.TipoEM Values(13, 'Anular Estudiante');
INSERT INTO dbo.TipoEM Values(14, 'Crear EvaluacionesxEstudiantes');
INSERT INTO dbo.TipoEM Values(15, 'Cambiar Nota EvaluacionesxEstudiantes');
go

go
CREATE PROCEDURE validar_login_profesor @email varchar(50), @password varchar(50)
AS
BEGIN
Declare @result int
	IF (SELECT COUNT(*) FROM dbo.Profesor as P WHERE @email = P.Correo AND @password = P.Contraseña) = 0
		SET @result=-1  --NO EXISTE
	ELSE
		SELECT @result = P.ID FROM dbo.Profesor as P WHERE  @email = P.Correo AND @password = P.Contraseña;
		-- SI EXISTE Y SE DEVUELVE EL ID COMO RESULTADO
	RETURN @result
END
go

go
CREATE PROCEDURE validar_login_estudiante @email varchar(50), @password varchar(50)
AS
BEGIN
Declare @result int
	IF (SELECT COUNT(*) FROM dbo.Estudiante as E WHERE @email = E.Correo AND @password = E.Contraseña) = 0
		SET @result=-1  --NO EXISTE
	ELSE
		SELECT @result = e.ID FROM dbo.Estudiante as e WHERE  @email = E.Correo AND @password = E.Contraseña;
		-- SI EXISTE Y SE DEVUELVE EL ID COMO RESULTADO
	RETURN @result
END
go

go
CREATE PROCEDURE rubro_crear @nombre nvarchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Rubro);
    SET @ID = @ID + 1;
	INSERT INTO dbo.Rubro(ID, Nombre)
	VALUES(@ID, @nombre)
END
go

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

go
CREATE PROCEDURE periodo_CambiarActivo @id int, @activo varchar(6),
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @XMLAntes varchar(2000);
	SET @XMLAntes = (SELECT * FROM dbo.Periodo WHERE id = @id FOR XML PATH('Periodo'));
	UPDATE dbo.Periodo
	SET Activo = @activo
	WHERE id = @id
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.Periodo WHERE id = @id FOR XML PATH('Periodo'));
	EXEC sp_tabla_mantenimiento 2, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE periodo_borrar @id int, @PostIn varchar(50),
@PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
        DECLARE @XMLAntes varchar(2000);
        SET @XMLAntes = (SELECT * FROM dbo.Periodo WHERE id = @ID FOR XML PATH('Periodo'));
		DELETE FROM dbo.Periodo WHERE id = @id;
		SET @result = 0;
        EXEC sp_tabla_mantenimiento 1, @XMLAntes, '', @PostIn, @PostBy, @PostDate;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE periodo_crear @inicio date, @final date, @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Periodo);
    SET @ID = @ID + 1;
	DECLARE @result int
	IF (@inicio < convert(varchar, getdate(), 101)) AND (@final > convert(varchar, getdate(), 101))
	BEGIN
		INSERT INTO dbo.Periodo(ID, FechaInicio, FechaFinal, Activo)
		VALUES(@ID, @inicio, @final, 'True'); --SE INSERTA UN "1" PORQUE ESTA ACTIVO
		SET @result = 1;
		DECLARE @XMLDespues varchar(2000);
		SET @XMLDespues = (SELECT * FROM dbo.Periodo WHERE id = @ID FOR XML PATH('Periodo'));
		EXEC sp_tabla_mantenimiento 0, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Periodo(ID, FechaInicio, FechaFinal, Activo)
		VALUES(@ID, @inicio, @final, 'False'); --SE INSERTA UN "0" PORQUE ESTA INACTIVO
		SET @result = 0;
		DECLARE @XMLDespues_false varchar(2000);
		SET @XMLDespues_false = (SELECT * FROM dbo.Periodo WHERE id = @ID FOR XML PATH('Periodo'));
		EXEC sp_tabla_mantenimiento 0, '', @XMLDespues_false, @PostIn, @PostBy, @PostDate;
	END
	RETURN @result;
END
go

go
CREATE PROCEDURE grupoxrubro_cambiar_cantidad @id int, @cantidad int
AS
BEGIN
	UPDATE dbo.GrupoxRubro
	SET Cantidad = @cantidad
	WHERE id = @id
END
go

go
CREATE PROCEDURE grupoxrubro_borrar @id int, @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DECLARE @XMLAntes varchar(2000);
		SET @XMLAntes = (SELECT * FROM dbo.GrupoxRubro WHERE id = @ID FOR XML PATH('GrupoxRubro'));
		DELETE FROM dbo.GrupoxRubro WHERE id = @id;
		SET @result = 0;
		EXEC sp_tabla_mantenimiento 9, @XMLAntes, '', @PostIn, @PostBy, @PostDate;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE grupoxrubro_crear @idGrupo int, @idRubro int, @valorPorcentual int, @esFijo varchar(6), @cantidad int,
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.GrupoxRubro);
    SET @ID = @ID + 1;
	DECLARE @result int;
	INSERT INTO dbo.GrupoxRubro(ID, idGrupo, idRubro, ValorPorcentual, Esfijo, Cantidad)
	VALUES(@ID, @idGrupo, @idRubro, @valorPorcentual, @esFijo, @cantidad);
	SET @result = @ID;
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.GrupoxRubro WHERE id = @ID FOR XML PATH('GrupoxRubro'));
	EXEC sp_tabla_mantenimiento 7, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
	RETURN @result;
END
go

go
CREATE PROCEDURE grupoxestudiante_crear @idgrupo int, @idestadogxe int, @idestudiante int,
@NotaAcumulada decimal(7, 4), @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.GrupoxEstudiante);
    SET @ID = @ID + 1;
	INSERT INTO dbo.GrupoxEstudiante (ID, idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada)
	VALUES(@ID, @idgrupo, @idestadogxe, @idestudiante, @NotaAcumulada)
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.GrupoxEstudiante WHERE ID = @ID FOR XML PATH('GrupoxEstudiante'));
	EXEC sp_tabla_mantenimiento 5, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE grupoxestudiante_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.GrupoxEstudiante
		WHERE id = @id;
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE grupoxestudiante_actualizar_nota_acumulada @id int, @nota decimal(7, 4)
AS
BEGIN
	UPDATE dbo.GrupoxEstudiante
	SET NotaAcumulada = @nota
	WHERE id = @id
END
go

go
CREATE PROCEDURE grupo_borrar @id int, @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DECLARE @XMLAntes varchar(2000);
		SET @XMLAntes = (SELECT * FROM dbo.Grupo WHERE ID = @id FOR XML PATH('Grupo'));
		DELETE FROM dbo.Grupo
		WHERE id = @id
		SET @result = 0;
		EXEC sp_tabla_mantenimiento 6, @XMLAntes, '', @PostIn, @PostBy, @PostDate;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE grupo_crear @idEstado int, @idPeriodo int, @idProfesor int, @NombreCurso varchar(50),
@CodigoGrupo varchar(50), @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Grupo);
    SET @ID = @ID + 1;
	DECLARE @result int;
	INSERT INTO dbo.Grupo(ID, idEstado, idPeriodo,idProfesor ,NombreCurso, CodigoGrupo)
	VALUES(@ID, @idEstado, @idPeriodo,@idProfesor ,@NombreCurso, @CodigoGrupo);
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.Grupo WHERE id = @ID FOR XML PATH('Grupo'));
	EXEC sp_tabla_mantenimiento 3, '', @XMLDespues, @PostIn, @PostBy, @PostDate
	SET @result = (SELECT SCOPE_IDENTITY());
	RETURN @result;
END
go

go
CREATE PROCEDURE evaluacionxestudiante_crear @idGrupoxEstudiante int, @idEvaluacion int, @Nota decimal(7, 4),
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EvaluacionesxEstudiantes);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EvaluacionesxEstudiantes(ID, idGrupoxEstudiante, idEvaluacion, Nota)
	VALUES(@ID, @idGrupoxEstudiante, @idEvaluacion, @Nota)
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.EvaluacionesxEstudiantes WHERE id = @ID FOR XML PATH('EvaluacionesxEstudiantes'));
	EXEC sp_tabla_mantenimiento 14, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE evaluacionesxestudiantes_cambiar_nota @idGrupoxEstudiante int, @idEvaluacion int, @Nota decimal(7, 4),
@PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @XMLAntes varchar(2000);
	SET @XMLAntes = (SELECT * FROM dbo.EvaluacionesxEstudiantes WHERE IdGrupoxEstudiante = @idGrupoxEstudiante
	AND IdEvaluacion = @idEvaluacion
	FOR XML PATH('EvaluacionesxEstudiantes'));
	UPDATE dbo.EvaluacionesxEstudiantes
	SET Nota = @Nota
	WHERE  IdGrupoxEstudiante = @idGrupoxEstudiante	AND IdEvaluacion = @idEvaluacion;
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.EvaluacionesxEstudiantes WHERE IdGrupoxEstudiante = @idGrupoxEstudiante
	AND IdEvaluacion = @idEvaluacion
	FOR XML PATH('EvaluacionesxEstudiantes'));
	EXEC sp_tabla_mantenimiento 15, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE evaluacionxestudiante_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.EvaluacionesxEstudiantes
		WHERE id = @id;
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE evaluacion_borrar @id int, @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DECLARE @XMLAntes varchar(2000);
		SET @XMLAntes = (SELECT * FROM dbo.Evaluacion WHERE id = @id FOR XML PATH('Evaluacion'));
		DELETE FROM dbo.Evaluacion
		WHERE ID = @id
		SET @result = 0;
		EXEC sp_tabla_mantenimiento 10, @XMLAntes, '', @PostIn, @PostBy, @PostDate;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE estudiante_crear @Nombre varchar(50), @Apellido varchar(50), @Correo varchar(50),
@Carnet varchar(50), @Telefono varchar(50), @Contraseña varchar(50), @PostIn varchar(50),
@PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Estudiante);
    SET @ID = @ID + 1;
	INSERT INTO dbo.Estudiante(ID, Nombre, Apellido, Correo, Carnet, Telefono, Contraseña)
	VALUES(@ID, @Nombre, @Apellido, @Correo, @Carnet, @Telefono, @Contraseña);
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.Estudiante WHERE id = @id FOR XML PATH('Estudiante'));
	EXEC sp_tabla_mantenimiento 11, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE estudiante_borrar @id int, @PostIn varchar(50),
@PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DECLARE @XMLAntes varchar(2000);
		SET @XMLAntes = (SELECT * FROM dbo.Estudiante WHERE id = @id FOR XML PATH('Estudiante'));
		DELETE FROM dbo.Estudiante
		WHERE ID = @id
		SET @result = 0;
		EXEC sp_tabla_mantenimiento 13, @XMLAntes, '', @PostIn, @PostBy, @PostDate;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE estadogxe_crear @Nombre varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EstadoGxE);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EstadoGxE(ID, Nombre)
	VALUES(@ID, @Nombre);
END
go

go
CREATE PROCEDURE estadogxe_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.EstadoGxE
		WHERE ID = @id
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE estadogrupo_crear @Nombre varchar(50)
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.EstadoGrupo);
    SET @ID = @ID + 1;
	INSERT INTO dbo.EstadoGrupo(ID, Nombre)
	VALUES(@ID, @Nombre)
END
go

go
CREATE PROCEDURE estadogrupo_borrar @id int
AS
BEGIN
	DECLARE @result int;
	BEGIN TRY
		DELETE FROM dbo.EstadoGrupo
		WHERE ID = @id
		SET @result = 0;
	END TRY
	BEGIN CATCH
		SET @result = -1;
	END CATCH
	RETURN @result;
END
go

go
CREATE PROCEDURE prueba_tabla
AS
BEGIN
	DECLARE @tmp Table (Nombre varchar(50), Carnet varchar(50));
	INSERT INTO @tmp SELECT Nombre, Carnet FROM dbo.Estudiante;
	SELECT * FROM @tmp;
END
go

go
CREATE PROCEDURE ver_estudiantes_grupo @idGrupo int
AS
BEGIN
	DECLARE @estudiantes_grupo Table (idGrupo int, Carnet varchar(50), Nombre varchar(50), Apellido varchar(50),
	Correo varchar(50));

	INSERT INTO @estudiantes_grupo SELECT GE.IdGrupo, E.Carnet, E.Nombre, E.Apellido, E.Correo
	FROM dbo.GrupoxEstudiante AS GE INNER JOIN
	dbo.Estudiante AS E ON GE.IdEstudiante = E.ID
	WHERE GE.IdGrupo = @idGrupo;

	SELECT * FROM @estudiantes_grupo;
END
go

go
CREATE PROCEDURE ver_evaluacion_estudiante_grupo @idGrupo int
AS
BEGIN
	DECLARE @evaluacion_estudiante_grupo Table (idEvaluacionxEstudiante int, idEstudiante int, NombreEstudiante varchar(50), ApellidoEstudiante varchar(50),
	CarnetEstudiante varchar(50), NombreEvaluacion varchar(50), NotaEvaluacion Decimal(7, 4));

	INSERT INTO @evaluacion_estudiante_grupo SELECT EE.ID, E.ID, E.Nombre, E.Apellido, E.Carnet, EVAL.Nombre, EE.Nota
	FROM dbo.Estudiante AS E
	INNER JOIN dbo.GrupoxEstudiante AS GE ON GE.IdEstudiante = E.ID
	INNER JOIN dbo.EvaluacionesxEstudiantes AS EE ON EE.IdGrupoxEstudiante = GE.ID
	INNER JOIN dbo.Evaluacion AS EVAL ON EVAL.ID = EE.IdEvaluacion
	WHERE GE.IdGrupo = @idGrupo;

	SELECT * FROM @evaluacion_estudiante_grupo ORDER BY idEstudiante ASC;
END
go

go
CREATE PROCEDURE ver_evaluacion_grupoxrubro @idGrupoxRubro int
AS
BEGIN
	DECLARE @result Table (ID int, idGrupoxRubro int, Nombre varchar(50), Fecha Date, ValorPorcentual Decimal(7, 4),
	Descripcion varchar(100));
	INSERT INTO @result SELECT * FROM dbo.Evaluacion WHERE IdGrupoxRubro = @idGrupoxRubro;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_evaluacionesxestudiantes @idGrupoxEstudiante int, @idEvaluacion int
AS
BEGIN
	DECLARE @result Table(Nota Decimal(7, 4))
	INSERT INTO @result SELECT Nota FROM dbo.EvaluacionesxEstudiantes WHERE IdGrupoxEstudiante = @idGrupoxEstudiante
	AND IdEvaluacion = @idEvaluacion;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_grupos_periodo_profesor @idPeriodo int, @idProfesor int
AS
BEGIN
	DECLARE @result Table (idGrupo int, idEstado int, idPeriodo int, idProfesor int, NombreCurso varchar(50),
	CodigoGrupo varchar(50));

	INSERT INTO @result SELECT ID, idEstado, idPeriodo, idProfesor, NombreCurso, CodigoGrupo
	FROM dbo.Grupo WHERE idProfesor = @idProfesor AND IdPeriodo = @idPeriodo;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_grupos_profesor @idProfesor int
AS
BEGIN
	DECLARE @grupos_profesor Table (idGrupo int, FechaInicio Date, FechaFinal Date, NombreCurso varchar(50),
	CodigoGrupo varchar(50), Activo varchar(6));

	INSERT INTO @grupos_profesor SELECT G.ID, P.FechaInicio, P.FechaFinal, G.NombreCurso, G.CodigoGrupo, P.Activo
	FROM dbo.Grupo AS G INNER JOIN
	dbo.Periodo AS P ON G.IdPeriodo = P.ID
	WHERE G.idProfesor = @idProfesor;

	SELECT * FROM @grupos_profesor ORDER BY idGrupo ASC;
END
go

go
CREATE PROCEDURE ver_grupoxestudiante_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table(ID int, idGrupo int, idEstadoGxE int, idEstudiante int, Nota Decimal(7, 4));
	INSERT INTO @result SELECT * FROM dbo.GrupoxEstudiante WHERE IdGrupo = @idGrupo;

	SELECT * FROM @result ORDER BY ID ASC;
END
go

go
CREATE PROCEDURE ver_grupoxrubro_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table(ID int, idGrupo int, idRubro int, ValorPorcentual Decimal(7, 4), Esfijo varchar(6), Cantidad int);
	INSERT INTO @result SELECT * FROM dbo.GrupoxRubro WHERE IdGrupo = @idGrupo;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_grupoxrubro_profesor @idGrupo int
AS
BEGIN
	DECLARE @grupoxrubro_profesor Table (ID int, NombreRubro varchar(50));
	INSERT INTO @grupoxrubro_profesor SELECT GR.ID, R.Nombre
	FROM dbo.GrupoxRubro AS GR INNER JOIN
	dbo.Rubro AS R ON GR.IdRubro = R.ID
	WHERE GR.IdGrupo = @idGrupo;

	SELECT * FROM @grupoxrubro_profesor;
END
go

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
	DECLARE @result Table (NotaAcumulada Decimal(7, 4));

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

	INSERT INTO @result SELECT NotaAcumulada FROM dbo.GrupoxEstudiante WHERE IdGrupo = @idGrupo
	AND IdEstudiante = @idEstudiante
	AND IdEstadoGxE != 3
	AND	IdEstadoGxE != 4;

	SELECT * FROM @result;

END
go

go
CREATE PROCEDURE ver_estadogrupo_disponibles
AS
BEGIN
	DECLARE @estadogrupo_disponibles Table (ID int, Nombre varchar(50));
	INSERT INTO @estadogrupo_disponibles SELECT * FROM dbo.EstadoGrupo;

	SELECT * FROM @estadogrupo_disponibles;
END
go

go
CREATE PROCEDURE ver_notas_estudiante @idEstudiante int
AS
BEGIN
	DECLARE @tablaResultados Table (idEstudiante int, Carnet varchar(50), idGrupo int, NombreCurso varchar(50),
	NombreEvaluacion varchar(50), Nota Decimal(7, 4), ValorPorcentual Decimal(7, 4));
	INSERT INTO @tablaResultados SELECT e.ID, e.Carnet, g.ID, g.NombreCurso, eva.Nombre, ee.Nota, eva.ValorPorcentual
	FROM dbo.Estudiante AS e INNER JOIN
	dbo.GrupoxEstudiante AS ge ON @idEstudiante = ge.IdEstudiante INNER JOIN
	dbo.Grupo AS g ON g.ID = ge.IdGrupo INNER JOIN
	dbo.EvaluacionesxEstudiantes AS ee ON ee.IdGrupoxEstudiante = ge.ID INNER JOIN
	dbo.Evaluacion AS eva ON eva.ID = ee.IdEvaluacion
	WHERE e.ID = @idEstudiante;

	SELECT * FROM @tablaResultados ORDER BY idGrupo ASC;
END
go

go
CREATE PROCEDURE ver_periodos
AS
BEGIN
	DECLARE @periodos_disponibles Table (ID int, FechaInicio Date, FechaFinal Date, Activo varchar(6));
	INSERT INTO @periodos_disponibles SELECT * FROM dbo.Periodo AS P;

	SELECT * FROM @periodos_disponibles;
END
go

go
CREATE PROCEDURE ver_periodos_disponibles
AS
BEGIN
	DECLARE @periodos_disponibles Table (ID int, FechaInicio Date, FechaFinal Date, Activo varchar(6));
	INSERT INTO @periodos_disponibles SELECT * FROM dbo.Periodo AS P WHERE P.Activo = 'True';

	SELECT * FROM @periodos_disponibles;
END
go

go
CREATE PROCEDURE ver_rubros_disponibles
AS
BEGIN
	DECLARE @rubros_disponibles Table (ID int, Nombre varchar(50));
	INSERT INTO @rubros_disponibles SELECT * FROM dbo.Rubro;

	SELECT * FROM @rubros_disponibles;
END
go

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


go
CREATE PROCEDURE ver_grupoxrubro_grupo_nofijos @idGrupo int
AS
BEGIN
	DECLARE @result Table (ID INT, IdGrupo int, IdRubro int, ValorPorcentual Decimal(7, 4), Esfijo varchar(6), Cantidad int);

	INSERT INTO @result SELECT * FROM dbo.GrupoxRubro AS GR WHERE GR.IdGrupo = @idGrupo AND GR.Esfijo != 'True';

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_grupos_estudiante @idEstudiante int
AS
BEGIN
	DECLARE @result Table (ID int ,IdEstado int ,IdPeriodo int, IdProfesor int, NombreCurso varchar(50), CodigoGrupo varchar(50));
	INSERT INTO @result SELECT G.ID, G.IdEstado, G.IdPeriodo, G.idProfesor, G.NombreCurso, G.CodigoGrupo FROM dbo.Grupo AS G INNER JOIN dbo.GrupoxEstudiante AS GE ON GE.IdGrupo = G.ID
	WHERE GE.IdEstudiante = @idEstudiante;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE actualizar_grupo_nombre_codigo @idGrupo int, @NombreCurso varchar(50),
@CodigoGrupo varchar(50), @PostIn varchar(50), @PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @XMLAntes varchar(2000);
	SET @XMLAntes = (SELECT * FROM dbo.Grupo WHERE id = @idGrupo FOR XML PATH('Grupo'));
	UPDATE dbo.Grupo
	SET NombreCurso = @NombreCurso, CodigoGrupo = @CodigoGrupo
	WHERE ID = @idGrupo;
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.Grupo WHERE id = @idGrupo FOR XML PATH('Grupo'));
	EXEC sp_tabla_mantenimiento 4, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE ver_grupo @idGrupo int
AS
BEGIN
	DECLARE @result Table (NombreCurso varchar(50), CodigoGrupo varchar(50));

	INSERT INTO @result SELECT NombreCurso, CodigoGrupo FROM dbo.Grupo WHERE ID = @idGrupo;

	SELECT * FROM @result;
END
go

go
CREATE PROCEDURE ver_notas_estudiante_grupo @idEstudiante int, @idGrupo int
AS
BEGIN
	DECLARE @tablaResultados Table (idEstudiante int, Carnet varchar(50), idGrupo int, NombreCurso varchar(50),
	NombreEvaluacion varchar(50), Nota Decimal(7, 4), ValorPorcentual Decimal(7, 4));
	INSERT INTO @tablaResultados SELECT e.ID, e.Carnet, g.ID, g.NombreCurso, eva.Nombre, ee.Nota, eva.ValorPorcentual
	FROM dbo.Estudiante AS e INNER JOIN
	dbo.GrupoxEstudiante AS ge ON @idEstudiante = ge.IdEstudiante INNER JOIN
	dbo.Grupo AS g ON g.ID = ge.IdGrupo INNER JOIN
	dbo.EvaluacionesxEstudiantes AS ee ON ee.IdGrupoxEstudiante = ge.ID INNER JOIN
	dbo.Evaluacion AS eva ON eva.ID = ee.IdEvaluacion
	WHERE e.ID = @idEstudiante
	AND g.ID = @idGrupo;

	SELECT * FROM @tablaResultados ORDER BY idGrupo ASC;
END
go

go
CREATE PROCEDURE grupoxrubro_aumentar_cantidad @idGrupoxRubro int
AS
BEGIN
	UPDATE dbo.GrupoxRubro
	SET Cantidad = Cantidad + 1
	WHERE ID = @idGrupoxRubro;
END
go

go
CREATE PROCEDURE evaluacion_crear @idGrupoxRubro int, @Nombre varchar(50), @Fecha Date,
@ValorPorcentual decimal(7, 4), @Descripcion varchar(100), @PostIn varchar(50),
@PostBy varchar(50), @PostDate Date
AS
BEGIN
    DECLARE @ID int = (SELECT MAX(ID) FROM dbo.Evaluacion);
    SET @ID = @ID + 1;
    Declare @TablaValores Table (Cantidad int, esfijo varchar(6));
    INSERT INTO @TablaValores SELECT Cantidad, esfijo FROM dbo.GrupoxRubro WHERE ID = @idGrupoxRubro;
    IF (SELECT esfijo FROM @TablaValores) = 'False' OR (SELECT esfijo FROM @TablaValores) = 'false'
        BEGIN
        DECLARE @CantidadDeEvaluaciones int;
        SET @CantidadDeEvaluaciones = (SELECT COUNT(*) FROM dbo.Evaluacion WHERE IdGrupoxRubro = @idGrupoxRubro);
		IF @CantidadDeEvaluaciones = 0
			SET @CantidadDeEvaluaciones = 1;
        DECLARE @Porcentaje Decimal(7, 4);
        SET @Porcentaje = (SELECT TOP 1 ValorPorcentual FROM dbo.Evaluacion WHERE IdGrupoxRubro = @idGrupoxRubro);
        IF @Porcentaje IS NULL
            BEGIN
            SET @Porcentaje = (SELECT ValorPorcentual FROM dbo.GrupoxRubro WHERE id = @idGrupoxRubro);
            END
        DECLARE @PorcentajeNuevo Decimal(7, 4);
        SET @PorcentajeNuevo = @Porcentaje / @CantidadDeEvaluaciones;
        INSERT INTO dbo.Evaluacion(ID, idGrupoxRubro, Nombre, Fecha, ValorPorcentual, Descripcion)
        VALUES(@ID, @idGrupoxRubro, @Nombre, @Fecha, @PorcentajeNuevo, @Descripcion);
        UPDATE dbo.Evaluacion SET ValorPorcentual = @PorcentajeNuevo WHERE IdGrupoxRubro = @idGrupoxRubro;
        EXEC grupoxrubro_aumentar_cantidad @idGrupoxRubro;
        END
    ELSE
        BEGIN
        INSERT INTO dbo.Evaluacion(ID, idGrupoxRubro, Nombre, Fecha, ValorPorcentual, Descripcion)
        VALUES(@ID, @idGrupoxRubro, @Nombre, @Fecha, @ValorPorcentual, @Descripcion)
        END
    DECLARE @XMLDespues varchar(2000);
    SET @XMLDespues = (SELECT * FROM dbo.Evaluacion WHERE id = @ID FOR XML PATH('Evaluacion'));
    EXEC sp_tabla_mantenimiento 8, '', @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE verEstudiantes
AS
BEGIN
	DECLARE @estudiantes Table (ID int, Nombre varchar(50), Apellido varchar(50), Correo varchar(50),Carnet varchar(50), Telefono varchar(50),Contraseña varchar(50));
	INSERT INTO @estudiantes SELECT * FROM dbo.Estudiante AS E;

	SELECT * FROM @estudiantes;
END
go

go
CREATE PROCEDURE estudiante_cambiar @ID int, @Nombre varchar(50), @Apellido varchar(50), @Correo varchar(50),
@Carnet varchar(50), @Telefono varchar(50), @Contraseña varchar(50), @PostIn varchar(50),
@PostBy varchar(50), @PostDate Date
AS
BEGIN
	DECLARE @XMLAntes varchar(2000);
	SET @XMLAntes = (SELECT * FROM dbo.Estudiante WHERE id = @ID FOR XML PATH('Estudiante'));
	UPDATE dbo.Estudiante
	SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Carnet = @Carnet,
	Telefono = @Telefono, Contraseña = @Contraseña
	WHERE ID = @ID;
	DECLARE @XMLDespues varchar(2000);
	SET @XMLDespues = (SELECT * FROM dbo.Estudiante WHERE id = @ID FOR XML PATH('Estudiante'));
	EXEC sp_tabla_mantenimiento 12, @XMLAntes, @XMLDespues, @PostIn, @PostBy, @PostDate;
END
go

go
CREATE PROCEDURE estudiante_nombre @id int
AS
BEGIN
	DECLARE @result Table(Nombre varchar(50))
	INSERT INTO @result SELECT Nombre FROM dbo.Estudiante WHERE id = @id
	SELECT * FROM @result;
END
go
