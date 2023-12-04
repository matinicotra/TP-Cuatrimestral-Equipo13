USE BBDD_Equipo13
GO
--CARGA DE DATOS TIPOS DE VEHICULOS
INSERT INTO TIPOS_VEHICULOS (TIPO, CANT_ASIENTOS) VALUES ('Camioneta', 4);
INSERT INTO TIPOS_VEHICULOS (TIPO, CANT_ASIENTOS) VALUES ('Sedan', 4);
INSERT INTO TIPOS_VEHICULOS (TIPO, CANT_ASIENTOS) VALUES ('Van', 11);
INSERT INTO TIPOS_VEHICULOS (TIPO, CANT_ASIENTOS) VALUES ('Mini Van', 6);
INSERT INTO TIPOS_VEHICULOS (TIPO, CANT_ASIENTOS) VALUES ('Ejecutivo', 4);
GO

--CARGA DE DATOS VEHICULOS
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (1, 2020, 'ABC123', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (2, 2022, 'XYZ789', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (3, 2021, 'LMN456', 0);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (4, 2022, 'PQR987', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (5, 2023, 'AD456FE', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (2, 2021, 'GHI789', 0);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (3, 2020, 'JKL123', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (4, 2022, 'MNO789', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (5, 2023, 'AE456FR', 0);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (2, 2021, 'UVW123', 1);
INSERT INTO VEHICULOS (IDTIPO, MODELO, PATENTE, ESTADO) VALUES (5, 2021, 'AB343GR', 1);
GO

-- CARGA DE DATOS DOMICILIOS
INSERT INTO DOMICILIO (DIRECCION, LOCALIDAD, PROVINCIA, DESCRIPCION)
VALUES 
	('Av. Corrientes 123', 'CABA', 'Buenos Aires', 'Central location in the city'),
    ('Calle Lavalle 456', 'San Isidro', 'Buenos Aires', 'Quiet residential street near the river'),
    ('Av. Libertador 789', 'Vicente López', 'Buenos Aires', 'Luxury apartment with a view of the skyline'),
    ('Calle Maipú 234', 'Olivos', 'Buenos Aires', 'Family home in a green neighborhood'),
    ('Av. Cabildo 567', 'Belgrano', 'CABA', 'Conveniently located near public transport'),
    ('Calle San Martín 890', 'La Matanza', 'Buenos Aires', 'Spacious house with a large backyard'),
    ('Av. Santa Fe 345', 'San Justo', 'Buenos Aires', 'Close to shopping centers and entertainment'),
    ('Calle Reconquista 678', 'Quilmes', 'Buenos Aires', 'Cozy apartment in a lively neighborhood'),
    ('Av. Callao 901', 'Lomas de Zamora', 'Buenos Aires', 'Modern loft in a trendy area'),
    ('Calle Pueyrredón 1234', 'Banfield', 'Buenos Aires', 'Suburban house with easy access to the city');
GO

-- CARGA DE DATOS PERSONAS
INSERT INTO PERSONA (NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, NACIONALIDAD)
VALUES 
('Nombre 1', 'Apellido 1', '12345678', '1990-01-01', 1, 'Argentino'),
('Nombre 2', 'Apellido 2', '23456789', '1991-02-02', 2, 'Argentino'),
('Nombre 3', 'Apellido 3', '34567890', '1992-03-03', 3, 'Argentino'),
('Nombre 4', 'Apellido 4', '45678901', '1993-04-04', 4, 'Argentino'),
('Nombre 5', 'Apellido 5', '56789012', '1994-05-05', 5, 'Uruguayo'),
('Nombre 6', 'Apellido 6', '67890123', '1995-06-06', 6, 'Uruguayo'),
('Nombre 7', 'Apellido 7', '78901234', '1996-07-07', 7, 'Uruguayo'),
('Nombre 8', 'Apellido 8', '89012345', '1997-08-08', 8, 'Chileno');
GO

--CARGA DE DATOS ZONAS
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Sur')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Norte')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Oeste')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona CABA')
GO

-- CARGA DE DATOS CHOFERES
INSERT INTO CHOFER (IDPERSONA, IDZONA, IDVEHICULO)
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4)
GO

-- CARGA DE DATOS CLIENTES
INSERT INTO CLIENTE (IDPERSONA, IDZONA)
VALUES
(5, 1),
(6, 2),
(7, 3),
(8 , 4)
GO


--CARGA DE DATOS VIAJES
INSERT INTO VIAJES (IDCHOFER, IDCLIENTE, TIPOVIAJE, IMPORTE, IDDOMORIGEN, IDDOMDESTINO1, IDDOMDESTINO2, IDDOMDESTINO3, ESTADO, FECHAHORAVIAJE, PAGADO, MEDIODEPAGO)
VALUES 
    (1, 1, 'Ejecutivo', 23.40, 1, 2, null, null, 'Asignado', '2023-11-4', 0, 'Efectivo'),
    (2, 2, 'Particular', 30.40, 7, 3, null, null, 'Asignado', GETDATE(), 0, 'Trajeta de Credito'),
    (3, 3, 'Ejecutivo', 40.40, 5, 4, null, null, 'Asignado', GETDATE(), 0, 'Trajeta de Debito'),
    (4, 4, 'Urbano', 28.40, 6, 8, null, null, 'Asignado', GETDATE(), 0, 'Efectivo');

SELECT * FROM DOMICILIO
SELECT * FROM CHOFER
SELECT * FROM VIAJES

DROP DATABASE BBDD_Equipo13