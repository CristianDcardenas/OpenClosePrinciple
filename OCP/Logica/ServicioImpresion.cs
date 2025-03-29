using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCP.Entidades;

namespace OCP.Logica
{
    public class ServicioImpresion
    {
        public void ImprimirLibro(LibroBase libro)
        {
            libro.Imprimir();
        }
    }
}
