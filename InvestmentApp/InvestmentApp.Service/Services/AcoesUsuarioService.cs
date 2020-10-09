using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Service.Services
{
    public class AcoesUsuarioService : IAcoesUsuarioService
    {
        public List<AcoesUsuario> RetornarAcoes(int usuarioID)
        {
            AcoesUsuarioRepository aur = new AcoesUsuarioRepository();
            try
            {
                return aur.RetornarAcoesUsuario(usuarioID); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void SalvarAcao(AcoesUsuario acao)
        {
            AcoesUsuarioRepository aur = new AcoesUsuarioRepository();
            try
            {
                aur.SalvarAcao(acao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ApagarAcao(int idAcao)
        {
            AcoesUsuarioRepository aur = new AcoesUsuarioRepository();
            try
            {
                aur.ApagarAcao(idAcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
