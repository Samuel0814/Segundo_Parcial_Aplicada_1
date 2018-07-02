Create database SegundoParcialDb
go
use SegundoParcialDb
go
CREATE TABLE Articulos
(
	VehiculoID int primary KEY identity(1,1),
	Descripcion varchar(max),
	Mantenimiento int,
);