using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Usuario
{
    public string Login { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }

    public Usuario() { }

    public Usuario (string login, string nome)
    {
        this.Login = login;
        this.Nome = nome;
    }
    public Usuario(string login, string nome, string senha)
    {
        this.Login = login;
        this.Nome = nome;
        this.Senha = senha;
    }
}
