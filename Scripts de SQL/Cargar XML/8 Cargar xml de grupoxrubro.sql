use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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