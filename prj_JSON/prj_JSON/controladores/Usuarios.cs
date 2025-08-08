using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Usuarios : Banco 
{
    public List<Usuario> Listar()
    {
        List<Usuario> lista = new List<Usuario>();
        try
        {
            MySqlDataReader dados = Consultar("listarUsuarios");
            while (dados.Read())
            {
                Usuario usuario = new Usuario(dados.GetString("nm_login"), dados.GetString("nm_usuario"));
                lista.Add(usuario);
            }
            if (dados != null)
                if (dados.IsClosed)
                {
                    dados.Close();
                }
        }
        catch(System.Exception)
        {
            throw new System.Exception("Não foi possível listar os usuários");
        }
        finally
        {
            Desconectar();
        }
        return lista;
       
    }
    public Usuario Acessar(string login, string senha)
    {
        Usuario usuario = null;
        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pLogin", login));
            parametros.Add(new MySqlParameter("pSenha", senha));
            MySqlDataReader dados = Consultar("acessar", parametros);

            if (dados.Read())
            {
                usuario = new Usuario(login, dados.GetString("nm_usuario"));
            }
            if(dados != null)
                if(!dados.IsClosed)
                {
                    dados.Close();
                }
        }
        catch (Exception)
        {

            throw new Exception("Login e/ou Senha inválidos");  
        }
        finally
        {
            Desconectar();
        }

        return usuario;
    }
    public Usuario VerificarLogin(string login)
    {
        Usuario usuario = null;
        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pLogin", login));

            MySqlDataReader dados = Consultar("verificarLogin", parametros);

            if (dados.Read())
            {
                usuario = new Usuario(login, dados.GetString("nm_usuario"));
            }
            if (dados != null)
                if (!dados.IsClosed)
                {
                    dados.Close();
                }
        }
        catch (Exception)
        {

            throw new Exception("E-mail não encontrado! Tente novamente");
        }
        finally
        {
            Desconectar();
        }

        return usuario;
    }
    public void AlterarSenha(string novaSenha, string login)
    {
       
        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pSenha", novaSenha));
            parametros.Add(new MySqlParameter("pLogin", login));

            Executar("alterarSenha", parametros);
        }
        catch (Exception)
        {

            throw new Exception("Não foi possível alterar a senha! Tente novamente");
        }

    }
    public string BuscarNome(string login)
    {
        string nome = "";

        List<MySqlParameter> parametros = new List<MySqlParameter>();
        parametros.Add(new MySqlParameter("pLogin", login));
        try
        {
            MySqlDataReader dados = Consultar("buscarNomeUsuario", parametros);
            if (dados.Read())
            {
                nome = dados.GetString(0);
            }
            if (dados != null)
                if (!dados.IsClosed)
                    dados.Close();
        }
        catch
        {
            throw new Exception("Não foi possível acessar o servidor. Tente novamente.");
        }
        finally
        {
            Desconectar();
        }

        return nome;
    }
}
