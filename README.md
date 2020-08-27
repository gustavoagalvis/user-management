# Gestión de usuarios y roles

## Introducción

Creación de una api rest y de un cliente angular para la gestión de los usuarios.

Proyecto"FrontEnd" -> Aplicación Angular (v. 8.2) para gestionar usuarios, permisos y roles del sistema

Proyecto " UserManagement" -> REST Api para consulta y escritura a la base de datos

Carpeta "BackupsDatabase" -> Script con la base de datos del sistema

## Ejemplos de llamado a la api

Obtener datos de un usuario:
http://localhost:63304/user/get/{ID}

Obtener todos los usuarios:
http://localhost:63304/user/get

Crear usuario:
http://localhost:63304/user/post 

    "Username" : string,
    "Password" : string,
    "Fullname" : string,
    "Address" : string,
    "Phone" : string,
    "Email" : string,
    "Age" : int,
    "RolesId" : int


Editar usuario:
http://localhost:63304/user/put/{ID} 

    "Id" : int,
    "Username" : string,
    "Fullname" : string,
    "Address": string,
    "Phone": string,
    "Email": string,
    "Age": int,
    "RolesId":  1


Eliminar usuario:
http://localhost:63304/user/delete/{ID}


