using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Listados
    {

        private static List<Persona> _listadoPersonas = ObtenerPersonas();
        public static List<Persona> ListadoPersonas {
            get { return _listadoPersonas; }
            set { _listadoPersonas = value; }
        }

        private static List<Departamento> _listadoDepartamentos = ObtenerDepartamentos();
        public static List<Departamento> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }

        /// <summary>
        /// Devuelve una lista con personas, emulando los contenidos iniciales de una base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Persona> ObtenerPersonas() {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona(1, "Manuel", "Morilla", 1));
            personas.Add(new Persona(2, "Juan Antonio", "Pineda", 3));
            return personas;
        }

        /// <summary>
        /// Devuelve una lista con departamentos, emulando los contenidos iniciales de una base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> ObtenerDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            departamentos.Add(new Departamento(1, "Ventas"));
            departamentos.Add(new Departamento(2, "Servicio al cliente"));
            departamentos.Add(new Departamento(3, "Informática"));
            return departamentos;
        }
    }
}
