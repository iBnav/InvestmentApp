using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Repository.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcoesController : ControllerBase
    {
        private readonly IAcoesUsuarioService acoesUsuarioService;
        public AcoesController(IAcoesUsuarioService _acoesUsuarioService)
        {
            acoesUsuarioService = _acoesUsuarioService;
        }

        [HttpGet("retornarAcoes/{idUsuario}")]
        public IActionResult RetornarAcoesUsuario(int idUsuario)
        {
            try
            {
                return Ok(acoesUsuarioService.RetornarAcoes(idUsuario).OrderByDescending(x=>x.Nota));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("salvar")]
        public IActionResult SalvarAcao(AcoesUsuario acao)
        {
            try
            {
                acoesUsuarioService.SalvarAcao(acao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}