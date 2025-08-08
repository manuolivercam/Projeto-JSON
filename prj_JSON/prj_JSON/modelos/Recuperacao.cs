using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;


public class Recuperacao
{
    public string Codigo { get; set; }

    public string Login { get; set; }

    public Recuperacao() { }

    public Recuperacao(string codigo, string login)
    {
        this.Codigo = codigo;
        this.Login = login;
    }
}
