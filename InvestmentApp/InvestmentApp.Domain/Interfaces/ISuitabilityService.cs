
using InvestmentApp.Domain.Classes;
using System.Collections.Generic;
using System.Net;

namespace InvestmentApp.Domain.Interfaces
{
    public interface ISuitabilityService
    {
        List<PerguntasSuitability> RetornarPerguntas();
        List<RespostasSuitability> RetornarRespostas();
        void SalvarPerfilUsuario(Classes.ReceiverAPI.UserPontuacao user);
    }
}
