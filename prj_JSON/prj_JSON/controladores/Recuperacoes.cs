using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Recuperacoes : Banco
{
    public Recuperacao Gravar(string codigo, string login)
    {
        Recuperacao recuperacao = new Recuperacao();
        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pCodigo", codigo));
            parametros.Add(new MySqlParameter("pLogin", login));

            Executar("gravarRecuperacao", parametros);

            recuperacao = new Recuperacao(codigo,login);

        }
        catch (Exception)
        {

            throw new Exception("E-mail não encontrado! Tente novamente");
        }
        finally
        {
            Desconectar();
        }
        return recuperacao;
    }
    public bool Verificar(string codigo, String login)
    {
        Recuperacao recuperacao = new Recuperacao();
        MySqlDataReader dados = null;
        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pCodigo", codigo));
            parametros.Add(new MySqlParameter("pLogin", login));
            
           dados = Consultar("verificarRecuperacao", parametros);

            if (dados.Read())
            {
                return true;
            }
        }
        catch (Exception)
        {

            throw new Exception("E-mail não encontrado! Tente novamente");
        }
        finally
        {
            if (dados != null)
                if (!dados.IsClosed)
                {
                    dados.Close();
                }
            Desconectar();
        }
        return false;
    }
    public void Apagar(string login)
    {

        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pLogin", login));

            Executar("apagarRecuperacao", parametros);
        }
        catch (Exception)
        {

            throw new Exception("Não foi possível alterar a senha! Tente novamente");
        }

    }
}
