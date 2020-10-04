using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICriptografiaService criptografiaService;
        public AuthService(ICriptografiaService _criptografiaService)
        {
            criptografiaService = _criptografiaService;
        }

        public Usuario AutenticarUsuario(Usuario usuario)
        {
            string password = string.Empty;
            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("Email não pode ser em branco");
            

            if (string.IsNullOrEmpty(usuario.Password))
                throw new Exception("Senha não pode ser em branco");
             else
                password = criptografiaService.RetornarMD5(usuario.Password);


            UsuarioRepository usuarioRepository = new UsuarioRepository();
            try
            {
                usuario = usuarioRepository.RetornarUsuarioPorEmail(usuario.Email, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (usuario.Password == password) 
            { 
                usuario.Password = null;
                return usuario;
            }
            else
                throw new Exception("Senha inválida");

        }
    }
}
