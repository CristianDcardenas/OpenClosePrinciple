using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCP.Entidades;
using OCP.Logica;

namespace OCP.Presentacion
{
    public class LibroGUI
    {
        ServicioLibros servicioLibros = new ServicioLibros();
        ServicioImpresion servicioImpresion = new ServicioImpresion();

        public void AgregarLibro()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 5); Console.WriteLine("--- Agregar Libro ---");

                string titulo;
                do
                {
                    Console.SetCursorPosition(38, 7); Console.Write("Ingrese el título del libro: ");
                    Console.SetCursorPosition(67, 7); titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.SetCursorPosition(38, 8); Console.WriteLine("Error: El título no puede estar vacío.");
                        Console.SetCursorPosition(67, 7); Console.Write(new string(' ', Console.WindowWidth - 67));
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                string autor;
                do
                {
                    Console.SetCursorPosition(38, 9); Console.Write("Ingrese el autor del libro: ");
                    Console.SetCursorPosition(66, 9); autor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(autor))
                    {
                        Console.SetCursorPosition(38, 10); Console.WriteLine("Error: El autor no puede estar vacío.");
                        Console.SetCursorPosition(66, 9); Console.Write(new string(' ', Console.WindowWidth - 66));
                    }
                } while (string.IsNullOrWhiteSpace(autor));

                int opcion;
                do
                {
                    Console.SetCursorPosition(38, 12); Console.WriteLine("Seleccione el tipo de libro:");
                    Console.SetCursorPosition(38, 14); Console.WriteLine("1. Libro Físico");
                    Console.SetCursorPosition(38, 15); Console.WriteLine("2. Libro Digital");
                    Console.SetCursorPosition(38, 16); Console.WriteLine("3. Audiolibro");
                    Console.SetCursorPosition(38, 18); Console.Write("Opción: ");
                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
                    {
                        Console.SetCursorPosition(38, 19); Console.WriteLine("Error: Opción no válida.");
                        Console.SetCursorPosition(38, 18); Console.Write(new string(' ', Console.WindowWidth - 38));
                    }
                } while (opcion < 1 || opcion > 3);

                int nuevoId = servicioLibros.libros.Count > 0 ? servicioLibros.libros.Max(l => l.Id) + 1 : 1;

                LibroBase libro;
                switch (opcion)
                {
                    case 1:
                        libro = new LibroFisico(nuevoId, titulo, autor);
                        break;
                    case 2:
                        libro = new LibroDigital(nuevoId, titulo, autor);
                        break;
                    case 3:
                        libro = new AudioLibro(nuevoId, titulo, autor);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. No se agregó el libro.");
                        return;
                }

                string mensaje = servicioLibros.AgregarLibro(libro);
                Console.SetCursorPosition(38, 21); Console.WriteLine(mensaje);
                Console.SetCursorPosition(38, 22); Console.WriteLine($"ID asignado: {libro.Id}");

