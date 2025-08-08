using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace prj_JSON.lib
{
    public partial class recuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = gerarCodigoAleatorio(10);

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

            string supostoLogin = Request["l"].ToString();

            try
            {
                Usuarios usuarios = new Usuarios();
                Usuario usuario = usuarios.VerificarLogin(supostoLogin);

                if (usuario != null)
                {
                    Recuperacoes recuperacoes = new Recuperacoes();
                    Recuperacao recuperacao = recuperacoes.Gravar(codigo,usuario.Login);


                    string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                    string link = $@"{baseUrl}/criarNovaS.aspx?c={recuperacao.Codigo}&l={recuperacao.Login}";

                    #region Configuração do Servidor de Email
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.office365.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("manuolivercam@hotmail.com", "manuzinha123");
                    #endregion

                    #region Criação da Mensagem de email
                    MailMessage theEmail = new MailMessage();

                    theEmail.To.Add(supostoLogin);

                    theEmail.From = new MailAddress("manuolivercam@hotmail.com", "Prefeitura de Santos", System.Text.Encoding.UTF8);

                    theEmail.Subject = "Recuperação da senha";
                    theEmail.SubjectEncoding = System.Text.Encoding.UTF8;

                    theEmail.Body = $@"<img src='https://www.santos.sp.gov.br/static/files_www/files/portal_files/hotsites/manual/logopmsfundobrancosvg2x.png' style='width:400px'>
                        <p>Olá, {usuario.Nome}</p>
                        <p>Recebemos uma solicitação para restaurar sua senha de acesso em nosso site.</p>
                        <p>Se você reconhece essa ação, clique no link abaixo para prosseguir:</p>
                        <a href='{link}'>Recuperar senha</a>";

                    theEmail.BodyEncoding = System.Text.Encoding.UTF8;

                    theEmail.Priority = MailPriority.High;

                    theEmail.IsBodyHtml = true;
                    #endregion

                    #region Envio do Email
                    try
                    {
                        client.Send(theEmail);
                    }
                    catch 
                    {
                        resposta = "{'situacao':'false'}";
                        Response.Write(resposta.Replace("'", "\""));
                    }
                    #endregion

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
        public static string gerarCodigoAleatorio(int tamanho)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder codigo = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < tamanho; i++)
            {
                int index = random.Next(0, caracteresPermitidos.Length);
                codigo.Append(caracteresPermitidos[index]);
            }

            return codigo.ToString();
        }
    }
}