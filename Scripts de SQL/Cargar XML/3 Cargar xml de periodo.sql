use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
--FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
FROM OPENROWSET(BULK 'C:\Users\Rubén González V\Documents\GitHub\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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