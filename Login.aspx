<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LestoCargo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row centralizar imagem-fundo">
            <div class="col-4 login">
                <div class="box-padding-30px">
                    <h2 style="text-align: center">Login</h2>
                    <asp:Label ID="Mensagem" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
                    <label>Login</label>
                    <asp:TextBox ID="NomeLogin" runat="server"></asp:TextBox>
                    <label>Senha</label>
                    <asp:TextBox ID="Senha" runat="server" type="password"></asp:TextBox>
                    <asp:Button ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Entrar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
