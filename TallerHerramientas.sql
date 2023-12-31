-- Crear la base de datos
CREATE DATABASE TallerHerramientas;

-- Seleccionar la base de datos creada
USE TallerHerramientas;

-- Creación de la tabla Colaboradores
CREATE TABLE Colaboradores (
    CedulaIdentidad NVARCHAR(20) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellidos NVARCHAR(100),
    FechaRegistro DATE,
    Estado NVARCHAR(10) CHECK (Estado IN ('activo', 'inactivo'))
);

-- Creación de la tabla Herramientas
CREATE TABLE Herramientas (
    CodigoHerramienta NVARCHAR(20) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(MAX),
    CantidadDisponible INT CHECK (CantidadDisponible >= 0)
);

-- Creación de la tabla PrestamosHerramientas
CREATE TABLE PrestamosHerramientas (
    IDPrestamo INT PRIMARY KEY IDENTITY(1,1),
    CedulaIdentidad NVARCHAR(20),
    CodigoHerramienta NVARCHAR(20),
    FechaPrestamo DATE,
    FechaCompromisoDevolucion DATE,
    FechaRealDevolucion DATE,
    FOREIGN KEY (CedulaIdentidad) REFERENCES Colaboradores(CedulaIdentidad),
    FOREIGN KEY (CodigoHerramienta) REFERENCES Herramientas(CodigoHerramienta)
);
