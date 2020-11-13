<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="LestoCargo.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="row padding-10px">
            <div class ="col-12 margin-top-20px">
                <h2>Faça uma cotação</h2>
                <div style="margin-top: 10px; margin-bottom: -20px;">
                    <asp:Label ID="Mensagem" ForeColor="#c22126" Font-Bold ="true" runat="server"></asp:Label>
                </div>
            <div class="row">
                <div class="col-6 padding-10px">
                    <label>Nome*</label>
                    <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
                </div>
                <div class="col-3 padding-10px">
                    <label>Email*</label>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </div>
                  <div class="col-3 padding-10px">
                    <label>Telefone*</label>
                    <asp:TextBox ID="Telefone" runat="server"></asp:TextBox>
                </div>
            </div>
            <label><strong>Dimensões do produto</strong></label>
            <div class="row">
                <div class="col-6 padding-10px">
                    <label>Comprimento*</label>
                    <asp:TextBox ID="Comprimento" placeholder="Medida em milimetros" onKeyPress="return SomenteNumero(event);" runat="server"></asp:TextBox>
                </div>
                <div class="col-6 padding-10px">
                    <label>Largura*</label>
                    <asp:TextBox ID="Largura" placeholder="Medida em milimetros" onKeyPress="return SomenteNumero(event);" runat="server"></asp:TextBox>
                </div>  
            </div>
            <div class="row">
                <div class="col-6 padding-10px">
                    <label>Altura*</label>
                    <asp:TextBox ID="Altura" placeholder="Medida em milimetros" onKeyPress="return SomenteNumero(event);" runat="server"></asp:TextBox>
                </div>
                <div class="col-6 padding-10px">
                    <label>Peso*</label>
                    <asp:TextBox ID="Peso" placeholder="Medida em quilogramas" onKeyPress="return SomenteNumero(event);" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12 padding-10px">
                    <label>Descricao do Produto / Informações Adicionais*</label>
                    <asp:TextBox ID="Descricao" TextMode="MultiLine" Columns="8" runat="server" Rows="6"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row padding-10px">
        <div class="col-12">
            <h2><strong>Endereço de Coleta</strong></h2>
            <div class="row">
                <div class="col-2 padding-10px">
                    <label>CEP*</label>
                    <asp:TextBox ID="CEP_Coleta" onblur="pesquisacep(this.value);" placeholder="somente números" onKeyPress="return SomenteNumero(event);" runat="server" MaxLength="8"></asp:TextBox>
                </div>
                <div class="col-4 padding-10px">
                    <label>Cidade*</label>
                    <asp:TextBox ID="Cidade_Coleta"  runat="server"></asp:TextBox>
                </div>
                <div class="col-5 padding-10px">
                    <label>Rua*</label>
                    <asp:TextBox ID="Rua_Coleta" runat="server" ClientIDMode="Inherit"></asp:TextBox>
                </div>
                <div class="col-1 padding-10px">
                    <label>Número*</label>
                    <asp:TextBox ID="Numero_Coleta" placeholder="somente números" onKeyPress="return SomenteNumero(event);" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6 padding-10px">
                    <label>Bairro*</label>
                    <asp:TextBox ID="Bairro_Coleta" runat="server"></asp:TextBox>
                </div>
                <div class="col-6 padding-10px">
                    <label>Estado*</label>
                    <asp:TextBox ID="Estado_Coleta" runat="server"></asp:TextBox>  
                </div>
            </div>
        </div>
    </div>
    <div class="row padding-10px">
        <div class="col-12">
            <h2><strong>Endereço de Entrega</strong></h2>
            <div class="row">
                <div class="col-2 padding-10px">
                 <label>CEP*</label>
                    <asp:TextBox ID="CEP_Entrega" onblur="pesquisacep2(this.value);" placeholder="somente números" onKeyPress="return SomenteNumero(event);" runat="server" MaxLength="8"></asp:TextBox>
                </div>
                <div class="col-4 padding-10px">
                    <label>Cidade*</label>
                    <asp:TextBox ID="Cidade_Entrega" runat="server"></asp:TextBox>
                </div>
                <div class="col-5 padding-10px">
                    <label>Rua*</label>
                    <asp:TextBox ID="Rua_Entrega" runat="server"></asp:TextBox>
                </div>
                 <div class="col-1 padding-10px">
                    <label>Número*</label>
                    <asp:TextBox ID="Numero_Entrega" onKeyPress="return SomenteNumero(event);" placeholder="somente números" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-6 padding-10px">
                    <label>Bairro*</label>
                    <asp:TextBox ID="Bairro_Entrega" runat="server"></asp:TextBox>
                </div>
                <div class="col-6 padding-10px">
                    <label>Estado*</label>
                    <asp:TextBox ID="Estado_Entrega" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:Button style="margin-left: 10px;" ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Fazer Cotação" />
            <br /><br />
        </div>
    </div>
</div>
<script type="text/javascript">
     // FUNÇÃO PARA PERMITIR QUE OS CAMPOS DE CEP OU NUMERO
     // SEJAM APENAS NÚMEROS
    function SomenteNumero(e) {
        var tecla = (window.event) ? event.keyCode : e.which;
        if ((tecla > 47 && tecla < 58 || tecla == 44)) return true;
        else {
            if (tecla == 8 || tecla == 0) return true;
            else return false;
        }
    }
    function pesquisacep(valor) {
        var cep = valor;
        var script = document.createElement('script');
        script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';
        document.body.appendChild(script);
        
    };
    function meu_callback(conteudo) {
        if (!("erro" in conteudo)) {

            document.getElementById("<%=Rua_Coleta.ClientID%>").value = conteudo.logradouro;
            document.getElementById("<%=Bairro_Coleta.ClientID%>").value = conteudo.bairro;
            document.getElementById("<%=Cidade_Coleta.ClientID%>").value = conteudo.localidade;
            document.getElementById("<%=Estado_Coleta.ClientID%>").value = conteudo.uf;
        }
    }

    function pesquisacep2(valor) {
        var cep = valor;
        var script = document.createElement('script');
        script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback2';
        document.body.appendChild(script);
    };
    function meu_callback2(conteudo) {
        if (!("erro" in conteudo)) {
            document.getElementById("<%=Rua_Entrega.ClientID%>").value = conteudo.logradouro;
            document.getElementById("<%=Bairro_Entrega.ClientID%>").value = conteudo.bairro;
            document.getElementById("<%=Cidade_Entrega.ClientID%>").value = conteudo.localidade;
            document.getElementById("<%=Estado_Entrega.ClientID%>").value = conteudo.uf;
        }
    }
    </script>
    <script src="/js/jsmaskedinput.js"></script>
    <script>
        $('#<%=Telefone.ClientID%>').mask('(99) 9999-99999');
    </script>
</asp:Content>
