using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Departamento
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Departamento() { }

        public Departamento(int id, string nombre) { 
            this.id = id;
            this.nombre = nombre;
        }
    }
}
