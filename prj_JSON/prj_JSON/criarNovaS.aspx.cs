using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_JSON
{
    public partial class criarNovaS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string codigo = Request.QueryString["c"];
                Session["loginRecuperacao"] = Request.QueryString["l"];

                litMensagem.Text = $@"  <div class='mensagem msgErro escondido'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>A nova senha precisa ser digitada!</span>
                </div>";


                if (String.IsNullOrEmpty(codigo) && String.IsNullOrEmpty(Session["loginRecuperacao"].ToString()))
                {
                    Response.Redirect("esqueceuSenha.html");
                }
                Recuperacoes recuperacoes = new Recuperacoes();

                if (!recuperacoes.Verificar(codigo, Session["loginRecuperacao"].ToString()))
                {
                    Response.Redirect("esqueceuSenha.html");
                }
            }
            catch
            {
                litMensagem.Text = $@"  <div class='mensagem msgErro'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>Algo deu errado. Tente novamente!</span>
                </div>";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validações

                if (String.IsNullOrEmpty(txtNovaSenha.Text))
                {
                    litMensagem.Text = $@"  <div class='mensagem msgErro'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>A nova senha precisa ser digitada!</span>
                </div>";
                    txtNovaSenha.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtConfirmaNovaS.Text))
                {
                    litMensagem.Text = $@"  <div class='mensagem msgErro'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>A confirmação da nova senha precisa ser digitada!</span>
                </div>";
                    txtConfirmaNovaS.Focus();
                    return;
                }
                if (txtConfirmaNovaS.Text != txtNovaSenha.Text)
                {
                    litMensagem.Text = $@"  <div class='mensagem msgErro'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>As senhas não conferem. Tente novamente!</span>
                </div>";
                    txtConfirmaNovaS.Text = "";
                    txtNovaSenha.Text = "";
                    txtNovaSenha.Focus();
                    return;
                }


                #endregion

                string novaSenha = txtNovaSenha.Text;

                if (String.IsNullOrEmpty(Session["loginRecuperacao"].ToString()))
                {
                    Response.Redirect("esqueciSenha.html");
                }

                Usuarios usuarios = new Usuarios();
                usuarios.AlterarSenha(novaSenha, Session["loginRecuperacao"].ToString());

                Recuperacoes recuperacoes = new Recuperacoes();
                recuperacoes.Apagar(Session["loginRecuperacao"].ToString());

                Response.Redirect("index.html");
            }
            catch
            {
                litMensagem.Text = $@"  <div class='mensagem msgErro'>
                <span class='material-symbols-outlined icone-mensagem'>warning</span>
                <span id='mensagemTexto'>Algo deu errado. Tente novamente!</span>
                </div>";
            }
        }
    }
}