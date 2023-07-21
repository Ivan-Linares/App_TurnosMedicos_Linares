USE Sistema_de_gestion_clinica
GO
-----------------USUARIOS-------------------------------
CREATE PROCEDURE SP_LISTAR_USUARIOS
AS
BEGIN
	SELECT U.IDUsuario, U.TipoUsuario, U.DNI, U.Contraseña, U.Email, U.Nombre, U.Apellido, 
	U.Direccion, U.Telefono, U.FechaNac, U.Activo
	FROM Usuario U
	WHERE U.Activo = 1
END
GO
----------------
CREATE PROCEDURE SP_BUSCAR_USUARIO (@DNI INT, @PASSWORD VARCHAR (50))
AS
BEGIN
	SELECT U.IDUsuario, U.TipoUsuario, U.DNI, U.Contraseña, U.Email, U.Nombre, U.Apellido, 
	U.Direccion, U.Telefono, U.FechaNac, U.Activo
	FROM Usuario U
	WHERE U.Activo = 1 AND (U.DNI = @DNI AND U.Contraseña = @PASSWORD)
END
GO
----------------
CREATE PROCEDURE SP_AGREGAR_USUARIO (  
@TipoUsuario INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20))
AS
BEGIN
	INSERT INTO Usuario (TipoUsuario, DNI, Contraseña, Email, Nombre, Apellido, FechaNac, Direccion, Telefono, Activo)
	VALUES (@TipoUsuario, @DNI, @Contraseña, @Email, @Nombre, @Apellido, @FechaNac, @Direccion, @Telefono, 1)
END
GO
----------------
CREATE PROCEDURE SP_MODIFICAR_USUARIO (
@IDUsuario INT,
@TipoUsuario INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20),
@Activo BIT)
AS
BEGIN
	UPDATE Usuario
	SET TipoUsuario = @TipoUsuario, DNI = @DNI, Contraseña = @Contraseña, Email = @Email, Nombre = @Nombre,
	Apellido = @Apellido, FechaNac = @FechaNac, Direccion = @Direccion, Telefono = @Telefono, Activo = 1
	WHERE IDUsuario = @IDUsuario
END
GO
----------------
CREATE PROCEDURE SP_ELIMINAR_USUARIO (@IDUsuario INT)
AS
BEGIN 
	UPDATE Usuario
	SET Activo = 0
	WHERE IDUsuario = @IDUsuario
END
GO

-----------------ESPECIALIDADES-------------------------------
CREATE PROCEDURE SP_LISTAR_ESP
AS
BEGIN
	SELECT E.IDEspecialidad, E.Descripcion 
	FROM Especialidad E
	WHERE E.Activo = 1
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_LISTAR_ESP_X_MEDICO (@IDUSER INT)
AS
BEGIN
	SELECT E.IDEspecialidad, E.Descripcion 
	FROM Especialidad E
	INNER JOIN Especialidad_Medico EXM ON EXM.IDEspecialidad = E.IDEspecialidad
	INNER JOIN Medico MED ON MED.IDMedico = EXM.MedicoID
	INNER JOIN Usuario USU ON USU.IDUsuario = MED.IDUsuario
	WHERE USU.IDUsuario = @IDUSER
END
GO
select * from Usuario
----------------
CREATE PROCEDURE SP_AGREGAR_ESP(@DESCRIP VARCHAR(50))
AS
BEGIN
	INSERT INTO Especialidad (Descripcion, Activo)
	VALUES (@DESCRIP, 1);
END
GO
----------------
CREATE PROCEDURE SP_MODIFICAR_ESP(@ID INT, @DESCRIP VARCHAR(50))
AS
BEGIN
	UPDATE Especialidad
	SET Descripcion = @DESCRIP
	WHERE IDEspecialidad = @ID
END
GO
----------------
CREATE PROCEDURE SP_ELIMINAR_ESP (@ID INT)
AS
BEGIN
	UPDATE Especialidad
	SET Activo = 0
	WHERE IDEspecialidad = @ID
END
GO

-----------------MEDICOS-------------------------------
CREATE OR ALTER PROCEDURE  SP_LISTAR_MEDICOS
AS
BEGIN
	SELECT Med.IDMedico, Usu.IDUsuario, Usu.DNI, Usu.Contraseña, Usu.Email, Usu.Nombre, 
	Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac, ESP.IDEspecialidad, ESP.Descripcion
	FROM Medico Med
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Med.IDUsuario
	INNER JOIN Especialidad_Medico EXM ON EXM.MedicoID = Med.IDMedico
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = EXM.IDEspecialidad
	WHERE Usu.TipoUsuario = 1 AND Med.Activo = 1 AND Usu.Activo = 1
	ORDER BY 1 ASC
