create procedure ActualizarUsuarios

@Usuario_Id int, @Fecha_ date, @Email_ varchar(30), @Usuario_ varchar(20), @Nombre_Usuario varchar(20), @Tipo_Usuario varchar(15), @Pass varchar(10)

as

if not exists (select UsuarioId from Usuarios where UsuarioId=@Usuario_Id)
	insert into Usuarios (UsuarioId,Fecha,Email,Usuario,NombreUsuario,TipoUsuario,Contrasena) values (@Usuario_Id,@Fecha_,@Email_,@Usuario_,@Nombre_Usuario,@Tipo_Usuario,@Pass)
else 
	update Usuarios set Fecha=@Fecha_, Email=@Email_, Usuario=@Usuario_, NombreUsuario=@Nombre_Usuario, TipoUsuario=@Tipo_Usuario, Contrasena=@Pass
