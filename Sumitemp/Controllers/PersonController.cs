using DataTransferObjects;
using Logic.PersonLogic;
using Microsoft.AspNetCore.Mvc;

namespace Sumitemp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonLogic _personLogic;

        public PersonController(IPersonLogic personLogic)
        {
            this._personLogic = personLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo registro.
        /// </summary>
        /// <param name="personDto">Informacion de la persona.</param>
        /// <returns>Nuevo registro agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] PersonDto personDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                       
            var result = await _personLogic.AddPersonAsync(personDto);

           
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }
    }
}
