using InvestmentApp.Domain.Classes;
using InvestmentApp.Repository.DbConfig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace InvestmentApp.Repository.Repositorios
{
    public class AcoesUsuarioRepository
    {
        public List<AcoesUsuario> RetornarAcoesUsuario(int usuarioID)
        {
            List<AcoesUsuario> listaAcoes = new List<AcoesUsuario>();
            SqlCommand query = new SqlCommand("SELECT * FROM tb_Acoes_usuario WHERE ID_usuario = " + usuarioID, DataBaseSettings.sqlConnection);
            try
            {
                DataBaseSettings.sqlConnection.Open();
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    AcoesUsuario acao = new AcoesUsuario
                    {
                        AcaoID = Convert.ToInt32(dr["ID_acao"]),
                        UsuarioID = usuarioID,
                        Nota = string.IsNullOrEmpty(dr["Nota"].ToString()) ? -1 : Convert.ToInt32(dr["Nota"]),
                        Papel = dr["Papel"].ToString(),
                        ValorPago = Convert.ToDouble(dr["Valor_pago"])
                    };
                    listaAcoes.Add(acao);
                }

                DataBaseSettings.sqlConnection.Close();
                return listaAcoes;
            }
            catch (Exception ex)
            {
                DataBaseSettings.sqlConnection.Close();
                throw ex;
            }
        }

        public void SalvarAcao(AcoesUsuario acao)
        {
            if(acao.AcaoID == 0)
            {
                SqlCommand query;
                if (acao.Nota == null)
                {
                     query = new SqlCommand($"INSERT INTO tb_Acoes_usuario(ID_usuario, Papel, Valor_pago) values ({acao.UsuarioID}, '{acao.Papel.ToUpper()}', {acao.ValorPago.ToString().Replace(',','.')} );", DataBaseSettings.sqlConnection);
                } else
                {
                    query = new SqlCommand($"INSERT INTO tb_Acoes_usuario(ID_usuario, Papel, Nota, Valor_pago) values ({acao.UsuarioID}, '{acao.Papel.ToUpper()}', {acao.Nota}, {acao.ValorPago.ToString().Replace(',', '.')} );", DataBaseSettings.sqlConnection);
                }
                

                try
                {
                    DataBaseSettings.sqlConnection.Open();
                    query.ExecuteNonQuery();
                    DataBaseSettings.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    DataBaseSettings.sqlConnection.Close();
                    throw ex;
                }
            } else
            {
                SqlCommand query = new SqlCommand($"UPDATE tb_Acoes_usuario SET Nota = {acao.Nota} WHERE ID_acao = {acao.AcaoID}", DataBaseSettings.sqlConnection);

                try
                {
                    DataBaseSettings.sqlConnection.Open();
                    query.ExecuteNonQuery();
                    DataBaseSettings.sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    DataBaseSettings.sqlConnection.Close();
                    throw ex;
                }
            }
        }

        public void ApagarAcao(int idAcao)
        {
            SqlCommand query = new SqlCommand($"DELETE FROM tb_Acoes_usuario WHERE ID_acao = " + idAcao, DataBaseSettings.sqlConnection);

            try
            {
                DataBaseSettings.sqlConnection.Open();
                query.ExecuteNonQuery();
                DataBaseSettings.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                DataBaseSettings.sqlConnection.Close();
                throw ex;
            }
        }
    }
}
