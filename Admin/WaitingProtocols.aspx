<%@ Page Title="Aguardando Protesto" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="WaitingProtocols.aspx.cs" Inherits="LestoCargo.Admin.WaitingProtocols" %>
<%@ MasterType VirtualPath="~/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- PAINEL -->
    <div class="row">
        <div class="col-12 padding-10px">
            <h2>Aguardando Protesto</h2>
            <br />
            <asp:Label ID="Erro" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
            <asp:Panel ID="Cotacoes" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                <asp:GridView ID="Cotacao" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" OnSelectedIndexChanged="Cotacao_SelectedIndexChanged" CellPadding="8" Width="100%" BorderColor="#c0c0c0" runat="server"></asp:GridView>
            </asp:Panel>
            <br />
            <asp:Button ID="Limpar" OnClick="Limpar_Click" Visible="false" runat="server" Text="Limpar" />
        </div>
    </div>
    <!-- FIM PAINEL -->
    <asp:Panel ID="ControleCotacao" Visible="false" runat="server">
        <div class="row padding-10px">
            <div class="col-6">
                <h3>Dados do Pedido</h3>
                <br />
                <asp:Label ID="CodCot" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
                <asp:Label ID="Codigo" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="Nome" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="Data" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="Status" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="AtualStatus" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="Protocolo" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="DataCartorio" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
            </div>
            <div class="col-6">
                <h3>Foi Pago?</h3>
                <br />
                <asp:DropDownList ID="Options" Width="125px" runat="server">
                    <asp:ListItem>Opções</asp:ListItem>
                    <asp:ListItem>Pago</asp:ListItem>
                    <asp:ListItem>Não Pago</asp:ListItem>
                    <asp:ListItem>Perdoar</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Salvar" OnClick="Salvar_Click" runat="server" Text="Salvar" /><br />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
