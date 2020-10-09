using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Classes
{
    public class AcoesUsuario
    {
        public int AcaoID { get; set; }
        public int UsuarioID { get; set; }
        public int? Nota { get; set; }
        public string Papel { get; set; }
        public double ValorPago { get; set; }
    }
}
