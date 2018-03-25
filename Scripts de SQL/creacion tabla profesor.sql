use BBD1;
go
CREATE TABLE Profesor (
	id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Nombre nvarchar(50),
	Correo nvarchar(50),
	Contraseña nvarchar(50)
)
go