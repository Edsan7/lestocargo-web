<%@ Page Title="Painel Administrativo" Language="C#" MasterPageFile="~/Pages/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LestoCargo.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="padding-10px">Painel administrativo</h2>
    <div class="row padding-10px">
        <div class="col-4">
            <div class="dashboard">
                <asp:Label ID="CotFeitas" runat="server" ForeColor="#c22126" Font-Size="40" Font-Bold="true"></asp:Label>
                <br />
                <span style="font-size: 20px; display: inline-flex; margin-top: 15px;">Transportes Feitos</span>
            </div>
        </div>
        <div class="col-4">
            <div class=" dashboard">
                <asp:Label ID="Aguardando" runat="server" ForeColor="#c22126" Font-Size="40" Font-Bold="true"></asp:Label>
                <br />
                <span style="font-size: 20px; display: inline-flex; margin-top: 15px;">Cotações Aguardando Resposta</span>
            </div>
        </div>
        <div class="col-4">
            <div class="dashboard">
                <asp:Label ID="CotNaoFeitas" runat="server" ForeColor="#c22126" Font-Size="40" Font-Bold="true"></asp:Label>
                <br />
                <span style="font-size: 20px; display: inline-flex; margin-top: 15px;">Cotações não Aceitas</span>
            </div>
        </div>
    </div>
    <div class="row margin-top-20px padding-10px">
        <div class="col-12">
            <h2>Lista de Cotações</h2>
            <asp:DropDownList ID="Ordenar" Width="125px" OnSelectedIndexChanged="Ordenar_SelectedIndexChanged" AutoPostBack="true" Style="float: right;" runat="server">
                <asp:ListItem>Ordenar por...</asp:ListItem>
                <asp:ListItem>Finalizadas</asp:ListItem>
                <asp:ListItem>Calote</asp:ListItem>
                <asp:ListItem>Cartório</asp:ListItem>
            </asp:DropDownList>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Ordenar" EventName="SelectedIndexChanged" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="Erro" Font-Bold="true" ForeColor="#c22126" runat="server"></asp:Label>
                    <asp:Panel ID="Panel1" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                        <asp:GridView ID="Pedido" AutoGenerateColumns="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" runat="server"></asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
