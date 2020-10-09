using InvestmentApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace InvestmentApp.Repository.Repositorios
{
    public class RespostasSuitabilityRepository
    {
        public List<RespostasSuitability> RetornarRespostas()
        {
            List<RespostasSuitability> respostas = new List<RespostasSuitability>();
            SqlCommand query = new SqlCommand("SELECT resp.*, pr.ID_Pergunta FROM tb_Respostas_Suitability resp, tb_Pergunta_Respostas pr WHERE resp.ID_resposta = pr.ID_resposta", DbConfig.DataBaseSettings.sqlConnection);
            try
            {
                DbConfig.DataBaseSettings.sqlConnection.Open();
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    RespostasSuitability resposta = new RespostasSuitability
                    {
                        IdResposta = Convert.ToInt32(dr["ID_resposta"]),
                        IdPergunta = Convert.ToInt32(dr["ID_pergunta"]),
                        Descricao = dr["Descricao_resposta"].ToString(),
                        Pontuacao = Convert.ToInt32(dr["Pontuacao_resposta"])
                    };
                    respostas.Add(resposta);
                }

                DbConfig.DataBaseSettings.sqlConnection.Close();
                return respostas;
            }
            catch (Exception ex)
            {
                DbConfig.DataBaseSettings.sqlConnection.Close();
                throw ex;
            }
        }
    }
}
