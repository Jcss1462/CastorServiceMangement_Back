--CREATE DATABASE CastorServiceMagement;

/*
Drop table  Empleados;
Drop table  Cargos;
*/

CREATE TABLE Cargos (
    IdCargo VARCHAR(5) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cedula BIGINT NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Foto VARBINARY(MAX),
    FechaIngreso DATE NOT NULL,
    IdCargo VARCHAR(5) FOREIGN KEY REFERENCES Cargos(IdCargo)
);