<%@ Page Title="Aguardando resposta" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewQuotations.aspx.cs" Inherits="LestoCargo.ViewCotations" %>

<%@ MasterType VirtualPath="~/Pages/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- PAINEL -->
    <div class="row">
        <div class="col-12 padding-10px">
            <h2>Cotações aguardando resposta</h2>
            <br />
            <asp:Label ID="Erro" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
            <asp:Panel ID="Cotacoes" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                <asp:GridView ID="Cotacao" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" OnSelectedIndexChanged="Cotacao_SelectedIndexChanged" runat="server"></asp:GridView>
            </asp:Panel>
            <br />
            <asp:Button ID="Limpar" Visible="false" OnClick="Limpar_Click" runat="server" Text="Limpar" />
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
                <asp:UpdatePanel ID="Pergunta" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ExcluirCot" />
                        <asp:PostBackTrigger ControlID="Agendar" />
                    </Triggers>
                    <ContentTemplate>
                        <h3 id="titulo" runat="server">Cotação Aceitada?</h3>
                        <br />
                        <asp:Button ID="Aceitar" OnClick="Aceitar_Click" runat="server" Text="Aceitada" />
                        <asp:Button ID="NaoAceitar" OnClick="NaoAceitar_Click" runat="server" Text="Não aceitada" />
                        <asp:DropDownList ID="MotivoSelect" Width="200px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="MotivoSelect_SelectedIndexChanged" runat="server">
                            <asp:ListItem>Motivo...</asp:ListItem>
                            <asp:ListItem>Carga</asp:ListItem>
                            <asp:ListItem>Disponibilidade</asp:ListItem>
                            <asp:ListItem>Valor</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="ExcluirCot" runat="server" OnClick="ExcluirCot_Click" Visible="false" Font-Bold="true" Text="Excluir Cotação" /><br />
                        <asp:Label ID="ErroMotivo" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
                        <asp:Panel ID="Agendamento" Visible="false" runat="server">
                            <h3>Agendamento</h3>
                            <br />
                            <asp:TextBox ID="DataAgendamento" placeholder="Data" Width="200px" runat="server"></asp:TextBox>
                            <asp:TextBox ID="HoraAgendamento" placeholder="Hora" Width="200px" runat="server"></asp:TextBox>
                            <asp:Button ID="Agendar" OnClick="Agendar_Click" runat="server" Text="Agendar" />
                            <br />
                            <span id="ErroAgendamento" runat="server"></span>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jsmaskedinput.js"></script>
    <script>
        $('#<%=DataAgendamento.ClientID%>').mask('99/99/9999');
        $('#<%=HoraAgendamento.ClientID%>').mask('99:99');
    </script>
</asp:Content>
