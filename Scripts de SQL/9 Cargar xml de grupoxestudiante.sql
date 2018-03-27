use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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