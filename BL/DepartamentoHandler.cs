using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DepartamentoHandler
    {
        /// <summary>
        /// Devuelve el listado de departamentos de la DAL
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> GetDepartamentos() {
            return DAL.Listados.ObtenerDepartamentos();
        }

        /// <summary>
        /// Devuelve un departamento del listado, si existe
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Departamento GetDepartamento(int id) { 
            return DAL.DepartamentoHandler.GetDepartamento(id);
        }

        /// <summary>
        /// Agrega un departamento al listado
        /// PRE: ni el departamento ni sus campos deben ser nulos
        /// </summary>
        /// <param name="departamento"></param>
        public static void AgregarDepartamento(Departamento departamento) {
            DAL.DepartamentoHandler.AgregarDepartamento(departamento);
        }
    }
}
