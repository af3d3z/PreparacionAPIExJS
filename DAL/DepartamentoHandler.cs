using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartamentoHandler
    {
        /// <summary>
        /// Devuelve un departamento del listado en base a su id
        /// PRE: el id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Departamento GetDepartamento(int id) {
            return Listados.ListadoDepartamentos.Where(p => p.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Agrega un departamento a la lista de departamentos
        /// PRE: Departamento no deberá de ser ni contener nulos.
        /// </summary>
        /// <param name="departamento"></param>
        public static void AgregarDepartamento(Departamento departamento) {
            List<Departamento> departamentos = Listados.ListadoDepartamentos;
            departamentos.Add(departamento);
            Listados.ListadoDepartamentos = departamentos;
        }
    }
}
