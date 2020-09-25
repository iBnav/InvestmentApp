using InvestmentApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Interfaces
{
    public interface IAuthService
    {
        Usuario AutenticarUsuario(Usuario usuario);
    }
}