END
GO
----------------
CREATE OR ALTER PROCEDURE  SP_LISTAR_MEDICOS_SOLODATOS
AS
BEGIN
	SELECT Med.IDMedico, Usu.IDUsuario, Usu.DNI, Usu.Contraseña, Usu.Email, Usu.Nombre, 
	Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac
	FROM Medico Med
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Med.IDUsuario
	WHERE Usu.TipoUsuario = 1 AND Med.Activo = 1 AND Usu.Activo = 1
	ORDER BY 1 ASC
END
GO
----------------
CREATE or alter PROCEDURE SP_LISTAR_MEDICO_X_ESP (@id INT)
AS
BEGIN
	SELECT ESP.IDEspecialidad, ESP.Descripcion, Med.IDMedico, Usu.IDUsuario, Usu.DNI, Usu.Contraseña, 
	Usu.Email, Usu.Nombre, Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac
	FROM Medico Med
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Med.IDUsuario
	INNER JOIN Especialidad_Medico EXM ON EXM.MedicoID = Med.IDMedico
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = EXM.IDEspecialidad
	WHERE Usu.TipoUsuario = 1 AND Med.Activo = 1 AND ESP.IDEspecialidad = 9
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_BUSCAR_MEDICO_USUARIO (@IDUSU INT)
AS
BEGIN
	SELECT Med.IDMedico, Usu.IDUsuario, Usu.DNI, Usu.Contraseña, Usu.Email, Usu.Nombre, 
	Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac, ESP.IDEspecialidad, ESP.Descripcion
	FROM Medico Med
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Med.IDUsuario
	INNER JOIN Especialidad_Medico EXM ON EXM.MedicoID = Med.IDMedico
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = EXM.IDEspecialidad
	WHERE Usu.TipoUsuario = 1 AND Med.Activo = 1 AND Usu.Activo = 1 AND Usu.IDUsuario = @IDUSU
END
GO
select * from Usuario
select * from Medico
select * from TurnosDisponibles
----------------
CREATE PROCEDURE SP_AGREGAR_MEDICO (  
@IDESP INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20))
AS
BEGIN
	--inserto usuario
	INSERT INTO Usuario (TipoUsuario, DNI, Contraseña, Email, Nombre, Apellido, FechaNac, Direccion, Telefono, Activo)
	VALUES (1, @DNI, @Contraseña, @Email, @Nombre, @Apellido, @FechaNac, @Direccion, @Telefono, 1)
	
	--inserto medico
	DECLARE @IDUsuario INT;
	SELECT @IDUsuario = MAX(IDUsuario) FROM Usuario 

	INSERT INTO Medico (IDUsuario, Activo)
	VALUES (@IDUsuario, 1)

	--inserto especialidad
	DECLARE @IDMedico INT;
	SELECT @IDMedico = MAX(IDMedico) FROM Medico 

	INSERT INTO Especialidad_Medico (IDEspecialidad, MedicoID)
	VALUES (@IDESP, @IDMedico);
END
GO
select * from Usuario
----------------
CREATE or alter PROCEDURE SP_MODIFICAR_MEDICO (  
@IDESP INT,
@IDMED INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20))
AS
BEGIN
	DECLARE @IDUsuario INT;
	SELECT @IDUsuario = IDUsuario FROM Medico WHERE IDMedico = @IDMED

	UPDATE Usuario
	SET DNI = @DNI, Contraseña = @Contraseña, Email = @Email, Nombre = @Nombre,
	Apellido = @Apellido, FechaNac = @FechaNac, Direccion = @Direccion, Telefono = @Telefono, Activo = 1
	WHERE IDUsuario = @IDUsuario

	UPDATE Especialidad_Medico
	SET IDEspecialidad = @IDESP
	WHERE MedicoID = @IDMED
END
GO
----------------
CREATE PROCEDURE SP_ELIMINAR_MEDICO (@IDMED INT)
AS
BEGIN
	DECLARE @IDUsuario INT;
	SELECT @IDUsuario = IDUsuario FROM Medico WHERE IDMedico = @IDMED

	UPDATE Medico 
	SET Activo = 0
	WHERE IDMedico = @IDMED

	UPDATE Usuario 
	SET Activo = 0
	WHERE IDUsuario = @IDUsuario
END
GO

