<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LestoCargo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="flexslider">
            <ul class="slides">
                <li>
                    <img src="Images/LestoCargo.png" /></li>
                <li>
                    <img src="Images/Banner-Carro.png" /></li>
            </ul>
        </div>
        <script>
            $(window).load(function () {
                $('.flexslider').flexslider({
                    animation: "slide",
                    prevText: "Anterior",
                    nextText: "Próximo"
                });
            });
        </script>
        <!-- CONTEUDO DA PÁGINA -->
        <div style="border-top: 1px solid rgba(0,0,0,0.15)" class="row centralizar">
            <div class="col-2 icones">
                <div class="icone">
                    <img src="Images/icn-caminhao.png" />
                </div>
                <span style="text-align: center;">Transporte Eficiente</span>
            </div>
            <div class="col-2 icones">
                <div class="icone">
                    <img src="Images/icn-relogio2%20.png" />
                </div>
                <span style="text-align: center;">Menor tempo possível</span>
            </div>
        </div>
        <div class="background">
            <div class="row box-padding-30px">
                <div class="col-6 home-text">
                    <h2>Conheça a Lesto Cargo</h2>
                    <p>
                        Fundada em 2019, a Lesto Cargo tem como principais focos as coletas e entregas de mercadorias urgentes.
                        Pensada em resolver suas necessidades de transporte rápido, a Lesto Cargo está sempre disposta a atender de maneira ágil à suas urgências. 
                        <br />
                        Utilizamos o modal rodoviário e atuamos em toda área do estado de São Paulo, nossa base está localizada em Santa Barbara D’Oeste.
                        Nossa frota é de veículos leves e transportamos mercadorias e documentos diversos.
                    </p>
                    <a class="link-cotacao" href="/Orders.aspx"><strong>Faça uma Cotação</strong></a>
                </div>
                <div class="col-4 cartao">
                    <img src="Images/CartaoAjus.jpg" />
                </div>
            </div>
        </div>
        <div class="row box-padding-30px margin-top-20px">
            <div class="col-6">
                <h2>Faça uma visita</h2>
                <br />
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3679.689371524416!2d-47.35252258499638!3d-22.73978423765024!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94c89bea5cdb94f9%3A0xffb368bd91ea12ae!2sFatec%20Americana%20-%20Faculdade%20de%20Tecnologia%20de%20Americana!5e0!3m2!1spt-BR!2sbr!4v1593912134020!5m2!1spt-BR!2sbr"
                    width="100%" height="300" frameborder="0" style="border: 0;" aria-hidden="false" tabindex="0"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
