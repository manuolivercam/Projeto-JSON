using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_JSON.lib
{
    public partial class acessar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            string resposta = "";

            if (Request["l"] == null)
            {
                resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }
            if (String.IsNullOrEmpty(Request["l"].ToString()))
            {
                resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }

            if (Request["s"] == null)
            {
                resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }
            if (String.IsNullOrEmpty(Request["s"].ToString()))
            {
                resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }

            string supostoLogin = Request["l"].ToString();
            string supostoSenha = Request["s"].ToString();

            try
            {
                Usuarios usuarios = new Usuarios();
                Usuario usuario = usuarios.Acessar(supostoLogin, supostoSenha);
                if (usuario != null)
                {
                    Session["logado"] = usuario.Login;
                    Session["nome"] = usuario.Nome;

                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    resposta = javaScriptSerializer.Serialize(usuario);
                    Response.Write(resposta);
                }
                else
                {
                    resposta = "{'situacao':'false'}";
                    Response.Write(resposta.Replace("'", "\""));
                }
                

            }
            catch (Exception)
            {

                resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
            }

        }
    }
}