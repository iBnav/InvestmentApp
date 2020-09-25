using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;

namespace InvestmentApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService cadastroService;
        public CadastroController(ICadastroService _cadastroService)
        {
            cadastroService = _cadastroService;
        }

        [HttpPost("Usuario")]
        public IActionResult CadastrarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                return Ok(new { Message = "Usuario cadastrado com sucesso!", ID = cadastroService.CadastrarUsuario(usuario).Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}