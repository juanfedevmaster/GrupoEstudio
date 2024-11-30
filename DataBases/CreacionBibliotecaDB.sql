-- Crear tabla Personas
CREATE TABLE Personas (
    Identificacion INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Celular NVARCHAR(15),
    FechaNacimiento DATE,
    FechaDefuncion DATE
);
GO

-- Crear tabla Roles
CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(50) NOT NULL
);
GO

-- Crear tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CorreoElectronico NVARCHAR(100) NOT NULL UNIQUE,
    [Password] NVARCHAR(255) NOT NULL,
    IdRol INT NOT NULL FOREIGN KEY REFERENCES Roles(Id),
    IdPersona INT NOT NULL FOREIGN KEY REFERENCES Personas(Identificacion)
);
GO

-- Crear tabla Prioridad
CREATE TABLE Prioridad (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CantidadDiasPrestamo INT NOT NULL,
    Descripcion NVARCHAR(100) NOT NULL
);
GO

-- Crear tabla Libros
CREATE TABLE Libros (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(255) NOT NULL,
    Autores NVARCHAR(255) NOT NULL,
    Genero NVARCHAR(100),
    ISBN NVARCHAR(20) NOT NULL UNIQUE,
    Editorial NVARCHAR(100),
    AnioPublicacion INT,
    CantidadCopias INT NOT NULL CHECK (CantidadCopias >= 0),
    Descripcion NVARCHAR(MAX),
    Idioma NVARCHAR(50),
    IdPrioridad INT FOREIGN KEY REFERENCES Prioridad(Id)
);
GO

-- Crear tabla Prestamos
CREATE TABLE Prestamos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaPrestamo DATE NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(Id)
);
GO

-- Crear tabla PrestamosLibros
CREATE TABLE PrestamosLibros (
    IdPrestamo INT NOT NULL FOREIGN KEY REFERENCES Prestamos(Id),
    IdLibro INT NOT NULL FOREIGN KEY REFERENCES Libros(Id),
    FechaLimite DATE NOT NULL,
    PRIMARY KEY (IdPrestamo, IdLibro)
);
GO

-- Crear tabla Reservas
CREATE TABLE Reservas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaReserva DATE NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(Id)
);
GO

-- Crear tabla ReservasLibros
CREATE TABLE ReservasLibros (
    IdReserva INT NOT NULL FOREIGN KEY REFERENCES Reservas(Id),
    IdLibro INT NOT NULL FOREIGN KEY REFERENCES Libros(Id),
    PRIMARY KEY (IdReserva, IdLibro)
);
GO

-- Insertar roles iniciales
INSERT INTO Roles (Descripcion) VALUES ('Usuario'), ('Administrador');
GO
