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
INSERT INTO PERSONA (NOMBRES, APELLIDOS, DNI, FECHANACIMIENTO, DOMICILIO, TELEFONO, EMAIL, NACIONALIDAD)
VALUES
('Ana', 'González', '32123456', '1990-05-15', 1, '1123456789', 'ana.gonzalez@email.com', 'Argentina'),
('Juan', 'Rodríguez', '40123456', '1985-08-22', 2, '1134567890', 'juan.rodriguez@email.com', 'Argentina'),
('María', 'López', '27123456', '1992-02-10', 3, '1145678901', 'maria.lopez@email.com', 'Argentina'),
('Lucas', 'Martínez', '38123456', '1988-11-03', 4, '1156789012', 'lucas.martinez@email.com', 'Argentina'),
('Laura', 'Sánchez', '45123456', '1995-07-18', 5, '1167890123', 'laura.sanchez@email.com', 'Argentina'),
('Gabriel', 'Díaz', '26123456', '1983-04-27', 6, '1178901234', 'gabriel.diaz@email.com', 'Argentina'),
('Silvina', 'Fernández', '34123456', '1998-01-05', 7, '1189012345', 'silvina.fernandez@email.com', 'Argentina'),
('Martín', 'Pérez', '50123456', '1980-09-14', 8, '1190123456', 'martin.perez@email.com', 'Argentina'),
('Cecilia', 'Giménez', '31123456', '1993-06-30', 9, '1101234567', 'cecilia.gimenez@email.com', 'Argentina'),
('Pablo', 'Torres', '43123456', '1987-12-08', 10, '1112345678', 'pablo.torres@email.com', 'Argentina');
GO

--CARGA DE DATOS ZONAS
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Sur')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Norte')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona Oeste')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Zona CABA')
INSERT INTO ZONAS (NOMBREZONA) VALUES ('Sin Zona')
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
    (1, 2, 'Particular', 30.40, 7, 3, null, null, 'Asignado', GETDATE(), 0, 'Trajeta de Credito'),
    (1, 3, 'Ejecutivo', 40.40, 5, 4, null, null, 'Asignado', GETDATE(), 0, 'Trajeta de Debito'),
    (1, 4, 'Urbano', 28.40, 6, 8, null, null, 'Asignado', GETDATE(), 0, 'Efectivo');

--CARGA DOS USUARIOS DE PRUEBA
INSERT INTO USUARIO (EMAIL, CONTRASENIA, ESADMIN, IDPERSONA)
VALUES
    ('admin@admin.com', '123', 1, null),
    ('chofer@chofer.com', '123', 0, 1),
    ('chofer2@chofer.com', '123', 0, 2)