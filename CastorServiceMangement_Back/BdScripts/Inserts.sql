INSERT INTO Cargos (IdCargo,Nombre) VALUES
('sm','Scrum Master'),
('dev','Desarrollador'),
('qa','QA'),
('po','PO');


INSERT INTO Empleados (Cedula, Nombre, Foto, FechaIngreso, IdCargo)
VALUES 
(1234567890, 'Juan Pérez', NULL, '2023-01-15','sm'),
(2345678901, 'María Rodríguez', NULL, '2023-02-20','dev'),
(3456789012, 'Carlos Gómez', NULL, '2023-03-05', 'qa'),
(4567890123, 'Ana Martínez', NULL, '2023-04-10','po'),
(5678901234, 'Pedro García', NULL, '2023-05-15', 'dev'),
(6789012345, 'Laura Fernández', NULL, '2023-06-20', 'dev'),
(7890123456, 'Jorge López', NULL, '2023-07-25', 'dev'),
(8901234567, 'Mónica Sánchez', NULL, '2023-08-30', 'dev'),
(9012345678, 'Felipe Ramírez', NULL, '2023-09-05', 'dev'),
(1238901234, 'Gabriela Castillo', NULL, '2023-10-10', 'dev');
