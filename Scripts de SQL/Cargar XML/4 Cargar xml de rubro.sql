use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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