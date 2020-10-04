using InvestmentApp.Domain.Classes;
using InvestmentApp.Domain.Interfaces;
using InvestmentApp.Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Service.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICriptografiaService criptografiaService;
        public CadastroService(ICriptografiaService _criptografiaService)
        {
            criptografiaService = _criptografiaService;
        }

        public Usuario CadastrarUsuario(Usuario usuario)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();

            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("Nome não pode ser em branco");
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("Email não pode ser em branco");
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                throw new Exception("Senha não pode ser em branco");
            }
            if (usuarioRepository.RetornarUsuarioPorEmail(usuario.Email, true)?.Email == usuario.Email)
            {
                throw new Exception("Email já cadastrado");
            }

            usuario.Password = criptografiaService.RetornarMD5(usuario.Password);

            try
            {
                return usuarioRepository.CadastrarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
