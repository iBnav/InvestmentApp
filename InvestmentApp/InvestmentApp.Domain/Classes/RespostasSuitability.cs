using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Classes
{
    public class RespostasSuitability
    {
        public int IdResposta { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
        public int IdPergunta { get; set; }
    }
}
