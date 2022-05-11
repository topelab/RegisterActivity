# Topelab.RegisterActivity para Topeinfo

## Descripción

Módulo Topelab.RegisterActivity creado con L2 Data2Code v2.10.422.504 (DB: sqlite) y con la versión 3.1.8 de la plantilla **CleanArchitectureWithEFCore6** (de doble paso) con las siguientes capas de Clean Architecture:

- Domain
- Adapters
- Business
- Services

## Tablas/Vistas seleccionadas

- winlog (Winlog)


## Dependencias del código generado

- Topelab.Core.Domain (interno)
    - [FluentValidation](https://fluentvalidation.net/)
    - [AutoMapper](https://automapper.org/)
- Topelab.Core.Adapters (interno)
    - [Newtonsoft.Json](https://www.newtonsoft.com/json)
- Topelab.Core.WebApi.Controllers (interno)
- Topelab.Core.Resolver (interno)

## Revisiones de plantilla

### 3.1.7

- Topelab.Core.Resolver to 1.3.1222.504
- Topelab.Core to 1.3.422.504
- Microsoft.EntityFramework to 6.0.4
- Moq to 4.17.2
- NLog to 4.7.15

### 3.1.6

- Refactor por revisión de DI en EF Core

### 3.1.5

- Requiere L2 Data2Code 2.10.322.423 que dispone la extensión  DoubleSlash para duplicar las contra barras.

### 3.1.4

- NUnit3TestAdapter to 4.2.1 from 4.2.0
- Pomelo.EntityFrameworkCore.MySql to 6.0.1 from 6.0.0
- Microsoft.NET.Test.Sdk to 17.1.0 from 17.0.0
- Microsoft.EntityFrameworkCore.Sqlite to 6.0.2 from 6.0.1
- Microsoft.EntityFrameworkCore.Design to 6.0.2 from 6.0.1
- Topelab.Core.Adapters to 1.3.322.218 from 1.3.322.111


### 3.1.3

- Requiere L2 Data2Code 2.10.122.123 que busca la sección "DataSources" en vez de "Areas". Se renombra "Areas.Name" a "DataSources.Area".

### 3.1.2

- Actualización de Topelab.Core.Resolver

### 3.1.1

- Adaptando de Topeinfo.Core.* a Topelab.Core.*
- Adaptando a Topelab.Core.Resolver

### 3.0.2

- Adaptación completa a .Net 6 y reorganización resolución DI

### 3.0.0

- Preparación para .Net 6

### 2.4.0

- La definición de las plantillas ahora están en el fichero `template-settings.json`
- Requiere L2 Data2Code 2.8.221.908 que soporta configuración de plantillas en ficheros json.
- Se actualizan algunos nugets

### 2.2.16

- Añadimos Topelab.RegisterActivity.Domain.Models para posible uso con MVVM

### 2.2.14

- Updating Topeinfo.Core.* to 1.2.721.626
- Updating NUnit3TestAdapter to 4.0.0 from 3.17.0
- Updating Pomelo.EntityFrameworkCore.MySql to 5.0.0 from 5.0.0-alpha.2
- Updating NUnit to 3.13.2 from 3.13.1
- Updating NLog to 4.7.10 from 4.7.9
- Updating Microsoft.NET.Test.Sdk to 16.10.0 from 16.9.4
- Updating Microsoft.EntityFrameworkCore.Sqlite to 5.0.7 from 5.0.5
- Updating Microsoft.EntityFrameworkCore.Design to 5.0.7 from 5.0.5

### 2.2.13

- Actualizar Topeinfo.Core.* a 1.2.621.531
- Actualizar NUnit a 3.13.2
- Actualizar Microsoft.NET.Test.Sdk a 16.10.0

### 2.2.12

- Renombrar Adapters.Models a Adapters.Builders y \*EntityModel.cs a \*EntityBuilder.cs
- Aplicar sugerencias de Roslynator

### 2.2.11

- Refactor del código de salida, sobre todo entidades y los tests, que había código duplicado

### 2.2.10

- Fix ApiControllers with FilterMultiple

### 2.2.9

- Actualizar Topeinfo.Core.* to 1.2.521.413

### 2.2.8

- Actualizar "NLog" Version="4.7.9"
- Actualizar "Microsoft.NET.Test.Sdk" Version="16.9.4"
- Actualizar "NLog.Web.AspNetCore" Version="4.12.0"
- Actualizar "Swashbuckle.AspNetCore" Version="6.1.2"

### 2.2.7

- Requiere L2 Data2Code 2.6.721.330 que añade los helpers *GetVar*, *Or*, *And* y *Equal*
- Actualizar NUnit a 3.13.1
- Actualizar Topeinfo.Core.* to 1.2.421.313
- Actualizar Moq a 4.16.1
- Actualizar Microsoft.EntityFrameworkCore 5.0.4
- Actualizar "Microsoft.NET.Test.Sdk" Version="16.9.1"
- Actualizar "NLog.Web.AspNetCore" Version="4.11.0"

### 2.2.6

- Requiere L2 Data2Code 2.6.1221.220 que añade el atributo *ShowWindow* al elemento *Command* dentro de *PreCommands* y/o *PostCommands*

### 2.2.5

- Requiere L2 Data2Code 2.6.121.220 que añade los elementos *PreCommands* y *PostCommands* dentro de *Template*

### 2.2.4

- Requiere L2 Data2Code 2.5.21.212 que incorpora *IsNumeric*, *IsString*, *IsDateOrTime*

### 2.2.3

- Añadimos Topelab.RegisterActivity.Tools como proyecto de consola para creaciones / migraciones de bases de datos

### 2.2.2

- Quitamos el año del final de las versiones y usamos la extension *AddBuildNumber*
- Tanto *AddMonthDay* como *AddBuildNumber* no añaden el punto a la versión.
- Mejoras en Repository y en Service
- Actualizar NUnit a 3.13.0
- Actualizar Topeinfo.Core.* to 1.2.221.123
- Actualizar Moq a 4.16.0
- Actualizar Microsoft.EntityFrameworkCore 5.0.2

### 2.1.321

- Simplificación de RegisterActivityDbContext y IDbContext para adaptarlo a EF Core 5.0: se eliminan AfterSave y BeforeSave ya que EF Core 5.0 ya lleva handlers para dicha gestión.

### 2.1.221

- Los controllers del módulo *Business* y los interfaces de los controllers del módulo *Business.Interfaces* sólo se generan si activamos *UseCases*

### 2.1.120

- Actualizar Topeinfo.Core.* a 1.2.120.1231 (net5.0)

### 2.1.020

- Cambios en la estructura de la solución
- Se elimina la variable SetWebApiConsole y el módulo
- Se crea el módulo *Business* que contiene los *Entity Controllers*, los *Entity Repository* que antes estaba en Adapters.
- Se crea el módulo *Business.Interfaces* para eliminar la dependencia de UseCases con Adapters
- Se crea la variable *SetBusiness* que controla el uso del módulo *Business*
- La relación de inclusión de módulos se define en:  `SetDomain < SetAdapters < SetBusiness < SetUseCases < SetWebApiControllers < SetWebApi`. La activación de un módulo hace que se incluyo los de su izquierda según la relación de inclusión.

### 2.0.2520

- Actualizar Moq to 4.15.2
- Actualizar Topeinfo.Core.* to 1.1.220.1126

### 2.0.2420

- Corregir el interface del DBContext y la forma de obtener el connectionString a partir de options

### 2.0.2320

- Actualizar Microsoft.NET.Test.SDK 16.8.0
- Actualizar Moq 4.15.1
- Actualizar Microsoft.EntityFrameworkCore 5.0.0
- Actualizar Pomelo.EntityFrameworkCore.MySql 3.2.4


### 2.0.2220

- Modificar RegisterActivityDbContext y FirstTableDbContextTest

### 2.0.2120

- Actualizar Microsoft.EntityFrameworkCore 3.1.9
- Actualizar Moq 4.14.7

### 2.0.2020

- Requiere L2 Data2Code 2.3.1020.1012 que incorpora:
    - *DbTypeOverrided* que nos indica si el tipo de la columna de la BdD se ha sobreescrito
    - *OverrideDbType* que nos indica el tipo de la columna de la BdD
- Corregir namespace de **MessageCodes**

### 2.0.1920

- Requiere L2 Data2Code 2.3.720.926 que incorpora:
    - *TableNameOrEntity* que proporciona o bien la *TableName* o bien *Entity Name* en función de la configuración de *Schemas."connectionName".NormalizedNames*
    - *ColumnNameOrName* dentro de secciones, que proporciona o bien la *ColumnName* o bien la propiedad *Name*
    - *CanCreateDb* que especifica si se podría crear la BD.
- Modificar las plantillas para que se pueda crear la base de datos y para que se puedan usar los nombres normalizados de las entidades y las propiedades

### 2.0.1820

- Actualizar nuget packages Swashbuckle.AspNetCore 5.6.3
- Cambiar numeración versión, las 2 últimas cifras de la parte *build* indican el año, y la revisión indica el mes y el día (como anteriormente)

### 2.0.17

- Actualizar Microsoft.EntityFrameworkCore 3.1.8
- Actualizar Pomelo.EntityFrameworkCore.MySql 3.2.0
- Añadir Microsoft.EntityFrameworkCore.Design en Topelab.RegisterActivity.WebApi\\Topelab.RegisterActivity.WebApi.csproj para poder activar Migrations:

```cmd
cd c:\arc\src\tmp\2.10.422.504-sqlite\Topelab.RegisterActivity\Topelab.RegisterActivity.Adapters
dotnet-ef migrations -s ..\Topelab.RegisterActivity.WebApi\Topelab.RegisterActivity.WebApi.csproj add InitialCreate
```

### 2.0.16

- Correcciones varias surgidas de los problemas al probrar WebAPI

### 2.0.15

- Añadir pruebas unitarias para DeleteEntityInteractor
- Corregir comentarios de los DTO

### 2.0.14

- Añadir pruebas unitarias para UpdateEntityInteractor
- Corregir prueba unitaria InsertEntityInteractor para que mock del repositorio falle al insertar duplicados

### 2.0.13

- Añadir pruebas unitarias para InsertEntityInteractor
- Actualizar Microsoft.NET.Test.Sdk 16.7.1
- Corregir los métodos del repositorio Insert, Update y Delete (convertimos parámetro opcional en fijo y se crean diferentes métodos)

### 2.0.12

- Actualizar Microsoft.EntityFrameworkCore.Sqlite 3.1.7 y Microsoft.NET.Test.Sdk 16.7.0

### 2.0.11

- Requiere L2 Data2Code 2.3.0.805 que proporciona el driver *JsonSchemaReader*

### 2.0.10

- Actualizar nuget package NLog.Web.AspNetCore 4.9.3

### 2.0.9

- Requiere L2 Data2Code 2.2.18.802 que proporciona nuevo atributo de *Templates.Global* llamado *FinalVars* que tiene por finalidad establecer valores de variables en función de otros. Se usa con variables que dependen de otras
- Añadimos atributo *FinalVars* para que se configuren correctamente las dependencias de *SetWebApi* > *SetWebApiControllers* > *SetAdapters* > *SetUseCases* > *SetDomain* (por ejemplo, si *SetAdapters* = 1, *SetUseCases* y *SetDomain* deben valer 1)

### 2.0.8

- Requiere L2 Data2Code 2.2.15.731 que proporciona *Sample* y *NextSample* mejorados y adaptados a *NextOne()*
- Requiere la versión 1.0.12.731 de los nugets de Topeinfo.Core (UseCases, Adapters, WebApiController) que incluye la extensión *NextOne()* para diferentes tipos de datos
- Añadidas las pruebas unitarias para GetListEntityInteractor

### 2.0.7

- Requiere L2 Data2Code 2.2.13.729 que proporciona *Sample* y *NextSample*
- Añadidas las pruebas unitarias para GetEntityInteractor

### 2.0.6

- Requiere L2 Data2Code 2.2.12.728 que soporta plantillas encadenadas
- Se añaden propiedades *IsGeneral* y *NextResource* en la especificación de plantilla. Con *IsGeneral* configuramos si la plantilla va a generar ficheros sin entidades. Con *NextResource* le especificamos la plantilla siguiente a procesar (se usa el *ResourcesFolder*).

### 2.0.5

- Actualizar nuget packages Pomelo.EntityFrameworkCore.MySql 3.1.2
- Con la versión L2 Data2Code 2.2.8.725+ se pueden usar las variables GeneratorApplication y GeneratorVersion

### 2.0.4

- Código generado con la versión L2 Data2Code 2.2.2.718
- Cambiada la raíz de las plantillas ya que L2 Data2Code ya no obliga a tener las plantillas bajo Topelab.RegisterActivity, la base de la salida del código se define en `Templates.xml`
- Requiere la versión 1.0.10.718 de los nugets de Topeinfo.Core (UseCases, Adapters, WebApiController)
- Ahora las variables se evalúan correctamente pudiendo usar valores de variables previas

### 2.0.3

- Actualizar nuget packages Moq 4.14.5, NUnit3TestAdapter 3.17.0 y Swashbuckle.AspNetCore 5.5.1

### 2.0.2

- Corregir el mapeo de tablas sin PK

### 2.0.1

- Código generado con la aplicación L2Data2Code 2.0.3.619 que permite el uso de una fake connection
- Actualizamos nuget packages de EntityFramework a 3.1.5
- Se añade detección de "fake" para que use Sqlite

### 2.0.0

- Código generado con la aplicación L2Data2Code 2.0.1.618 (un refactor de Wigos Code Generator) ya que se estandarizan nombres de propiedades y se usa el inglés.
- Grandes cambios, se renombras los siguientes nombres:

    - Atributos: Columns
    - AtributosFK: ForeignKeyColumns
    - AtributosNotPrimaryKey: NotPrimaryKeyColumns
    - AtributosPersistibles: PersistedColumns
    - AtributosTodos: AllColumns
    - CadenaConexion: ConnectionString
    - Colecciones: Collections
    - Descripcion: Description
    - **Entidad**: Entity
    - EntidadDebil: IsWeakEntity
    - EsVista: IsView
    - GenerarBase: GenerateBase
    - HayAtributosNoPK: HasNotPrimaryKeyColumns
    - HayAtributosPK: HasPrimaryKeyColumns
    - HayColecciones: HasCollections
    - HayForeignKeys: HasForeignKeys
    - Id_o_Nombre: IdOrName
    - **Libreria**: Module
    - ListaIgnorados: IgnoreColumns
    - Nombre: Name
    - NombreColumna: ColumnName
    - NombreColumnaDiferente: IsNameDifferentToColumnName
    - NombreTabla: TableName
    - Parametros: UnfilteredColumns
    - ProveedorDatos: DataProvider
    - SeGeneranReferencias: GenerateReferences
    - Tabla: Table
    - Tipo: Type
    - TipoNullable: NullableType
    - UsarCastellano: UseSpanish

    En negrita los que se aplican también a nombres de ficheros



### 1.0.6

- Añadimos proyecto Adapters.Test

### 1.0.4

- Se activa la generación de nupkg en Domain, UseCases y Adapters, ya que este último tiene dependencia de los anteriores
- Los Dto de los UseCases no se generan si sólo hay que generar Domain

### 1.0.3

- Código generado con la versión 1.4.12.0604 de Wigos Code Generator que incluye una corrección para las variables por plantilla.
- Requiere la versión 1.0.9.603 de Topeinfo.Core.Adapters, que corrige los filtros con fechas
- Mediante las variables `SetDomain SetUseCases SetAdapters SetWebApiControllers SetWebApi SetWebApiConsole` se controla la generación de cada uno de los proyectos.

### 1.0.2

- Requiere la versión 1.0.8.602 de Topeinfo.Core.Adapters, que incluye la propiedad Count en los IResponseRequests
- Corregir verbos de los API Controllers: PUT para updates y POST para inserts

### 1.0.1

- Requiere la versión 1.0.6.601 de Topeinfo.Core.Adapters que ya incorpora el caché para las expresiones y las extensiones Where, Count y OrderBy para poder pasar un string como filtro.
- Se elimina la clase `CriteriaDto<T>` y se simplifica a `CriteriaDto` sin genéricos (se ha eliminado el uso de `Expression<T>`, por eso no es necesario la clase genérica).
- Se mejora GetList para que tenga en cuenta la paginación.

### 1.0.0 Versión inicial

- Se genera una WebApi con 5 casos de uso por cada una de las entidades
    - Get
    - GetList
    - Insert
    - Update
    - Delete
- Se genera un repositorio basado en un DbContext de EF Core 3.1. El repositorio generado es a modo de demostración, aunque es 100% funcional.

