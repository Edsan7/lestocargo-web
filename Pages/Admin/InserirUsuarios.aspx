<%@ Page Title="Inserir Funcionários" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="InserirUsuarios.aspx.cs" Inherits="LestoCargo.InserirUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row">
          <div style="" class="col-4 padding-10px">
                <asp:Label ID="codfunc" Visible="false" runat="server" ForeColor="#c22126" Font-Bold="true" Text="Codigo do Funcionário: "></asp:Label><asp:Label ID="Codigo" runat="server" ForeColor="#c22126" Font-Bold="true"></asp:Label>
                <br />
                <label>Nome</label>
                <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
                <label>Login</label>
                <asp:TextBox ID="Login" runat="server"></asp:TextBox>
                <label>Senha</label>
                <asp:TextBox ID="Senha" runat="server"></asp:TextBox>
                <label>Anotações</label>
                <asp:TextBox ID="Anotacoes" runat="server"></asp:TextBox>
                <asp:Label ID="Mensagem" ForeColor="#c22126" Font-Bold="true" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Salvar" OnClick="Salvar_Click" runat="server" Text="Salvar" />
                <asp:Button ID="Excluir" OnClick="Excluir_Click"  runat="server" Text="Excluir" />
                <asp:Button ID="Limpar" OnClick="Limpar_Click" runat="server" Text="Limpar" />
            </div>
            
            <div style="border-left: 1px solid rgba(0,0,0,0.15)" class="col-8 padding-10px margin-top-20px ">
               <h2>Lista de Funcionários</h2><hr />
                <asp:Panel ID="Panel1"  Width="100%" Height="200px" runat="server">
                    <asp:GridView ID="Funcionarios" ScrollBars="Vertical" Width="100%" HeaderStyle-BackColor="#dfdfdf" BorderStyle="ridge" BorderColor="#c0c0c0" AutoGenerateSelectButton="true" AutoGenerateColumns="true" OnSelectedIndexChanged="Funcionarios_SelectedIndexChanged" runat="server"></asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
