create database SystemOfSalesDB
go
use SystemOfSalesDB
go

--select * from Productos

create table Usuarios(
UsuarioId int identity primary key,
Fecha date,
Usuario varchar(15),
NombreUsuario varchar(20),
TipoUsuario varchar(15),
Contrasena varchar(10)
);
go

insert into Usuarios(Fecha, Usuario,NombreUsuario, TipoUsuario, Contrasena) values ('2018/07/28','root','Administrador','ADMINISTRADOR','123');
select * from Usuarios
go

create table Clientes(
ClienteId int identity primary key,
Fecha date,
Nombres varchar(30),
Apellidos varchar(30),
Direccion varchar(50),
Email varchar(55),
Cedula varchar(14),
Sexo varchar(10),
Telefono varchar(13),
Balance money
);

go

create table Inventarios(
InventarioId int identity primary key,
ProductoId int not null,
Descripcion varchar(25),
Fecha date,
Cantidad int
);

go

create table Pagos(
PagoId int identity primary key,
Fecha date,
ClienteId int not null,
Nombres varchar(30),
Total money
);


go

create table Productos(
ProductoId int identity primary key,
FechaRegistro date,
FechaVencimiento date,
Descripcion varchar(30),
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
Total money,
Efectivo money,
Devuelta money
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
