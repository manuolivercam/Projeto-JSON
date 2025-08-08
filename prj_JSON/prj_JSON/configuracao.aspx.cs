using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_JSON
{
    public partial class configuracao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (String.IsNullOrEmpty(Session["logado"].ToString()))
            {
                Response.Redirect("index.aspx");
            }

            string login = Session["logado"].ToString();
            txtNome.Text = Session["nome"].ToString(); 
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Validações
            if (String.IsNullOrEmpty(txtSenhaAtual.Text))
            {
                litMensagem.Text = $@"<div class='mensagem msgErro'>
                                                <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                                <span id='mensagemTexto'>Senha Atual deve ser informada!</span>
                                            </div>";
                return;
            }

            if (String.IsNullOrEmpty(txtNovaSenha.Text))
            {
                litMensagem.Text = $@"<div class='mensagem msgErro'>
                                                <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                                <span id='mensagemTexto'>Nova Senha deve ser informada!</span>
                                            </div>";
                return;
            }

            if (String.IsNullOrEmpty(txtConfSenha.Text))
            {
                litMensagem.Text = $@"<div class='mensagem msgErro'>
                                                <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                                <span id='mensagemTexto'>Confirmação de Senha deve ser informada!</span>
                                            </div>";
                return;
            }
            #endregion

            try
            {
                Usuarios usuarios = new Usuarios();
                Usuario usuario = usuarios.Acessar(Session["logado"].ToString(), txtSenhaAtual.Text);
                if (usuario == null)
                {
                    litMensagem.Text = $@"<div class='mensagem msgErro'>
                                                <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                                <span id='mensagemTexto'>Senha inválida!</span>
                                            </div>";
                    return;
                }

                if (txtNovaSenha.Text != txtConfSenha.Text)
                {
                    litMensagem.Text = $@"<div class='mensagem msgErro'>
                                            <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                            <span id='mensagemTexto'>Senhas não conferem!</span>
                                        </div>";
                    return;
                }

                usuarios.AlterarSenha(txtNovaSenha.Text,Session["logado"].ToString());
                litMensagem.Text = $@"<div class='mensagem msgSucesso'>
                                        <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                        <span id='mensagemTexto'>Senhas alterada com Sucesso!</span>
                                    </div>";
            }
            catch (Exception erro)
            {
                litMensagem.Text = $@"<div class='mensagem msgErro'>
                                                <span class='material-symbols-outlined icone-mensagem'>warning</span> 
                                                <span id='mensagemTexto'>{erro.Message}</span>
                                            </div>";
            }
        }
    }
}