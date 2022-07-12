# Introducción

RegisterActiviy es una pequeña aplicación destinada a registrar el tiempo que se dedica a cada una de las aplicaciones abiertas mientras trabajas con el PC. Conforme el tiempo va pasando, se registra el título de la ventana, el nombre del ejecutable, la hora inicial y final que la aplicación ha estado en primer plano.

# Primeros pasos

## Construir solución

Simplemente abrir la solución con Visual Studio 2022 y compilarla. El proyecto principal es *RegisterActity*, es el que se deberá ejecutar.

## Ajustar la configuración

La aplicación se configura a través del fichero *appsettings.json*, cuyas claves principales son "ConnectionStrings:localserver", "OutputDirectory" y "OutputFileName"

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "localserver": "Data Source=data\\ActivitiesDB.db;"
  },
  "OutputDirectory": "C:\\Data\\RegisterActivity",
  "OutputFileName": "ActivitiesDB",
  "EPPlus": {
    "ExcelPackage": {
      "LicenseContext": "NonCommercial"
    }
  }
}
```

- **ConnectionStrings:localserver**: Debe indicar una cadena de conexión para SQLite, puede ser relativa a la carpeta donde se ejecuta *RegisterActivity*.
- **OutputDirectory**: Indica la ruta donde se guardarán los datos que exportemos, por defecto es la carpeta "Documentos" del usuario.
- **OutputFileName**: Indica el nombre del fichero que se usará al exportar (sin extensión), por defecto es el mismo nombre que el nombre de la base de datos.

## Uso de la aplicación

Una vez hayamos ajustado la configuración, deberíamos poder abrirla sin problemas. Se añadirá un icono en el área de notificación de la barra de tareas al que podemos hacer doble clic y ver los que se  registrando.

Con el botón derecho haciendo clic encima del icono, podemos acceder a un menú sencillo desde el cual podemos exportar a CSV o EXCEL los datos registrados en la base de datos.



