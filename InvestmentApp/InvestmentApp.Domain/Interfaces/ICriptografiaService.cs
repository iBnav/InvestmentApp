using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentApp.Domain.Interfaces
{
    public interface ICriptografiaService
    {
        string RetornarMD5(string Senha);
        bool ComparaMD5(string senhabanco, string Senha_MD5);
    }
}
