using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost("AutenticarUsuario")]
        public IActionResult AutenticarUsuario(Usuario usuario)
        {
            try
            {
                return Ok(authService.AutenticarUsuario(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}