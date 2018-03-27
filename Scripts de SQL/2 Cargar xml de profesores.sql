use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML

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