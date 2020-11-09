<%@ Page Title="Fazer Cotações" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="LestoCargo.Admin.ViewOrders" %>

<%@ MasterType VirtualPath="~/Admin/SiteAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="col-12 padding-10px">
                <h2>Fazer Cotações</h2>
                <br />
                <asp:Label ID="Erro" runat="server" Font-Bold="true" ForeColor="#c22126"></asp:Label>
                <div class="row">
                    <div class="col-4">
                        <asp:TextBox ID="Pesquisa" placeholder="Pesquisa" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-2" style="margin-left: 10px;">
                        <asp:Button ID="Buscar" OnClick="Buscar_Click" runat="server" Text="Buscar" />
                        <asp:Button ID="Limpar_Busca" OnClick="Limpar_Busca_Click" runat="server" Text="Limpar" />
                    </div>
                </div>
                <asp:Panel ID="Panel1" BorderStyle="Ridge" ScrollBars="Vertical" Width="100%" Height="200px" runat="server">
                    <asp:GridView ID="Pedido" AutoGenerateColumns="true" AutoGenerateSelectButton="true" HeaderStyle-BackColor="#dfdfdf" CellPadding="8" Width="100%" BorderColor="#c0c0c0" OnSelectedIndexChanged="Pedido_SelectedIndexChanged" runat="server">
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
        <div class="padding-10px">
            <asp:Button ID="Limpar" OnClick="Limpar_Click" runat="server" Text="Limpar" /><asp:Button Style="float: right;" ID="Responder" OnClick="Responder_Click" runat="server" Text="Responder" />
            <br />
            <div class="margin-top-20px">
                <script src="../ckeditor/ckeditor.js"></script>
                <asp:TextBox ID="editor" runat="server"></asp:TextBox>
                <script>
                    CKEDITOR.replace('<%=editor.ClientID%>', {
                        language: 'pt'
                    });
                </script>
                <br />
                <asp:Button ID="EnviarMsg" runat="server" OnClick="EnviarMsg_Click" OnClientClick="Resgate()" Text="Enviar Mensagem" />
                <asp:HiddenField ID="Resgate" runat="server" />
                <script>
                    function Resgate() {
                        var data = CKEDITOR.instances.<%=editor.ClientID%>.getData();
                        var strTag = data.replace(/<\/?[^>]+(>|$)/g, "");
                        document.all['<%=Resgate.ClientID%>'].value = strTag;
                    }
                </script>
            </div>
            <asp:Panel ID="ControleCotacao" runat="server">
                <asp:Label ID="codcot" runat="server" Font-Bold="true" ForeColor="#c22126"></asp:Label><asp:Label ID="Codigo" Font-Bold="true" ForeColor="#c22126" runat="server"></asp:Label><br />
                <asp:Label ID="Nome" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label><br />
                <asp:Label ID="DataPedido" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
