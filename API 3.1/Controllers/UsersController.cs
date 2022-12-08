using Domain.Entidades;
using Domain.interfaces.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API_3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService service)
        {
            _userService = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid) // Se ele ñ for valido
            {
                return BadRequest(ModelState); // retorna um 400 BadRequest - solicitação inválida
            }

            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