-----------------COBERTURA-------------------------------
CREATE PROCEDURE SP_LISTAR_COBERTURAS
AS
BEGIN
	SELECT IDCobertura, Nombre
	FROM Cobertura 
	WHERE Activo = 1
END
GO
----------------
CREATE PROCEDURE SP_LISTAR_COBERTURAS_PACIENTE (@id int)
AS
BEGIN
	SELECT COB.Nombre
	FROM Cobertura COB
	INNER JOIN Paciente PAC ON COB.IDCobertura = PAC.CoberturaID
	INNER JOIN Usuario USU ON USU.IDUsuario = PAC.IDUsuario
	WHERE USU.IDUsuario = @id
END
GO
----------------
CREATE PROCEDURE SP_AGREGAR_COBERTURA (@DESCR VARCHAR(50))
AS
BEGIN
	INSERT INTO Cobertura(Nombre, Activo)
	VALUES(@DESCR, 1);
END
GO
----------------
CREATE PROCEDURE SP_MODIFICAR_COBERTURA (
@ID INT,
@DESCR VARCHAR(50)
)
AS
BEGIN
	UPDATE Cobertura
	SET Nombre = @DESCR
	WHERE IDCobertura = @ID
END
GO
----------------
CREATE PROCEDURE SP_ELIMINAR_COBERTURA (@ID INT)
AS
BEGIN
	UPDATE Cobertura
	SET Activo = 0
	WHERE IDCobertura = @ID
END
GO

-----------------PACIENTES-------------------------------
CREATE PROCEDURE SP_LISTAR_PACIENTES
AS
BEGIN
	SELECT Pad.IDPaciente, 
	Cob.IDCobertura, Cob.Nombre, Cob.Activo, 
	Usu.IDUsuario, Usu.TipoUsuario, Usu.DNI, Usu.Contraseña, Usu.Email, Usu.Nombre, 
	Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac, Usu.Activo, 
	Pad.Activo
	FROM Paciente Pad
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Pad.IDUsuario
	INNER JOIN Cobertura Cob ON Cob.IDCobertura = Pad.CoberturaID
	WHERE Usu.TipoUsuario = 0 AND Pad.Activo = 1 AND Usu.Activo = 1 AND Cob.Activo = 1
	ORDER BY 1 ASC
END
GO
----------------
CREATE PROCEDURE SP_AGREGAR_PACIENTE (  
@IDCOB INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20))
AS
BEGIN
	--inserto usuario
	INSERT INTO Usuario (TipoUsuario, DNI, Contraseña, Email, Nombre, Apellido, FechaNac, Direccion, Telefono, Activo)
	VALUES (0, @DNI, @Contraseña, @Email, @Nombre, @Apellido, @FechaNac, @Direccion, @Telefono, 1)
	
	--inserto paciente
	DECLARE @IDUsuario INT;
	SELECT @IDUsuario = MAX(IDUsuario) FROM Usuario 

	INSERT INTO Paciente (IDUsuario, CoberturaID, Activo)
	VALUES (@IDUsuario, @IDCOB, 1);
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_MODIFICAR_PACIENTE(
@IDUSER INT,
@IDCOB INT,
@DNI INT,
@Contraseña VARCHAR(50),
@Email VARCHAR(50),
@Nombre VARCHAR(50),
@Apellido VARCHAR(50),
@FechaNac DATE,
@Direccion VARCHAR(50),
@Telefono VARCHAR(20))
AS 
BEGIN
	DECLARE @IDPAC INT;
	SELECT @IDPAC = IDPaciente FROM Paciente WHERE IDUsuario = @IDUSER

	UPDATE Usuario 
	SET DNI = @DNI, Contraseña = @Contraseña, Email = @Email, Nombre = @Nombre,
	Apellido = @Apellido, FechaNac = @FechaNac, Direccion = @Direccion, Telefono = @Telefono
	WHERE IDUsuario = @IDUSER

	UPDATE Paciente 
	SET CoberturaID = @IDCOB
	WHERE IDPaciente = @IDPAC
