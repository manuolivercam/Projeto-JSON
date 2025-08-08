<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criarNovaS.aspx.cs" Inherits="prj_JSON.criarNovaS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="icon" type="image/png" href="images/favicon.png"/>
    <title>Prefeitura de Santos</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0" /> 
    <link rel="stylesheet" href="css/estilo.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <main id="formEntrar">
        <asp:Literal ID="litMensagem" runat="server"></asp:Literal>
        <p class="tituloEntrada">
            <img src="images/logoBranco.png"/>
        </p>
        <p class="caixasSenha">
            <label for="txtNovaSenha">Nova senha:</label>
            <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password" placeholder="Digite a nova senha"></asp:TextBox>
        </p>
        <p class="caixasSenha">
            <label for="txtConfirmaNovaS">Confirme a nova senha:</label>
            <asp:TextBox ID="txtConfirmaNovaS" runat="server" TextMode="Password" placeholder="Confirme a nova senha" ></asp:TextBox>
        </p>
        <p id="botao">
              <asp:Button ID="btnSalvar" runat="server" Text="Salvar"  OnClick="btnSalvar_Click" CssClass="btnSalvar"/>           
        </p>      
    </main>
    </form>
</body>
</html>
