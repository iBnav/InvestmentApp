using InvestmentApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace InvestmentApp.Repository.Repositorios
{
    public class PerguntasSuitabilityRepository
    {
        public List<PerguntasSuitability> RetornarPerguntas()
        {
            List<PerguntasSuitability> perguntas = new List<PerguntasSuitability>();
            SqlCommand query = new SqlCommand("SELECT * FROM tb_Perguntas_Suitability", DbConfig.DataBaseSettings.sqlConnection);
            try
            {
                DbConfig.DataBaseSettings.sqlConnection.Open();
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    PerguntasSuitability pergunta = new PerguntasSuitability
                    {
                        IdPergunta = Convert.ToInt32(dr["ID_pergunta"]),
                        Descricao = dr["Descricao_pergunta"].ToString()
                    };

                    perguntas.Add(pergunta);
                }

                DbConfig.DataBaseSettings.sqlConnection.Close();
                return perguntas;
            }
            catch (Exception ex)
            {
                DbConfig.DataBaseSettings.sqlConnection.Close();
                throw ex;
            }
        }
    }
}
