<%@ Page Title="Aguardando Pagamentos" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="WaitingPayments.aspx.cs" Inherits="LestoCargo.Admin.WaitingPayments" %>

<%@ MasterType VirtualPath="~/Pages/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row padding-10px">
        <div class="col-12">
            <h2>Aguardando Pagamento</h2>
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
                <asp:Label ID="Boleto" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="DataPagamento" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
            </div>
            <div class="col-6">
                <asp:Panel ID="Pergunta" runat="server">
                    <h3>Pagamento Realizado?</h3>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="Salvar" />
                            <asp:AsyncPostBackTrigger ControlID="Sim" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Nao" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Button ID="Sim" OnClick="Sim_Click" runat="server" Text="Sim" />
                            <asp:Button ID="Nao" OnClick="Nao_Click" runat="server" Text="Não" />
                            <asp:DropDownList ID="MotivoList" Width="200px" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="MotivoList_SelectedIndexChanged" runat="server">
                                <asp:ListItem>Motivo...</asp:ListItem>
                                <asp:ListItem>Renegociado</asp:ListItem>
                                <asp:ListItem>Perdão</asp:ListItem>
                                <asp:ListItem>Cartório</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="Valor" Width="200px" placeholder="Valor" Visible="false" runat="server"></asp:TextBox>
                            <asp:Button ID="Salvar" OnClick="Salvar_Click" runat="server" Visible="false" Text="Salvar" /><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label ID="Aviso" ForeColor="#c22126" Font-Bold="true" runat="server" Visible="false" Text="Preencha os dados corretamente"></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
