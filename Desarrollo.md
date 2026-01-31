# Introduccion
En el contexto actual de la ingeniería de software, la calidad y mantenibilidad del código son críticas. Este trabajo se centra en Test Driven Development (TDD), una metodología donde las pruebas unitarias guían el diseño del software antes de la implementación.
El objetivo principal es demostrar de manera práctica el ciclo Red-Green-Refactor: escribir un test que falla, implementar el código mínimo para que pase, y refactorizar. Utilizaremos el ecosistema .NET (C#) y el framework xUnit para construir un módulo de "Carrito de Compras".
Veremos cómo esta práctica influye directamente en:
- **La Arquitectura**: Fomentando el desacoplamiento mediante la Inversión de Dependencias.
- **La Robustez**: Asegurando la validación de invariantes y lógica de negocio
Para medir la robustez, utilizamos métricas de Cobertura de Código (Code Coverage) con la herramienta coverlet, buscando un porcentaje elevado para asegurar que todas las ramas lógicas (incluyendo casos de borde y manejo de nulos) estén validadas. Los referentes teóricos principales de esta técnica incluyen a Kent Beck (creador de XP) y Robert C. Martin, quienes sostienen que TDD es, ante todo, una técnica de diseño.

## Requisitos y dependencias
Requisitos y dependencias para ejecutar el sistema:
- **.NET SDK** Versión 9.0
- **xunit (2.4.2)**: Framework de pruebas unitarias.
- **xunit.runner.visualstudio**: Ejecutor de pruebas para la integración con el CLI de .NET.
- **coverlet.collector** (Version 3.2.0)

## Secuencia de comandos para levantar y ejecutar  el sistema :
1. Clonar el repositorio: **git clone https://github.com/ExequielCoronel/ProyectoIngenieriaSofware2.git**
(luego movernos a la carpeta de trabajo)
2. Restaurar dependencias: **dotnet restore** (este descarga e instala los paquetes NuGet listados anteriormente, no es estrictamente necesario utilizar este comando)
3. Compilar la solución: **dotnet build** (verifica que no existan errores de sintaxis en el código base, no es estrictamente necesario utilizar este comando)

### Ejecucion depruebas
Dado que este proyecto es una Biblioteca de Clases desarrollada bajo la metodología TDD, la "ejecución" y la validación del sistema se realizan a través de la **suite** de pruebas automatizadas que valida todas las iteraciones.

Para ejecutar todos los tests y ver el estado (Passed/Failed) aplicamos el siguiente comando:
**dotnet test**

Para validar la robustez del código, se debe ejecutar el siguiente comando que analiza qué porcentaje del código es cubierto por las pruebas:
**dotnet test --collect:"XPlat Code Coverage**

## Desarrollo Practico:
El desarrollo se llevó a cabo en 7 iteraciones incrementales, cada una abordando un requisito funcional y un desafío técnico específico.
Entorno y Herramientas
Para reproducir esta experiencia, se utilizo el SDK de .NET 9.0.
- Lenguaje: C#
- Testing: xUnit
- Métricas: Coverlet (Collector)
- Gestión de Versiones: Git (Commits semánticos por iteración).

- Primero creamos la estructura de trabajo.

dotnet new sln

dotnet new classlib -o CarritoDeCompra.Base

dotnet new xunit -o CarritoDeCompra.Tests

dotnet sln add  CarritoDeCompra.Base/CarritoDeCompra.Base.csproj

dotnet sln add  CarritoDeCompra.Tests/CarritoDeCompra.Tests.csproj

dotnet add  CarritoDeCompra.Tests/CarritoDeCompra.Tests.csproj reference CarritoDeCompra.Base/CarritoDeCompra.Base.csproj

dotnet add  CarritoDeCompra.Tests/CarritoDeCompra.Tests.csproj package coverlet.collector

Se crearon las clases bases para el desarrollo
- Iteracion 1: Agregar un item al carrito
  
**Objetivo**: Establecer la configuración del proyecto (Solution, Core, Tests) y permitir la persistencia en memoria de productos.
  
**RED**: se trabajo con ausencia de codigo (no se desarrollo el metodo que permitia agregar el item).
  
**GREEN**:Para lograr que se pase el test, se agrego un metodo util para la adhesion de items al carrito.
Como refactor, se protegio el acceso a la lista de productos.

- Iteracion 2: Cálculo de subtotal simple y fixtures
  
**Objetivo**: Implementar la sumatoria simple de precios.

**RED**: Nuevaemente trabajamos en ausencia de codigo.
  
**GREEN**: Implementamos el metodo que calcula el subtotal.
en la etapa red se trabajo con usencia de codigo, para pasar el test, se agrego un metodo que suma los precios de los items agregados a la lista.

**Refactor**: Notamos que repetíamos la creación de productos (new Product(...)) en los tests, introdujimos un fixture (ProductoFixture). Esto mejora la mantenibilidad y reduce la duplicación de código en la suite de test

- Iteracion 3: Refactorizacion estructural (Agrupacion por cantidad)
  
**Objetivo**: Manejar cantidades de un mismo producto en lugar de tener objetos duplicados en la lista.
  
**RED**: Producto no contaba con un campo de cantidad, para esto hacemos que el test intente acceder a un campo de cantidad de una lista todavia no definida.
  
**GREEN** y Refactor: Se creo una clase intermedia "CarritoItem", esta encapsulaba el producto y la cantidad del mismo. Se modifico en clase carrito para que en vez de trabajar con una lista de productos, trabaje con una lista de items. Se modificó la lógica interna del metodo para Agregar un item demanera que busque ítems existentes y sume cantidades en lugar de agregar nuevas filas.

- Iteracion 4: Eliminar items del carrito
  
**Objetivo**: Quitar una cantidad x de elementos del carrito de compras o directamente suprimir el item del carrito. 

**RED** Lanzamos el test llamando a la funcion `EliminarItem()` aun no implementada en la clase carrito.
  
**GREEN** Se implemento en la clase carrito la funcion `EliminarItem()`, donde el test paso con lo minimo implementado, controlando la existencia del item solicitado en la lista, eliminando el item del carrito si la cantidad a eliminar superaba a la existente en el carrito. Para el refactor, se mejoro la funcion de `EliminarCantidad()` de la clase `CarritoItem` haciendo uso de Math.Max, testeando distintos casos como: cantidad negativa, positiva y nula.

 - Iteracion 5: Servicio de impuestos
   
 **Objetivo**: Calcular el impuesto sin acoplarlo al carrito utilizando interfaces `IServiciosImpuestos`, testeando haciendo uso de Stubs `ServiciosImpuestosStub`.
 
 **RED** Lanzamos el test sin haber implementado la interfase, ni el Stub correspondiente.
   
 **GREEN** Desarrollamos la interfase `IServiciosImpuestos` y el Stub `ServiciosImpuestosStub`, de manera que los test sean exitosos (por defecto pusimos que la funcion de impuesto retorne un valor fijado en 10).

 - Iteracion 6: Servicio de descuentos
   
 **Objetivo**: Calcular el descuento sin acoplarlo al carrito utilizando interfaces `IServiciosDescuentos`, Donde para realizar el testeo utilizamos Mocks `ServiciosDescuentoMocks`.
   
 **RED**: Lanzamos el test sin haber implementado la interfase, ni el Mock correspondiente.
   
 **GREEN**: Desarrollamos la interfase `IServiciosDescuentos` y el Mock `ServicioDescuentoMocks` el mismo solo descuenta una cantidad fija pasada por parametro.

 - Iteracion 7: Modificacion Servicios de descuentos e impuestos
   
 **Objetivo**: Por ultimo Se proveen de servicios de descuentos e impuestos reales tales como la logica del IVA `ServicioDeImpuestoEstandar` y el descuento 3x2 `ServicioDeDescuento3por2`. 

Fuimos recolectando metricas de cobertura por medio del siguiente comando `dotnet test --collect:"XPlat Code Coverage"`, dichas metricas se encuentran en TestResults.

## Beneficios de Implementar TDD

Al aplicar la tecnica Test Driven Development en este proyecto obtuvimos los siguientes beneficios: 
- **Obtención de documentacion** por medio de la creación de los test, es decir que los test en `CarritoTest.cs` dan documentacion sobre el funcionamiento del sistema. Ejemplo: si queremos saber el funcionamiento del sistema de impuestos basta con observar dicho test.
- **Evolución de la arquitectura** no se implemento desde cero la inyeccion de dependencias al contrario, la necesidad de utilizacion de el Stub para probar el impuesto provoco la creación de la interfaz `IServiciosImpuestos` desacoplando al carrito de los impuestos.
- **Errores Detectados de manera temprana** se cubrieron casos bordes como por ejemplo eliminar un item del carrito que no existe.
- **Confianza en el cambio** En la iteración numero 3 se reescribio la logica de almacenamiento interna, evitando pruebas manuales extensas.

## Desafios y consideraciones
- **Curva de aprendizaje**: La dificultad a la hora de escribir el test en fase RED antes de implementar la solución va en contra de la forma en la que estamos acostumbrados a programar. Esto provocó un inicio de proyecto más lento, requiriendo disciplina para contener el impulso de saltar directamente a la implementación.

- **Complejidad tectina**: Al utiizar Mock se complico en cuanto a la configuracion de la inyeccion de dependencias en el construcctor del test.

- **Calidad de los tests**: Un test mal escrito puedo pasar sin probar realmente la logica, por lo tanto es muy importante revisar el acierto del mismo. 

- **Consideración (cobertura vs calidad)**: Si bien en las metricas de coberturas procuramos obtener 100% esto no garantiza la ausencia de bugs, estamos seguros de que la falta de tests provoca deuda tecnica, por lo tanto debemos testear el comportamiento y las reglas de negocio criticas.

## Conclusion
Al finalizar el desarrollo del carrito, notamos el cambio de mentalidad que exige el TDD. Al principio, escribir un test para una funcionalidad que aún no existía parecía contraintuitivo y sentíamos ralentizaba el avance. Sin embargo, a medida que se avanzaba en las iteraciones, notamos que esa "lentitud" inicial se traducía en una mayor velocidad y confianza para detectar errores.

Un punto clave fue la iteración de los impuestos: la necesidad de testear esa lógica aislada nos obligó a desacoplar el código usando inyección de dependencias, evitando que el sistema se vuelva rígido. Podemos concluir que TDD nos forzó a escribir código más limpio y modular, por necesidad práctica para que las pruebas pasaran.

## Referencias
- Beck, K. (2002). Test Driven Development: By Example. Addison-Wesley Professional.

- xUnit.net. (2025). Documentation. https://xunit.net/



