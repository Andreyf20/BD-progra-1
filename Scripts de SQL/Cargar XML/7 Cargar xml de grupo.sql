use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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