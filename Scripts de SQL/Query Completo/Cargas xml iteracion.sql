use BBD1;
GO
--ESTUDIANTES
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML
DECLARE @xmlTable Table (ID int, name varchar(50), lastName varchar(50), email varchar(50), 
carnet varchar(50), phone varchar(50), password varchar(50))
INSERT INTO @xmlTable SELECT ID, name, lastName, email, carnet, phone, password
FROM OPENXML(@hDoc, 'XML/studentData/student')
WITH 
(
ID int '@ID',
name [varchar](50) '@name',
lastName [varchar](50) '@lastName',
email [varchar](50) '@email',
carnet [varchar](50) '@carnet',
phone [varchar](50) '@phone',
password [varchar](50) '@carnet'
);

INSERT INTO dbo.Estudiante SELECT ID, name, lastName, email, carnet, phone, password FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- PROFESORES
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, name varchar(50), email varchar(50), password varchar(50))
INSERT INTO @xmlTable SELECT ID, name, email, password
FROM OPENXML(@hDoc, 'XML/teacherData/teacher')
WITH 
(
ID int '@ID',
name [varchar](50) '@name',
email [varchar](50) '@email',
password [varchar](50) '@password'
);

INSERT INTO dbo.Profesor SELECT ID, name, email, password FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO

GO
-- RUBROS
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, name varchar(50))
INSERT INTO @xmlTable SELECT ID, name
FROM OPENXML(@hDoc, 'XML/itemData/item')
WITH 
(
ID int '@ID',
name [varchar](50) '@name'
);

INSERT INTO dbo.Rubro SELECT ID, name FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- ESTADOGRUPO
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, name varchar(50))
INSERT INTO @xmlTable SELECT ID, name
FROM OPENXML(@hDoc, 'XML/groupStateData/groupState')
WITH 
(
ID int '@ID',
name [varchar](50) '@name'
);

INSERT INTO dbo.EstadoGrupo SELECT ID, name FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO

GO
-- ESTADOGXE
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, Nombre varchar(50))
INSERT INTO @xmlTable SELECT ID, Nombre
FROM OPENXML(@hDoc, 'XML/studentGroupStateData/studentGroupState')
WITH 
(
ID int '@ID',
Nombre varchar(50) '@name'
);

INSERT INTO dbo.EstadoGxE SELECT ID, Nombre FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO

GO
-- PERIODOS
DECLARE @XML_Periodo AS XML, @hDoc_Periodo AS INT, @SQL_Periodo NVARCHAR (MAX)

SET @XML_Periodo = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc_Periodo OUTPUT, @XML_Periodo

DECLARE @xmlTable_Periodo Table (ID int, Inicio DateTime, Final DateTime, Activo varchar(6))
INSERT INTO @xmlTable_Periodo SELECT ID, Inicio, Final, Activo
FROM OPENXML(@hDoc_Periodo, 'XML/termData/term')
WITH 
(
ID int '@ID',
Inicio DateTime '@start',
Final DateTime '@end',
Activo [varchar](6) '@active'
);

EXEC sp_xml_removedocument @hDoc_Periodo

-- GRUPOS
DECLARE @XML_Grupos AS XML, @hDoc_Grupos AS INT, @SQL_Grupo NVARCHAR (MAX)

SET @XML_Grupos = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc_Grupos OUTPUT, @XML_Grupos

DECLARE @xmlTable_Grupos Table (ID int, idEstado int, idProfesor int, idPeriodo int, NombreCurso varchar(50),
CodigoGrupo varchar(50))
INSERT INTO @xmlTable_Grupos SELECT ID, idEstado, idProfesor, idPeriodo, NombreCurso, CodigoGrupo
FROM OPENXML(@hDoc_Grupos, 'XML/groupData/group')
WITH 
(
ID int '@ID',
idEstado varchar(50) '@groupStateID',
idProfesor int '@teacherID',
idPeriodo int '@termID',
NombreCurso varchar(50) '@courseName',
CodigoGrupo varchar(50) '@code'
);

EXEC sp_xml_removedocument @hDoc_Grupos

-- GRUPOXRUBRO
DECLARE @XML_GrupoxRubro AS XML, @hDoc_GrupoxRubro AS INT, @SQL_GrupoxRubro NVARCHAR (MAX)

SET @XML_GrupoxRubro = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc_GrupoxRubro OUTPUT, @XML_GrupoxRubro;

DECLARE @xmlTable_GrupoxRubroc Table (ID int, idRubro int, idGrupo int, percentage Decimal(7, 4),
count int, constantCount varchar(6));
INSERT INTO @xmlTable_GrupoxRubroc SELECT ID, idRubro, idGrupo, percentage, count, constantCount
FROM OPENXML(@hDoc_GrupoxRubro, 'XML/groupItemData/groupItem')
WITH 
(
ID int '@ID',
idRubro varchar(50) '@itemID',
idGrupo int '@groupID',
percentage Decimal(7, 4) '@percentage',
count varchar(50) '@count',
constantCount varchar(6) '@constantCount'
);

EXEC sp_xml_removedocument @hDoc_GrupoxRubro

-- GRUPOXESTUDIANTE
DECLARE @XML_GXE AS XML, @hDoc_GXE AS INT, @SQL_GXE NVARCHAR (MAX)

SET @XML_GXE = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc_GXE OUTPUT, @XML_GXE

DECLARE @xmlTable_GXE Table (ID int, NotaAcumulada Decimal(7, 4), idGrupo int, idEstudiante int, idEstadoGxE int)
INSERT INTO @xmlTable_GXE SELECT ID, NotaAcumulada, idGrupo, idEstudiante, idEstadoGxE
FROM OPENXML(@hDoc_GXE, 'XML/studentGroupData/studentGroup')
WITH 
(
ID int '@ID',
NotaAcumulada Decimal(7, 4) '@totalGrade',
idGrupo int '@groupID',
idEstudiante int '@studentID',
idEstadoGxE int '@studentGroupStateID'
);

