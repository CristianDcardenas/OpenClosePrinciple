# OpenClosePrinciple
Descripción del Repositorio
Este repositorio contiene un proyecto en C# que implementa un sistema de gestión de libros. El proyecto sigue el Principio de Abierto/Cerrado (OCP) de la Programación Orientada a Objetos, permitiendo la extensión de funcionalidades sin modificar el código existente.

Características Principales
•	Gestión de Libros: Permite agregar, eliminar, buscar, listar e imprimir libros.
•	Tipos de Libros: Soporta diferentes tipos de libros, incluyendo libros físicos, libros digitales y audiolibros.
•	Interfaz de Usuario en Consola: Proporciona una interfaz de usuario en consola para interactuar con el sistema.
•	Validación de Datos: Incluye validaciones para asegurar que los datos ingresados por el usuario sean correctos.

Estructura del Proyecto
•	Entidades: Contiene las clases base y derivadas para los diferentes tipos de libros.
•	LibroBase: Clase abstracta que define la estructura básica de un libro.
•	LibroFisico: Clase que representa un libro físico.
•	LibroDigital: Clase que representa un libro digital.
•	AudioLibro: Clase que representa un audiolibro.
•	Lógica: Contiene la lógica de negocio para la gestión de libros.
•	ServicioLibros: Clase que maneja las operaciones de agregar, eliminar, buscar y listar libros.
•	ServicioImpresion: Clase que maneja la impresión de libros.
•	Presentación: Contiene la interfaz de usuario en consola.
•	LibroGUI: Clase que proporciona métodos para interactuar con el usuario y gestionar libros.
•	Menu: Clase que muestra el menú principal y maneja la navegación entre las opciones.
•	Program.cs: Punto de entrada del programa que inicia la aplicación y muestra el menú principal.

Requisitos
•	C#: Versión 7.3
•	.NET Framework: Versión 4.7.2

Cómo Ejecutar
1.	Clona el repositorio en tu máquina local.
2.	Abre el proyecto en Visual Studio 2022.
3.	Compila y ejecuta el proyecto.
4.	Interactúa con el sistema a través de la interfaz de usuario en consola.
