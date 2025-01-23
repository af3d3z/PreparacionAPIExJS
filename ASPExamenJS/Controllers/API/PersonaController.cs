using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPExamenJS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<PersonaController>
        /// <summary>
        /// Devuelve la lista de personas en formato json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Persona> Get()
        {
            return BL.PersonaHandlerBL.GetPersonas();
        }

        // GET api/<PersonaController>/5
        /// <summary>
        /// Devuelve una persona en concreto en formato json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            Persona persona;

            try
            {
                persona = BL.PersonaHandlerBL.GetPersona(id);
                if (persona == null)
                {
                    salida = Ok("La persona no existe.");
                }
                else {
                    salida = StatusCode(200, persona);
                }
            }
            catch (Exception e) {
                salida = StatusCode(500, "Ha ocurrido un error: " + e.Message);
            }

            return salida;
        }

        // POST api/<PersonaController>
        /// <summary>
        /// Añade una persona al listado en base a un objeto serializado en json
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            IActionResult salida;
            if (persona != null)
            {
                try
                {
                    bool agregado = BL.PersonaHandlerBL.AgregarPersona(persona);
                    if (agregado)
                    {
                        salida = Ok("Se ha guardado correctamente.");
                    }
                    else
                    {
                        salida = Ok("No se ha podido guardar.");
                    }
                }
                catch (Exception e)
                {
                    salida = StatusCode(500, "Ha ocurrido un error: " + e.Message);
                }
            }
            else {
                salida = BadRequest("Petición inválida o la persona ya existe");
            }

            return salida;
        }

        // PUT api/<PersonaController>/5
        /// <summary>
        /// Edita una persona del listado a partir de un objeto serializado json
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Persona persona)
        {
            IActionResult salida;
            if (persona != null)
            {
                try
                {
                    bool editado = BL.PersonaHandlerBL.EditarPersona(persona);
                    if (editado)
                    {
                        salida = Ok("Se ha editado correctamente");
                    }
                    else
                    {
                        salida = Ok("No se ha podido editar correctamente");
                    }
                }
                catch (Exception e)
                {
                    salida = StatusCode(500, "Ha ocurrido un error: " + e.Message);
                }
            }
            else {  salida = BadRequest(); }

            return salida;
        }

        // DELETE api/<PersonaController>/5
        /// <summary>
        /// Borra una persona del listado a partir de su id
        /// PRE: El id debe ser mayor a 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            if (id > 0)
            {
                try
                {
                    bool borrado = BL.PersonaHandlerBL.DeletePersona(id);
                    if (borrado)
                    {
                        salida = Ok("La persona se ha borrado correctamente.");
                    }
                    else {
                        salida = Ok("No se ha podido borrar la persona.");
                    }
                }
                catch (Exception e) {
                    salida = StatusCode(500, "Ha ocurrido un error: " + e.Message);
                }
            }
            else {
                salida = BadRequest();
            }

            return salida;
        }
    }
}