EXEC sp_xml_removedocument @hDoc_GXE

-- EVALUACION
DECLARE @XML_eval AS XML, @hDoc_eval AS INT, @SQL_eval NVARCHAR (MAX)

SET @XML_eval = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc_eval OUTPUT, @XML_eval

DECLARE @xmlTable_eval Table (ID int, idGrupoxRubro int, Nombre varchar(50), Fecha DateTime, Porcentaje Decimal(7, 4),
Descripcion varchar(100))
INSERT INTO @xmlTable_eval SELECT ID, idGrupoxRubro, Nombre, Fecha, Porcentaje, Descripcion
FROM OPENXML(@hDoc_eval, 'XML/evaluationData/evaluation')
WITH 
(
ID int '@ID',
idGrupoxRubro [varchar](50) '@groupItemID',
Nombre [varchar](50) '@name',
Fecha [varchar](50) '@date',
Porcentaje [varchar](50) '@percentage',
Descripcion [varchar](100) '@description'
);

DECLARE @EvalOrdenada TABLE (ID int, idGrupoxRubro int, Nombre varchar(50), Fecha DateTime, Porcentaje Decimal(7, 4),
Descripcion varchar(100))

INSERT INTO @EvalOrdenada SELECT * FROM @xmlTable_eval ORDER BY Fecha ASC

EXEC sp_xml_removedocument @hDoc_eval

DECLARE @XML_evalestu AS XML, @hDoc_evalestu AS INT, @SQL_evalestu NVARCHAR (MAX)

SET @XML_evalestu = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomDataNuevo.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc_evalestu OUTPUT, @XML_evalestu

DECLARE @xmlTable_evalestu Table (ID int, idGrupoxEstudiante int, idEvaluacion int, Nota Decimal(7, 4))
INSERT INTO @xmlTable_evalestu SELECT ID, idGrupoxEstudiante, idEvaluacion, Nota
FROM OPENXML(@hDoc_evalestu, 'XML/studentEvaluationData/studentEvaluation')
WITH 
(
ID int '@ID',
idGrupoxEstudiante int '@studentGroupID',
idEvaluacion int '@evaluationID',
Nota Decimal(7, 4) '@grade'
);

EXEC sp_xml_removedocument @hDoc_evalestu

DECLARE @CantidadPeriodos int;
SET @CantidadPeriodos = (SELECT COUNT(*) FROM @xmlTable_Periodo);
DECLARE @idPeriodo int;
DECLARE @idGrupo int;
DECLARE @idGrupoxRubro int;
INSERT INTO dbo.Periodo SELECT ID, Inicio, Final, Activo FROM @xmlTable_Periodo;

-- GRUPOS
WHILE @CantidadPeriodos >= 0
	BEGIN
	Select top 1 @idPeriodo = ID from @xmlTable_Periodo;
	INSERT INTO dbo.Grupo SELECT ID, idEstado, idPeriodo, idProfesor, NombreCurso, CodigoGrupo FROM @xmlTable_Grupos WHERE idPeriodo = @idPeriodo;
	
	DECLARE @Grupos Table (ID int, idEstado int, idProfesor int, idPeriodo int, NombreCurso varchar(50), CodigoGrupo varchar(50))
	INSERT INTO @Grupos SELECT ID, idEstado, idPeriodo, idProfesor, NombreCurso, CodigoGrupo FROM @xmlTable_Grupos WHERE idPeriodo = @idPeriodo;
	-- GRUPOxRUBRO
	While (Select Count(*) From @Grupos) > 0
		Begin
		select top 1 @idGrupo = ID FROM @Grupos;

		INSERT INTO dbo.GrupoxRubro SELECT ID, idGrupo, idRubro, percentage, constantCount, count FROM @xmlTable_GrupoxRubroc WHERE idGrupo = @idGrupo;

		DECLARE @GrupoxRubro Table (ID int, idRubro int, idGrupo int, percentage Decimal(7, 4), constantCount varchar(6), count int);
		INSERT INTO @GrupoxRubro SELECT ID, idGrupo, idRubro, percentage, constantCount, count FROM @xmlTable_GrupoxRubroc WHERE idGrupo = @idGrupo;
		
		-- GRUPOxESTUDIANTE
		INSERT INTO dbo.GrupoxEstudiante SELECT ID, idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada FROM @xmlTable_GXE WHERE idGrupo = @idGrupo;

		DELETE @Grupos WHERE ID = @idGrupo;
		END

	DELETE @xmlTable_Periodo WHERE ID = @idPeriodo;
	DELETE @xmlTable_Grupos WHERE idPeriodo = @idPeriodo;
	SET @CantidadPeriodos = @CantidadPeriodos - 1;
	END;

DECLARE @idEvaluacion int;
WHILE (SELECT COUNT(*) FROM @EvalOrdenada) > 0
	BEGIN 
	select top 1 @idEvaluacion = ID FROM @EvalOrdenada;
	INSERT INTO dbo.Evaluacion SELECT * FROM @EvalOrdenada WHERE ID = @idEvaluacion;
	-- EVALXESTU
	INSERT INTO dbo.EvaluacionesxEstudiantes SELECT ID, idGrupoxEstudiante, idEvaluacion, Nota FROM @xmlTable_evalestu WHERE idEvaluacion = @idEvaluacion;
	DELETE FROM @EvalOrdenada WHERE ID = @idEvaluacion;
	END
GO

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