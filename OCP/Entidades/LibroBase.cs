using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Entidades
{
    public abstract class LibroBase
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        protected LibroBase(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
        }

        public abstract void Imprimir();
    }
}
