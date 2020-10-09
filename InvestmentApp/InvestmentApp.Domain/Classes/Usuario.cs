using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Classes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Perfil { get; set; }
        public bool FlagPrimeiroLogin { get; set; }

    }
}
