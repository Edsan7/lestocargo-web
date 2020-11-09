using System;
using System.Linq;
using System.Web;
using ADSLIB2020;


namespace LestoCargo
{
    public partial class Pedido : System.Web.UI.Page
    {
        // STRING CONEXÃO BANCO DE DADOS

        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = new TimeSpan(3, 0, 0);
                string email = Email.Text.Trim();
                bool valida = email.Contains("@") && email.Contains(".com");
                Cidade_Coleta.Text = Cidade_Coleta.Text.Replace('\'', ' ');
                Cidade_Entrega.Text = Cidade_Entrega.Text.Replace('\'', ' ');
                if (Nome.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Nome";
                }
                else if (!valida)
                {
                    Mensagem.Text = "Insira um email válido";
                }
                else if (Telefone.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha corretamente o campo Telefone";
                }
                else if (Comprimento.Text.Trim() == "" || Largura.Text.Trim() == "" || Altura.Text.Trim() == "" || Peso.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha corretamente os campos de dimensões dos produtos";
                }
                else if (CEP_Coleta.Text.Trim() == "" || CEP_Entrega.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo CEP";
                }
                else if (Cidade_Coleta.Text.Trim() == "" || Cidade_Entrega.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Cidade";
                }
                else if (Rua_Coleta.Text.Trim() == "" || Rua_Entrega.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha corretamente o campo Rua";
                }
                else if (Numero_Coleta.Text.Trim() == "" || Numero_Entrega.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha corretamente o campo Numero";
                }
                else if (Bairro_Coleta.Text.Trim() == "" || Bairro_Entrega.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha corretamente o campo Bairro";
                }
                else if (Descricao.Text.Trim() == "")
                {
                    Mensagem.Text = "Insira a descricao do produto";
                }
                else
                {
                    // CRIAÇÃO DO COMANDO SQL   
                    string comando = "INSERT INTO Pedido(Nome,Email,Telefone,Comprimento,Largura,Altura,Peso,Descricao,CEP_Coleta,Cidade_Coleta,Rua_Coleta,Numero_Coleta,Bairro_Coleta,Estado_Coleta," +
                        "CEP_Entrega,Cidade_Entrega,Rua_Entrega,Numero_Entrega,Bairro_Entrega,Estado_Entrega,Data,Status) VALUES('" + Nome.Text + "','" + Email.Text + "','" + Telefone.Text + "','" + Comprimento.Text + "','" + Largura.Text + "','" + Altura.Text + "','" +
                        Peso.Text + "','" + Descricao.Text + "','" + CEP_Coleta.Text + "','" + Cidade_Coleta.Text + "','" + Rua_Coleta.Text + "','" + Numero_Coleta.Text + "','" + Bairro_Coleta.Text + "','" + Estado_Coleta.Text + "','" + CEP_Entrega.Text + "','" +
                        Cidade_Entrega.Text + "','" + Rua_Entrega.Text + "','" + Numero_Entrega.Text + "','" + Bairro_Entrega.Text + "','" + Estado_Entrega.Text + "','" + DateTime.UtcNow.Subtract(ts).ToString() + "','" + "Aguardando Cotacao" + "');";

                    // CONEXAO AO BANCO DE DADOS

                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    db.Query(comando);

                    Mensagem.Text = "Pedido realizado com sucesso. Em breve entraremos em contato com você.";

                }
                
            }
            catch (Exception ex)
            {
                Mensagem.Text = "Houve uma falha inesperada. Tente novamente mais tarde";
                //INSTANCIA A CLASSE RecoverExceptions QUE ESTA NA BIBLIOTECA ADSLIB2020
                RecoverExceptions re = new RecoverExceptions();
                //Salva a excecao
                re.SaveException(ex);
            }
        }
    }
}