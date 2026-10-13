CREATE DATABASE exploracion_submarina; 
USE exploracion_submarina; 
CREATE TABLE zona ( 
id_zona INT AUTO_INCREMENT, 
nombre VARCHAR(100) NOT NULL, 
ubicacion VARCHAR(100) NOT NULL, 
profundidad_maxima INT NOT NULL, 
PRIMARY KEY (id_zona) 
); 
CREATE TABLE sumergible ( 
id_sumergible INT AUTO_INCREMENT, 
nombre VARCHAR(100) NOT NULL, 
modelo VARCHAR(100) NOT NULL, 
autonomia_horas INT NOT NULL, 
PRIMARY KEY (id_sumergible) 
); 
CREATE TABLE investigador ( 
id_investigador INT AUTO_INCREMENT, 
nombre VARCHAR(100) NOT NULL, 
especialidad VARCHAR(100) NOT NULL, 
PRIMARY KEY (id_investigador) 
); 
CREATE TABLE expedicion ( 
id_expedicion INT AUTO_INCREMENT, 
nombre VARCHAR(150) NOT NULL, 
fecha_salida DATE NOT NULL, 
duracion_horas INT NOT NULL, 
id_zona INT NOT NULL, 
id_sumergible INT NOT NULL, 
PRIMARY KEY (id_expedicion), 
FOREIGN KEY (id_zona) 
REFERENCES zona(id_zona), 
FOREIGN KEY (id_sumergible) 
REFERENCES sumergible(id_sumergible) 
); 
CREATE TABLE participacion ( 
id_expedicion INT, 
id_investigador INT, 
PRIMARY KEY (id_expedicion, id_investigador), 
FOREIGN KEY (id_expedicion) 
REFERENCES expedicion(id_expedicion), 
FOREIGN KEY (id_investigador) 
REFERENCES investigador(id_investigador) 
); 
CREATE TABLE muestra ( 
id_muestra INT AUTO_INCREMENT, 
id_expedicion INT NOT NULL, 
tipo VARCHAR(100) NOT NULL, 
profundidad_m INT NOT NULL, 
masa_kg DECIMAL(6,2) NOT NULL, 
PRIMARY KEY (id_muestra), 
FOREIGN KEY (id_expedicion) 
REFERENCES expedicion(id_expedicion) 
); 


-- INSERTAR LOS DATOS --
-- Ejecutar el siguiente script: --


USE exploracion_submarina; 
INSERT INTO zona 
(nombre, ubicacion, profundidad_maxima) 
VALUES 
('Abismo de Calipso', 'Atlántico Norte', 4000), 
('Arrecife Boreal', 'Mar de Noruega', 800), 
('Cañón Azul', 'Mediterráneo', 2200), 
('Bosque de Coral', 'Pacífico Sur', 300), 
('Llanura Somera', 'Mar del Norte', 150); 
INSERT INTO sumergible 
(nombre, modelo, autonomia_horas) 
VALUES 
('Nautilus-X', 'Explorer 3000', 18), 
('Triton II', 'Deep Scout', 12), 
('Leviathan', 'Abyss Pro', 20), 
('Mako', 'Mini Explorer', 8); 
INSERT INTO investigador 
(nombre, especialidad) 
VALUES 
('Alba Ruiz', 'Biología marina'), 
('Diego Martín', 'Geología'), 
('Nora Vidal', 'Microbiología'), 
('Mateo Sanz', 'Robótica submarina'), 
('Sara León', 'Oceanografía'); 
INSERT INTO expedicion 
(nombre, fecha_salida, duracion_horas, id_zona, id_sumergible) 
VALUES 
('Primera inmersión Calipso', '2026-09-10', 14, 1, 1), 
('Cartografía Boreal', '2026-09-12', 8, 2, 2), 
('Cañón Azul Norte', '2026-09-15', 11, 3, 3), 
('Fondo Calipso', '2026-09-18', 16, 1, 1), 
('Coral Nocturno', '2026-09-20', 6, 4, 2), 
('Silencio Abisal', '2026-09-25', 9, 3, 3); 
INSERT INTO participacion 
(id_expedicion, id_investigador) 
VALUES 
(1, 1), 
(1, 2), 
(2, 2), 
(2, 3), 
(3, 1), 
(3, 4), 
(4, 2), 
(4, 3), 
(4, 4), 
(5, 1), 
(6, 3); 
INSERT INTO muestra 
(id_expedicion, tipo, profundidad_m, masa_kg) 
VALUES 
(1, 'Sedimento', 3500, 2.40), 
(1, 'Organismo', 3600, 1.70), 
(1, 'Sedimento', 3420, 0.90), 
(2, 'Coral', 120, 1.20), 
(2, 'Sedimento', 150, 0.80), 
(2, 'Organismo', 95, 2.00), 
(3, 'Sedimento', 870, 3.30), 
(3, 'Organismo', 910, 2.50), 
(4, 'Sedimento', 3900, 1.10), 
(4, 'Organismo', 3760, 0.60), 
(4, 'Microorganismo', 3850, 1.30), 
(5, 'Coral', 80, 0.70), 
(5, 'Organismo', 120, 0.50); 