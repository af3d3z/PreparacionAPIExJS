using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PersonaHandlerBL
    {
        /// <summary>
        /// Devuelve el listado de personas de la DAL
        /// </summary>
        /// <returns></returns>
        public static List<Persona> GetPersonas() {
            return DAL.Listados.ListadoPersonas;
        }

        /// <summary>
        /// Devuelve una persona del listado si existe
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Persona GetPersona(int id) { 
            return DAL.PersonaHandler.GetPersona(id);
        }

        public static bool AgregarPersona(Persona persona) {
            return DAL.PersonaHandler.AgregarPersona(persona);
        }

        /// <summary>
        /// Edita una persona en el listado
        /// PRE: ni la persona ni sus campos deben ser nulos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool EditarPersona(Persona persona) { 
            return DAL.PersonaHandler.EditarPersona(persona);
        }

        /// <summary>
        /// Borra a una persona del listado
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool DeletePersona(int id) { 
            return DAL.PersonaHandler.DeletePersona(id);
        }
    }
}
