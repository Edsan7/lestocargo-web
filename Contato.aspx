<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="LestoCargo.Contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row margin-top-120px">
            <div class="contato1 col-5">
                <h2>Entre em contato conosco</h2>
                <p style="">Possui alguma dúvida, quer fazer alguma crítica ou sugerir melhorias?
                    Entre em contato por meio dos campos ao lado que responderemos o mais rápido possível.
                    Saber sua opinião é muito importante para o nosso desenvolvimento.
                </p>
            </div>
            <div class="col-7">
                <div class="box-contato">
                    <asp:Label ID="Erro" ForeColor="#c22126" Font-Bold="true" runat="server"></asp:Label>
                    <label><strong>Nome</strong></label>
                    <asp:TextBox ID="Nome" name="Nome" runat="server"></asp:TextBox>
                    <label><strong>Email</strong></label>
                    <asp:TextBox ID="Email" name="Email" runat="server"></asp:TextBox>
                    <label><strong>Mensagem</strong></label>
                    <asp:TextBox ID="Mensagem" TextMode="MultiLine" runat="server" Rows="6"></asp:TextBox>
                    <asp:Button ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Enviar" />
                </div>
            </div> 
        </div>
    </div>
</asp:Content>
