using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Classes.ReceiverAPI;
using InvestmentApp.Repository.DbConfig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace InvestmentApp.Repository.Repositorios
{
    public class UsuarioRepository
    {
        public Usuario CadastrarUsuario(Usuario usuario)
        {
            SqlCommand query = new SqlCommand($"INSERT INTO tb_Usuario(Nome_usuario,Email_usuario,Password_usuario) VALUES ('{usuario.Nome.ToUpper()}','{usuario.Email.ToLower()}','{usuario.Password}'); SELECT SCOPE_IDENTITY()", DataBaseSettings.sqlConnection);
            try
            {
                DataBaseSettings.sqlConnection.Open();
                usuario.Id = Convert.ToInt32(query.ExecuteScalar());
                DataBaseSettings.sqlConnection.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                DataBaseSettings.sqlConnection.Close();
                throw ex;
            }
            
        }

        public Usuario RetornarUsuarioPorEmail(string email, bool isCadastro)
        {
            SqlCommand query = new SqlCommand($"SELECT * FROM tb_Usuario WHERE Email_usuario = '{email}'", DataBaseSettings.sqlConnection);
            try
            {
                DataBaseSettings.sqlConnection.Open();
                SqlDataReader dr = query.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(dr["ID_usuario"]),
                        Email = dr["Email_usuario"].ToString(),
                        Nome = dr["Nome_usuario"].ToString(),
                        Password = dr["Password_usuario"].ToString(),
                        FlagPrimeiroLogin = Convert.ToBoolean(dr["flag_Primeiro_Login"]),
                        Perfil = string.IsNullOrEmpty(dr["Perfil_usuario"].ToString()) ? 0 : Convert.ToInt32(dr["Perfil_usuario"].ToString())
                    };
                    DataBaseSettings.sqlConnection.Close();
                    return usuario;
                } else
                {
                    if (isCadastro)
                    {
                        DataBaseSettings.sqlConnection.Close();
                        return null;
                    } else
                    {
                        DataBaseSettings.sqlConnection.Close();
                        throw new Exception("Email não cadastrado");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                DataBaseSettings.sqlConnection.Close();
                throw ex;
            }

        }

        public void AtualizarPerfil(Usuario user)
        {
            SqlCommand query = new SqlCommand($"UPDATE tb_Usuario SET Perfil_usuario = '{user.Perfil}', flag_Primeiro_Login = 0 WHERE ID_usuario = {user.Id}", DataBaseSettings.sqlConnection);
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
