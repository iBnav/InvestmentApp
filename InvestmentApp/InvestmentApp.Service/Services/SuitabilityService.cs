using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Classes.ReceiverAPI;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Service.Services
{
    public class SuitabilityService : ISuitabilityService
    {
        public List<PerguntasSuitability> RetornarPerguntas()
        {
            PerguntasSuitabilityRepository perguntasRepository = new PerguntasSuitabilityRepository();
            try
            {
                return perguntasRepository.RetornarPerguntas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<RespostasSuitability> RetornarRespostas()
        {
            try
            {
                RespostasSuitabilityRepository respostasRepository = new RespostasSuitabilityRepository();
                return respostasRepository.RetornarRespostas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void SalvarPerfilUsuario(UserPontuacao user)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            Usuario usuario = new Usuario();
            usuario.Id = user.UserID;
            usuario.Perfil = CalcularPerfil(user.Pontuacao);
            
            try
            {
                usuarioRepository.AtualizarPerfil(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CalcularPerfil(int pontuacao)
        {
            if (pontuacao > 0 && pontuacao <= 10)
                return 1;
            else if (pontuacao > 10 && pontuacao <= 25)
                return 2;
            else 
                return 3;
        }
    }
}