END
GO
select * from Usuario
----------------
CREATE PROCEDURE SP_ELIMINAR_PACIENTE (@ID INT)
AS
BEGIN
	DECLARE @IDUsuario INT;
	SELECT @IDUsuario = IDUsuario FROM Paciente WHERE IDPaciente = @ID

	UPDATE Paciente 
	SET Activo = 0
	WHERE IDPaciente = @ID

	UPDATE Usuario 
	SET Activo = 0
	WHERE IDUsuario = @IDUsuario
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_BUSCAR_PACIENTE_USUARIO (@IDUSER INT)
AS
BEGIN
	SELECT Pad.IDPaciente, Cob.IDCobertura, Cob.Nombre, Cob.Activo, 
	Usu.IDUsuario, Usu.TipoUsuario, Usu.DNI, Usu.Contraseña, Usu.Email, Usu.Nombre, 
	Usu.Apellido, Usu.Direccion, Usu.Telefono, Usu.FechaNac, Usu.Activo, Pad.Activo
	FROM Paciente Pad
	INNER JOIN Usuario Usu ON Usu.IDUsuario = Pad.IDUsuario
	INNER JOIN Cobertura Cob ON Cob.IDCobertura = Pad.CoberturaID
	WHERE Usu.TipoUsuario = 0 AND Pad.Activo = 1 AND Usu.Activo = 1 AND Cob.Activo = 1 AND Usu.IDUsuario = @IDUSER
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_LISTAR_TURNOSDISPONIBLES_MEDICOESPECIALIDAD(@IDMED INT, @IDESPEC INT)
AS
BEGIN
	SELECT distinct T.IDTurno, T.FechaTurno, T.HoraTurno, T.MedicoID, T.EspecialidadID, ESP.Descripcion
	FROM TurnosDisponibles T
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = T.EspecialidadID
	WHERE T.Disponible = 1 AND T.MedicoID = @IDMED AND T.EspecialidadID = @IDESPEC AND T.FechaTurno > GETDATE()
	ORDER BY 2 ASC, 3 ASC
END
GO

----------------
CREATE OR ALTER PROCEDURE SP_LISTAR_TURNOSDISPONIBLES_MEDICO(@IDMED INT)
AS
BEGIN
	SELECT distinct T.IDTurno, T.FechaTurno, T.HoraTurno, T.MedicoID, T.EspecialidadID, ESP.Descripcion
	FROM TurnosDisponibles T
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = T.EspecialidadID
	WHERE T.Disponible = 1 AND T.MedicoID = @IDMED AND T.FechaTurno > GETDATE()
	ORDER BY 2 ASC, 3 ASC
END
GO
----------------
CREATE OR ALTER PROCEDURE SP_CREAR_TURNO_DISPONIBLE(
@FECHATURNO DATE,
@HORATURNO TIME,
@IDUSUARIO INT,
@IDESPEC INT)
AS
BEGIN
	DECLARE @IDMEDICO INT
	SELECT @IDMEDICO =	IDMedico
						FROM Medico
						WHERE IDUsuario = @IDUSUARIO

	INSERT INTO TurnosDisponibles(FechaTurno, HoraTurno, MedicoID, EspecialidadID, Disponible)
	VALUES (@FECHATURNO, @HORATURNO, @IDMEDICO, @IDESPEC, 1)
END
GO
----------------------------------------
CREATE OR ALTER PROCEDURE SP_CREAR_TURNO_DISPONIBLE_IDMED(
@FECHATURNO DATE,
@HORATURNO TIME,
@IDMEDICO INT,
@IDESPEC INT)
AS
BEGIN
	INSERT INTO TurnosDisponibles(FechaTurno, HoraTurno, MedicoID, EspecialidadID, Disponible)
	VALUES (@FECHATURNO, @HORATURNO, @IDMEDICO, @IDESPEC, 1)
END
GO
--HACER SPs PARA RESERVAR TURNOS
CREATE OR ALTER PROCEDURE SP_RESERVAR_TURNO(@IDTURNO INT, @IDUSU INT)
AS
BEGIN
	DECLARE @IDPAC INT
	SELECT @IDPAC = PAC.IDPaciente
	FROM Paciente PAC
	INNER JOIN Usuario USU ON USU.IDUsuario = PAC.IDUsuario
	WHERE USU.IDUsuario = @IDUSU AND USU.Activo = 1 AND PAC.Activo = 1
	
	INSERT INTO TurnosAgendados (IDTurnoDisp, PacienteID, Activo)
	VALUES (@IDTURNO, @IDPAC, 1)

	UPDATE TurnosDisponibles
	SET Disponible = 0
	WHERE IDTurno = @IDTURNO
END
GO
select * from Usuario
-----------------------------------
CREATE OR ALTER PROCEDURE SP_RESERVAR_TURNO_SECRETARIA(@IDTURNO INT, @DNIPAC INT)
AS
BEGIN
	DECLARE @IDPAC INT
	
	SELECT @IDPAC = PAC.IDPaciente
					FROM Paciente PAC
					INNER JOIN Usuario USU ON USU.IDUsuario = PAC.IDUsuario
					WHERE USU.DNI = @DNIPAC AND USU.Activo = 1 AND PAC.Activo = 1
	
	INSERT INTO TurnosAgendados (IDTurnoDisp, PacienteID, Activo)
	VALUES (@IDTURNO, @IDPAC, 1)

	UPDATE TurnosDisponibles
	SET Disponible = 0
	WHERE IDTurno = @IDTURNO