                Console.SetCursorPosition(38, 24); Console.Write("¿Desea agregar otro libro? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();
                continuar = respuesta == "s";
            }
        }

        public void EliminarLibro()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 5); Console.WriteLine("--- Eliminar Libro ---");

                string titulo;
                do
                {
                    Console.SetCursorPosition(38, 7); Console.Write("Ingrese el título del libro a eliminar: ");
                    titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.SetCursorPosition(38, 8); Console.WriteLine("Error: El título no puede estar vacío.");
                        Console.SetCursorPosition(67, 7); Console.Write(new string(' ', Console.WindowWidth - 67));
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                var libro = servicioLibros.ObtenerLibroPorTitulo(titulo);
                if (libro != null)
                {
                    Console.SetCursorPosition(38, 9); Console.WriteLine($"ID: {libro.Id}");
                    Console.SetCursorPosition(38, 10); Console.WriteLine($"Título: {libro.Titulo}");
                    Console.SetCursorPosition(38, 11); Console.WriteLine($"Autor: {libro.Autor}");

                    string confirmacion;
                    do
                    {
                        Console.SetCursorPosition(38, 13); Console.Write("¿Está seguro de que desea eliminar este libro? (s/n): ");
                        confirmacion = Console.ReadLine().ToLower();
                        if (confirmacion != "s" && confirmacion != "n")
                        {
                            Console.SetCursorPosition(38, 14); Console.WriteLine("Error: Opción no válida.");
                            Console.SetCursorPosition(38, 13); Console.Write(new string(' ', Console.WindowWidth - 38));
                        }
                    } while (confirmacion != "s" && confirmacion != "n");

                    if (confirmacion == "s")
                    {
                        string mensaje = servicioLibros.EliminarLibro(libro.Id);
                        Console.SetCursorPosition(38, 15); Console.WriteLine(mensaje);
                    }
                    else
                    {
                        Console.SetCursorPosition(38, 15); Console.WriteLine("Eliminación cancelada.");
                    }
                }
                else
                {
                    Console.SetCursorPosition(38, 9); Console.WriteLine("Libro no encontrado.");
                }

                string respuesta;
                do
                {
                    Console.SetCursorPosition(38, 17); Console.Write("¿Desea eliminar otro libro? (s/n): ");
                    respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s" && respuesta != "n")
                    {
                        Console.SetCursorPosition(38, 18); Console.WriteLine("Error: Opción no válida.");
                        Console.SetCursorPosition(38, 17); Console.Write(new string(' ', Console.WindowWidth - 38));
                    }
                } while (respuesta != "s" && respuesta != "n");

                continuar = respuesta == "s";
            }
        }

        public void BuscarLibro()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 5); Console.WriteLine("--- Buscar Libro ---");

                string titulo;
                do
                {
                    Console.SetCursorPosition(38, 7); Console.Write("Ingrese el título del libro a buscar: ");
                    Console.SetCursorPosition(78, 7); titulo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titulo))
                    {
                        Console.SetCursorPosition(38, 8); Console.WriteLine("Error: El título no puede estar vacío.");
                        Console.SetCursorPosition(78, 7); Console.Write(new string(' ', Console.WindowWidth - 78));
                    }
                } while (string.IsNullOrWhiteSpace(titulo));

                servicioLibros.BuscarLibro(titulo);

                string respuesta;
                do
                {
                    Console.SetCursorPosition(38, 9); Console.Write("¿Desea buscar otro libro? (s/n): ");
                    respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s" && respuesta != "n")
                    {
                        Console.SetCursorPosition(38, 10); Console.WriteLine("Error: Opción no válida.");
                        Console.SetCursorPosition(38, 9); Console.Write(new string(' ', Console.WindowWidth - 38));
                    }
                } while (respuesta != "s" && respuesta != "n");

                continuar = respuesta == "s";
            }
        }

        public void ImprimirLibro()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 5); Console.WriteLine("--- Imprimir Libro ---");

            string titulo;
            do
            {
                Console.SetCursorPosition(38, 7); Console.Write("Ingrese el título del libro a imprimir: ");
                Console.SetCursorPosition(78, 7); titulo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Console.SetCursorPosition(38, 8); Console.WriteLine("Error: El título no puede estar vacío.");
                    Console.SetCursorPosition(78, 7); Console.Write(new string(' ', Console.WindowWidth - 78));
                }
            } while (string.IsNullOrWhiteSpace(titulo));

            var libro = servicioLibros.ObtenerLibroPorTitulo(titulo);
            if (libro != null)
            {
                Console.SetCursorPosition(38, 12); servicioImpresion.ImprimirLibro(libro);
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public void ListarLibros()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 5); Console.WriteLine("--- Listar Libros ---");
            Console.SetCursorPosition(38, 7); Console.WriteLine("\nLista de libros:");

            if (servicioLibros.libros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }
            int x = 38;
            int y = 9;
            int yActual = y;

            foreach (var libro in servicioLibros.libros)
            {
                Console.SetCursorPosition(x, yActual);
                Console.WriteLine($"- ID: {libro.Id}, {libro.Titulo} de {libro.Autor}");
                yActual++;
            }
        }
    }
}
