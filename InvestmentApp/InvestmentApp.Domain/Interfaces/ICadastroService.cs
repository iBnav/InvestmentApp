using System;
using System.Collections.Generic;
using System.Text;
using InvestmentApp.Domain.Classes;

namespace InvestmentApp.Domain.Interfaces
{
    public interface ICadastroService
    {
        Usuario CadastrarUsuario(Usuario usuario);
    }
}
