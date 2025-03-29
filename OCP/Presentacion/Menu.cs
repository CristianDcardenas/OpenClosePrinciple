using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCP.Logica;

namespace OCP.Presentacion
{
    public class Menu
    {
        private readonly ServicioLibros servicioLibros = new ServicioLibros();
        LibroGUI LibrosGUI = new LibroGUI();

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(45,5); Console.WriteLine("--- Gestión de Libros ---");
                Console.SetCursorPosition(40, 7); Console.WriteLine("1. Agregar Libro");
                Console.SetCursorPosition(40, 9); Console.WriteLine("2. Listar Libros");
                Console.SetCursorPosition(40, 11); Console.WriteLine("3. Eliminar Libro");
                Console.SetCursorPosition(40, 13); Console.WriteLine("4. Buscar Libro");
                Console.SetCursorPosition(40, 15); Console.WriteLine("5. Imprimir Libro");
                Console.SetCursorPosition(40, 18); Console.WriteLine("6. Salir");
                Console.SetCursorPosition(38, 20); Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        LibrosGUI.AgregarLibro();
                        break;
                    case 2:
                        Console.Clear();
                        LibrosGUI.ListarLibros();
                        break;
                    case 3:
                        LibrosGUI.EliminarLibro();
                        break;
                    case 4:
                        LibrosGUI.BuscarLibro();
                        break;
                    case 5:
                        LibrosGUI.ImprimirLibro();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }
    }

}
