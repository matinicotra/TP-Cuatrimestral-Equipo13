use master
go
CREATE DATABASE BBDD_Equipo13
GO
USE BBDD_Equipo13
GO
--TABLA PARA TIPOS DE VEHICULOS
CREATE TABLE TIPOS_VEHICULOS(
    IDTIPO INT PRIMARY KEY IDENTITY(1,1),
    TIPO VARCHAR(20) NOT NULL,
    CANT_ASIENTOS INT NULL
)
GO
--RESTRICCIONES TIPOS DE VEHICULOS
ALTER TABLE TIPOS_VEHICULOS
ADD CHECK(CANT_ASIENTOS >= 4)
GO

--TABLA PARA VEHICULOS
CREATE TABLE VEHICULOS(
    IDVEHICULO INT PRIMARY KEY IDENTITY(1,1),
    IDTIPO INT NOT NULL,
    MODELO INT NOT NULL DEFAULT(2022),
    PATENTE VARCHAR(7) NOT NULL,
    ESTADO BIT NULL DEFAULT (1)
)
GO
--RESTRICCIONES VEHICULOS
ALTER TABLE VEHICULOS
ADD CONSTRAINT FK_VEHICULO_TIPO FOREIGN KEY (IDTIPO) REFERENCES TIPOS_VEHICULOS (IDTIPO)
GO
ALTER TABLE VEHICULOS
ADD CHECK(MODELO <= YEAR(GETDATE()))
GO

--TABLA PARA DOMICILIO
CREATE TABLE DOMICILIO (
    IDDOMICILIO BIGINT PRIMARY KEY IDENTITY(1,1),
    DIRECCION VARCHAR(100) NOT NULL,
    LOCALIDAD VARCHAR(80) NOT NULL,
    PROVINCIA VARCHAR(25) NOT NULL,
    DESCRIPCION VARCHAR(200) NULL,
)
GO  

-- TABLA PARA PERSONAS
CREATE TABLE PERSONA (
    IDPERSONA INT PRIMARY KEY IDENTITY(1,1),
    NOMBRES VARCHAR(50) NOT NULL,
    APELLIDOS VARCHAR(50) NOT NULL,
    DNI VARCHAR(10) NULL,
    FECHANACIMIENTO DATE NULL,
    DOMICILIO BIGINT FOREIGN KEY REFERENCES DOMICILIO(IDDOMICILIO) NULL,
    TELEFONO VARCHAR(15) NOT NULL DEFAULT 1588888,
    EMAIL VARCHAR(30) NULL DEFAULT 'ejemplo@ej.com',
    NACIONALIDAD VARCHAR(40) NULL
)
GO

--TABLA PARA ZONAS
CREATE TABLE ZONAS(
    IDZONA INT PRIMARY KEY IDENTITY(1,1),
    NOMBREZONA VARCHAR(15) NOT NULL
)
GO

-- TABLA PARA CHOFERES
CREATE TABLE CHOFER (
    IDCHOFER INT PRIMARY KEY IDENTITY (1,1),
    IDPERSONA INT FOREIGN KEY REFERENCES PERSONA (IDPERSONA) NOT NULL,
    IDZONA INT FOREIGN KEY REFERENCES ZONAS (IDZONA) NOT NULL,
    IDVEHICULO INT FOREIGN KEY REFERENCES VEHICULOS (IDVEHICULO) NULL,
    ESTADO BIT NOT NULL DEFAULT 1
)
GO

-- TABLA PARA CLIENTES
CREATE TABLE CLIENTE (
	IDCLIENTE INT PRIMARY KEY IDENTITY (1, 1),
	IDPERSONA INT NOT NULL FOREIGN KEY REFERENCES PERSONA (IDPERSONA),
    IDZONA INT NOT NULL FOREIGN KEY REFERENCES ZONAS (IDZONA) DEFAULT 2
)
GO

-- TABLA PARA VIAJES
CREATE TABLE VIAJES (
    IDVIAJE BIGINT PRIMARY KEY IDENTITY(1,1),
    IDCHOFER INT NOT NULL FOREIGN KEY REFERENCES CHOFER (IDCHOFER),
    IDCLIENTE INT NULL FOREIGN KEY REFERENCES CLIENTE (IDCLIENTE),
    TIPOVIAJE VARCHAR(15) NULL,
    IMPORTE MONEY NOT NULL,
    IDDOMORIGEN BIGINT NOT NULL FOREIGN KEY REFERENCES DOMICILIO (IDDOMICILIO),
    IDDOMDESTINO1 BIGINT NOT NULL FOREIGN KEY REFERENCES DOMICILIO (IDDOMICILIO),
    IDDOMDESTINO2 BIGINT NULL FOREIGN KEY REFERENCES DOMICILIO (IDDOMICILIO),    
    IDDOMDESTINO3 BIGINT NULL FOREIGN KEY REFERENCES DOMICILIO (IDDOMICILIO),    
    ESTADO VARCHAR(15) NOT NULL DEFAULT 'ASIGNADO',
    FECHAHORAVIAJE DATETIME NOT NULL DEFAULT GETDATE(),
    PAGADO BIT NOT NULL DEFAULT 0,
    MEDIODEPAGO VARCHAR(25) NOT NULL
)
GO
-- RESTRICCIONES VIAJES
ALTER TABLE VIAJES
ADD CHECK (IMPORTE > 0)
GO
ALTER TABLE VIAJES
ADD CHECK (FECHAHORAVIAJE <= GETDATE())
GO

-- STORED PROCEDURE
GO
CREATE PROCEDURE SP_BAJAFISICACLIENTE (@IDCLIENTE INT)
AS BEGIN
DECLARE @IDPERSONA INT
SET @IDPERSONA = (SELECT IDPERSONA FROM CLIENTE WHERE @IDCLIENTE = IDCLIENTE)
DELETE FROM CLIENTE WHERE @IDCLIENTE = IDCLIENTE
DELETE FROM PERSONA WHERE @IDPERSONA = IDPERSONA
END


--STORE PROCEDURE RESUMENES DE VIAJES
GO
CREATE PROCEDURE SP_RESUMENES_VIAJES (
    @IDPERSONA INT,
    @FECHAIN DATETIME,
    @FECHAFIN DATETIME
)
AS
BEGIN
    DECLARE @CHOFER INT
    SELECT @CHOFER = IDCHOFER FROM CHOFER WHERE IDPERSONA = @IDPERSONA

    SELECT 
        V.TIPOVIAJE,
        V.IMPORTE,
        V.FECHAHORAVIAJE
    FROM VIAJES AS V 
    WHERE IDCHOFER = @CHOFER
    AND V.FECHAHORAVIAJE >= @FECHAIN
    AND V.FECHAHORAVIAJE <= @FECHAFIN
    AND UPPER(ESTADO) <> 'CANCELADO'
    GROUP BY V.IDCHOFER, V.TIPOVIAJE, V.IMPORTE, V.FECHAHORAVIAJE
    ORDER BY V.FECHAHORAVIAJE ASC
END
