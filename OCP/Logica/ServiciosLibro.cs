using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCP.Entidades;

namespace OCP.Logica
{
    public class ServicioLibros
    {
        public List<LibroBase> libros = new List<LibroBase>();

        public string AgregarLibro(LibroBase libro)
        {
            if (EsValido(libro))
            {
                libros.Add(libro);
                return "Libro agregado correctamente.";
            }
            else
            {
                return "Error: Datos del libro no válidos.";
            }
        }

        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

           
            foreach (var libro in libros)
            {
                Console.WriteLine($"- ID: {libro.Id}, {libro.Titulo} de {libro.Autor}");
            }
        }

        public string EliminarLibro(int id)
        {
            var libro = libros.Find(l => l.Id == id);
            if (libro != null)
            {
                libros.Remove(libro);
                return "Libro eliminado correctamente.";
            }
            else
            {
                return "Libro no encontrado.";
            }
        }

        public void BuscarLibro(string titulo)
        {
            var libro = libros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro != null)
            {
                Console.WriteLine($"Libro encontrado: ID {libro.Id}, {libro.Titulo} de {libro.Autor}");
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public bool EsValido(LibroBase libro)
        {
            return libro != null && libro.Id > 0 && !string.IsNullOrWhiteSpace(libro.Titulo) && !string.IsNullOrWhiteSpace(libro.Autor);
        }

        public LibroBase ObtenerLibroPorTitulo(string titulo)
        {
            return libros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
