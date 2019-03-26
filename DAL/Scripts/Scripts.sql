create database SystemOfSalesDB
go
use SystemOfSalesDB
go

select * from facturasdetalles

create table Usuarios(
UsuarioId int identity primary key,
Fecha date,
Email varchar(30),
Usuario varchar(20),
NombreUsuario varchar(20),
TipoUsuario varchar(15),
Contrasena varchar(10)
);
go

insert into Usuarios(Fecha, Email, Usuario,NombreUsuario, TipoUsuario, Contrasena) values ('2018/11/21','albertrosario@gmail.com','ADJ','Alber De Jesus','Administrador','123');
insert into Usuarios(Fecha, Email, Usuario,NombreUsuario, TipoUsuario, Contrasena) values ('2018/11/21','jesusmendoza@gmail.com','Jesus06','Jesus Mendoza','Cliente','1234');
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
Balance decimal(16,2)
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
Total decimal(16,2)
);


go

create table Productos(
ProductoId int identity primary key,
FechaRegistro date,
Descripcion varchar(30),
Costo decimal(16,2),
Precio decimal(16,2),
Ganancias decimal(16,2),
Inventario int
);

go

create table Facturas(
FacturaId int identity primary key,
Fecha date,
ClienteId int not null,
SubTotal decimal(16,2),
Itbis decimal(16,2),
Total decimal(16,2),
Efectivo decimal(16,2),
Devuelta decimal(16,2)
);

go

create table FacturasDetalles(
Id int identity primary key,
FacturaId int not null,
ProductoId int not null,
Descripcion varchar(50),
Cantidad int,
Precio decimal(16,2),
Importe decimal(16,2),
);
