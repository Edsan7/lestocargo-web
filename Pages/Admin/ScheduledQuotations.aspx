<%@ Page Title="Cotações Agendadas" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ScheduledQuotations.aspx.cs" Inherits="LestoCargo.Admin.ScheduledCotations" %>

<%@ MasterType VirtualPath="~/Pages/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row padding-10px">
            <div class="col-12">
                <h2>Cotações agendadas</h2>
                <br />
                <asp:Label ID="Erro" Font-Bold="true" ForeColor="#c22126" runat="server"></asp:Label>
                <asp:Panel ID="Panel1" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                    <asp:GridView ID="Pedido" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" OnSelectedIndexChanged="Pedido_SelectedIndexChanged" runat="server"></asp:GridView>
                </asp:Panel>
                <br />
                <asp:Button ID="Limpar" Visible="false" OnClick="Limpar_Click" runat="server" Text="Limpar" />
            </div>
        </div>
        <asp:Panel ID="ControleCotacao" Visible="false" runat="server">
            <div class="row margin-top-20px padding-10px">
                <div class="col-6">
                    <h3>Dados da Cotação</h3>
                    <br />
                    <asp:Label ID="CodCot" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
                    <asp:Label ID="Codigo" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="Nome" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="Data" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="Status" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="AtualStatus" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="DataColeta" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                    <asp:Label ID="HoraColeta" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                </div>
                <div class="col-6">
                    <asp:Panel ID="Pergunta" runat="server">
                        <h3>Coleta Realizada?</h3>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="Realizada" />
                                <asp:PostBackTrigger ControlID="Excluir" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Button ID="Realizada" runat="server" OnClick="Realizada_Click" Text="Realizada" />
                                <asp:Button ID="NaoRealizada" OnClick="NaoRealizada_Click" runat="server" Text="Não Realizada" />
                                <asp:DropDownList ID="MotivoList" Width="200px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="MotivoList_SelectedIndexChanged" runat="server">
                                    <asp:ListItem>Motivo...</asp:ListItem>
                                    <asp:ListItem>Carga</asp:ListItem>
                                    <asp:ListItem>Cancelamento</asp:ListItem>
                                    <asp:ListItem>Disponibilidade</asp:ListItem>
                                </asp:DropDownList>
                                <span id="ErroMotivo" runat="server"></span>
                                <asp:Label ID="Aviso" runat="server" ForeColor="#c22126" Font-Bold="true" Visible="false" Text="Deseja reagendar a coleta?"></asp:Label>
                                <br />
                                <asp:Button ID="Reagendar" OnClick="Reagendar_Click" Visible="false" runat="server" Text="Sim" />
                                <asp:Button ID="NaoReagendar" Visible="false" OnClick="NaoReagendar_Click" runat="server" Text="Não" />
                                <asp:TextBox ID="DataAgendamento" Width="200px" Visible="false" placeholder="Data" runat="server"></asp:TextBox>
                                <asp:TextBox ID="HoraAgendamento" Width="200px" Visible="false" placeholder="Hora" runat="server"></asp:TextBox>
                                <asp:Button ID="Excluir" Visible=" false" runat="server" OnClick="Excluir_Click" Text="Remover Coleta" />
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </asp:Panel>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jsmaskedinput.js"></script>
    <script>
        $('#<%=DataAgendamento.ClientID%>').mask('99/99/9999');
        $('#<%=HoraAgendamento.ClientID%>').mask('99:99');
    </script>
</asp:Content>
