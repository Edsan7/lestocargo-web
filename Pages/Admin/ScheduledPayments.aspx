<%@ Page Title="Agendar Pagamento" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ScheduledPayments.aspx.cs" Inherits="LestoCargo.Admin.SchedulePayment" %>

<%@ MasterType VirtualPath="~/Pages/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row padding-10px">
        <div class="col-12">
            <h2>Agendar Pagamento</h2>
            <br />
            <asp:Label ID="Erro" Font-Bold="true" ForeColor="#c22126" runat="server"></asp:Label>
            <asp:Panel ID="Panel1" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                <asp:GridView ID="Pedido" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" OnSelectedIndexChanged="Pedido_SelectedIndexChanged" runat="server"></asp:GridView>
            </asp:Panel>
            <br />
            <asp:Button ID="Limpar" Visible="false" runat="server" Text="Limpar" />
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
                <asp:Label ID="NotaFiscal" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="DataPagamento" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
            </div>
            <div class="col-6">
                <asp:Panel ID="Pergunta" runat="server">
                    <h3>Agendar Pagamento</h3>
                    <br />
                    <asp:TextBox ID="Boleto" Width="200px" placeholder="Número do Boleto" runat="server"></asp:TextBox>
                    <asp:Button ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Salvar número" /><br />
                    <asp:Label ID="Aviso" runat="server" ForeColor="#c22126" Font-Bold="true" Visible="false" Text="Preencha o campo Número do Boleto"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
