use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)

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