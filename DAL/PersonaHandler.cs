using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonaHandler
    {
        /// <summary>
        /// Busca una persona en base a su id dentro del listado
        /// PRE: el id suministrado debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Persona GetPersona(int id) {
            return Listados.ListadoPersonas.Where(p => p.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Agrega una persona a la lista de personas
        /// PRE: Que la persona esté rellena y que no sea o contenga nulos
        /// </summary>
        /// <param name="persona"></param>
        public static bool AgregarPersona(Persona persona) {
            bool agregado = false;
            List<Persona> personas = Listados.ListadoPersonas;
            personas.Add(persona);
            Listados.ListadoPersonas = personas;
            if (Listados.ListadoPersonas.Contains(persona)) {
                agregado = true;
            }
            return agregado;
        }

        /// <summary>
        /// Edita una persona del listado
        /// PRE: La persona no deberá ser o contener nulos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool EditarPersona(Persona persona) {
            List<Persona> personas = Listados.ListadoPersonas;
            bool encontrado = false;
            int index = personas.FindIndex(per => per.id == persona.id);
            if (index != -1) {
                personas[index] = persona;
                encontrado = true;
                Listados.ListadoPersonas = personas;
            }

            return encontrado;
        }

        /// <summary>
        /// Elimina una persona del listado
        /// PRE: Debe tener al menos el id
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool DeletePersona(int id) {
            Persona personaBusqueda = Listados.ListadoPersonas.Where(p => p.id == id).FirstOrDefault();
            return Listados.ListadoPersonas.Remove(personaBusqueda);
        }
    }
}
