use BBD1;
GO


DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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