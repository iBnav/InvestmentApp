using InvestmentApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Interfaces
{
    public interface IAcoesUsuarioService
    {
        List<AcoesUsuario> RetornarAcoes(int usuarioID);
        void SalvarAcao(AcoesUsuario acao);
        void ApagarAcao(int idAcao);
    }
}
