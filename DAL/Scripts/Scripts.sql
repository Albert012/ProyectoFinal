create database SystemOfSales
go
use SystemOfSales
go

create table Usuarios(
UsuarioId int identity primary key,
Fecha date,
Usuario varchar(max),
NombreUsuario varchar(max),
TipoUsuario varchar(max),
Contrasena varchar(max)
);
go

insert into Usuarios(Fecha, Usuario,NombreUsuario, TipoUsuario, Contrasena) values ('2018/07/28','root','Administrador','ADMINISTRADOR','123');

go

create table Clientes(
ClienteId int identity primary key,
Fecha date,
Nombres varchar(max),
Direccion varchar(max),
Cedula varchar(13),
Sexo varchar(6),
Telefono varchar(12)
);

go

create table Inventarios(
InventarioId int identity primary key,
ProductoId int not null,
Descripcion varchar(max),
Fecha date,
Cantidad int
);

go

create table Productos(
ProductoId int identity primary key,
FechaRegistro date,
FechaVencimiento date,
Descripcion varchar(max),
Costo decimal,
Precio decimal,
Ganancias decimal,
Inventario int
);

go

create table Facturas(
FacturaId int identity primary key,
Fecha date,
ClienteId int not null,
SubTotal money,
Itbis money,
Total money
);

go

create table FacturasDetalles(
Id int identity primary key,
FacturaId int not null,
ProductoId int not null,
Cantidad int,
Precio money,
Importe money,
);