END
GO
-----------------------------------
CREATE or alter PROCEDURE SP_LISTAR_TURNOS_RESERVADOS_PAC(@IDUSU INT)
AS
BEGIN
	DECLARE @IDPAC INT

	SELECT @IDPAC = IDPaciente
					FROM Paciente
					WHERE IDUsuario = @IDUSU

	SELECT TA.IDTurnoAgendado, DISP.FechaTurno, DISP.HoraTurno, DISP.MedicoID, USU.Nombre, USU.Apellido, DISP.EspecialidadID, ESP.Descripcion
	FROM TurnosAgendados TA
	INNER JOIN TurnosDisponibles DISP ON DISP.IDTurno = TA.IDTurnoDisp
	INNER JOIN Medico MED ON DISP.MedicoID = MED.IDMedico
	INNER JOIN Usuario USU ON USU.IDUsuario = MED.IDUsuario
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = DISP.EspecialidadID
	WHERE TA.PacienteID = @IDPAC AND TA.Activo = 1 AND DISP.FechaTurno > GETDATE()
END
GO
------------------------------------------
CREATE or alter PROCEDURE SP_LISTAR_TURNOS_RESERVADOS_DNIPAC(@DNIPAC INT)
AS
BEGIN
	DECLARE @IDPAC INT

	SELECT @IDPAC = IDPaciente
					FROM Paciente P
					INNER JOIN Usuario U ON U.IDUsuario = P.IDUsuario
					WHERE U.DNI = @DNIPAC

	SELECT TA.IDTurnoAgendado, DISP.FechaTurno, DISP.HoraTurno, DISP.MedicoID, USU.Nombre, USU.Apellido, DISP.EspecialidadID, ESP.Descripcion
	FROM TurnosAgendados TA
	INNER JOIN TurnosDisponibles DISP ON DISP.IDTurno = TA.IDTurnoDisp
	INNER JOIN Medico MED ON DISP.MedicoID = MED.IDMedico
	INNER JOIN Usuario USU ON USU.IDUsuario = MED.IDUsuario
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = DISP.EspecialidadID
	WHERE TA.PacienteID = @IDPAC AND TA.Activo = 1 AND DISP.FechaTurno > GETDATE()
END
GO
------------------------------------------
CREATE OR ALTER PROCEDURE SP_LISTAR_TURNOS_RESERVADOS_MED(@IDUSU INT)
AS
BEGIN
	DECLARE @IDMED INT
	SELECT @IDMED = IDMedico
					FROM Medico
					WHERE IDUsuario = @IDUSU

	SELECT TA.IDTurnoAgendado, TD.IDTurno, TD.FechaTurno, TD.HoraTurno, TD.MedicoID, TD.EspecialidadID,
	USU.Nombre, USU.Apellido, ESP.Descripcion
	FROM TurnosAgendados TA
	INNER JOIN TurnosDisponibles TD ON TD.IDTurno = TA.IDTurnoDisp
	INNER JOIN Paciente PAC ON PAC.IDPaciente = TA.PacienteID
	INNER JOIN Usuario USU ON USU.IDUsuario = PAC.IDUsuario
	INNER JOIN Especialidad ESP ON ESP.IDEspecialidad = TD.EspecialidadID
	WHERE TD.MedicoID = @IDMED AND TA.Activo = 1
END
GO
-----------------------------
CREATE OR ALTER PROCEDURE SP_DAR_BAJA_TURNO_AGENDADO (@IDAGENDADO INT)
AS
BEGIN
	DECLARE @IDDISP INT
	SELECT @IDDISP =	IDTurnoDisp
						FROM TurnosAgendados
						WHERE IDTurnoAgendado = @IDAGENDADO

	UPDATE TurnosDisponibles
	SET Disponible = 1
	WHERE IDTurno = @IDDISP

	DELETE TurnosAgendados
	WHERE IDTurnoAgendado = @IDAGENDADO
END
GO

CREATE OR ALTER PROCEDURE SP_TURNO_REALIZADO (@IDAGENDADO INT)
AS
BEGIN
	DELETE TurnosAgendados
	WHERE IDTurnoAgendado = @IDAGENDADO
END
GO