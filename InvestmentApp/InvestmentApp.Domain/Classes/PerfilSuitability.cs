using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Classes
{
    public class PerfilSuitability
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public enum PerfilInvestidor
        {
            Conservador = 1,
            Moderado = 2,
            Agresivo = 3
        }
    }
}
