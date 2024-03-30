Create database Veterinaria
use Veterinaria
create table Usuarios (login_usuario int primary key not null, clave_usuario varchar(20), nombre_usuario varchar(50))
create table Mascotas (id_mascota int primary key identity(1,1), nombre_mascota varchar(50), tipo_mascota varchar(20), comida_favorita varchar(40))
create table citas (
id_mascota int, 
proxima_fecha date, 
medico_asignado varchar(50) 
constraint FK_id_mascota FOREIGN key (id_mascota) references Mascotas(id_mascota)
) 

insert into Usuarios values (0001,'Administrador', 'Usuario administrador')
insert into Usuarios values (0002,'123456789', 'Kevin Alfaro')
insert into Usuarios values (0003,'456', 'Alexander Alfaro')
insert into Usuarios values (0004,'123', 'pruebas Alfaro')
insert into Mascotas values ('Garfield','Gato','Lasagna')
insert into Mascotas values ('Leonardo','Tortuga', 'Pizza')
insert into Mascotas values ('Michelangelo','Tortuga', 'Pizza')
insert into Mascotas values ('Donatello','Tortuga', 'Pizza')
insert into Mascotas values ('Raphael','Tortuga', 'Pizza')
insert into Mascotas values ('Juancho','Gato', 'Atun')
insert into citas values (2, '2024-03-17', 'Kevin Alfaro')
insert into citas values (3, '2024-03-30', 'Kevin Alfaro')
SELECT * FROM Usuarios;
SELECT * FROM citas;
SELECT * FROM Mascotas;

SELECT M.id_mascota,M.nombre_mascota, C.proxima_fecha, C.medico_asignado
FROM Mascotas M
INNER JOIN citas C ON M.id_mascota=C.id_mascota WHERE C.proxima_fecha>=GETDATE() ORDER BY C.proxima_fecha
