using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Entidades
{
   public class LibroFisico : LibroBase
    {
        public LibroFisico(int id, string titulo, string autor) : base(id, titulo, autor) { }

        public override void Imprimir()
        {
            Console.WriteLine($"Imprimiendo libro físico: {Titulo} - {Autor}");
        }
    }
}
