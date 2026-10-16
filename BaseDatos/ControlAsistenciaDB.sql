-- ====================================================================
-- SISTEMA DE CONTROL DE ASISTENCIA Y PLANIFICACIÓN DE HORARIOS - GRUPO 1
-- Script de creación de la base de datos ControlAsistenciaDB (SQL Express)
-- Basado en el script del enunciado (caso 6) con estos agregados:
--   * Empleados: Puesto y SalarioBase (para el pago de horas extras).
--   * RegistroAsistencia: MinutosRetardo.
--   * Usuarios: tabla para el inicio de sesión.
--   * Códigos de empleado en formato numérico de 3 dígitos (001, 002, ...).
-- ADVERTENCIA: si la base ya existe, este script la BORRA y la vuelve a crear.
-- ====================================================================
USE master;
GO

IF DB_ID('ControlAsistenciaDB') IS NOT NULL
BEGIN
    ALTER DATABASE ControlAsistenciaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ControlAsistenciaDB;
END
GO

CREATE DATABASE ControlAsistenciaDB;
GO

USE ControlAsistenciaDB;
GO

-- Tabla: Departamentos
CREATE TABLE Departamentos (
    IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    NombreDepartamento VARCHAR(100) NOT NULL
);
GO

-- Tabla: Turnos
CREATE TABLE Turnos (
    IdTurno INT IDENTITY(1,1) PRIMARY KEY,
    NombreTurno VARCHAR(50) NOT NULL,
    HoraEntrada TIME NOT NULL,
    HoraSalida TIME NOT NULL,
    ToleranciaMinutos INT NOT NULL DEFAULT 10 CHECK (ToleranciaMinutos BETWEEN 0 AND 120)
);
GO

-- Tabla: Empleados (código de 3 dígitos: 001, 002, ...)
CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCarnet VARCHAR(20) UNIQUE NOT NULL CHECK (CodigoCarnet LIKE '[0-9][0-9][0-9]'),
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    IdDepartamento INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento),
    Puesto VARCHAR(100) NOT NULL DEFAULT 'Sin puesto',
    SalarioBase DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (SalarioBase >= 0),
    Activo BIT DEFAULT 1
);
GO

-- Tabla: AsignacionTurnos (turnos rotativos por fecha)
CREATE TABLE AsignacionTurnos (
    IdAsignacion INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado),
    IdTurno INT FOREIGN KEY REFERENCES Turnos(IdTurno),
    FechaProgramada DATE NOT NULL,
    CONSTRAINT UQ_Empleado_Fecha UNIQUE (IdEmpleado, FechaProgramada)
);
GO

-- Tabla: RegistroAsistencia (entradas, salidas, tardanzas y horas extras)
CREATE TABLE RegistroAsistencia (
    IdRegistro INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT FOREIGN KEY REFERENCES Empleados(IdEmpleado),
    FechaHoraEntrada DATETIME NOT NULL,
    FechaHoraSalida DATETIME NULL,
    Estado VARCHAR(20) DEFAULT 'Pendiente', -- 'Presente', 'Tarde', 'Ausente', 'Justificado'
    MinutosRetardo INT NOT NULL DEFAULT 0,
    HorasExtras DECIMAL(5,2) DEFAULT 0.00
);
GO

-- Tabla: Usuarios (inicio de sesión)
CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Contrasena VARCHAR(100) NOT NULL,
    NombreCompleto VARCHAR(150) NOT NULL
);
GO

-- ====================================================================
-- DATOS DE PRUEBA
-- ====================================================================
INSERT INTO Departamentos (NombreDepartamento) VALUES
('Tecnología y Sistemas'), ('Recursos Humanos'), ('Operaciones y Logística'), ('Finanzas');
GO

INSERT INTO Turnos (NombreTurno, HoraEntrada, HoraSalida, ToleranciaMinutos) VALUES
('Turno Matutino', '08:00:00', '17:00:00', 10),
('Turno Vespertino', '14:00:00', '22:00:00', 10),
('Turno Nocturno', '22:00:00', '06:00:00', 15);
GO

INSERT INTO Empleados (CodigoCarnet, Nombres, Apellidos, IdDepartamento, Puesto, SalarioBase, Activo) VALUES
('001', 'Carlos Enrique', 'Gómez Morales', 1, 'Desarrollador', 8000.00, 1),
('002', 'Ana María', 'Pérez López', 2, 'Analista de RRHH', 6500.00, 1),
('003', 'Jorge Luis', 'Rodríguez Castillo', 3, 'Supervisor de Bodega', 5500.00, 1),
('004', 'María Fernanda', 'Juárez Ruiz', 4, 'Contadora', 7000.00, 1),
('005', 'Luis Alberto', 'Méndez Ochoa', 3, 'Guardia de Seguridad', 4200.00, 1),
('006', 'Sofía Alejandra', 'Castro Díaz', 1, 'Practicante', 3000.00, 0);
GO

INSERT INTO AsignacionTurnos (IdEmpleado, IdTurno, FechaProgramada) VALUES
(1, 1, CAST(GETDATE() AS DATE)),
(2, 1, CAST(GETDATE() AS DATE)),
(3, 2, CAST(GETDATE() AS DATE)),
(4, 1, CAST(GETDATE() AS DATE)),
(5, 3, CAST(GETDATE() AS DATE)),
(1, 1, DATEADD(DAY, -1, CAST(GETDATE() AS DATE))),
(2, 1, DATEADD(DAY, -1, CAST(GETDATE() AS DATE))),
(3, 2, DATEADD(DAY, -1, CAST(GETDATE() AS DATE))),
(4, 1, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)));
GO

-- Ayer: 001 presente con extras, 002 tarde, 003 presente con extras, 004 ausente (sin registro)
INSERT INTO RegistroAsistencia (IdEmpleado, FechaHoraEntrada, FechaHoraSalida, Estado, MinutosRetardo, HorasExtras) VALUES
(1, CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('07:55:00' AS DATETIME),
    CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('17:15:00' AS DATETIME), 'Presente', 0, 0.33),
(2, CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('08:12:00' AS DATETIME),
    CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('17:00:00' AS DATETIME), 'Tarde', 12, 0.00),
(3, CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('13:58:00' AS DATETIME),
    CAST(DATEADD(DAY, -1, CAST(GETDATE() AS DATE)) AS DATETIME) + CAST('22:30:00' AS DATETIME), 'Presente', 0, 0.53),
-- Hoy: 001 ya marcó entrada
(1, CAST(CAST(GETDATE() AS DATE) AS DATETIME) + CAST('08:02:00' AS DATETIME), NULL, 'Presente', 2, 0.00);
GO

-- Usuario de prueba: admin / admin123
INSERT INTO Usuarios (NombreUsuario, Contrasena, NombreCompleto) VALUES
('admin', 'admin123', 'Administrador RRHH');
GO
