# Implementación práctica de TDD
## Motor de compras en .NET
### Integrantes:
	Coronel Francisco Exequiel
	Jeder Patricio Javier

### Descripción del tema trabajo:
- Este trabajo se centrará en la metodología de desarrollo Test Driven Development (TDD). En este trabajo, se abordará el ciclo Red-Green-Refactor (se empezará con una prueba unitaria que falle, luego se implementará el código mínimo necesario para que la prueba pase y se cerrará mejorando la estructura y calidad del código sin romper las pruebas), demostrando cómo las pruebas unitarias guían el diseño del software (favoreciendo un código más limpio, modular y mantenible) antes que la implementación. Para el desarrollo de este trabajo, utilizaremos el ecosistema .NET (C#) y el framework de pruebas xUnit.

### Objetivos del trabajo:

#### Principal: 
- Mostrar en la práctica cómo TDD utilizando el ciclo Red-Green-Refactor para este tipo de proyecto influye positivamente en la arquitectura y robustez del código.

#### Específicos:
- Ejecutar el ciclo de TDD en al menos 7 iteraciones funcionales.
- Implementar pruebas unitarias utilizando xUnit.
- Aplicar principios de diseño SOLID y refactorización continua.
- Documentar el avance progresivo mediante un historial de commits semánticos en Git.
- Uso de tests doubles, fixtures, manejo de Setup y Teardown para la organización

#### Alcance del trabajo: 
El proyecto se limitará al desarrollo de una biblioteca de clases (Class Library) que encapsule la lógica de negocio de un "Carrito de Compras". No se incluirá una interfaz gráfica ni una base de datos, se mantendra el foco en la lógica y las pruebas unitarias. 
El alcance funcional cubrirá: gestión de ítems, cálculo de totales, lógica de agrupación por cantidad, cálculo de impuestos, y aplicación de reglas de descuento complejas,entre otros.
