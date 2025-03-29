using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Entidades
{
    public class LibroDigital : LibroBase
    {
        public LibroDigital(int id, string titulo, string autor) : base(id, titulo, autor) { }

        public override void Imprimir()
        {
            Console.WriteLine($"No se puede imprimir un libro digital: {Titulo}");
        }
    }

}
