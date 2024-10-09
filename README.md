# BibliotecaAPI
Este proyecto fue creado en `.net core` utilizando el framework `.net 8`.

## Como descargarlo
Deben de ir al boton verde que dice `<> code` y ahi seleccionan la opcion que prefieran ya sea clonar el repositio mediante el `link` o descargarlo como `.zip` y descomprirlo en una carpeta que gusten

## Como ejecutarlo
1- Deben tener `Microsoft Visual Studio` (actualizado recomendablemente) y `SQL Server 2022` con el `SSMS` instalado.

2- Una vez ya descargado, clonado y/o descomprido, entonces deben buscar el archivo `bibliotecaBD.sql` abrirlo y ejecutarlo para crear la base de datos y luego buscar `BibliotecaAPI.sln` y ejecutarlo para abrir el proyecto.

3- Colocar el connection string de la base de datos creada en el apartado de `ConnectionStrings` en el  `appsetting.json`. Por ejemplo: "BibliotecaConnection": "Server=TUSERVER;Database=biblioteca;Trusted_Connection=True;TrustServerCertificate=True;".

4- Luego ejecutar el proyecto como `IIS Express`.
