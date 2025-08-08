using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;
using System;
using System.Collections.Generic;

public static class DadosConexao {

	private static string _linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=santos";

	public static string GetConexao()
	{
		return _linhaConexao;
	}
}


public class Banco
{
	MySqlConnection conexao = null;

    private string _linhaConexao;

	public string LinhaConexao
	{
		get {
			if (_linhaConexao == null)
			{
				throw new Exception("Linha de conexão não foi definida");
			}
			return _linhaConexao; 
		}
		set {
			if (String.IsNullOrEmpty(value))
			{
				throw new Exception("Linha de conexão inválida");
			}
			_linhaConexao = value; 
		}
	}

	public Banco()
	{ 
		LinhaConexao = DadosConexao.GetConexao();
	}

	private void Conectar()
	{
		try
		{
			conexao = new MySqlConnection(LinhaConexao);
			conexao.Open();
		}
		catch
		{
			throw new Exception("Não foi possível conectar ao Servidor.");
		}
	}

	public void Desconectar()
	{
		try
		{
			if (conexao != null)
			{ 
				if (conexao.State == System.Data.ConnectionState.Open)
				{
					conexao.Close();
				}
			}
		}
		catch
		{
			throw new Exception("Não foi possível fechar a conexão com o Servidor");
		}
	}

	public void Executar(string nomeSP)
    {
        Conectar();
		try
		{
			MySqlCommand cSQL = new MySqlCommand(nomeSP, conexao);
			cSQL.CommandType = System.Data.CommandType.StoredProcedure;
			cSQL.ExecuteNonQuery();
		}
		catch
		{
			throw new Exception("Não foi possível executar o comando. Verifique e tente novamente.");
		}
		finally
		{ 
			Desconectar();
		}
    }

    public void Executar(string nomeSP, List<MySqlParameter> parametros)
    {
        Conectar();
		try
		{
			MySqlCommand cSQL = new MySqlCommand(nomeSP, conexao);
			cSQL.CommandType = System.Data.CommandType.StoredProcedure;
			cSQL.Parameters.Clear();
			if (parametros != null)
			{
				foreach (MySqlParameter item in parametros)
				{
					cSQL.Parameters.Add(item);
				}
			}
			cSQL.ExecuteNonQuery();
		}
		catch
		{
			throw new Exception("Não foi possível executar o comando. Verifique e tente novamente.");
		}
		finally
		{ 
			Desconectar();
		}
    }

    public MySqlDataReader Consultar(string nomeSP)
    {
        Conectar();
        try
        {
            MySqlCommand cSQL = new MySqlCommand(nomeSP, conexao);
			cSQL.CommandType = System.Data.CommandType.StoredProcedure;
            return cSQL.ExecuteReader();
        }
        catch
        {
            throw new Exception("Não foi possível realizar a consulta");
        }
    }

	public MySqlDataReader Consultar(string nomeSP, List<MySqlParameter> parametros)
    {
        Conectar();
        try
        {
            MySqlCommand cSQL = new MySqlCommand(nomeSP, conexao);
			cSQL.CommandType = System.Data.CommandType.StoredProcedure;
			cSQL.Parameters.Clear();
			if (parametros != null)
			{
				foreach (MySqlParameter item in parametros)
				{
					cSQL.Parameters.Add(item);
				}
			}
            return cSQL.ExecuteReader();
        }
        catch
        {
            throw new Exception("Não foi possível realizar a consulta");
        }
    }
}