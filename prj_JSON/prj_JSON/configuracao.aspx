<%@ Page Title="" Language="C#" MasterPageFile="~/Geral.Master" AutoEventWireup="true" CodeBehind="configuracao.aspx.cs" Inherits="prj_JSON.configuracao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/estiloConfiguracao.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="titulo">Configurações da Conta</h1>
        <section class="formulario-perfil">
            <asp:Literal ID="litMensagem" runat="server"></asp:Literal>
            <%--<div class="mensagem msgErro">
                <span class="material-symbols-outlined icone-mensagem">warning</span> 
                <span id="mensagemTexto">Senhas não conferem!</span>
            </div>--%>
            
            <p>
                <label for="txtNome">Nome: </label>
                <asp:TextBox ID="txtNome" runat="server" disabled></asp:TextBox>
            </p>

            <p>
                <label for="txtSenhaAtual">Senha Atual: </label>
                <asp:TextBox TextMode="Password" ID="txtSenhaAtual" runat="server"></asp:TextBox>
            </p>

            <p>
                <label for="txtNovaSenha">Nova Senha: </label>
                <asp:TextBox TextMode="Password" ID="txtNovaSenha" runat="server"></asp:TextBox>
            </p>

            <p>
                <label for="txtConfirmacaoSenha">Confirmação Senha: </label>
                <asp:TextBox TextMode="Password" ID="txtConfSenha" runat="server"></asp:TextBox>
            </p>

            <p class="areaBotoesConfiguracao">
                <asp:Button ID="btnSalvar" CssClass="botaoPadrao" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                <a href="principal.aspx" class="botaoPadrao">Cancelar</a>
            </p>
        </section>
</asp:Content>
