using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Classes.ReceiverAPI;
using InvestmentApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuitabilityController : ControllerBase
    {
        private readonly ISuitabilityService suitabilityService;
        public SuitabilityController(ISuitabilityService _suitabilityService)
        {
            suitabilityService = _suitabilityService;
        }

        [HttpGet("retornarPerguntasRespostas")]
        public IActionResult RetornarPerguntasRespostas()
        {
            try
            {
                List<PerguntasSuitability> listPerguntas = suitabilityService.RetornarPerguntas();
                List<RespostasSuitability> listRespostas = suitabilityService.RetornarRespostas();
                return Ok(new {perguntas =  listPerguntas, respostas = listRespostas });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("salvarPontuacao")]
        public IActionResult SalvarPontuacao([FromBody] UserPontuacao usuario)
        {
            try
            {
                suitabilityService.SalvarPerfilUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
    }
}