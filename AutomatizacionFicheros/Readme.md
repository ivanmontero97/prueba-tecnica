# Proyecto de Consola con version .NET Core 3.1

## Descripción general del proyecto

Se trata de un sistema automatizado en el que existe un directorio de entrada y otro de salida. El programa detecta automáticamente 
(previa ejecución de la aplicación de consola) los ficheros dentro del directorio de entrada los lee linea a linea y los procesa según
ciertos criterios establecidos. 

Las lineas procesadas se transforman en ficheros .xlsx para que puedan ser procesados por excel. Según un carácter de la línea leída
en la posición 15 del fichero de entrada, la línea se procesara y se transformara en un fichero u otro dependiendo del valor de esta variable.
Aquellas lineas cuya variable en la posición 15 no se encuentre dentro de los parámetros buscados se anotara en un fichero de tipo .txt
de errores, en el directorio de Salida (el fin de esto es que no se pierda información potencialmente valiosa).

Los archivos de entrada procesados irán a una carpeta llamada Procesados.

-----------------------------------------------  Despliegue del proyecto  ------------------------------------------------------
El proyecto esta desarrollado para poder ser ejecutado en un entorno multiplataforma.
Los pasos a seguir independientemente del SO anfitrion son :
1º El SO debe ser compatible con .NET Core 3.1 y tenerlo instalado. Preferiblemente la 3.1.9
https://dotnet.microsoft.com/es-es/download/dotnet/3.1
2º Hay que crear dos variables de Entorno de nombre DIRECTORIA_ENTRADA y DIRECTORIO_SALIDA . Y en su valor ponerles el path del directorio como destino. 
	Por ejemplo :

	DIRECTORIO_ENTRADA = <path_directorio_entrada_ficheros> 
	DIRECTORIO_SALIDA= <path_directorio_salida_ficheros>
3º Se debe ejecutar el ejecutable de la carpeta publish. 
Para generar la carpeta publish desde el proyecto de desarrollo de .NET ejecutar el siguiente comando sobre el directorio del proyecto en
la terminal :
dotnet publish -c Release -r <RID>

Donde <RID> es el Identificador de Destino de Tiempo de Ejecución (Runtime Identifier) correspondiente al sistema operativo de destino. 
Por ejemplo, para Linux x64 sería linux-x64, para macOS sería osx-x64, y para Windows x64 sería win-x64.


------------------------------------------------------ Nuggets Instalados --------------------------------------------------------

Nuggets Instalados :
ClosedXML - Tratamiento de ficheros para excel.

-------------------------------------------------------------Bibliografía ---------------------------------------------------------
Fuentes consultadas para la prueba :
https://learn.microsoft.com/es-es/dotnet/api/system.io.filesystemwatcher?view=netcore-3.1
https://learn.microsoft.com/es-es/dotnet/api/system.io.notifyfilters?view=netcore-3.1
https://renatogroffe.medium.com/net-core-3-1-excel-gerando-um-arquivo-xlsx-com-closedxml-b19f35ba5f42
https://github.com/ClosedXML/ClosedXML/blob/develop/ClosedXML.Examples/Columns/InsertColumns.cs
https://learn.microsoft.com/es-es/dotnet/api/system.io.filestream?view=netcore-3.1#definition
SSS
