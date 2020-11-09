<%@ Page Title="Protocolar Cartório" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Protocol.aspx.cs" Inherits="LestoCargo.Admin.Protocol" %>

<%@ MasterType VirtualPath="~/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- PAINEL -->
    <div class="row">
        <div class="col-12 padding-10px">
            <h2>Protocolar Cartório</h2>
            <br />
            <asp:Label ID="Erro" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
            <asp:Panel ID="Cotacoes" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                <asp:GridView ID="Cotacao" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" OnSelectedIndexChanged="Cotacao_SelectedIndexChanged" runat="server"></asp:GridView>
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
            </div>
            <div class="col-6">
                <h3>Protocar Cartório</h3>
                <br />
                <asp:TextBox ID="Protocolo" Width="200px" placeholder="Nº Protocolo" runat="server"></asp:TextBox>
                <asp:TextBox ID="DataCartorio" Width="200px" placeholder="Data do cartório" runat="server"></asp:TextBox>
                <asp:Button ID="Salvar" OnClick="Salvar_Click" runat="server" Text="Salvar" />
                 <asp:Label ID="Motivo" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
            </div>
        </div>
    </asp:Panel>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jsmaskedinput.js"></script>
    <script>
        $('#<%=DataCartorio.ClientID%>').mask('99/99/9999');
    </script>
</asp:Content>
