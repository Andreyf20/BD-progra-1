use BBD1;
GO

DECLARE @XML AS XML, @hDoc AS INT, @SQL NVARCHAR (MAX)

SET @XML = (SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\torre\Documents\GIT_ROOT\BD-progra-1\randomData.XML', SINGLE_BLOB) AS x)
--AQUI VA EL DIRECTORIO DEL XML


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