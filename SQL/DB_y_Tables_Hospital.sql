-- Crear la base de datos
CREATE DATABASE Sistema_de_gestion_clinica;
GO

-- Utilizar la base de datos recién creada
USE Sistema_de_gestion_clinica;
GO

-- Crear la tabla TurnosDisponibles
CREATE TABLE TurnosDisponibles (
    IDTurno INT IDENTITY(1,1) PRIMARY KEY,
    FechaTurno DATE,
    HoraTurno TIME,
    MedicoID INT,
    EspecialidadID INT,
	Disponible BIT
);
GO

-- Crear la tabla TurnosAgendados
CREATE TABLE TurnosAgendados (
    IDTurnoAgendado INT IDENTITY(1,1) PRIMARY KEY,
    IDTurnoDisp INT,
    MedicoID INT,
    PacienteID INT,
	Activo BIT
);
GO

-- Crear la tabla Medico
CREATE TABLE Medico (
    IDMedico INT IDENTITY(1,1) PRIMARY KEY,
    IDUsuario INT,
    Activo BIT
);
GO

-- Crear la tabla Especialidad
CREATE TABLE Especialidad (
    IDEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50),
	Activo BIT
);
GO

-- Crear la tabla Especialidad_Medico (relación muchos a muchos entre Medico y Especialidad)
CREATE TABLE Especialidad_Medico (
    IDEspecialidad INT,
    MedicoID INT
);
GO

-- Crear la tabla Paciente
CREATE TABLE Paciente (
    IDPaciente INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario INT,
    CoberturaID INT,
	Activo BIT
);
GO

-- Crear la tabla Usuario (para el inicio de sesión)
CREATE TABLE Usuario (
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
	TipoUsuario INT,
	DNI INT,
	Contraseña VARCHAR(50),
    Email VARCHAR(50),
	Nombre VARCHAR(50),
	Apellido VARCHAR(50),
	FechaNac DATE,
	Direccion VARCHAR(50),
	Telefono VARCHAR(20),
    Activo BIT
);
GO

-- Crear la tabla Cobertura
CREATE TABLE Cobertura (
    IDCobertura INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
	Activo BIT
);
GO
