use BBD1;
GO
--ESTUDIANTES
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

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

INSERT INTO dbo.Estudiante SELECT name, lastName, email, carnet, phone, password FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- PROFESORES
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

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

INSERT INTO dbo.Profesor SELECT name, email, password FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- PERIODOS
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, Inicio DateTime, Final DateTime, Activo varchar(6))
INSERT INTO @xmlTable SELECT ID, Inicio, Final, Activo
FROM OPENXML(@hDoc, 'XML/termData/term')
WITH 
(
ID int '@ID',
Inicio DateTime '@start',
Final DateTime '@end',
Activo [varchar](6) '@active'
);

INSERT INTO dbo.Periodo SELECT Inicio, Final, Activo FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- RUBROS
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, name varchar(50))
INSERT INTO @xmlTable SELECT ID, name
FROM OPENXML(@hDoc, 'XML/itemData/item')
WITH 
(
ID int '@ID',
name [varchar](50) '@name'
);

INSERT INTO dbo.Rubro SELECT name FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- ESTADOGRUPO
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, name varchar(50))
INSERT INTO @xmlTable SELECT ID, name
FROM OPENXML(@hDoc, 'XML/groupStateData/groupState')
WITH 
(
ID int '@ID',
name [varchar](50) '@name'
);

INSERT INTO dbo.EstadoGrupo SELECT name FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO

GO
-- ESTADOGXE
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, Nombre varchar(50))
INSERT INTO @xmlTable SELECT ID, Nombre
FROM OPENXML(@hDoc, 'XML/studentGroupStateData/studentGroupState')
WITH 
(
ID int '@ID',
Nombre varchar(50) '@name'
);

INSERT INTO dbo.EstadoGxE SELECT Nombre FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- GRUPOS
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, idEstado int, idProfesor int, idPeriodo int, NombreCurso varchar(50),
CodigoGrupo varchar(50))
INSERT INTO @xmlTable SELECT ID, idEstado, idProfesor, idPeriodo, NombreCurso, CodigoGrupo
FROM OPENXML(@hDoc, 'XML/groupData/group')
WITH 
(
ID int '@ID',
idEstado varchar(50) '@groupStateID',
idProfesor int '@teacherID',
idPeriodo int '@termID',
NombreCurso varchar(50) '@courseName',
CodigoGrupo varchar(50) '@code'
);

INSERT INTO dbo.Grupo SELECT idEstado, idPeriodo, idProfesor, NombreCurso, CodigoGrupo FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- GRUPOXRUBRO
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, idRubro int, idGrupo int, percentage Decimal(7, 4),
count int, constantCount varchar(6))
INSERT INTO @xmlTable SELECT ID, idRubro, idGrupo, percentage, count, constantCount
FROM OPENXML(@hDoc, 'XML/groupItemData/groupItem')
WITH 
(
ID int '@ID',
idRubro varchar(50) '@itemID',
idGrupo int '@groupID',
percentage Decimal(7, 4) '@percentage',
count varchar(50) '@count',
constantCount varchar(6) '@constantCount'
);

INSERT INTO dbo.GrupoxRubro SELECT idGrupo, idRubro, percentage, constantCount, count FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- GRUPOXESTUDIANTE
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, NotaAcumulada Decimal(7, 4), idGrupo int, idEstudiante int, idEstadoGxE int)
INSERT INTO @xmlTable SELECT ID, NotaAcumulada, idGrupo, idEstudiante, idEstadoGxE
FROM OPENXML(@hDoc, 'XML/studentGroupData/studentGroup')
WITH 
(
ID int '@ID',
NotaAcumulada Decimal(7, 4) '@totalGrade',
idGrupo int '@groupID',
idEstudiante int '@studentID',
idEstadoGxE int '@studentGroupStateID'
);

INSERT INTO dbo.GrupoxEstudiante SELECT idGrupo, idEstadoGxE, idEstudiante, NotaAcumulada FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- EVALUACION
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)


EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, idGrupoxRubro int, Nombre varchar(50), Fecha DateTime, Porcentaje Decimal(7, 4),
Descripcion varchar(100))
INSERT INTO @xmlTable SELECT ID, idGrupoxRubro, Nombre, Fecha, Porcentaje, Descripcion
FROM OPENXML(@hDoc, 'XML/evaluationData/evaluation')
WITH 
(
ID int '@ID',
idGrupoxRubro [varchar](50) '@groupItemID',
Nombre [varchar](50) '@name',
Fecha [varchar](50) '@date',
Porcentaje [varchar](50) '@percentage',
Descripcion [varchar](100) '@description'
);

INSERT INTO dbo.Evaluacion SELECT idGrupoxRubro, Nombre, Fecha, Porcentaje, Descripcion FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO


GO
-- EVALUACIONESXESTUDIANTES
DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

--FROM OPENROWSET(BULK 'K:\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

EXEC sp_xml_preparedocument @hDoc OUTPUT, @XML

DECLARE @xmlTable Table (ID int, idGrupoxEstudiante int, idEvaluacion int, Nota Decimal(7, 4))
INSERT INTO @xmlTable SELECT ID, idGrupoxEstudiante, idEvaluacion, Nota
FROM OPENXML(@hDoc, 'XML/studentEvaluationData/studentEvaluation')
WITH 
(
ID int '@ID',
idGrupoxEstudiante int '@studentGroupID',
idEvaluacion int '@evaluationID',
Nota Decimal(7, 4) '@grade'
);

INSERT INTO dbo.EvaluacionesxEstudiantes SELECT idGrupoxEstudiante, idEvaluacion, Nota FROM @xmlTable;

EXEC sp_xml_removedocument @hDoc
GO