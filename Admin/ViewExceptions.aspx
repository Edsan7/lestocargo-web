<%@ Page Title="Exceções" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewExceptions.aspx.cs" Inherits="LestoCargo.ViewExceptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="col-12 margin-top-60px">
                <h1>Lista de Exceções</h1>
                <hr />
                <asp:Label ID="Lista" Width="100%" runat="server" ></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>