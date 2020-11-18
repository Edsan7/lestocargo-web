using ADSLIB2020;
using System;
using System.Web;


namespace LestoCargo.Admin
{
    public partial class WaitingPayments : System.Web.UI.Page
    {

        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecuperarDados();
            }
        }
        void RecuperarDados()
        {
            try
            {
                string comando = "SELECT Codigo,Nome,Descricao,Data_Pagamento AS Data FROM Pedido WHERE Status='Aguardando Pagamento' ORDER BY Data_Pagamento ASC";
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                Pedido.DataSource = tb;
                Pedido.DataBind();
                Pedido.Dispose();

                ControleCotacao.Visible = false;
                this.Master.MasterForm = false;
                Pergunta.Visible = false;
                Valor.Text = "";
                Valor.Visible = false;
                Salvar.Visible = false;
                Sim.Visible = true;
                Nao.Visible = true;
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada.";
            }
        }

        protected void Pedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo.Text = Pedido.SelectedRow.Cells[1].Text;
                this.Master.Codigo = Codigo.Text.ToString();
                string comando = "SELECT * FROM Pedido WHERE Codigo=" + Codigo.Text;

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                CodCot.Text = "Código da cotação: ";
                Nome.Text = "Nome do Cliente: ";
                Data.Text = "Data do Pedido: ";
                Status.Text = "Status do Pedido: ";
                AtualStatus.Text = "Data de atualização do status: ";
                Boleto.Text = "Número do Boleto: ";
                DataPagamento.Text = "Data de Pagamento: ";
                if (tb.Rows.Count == 1)
                {
                    Nome.Text += tb.Rows[0]["Nome"].ToString();
                    Data.Text += tb.Rows[0]["Data"].ToString();
                    Status.Text += tb.Rows[0]["Status"].ToString();
                    AtualStatus.Text += tb.Rows[0]["Atual_Status"].ToString();
                    Boleto.Text += tb.Rows[0]["Boleto"].ToString();
                    DataPagamento.Text += tb.Rows[0]["Data_Pagamento"].ToString().Remove(11);
                    this.Master.MasterObservacao = tb.Rows[0]["Observacao"].ToString();
                    this.Master.MasterNome = tb.Rows[0]["Nome"].ToString();
                    this.Master.MasterEmail = tb.Rows[0]["Email"].ToString();
                    this.Master.MasterTelefone = tb.Rows[0]["Telefone"].ToString();
                    this.Master.MasterComprimento = tb.Rows[0]["Comprimento"].ToString();
                    this.Master.MasterLargura = tb.Rows[0]["Largura"].ToString();
                    this.Master.MasterAltura = tb.Rows[0]["Altura"].ToString();
                    this.Master.MasterPeso = tb.Rows[0]["Peso"].ToString();
                    this.Master.MasterDescricao = tb.Rows[0]["Descricao"].ToString();
                    this.Master.MasterCepColeta = tb.Rows[0]["CEP_Coleta"].ToString();
                    this.Master.MasterCidadeColeta = tb.Rows[0]["Cidade_Coleta"].ToString();
                    this.Master.MasterRuaColeta = tb.Rows[0]["Rua_Coleta"].ToString();
                    this.Master.MasterNumeroColeta = tb.Rows[0]["Numero_Coleta"].ToString();
                    this.Master.MasterBairroColeta = tb.Rows[0]["Bairro_Coleta"].ToString();
                    this.Master.MasterEstadoColeta = tb.Rows[0]["Estado_Coleta"].ToString();
                    this.Master.MasterCepEntrega = tb.Rows[0]["CEP_Entrega"].ToString();
                    this.Master.MasterCidadeEntrega = tb.Rows[0]["Cidade_Entrega"].ToString();
                    this.Master.MasterRuaEntrega = tb.Rows[0]["Rua_Entrega"].ToString();
                    this.Master.MasterNumeroEntrega = tb.Rows[0]["Numero_Entrega"].ToString();
                    this.Master.MasterBairroEntrega = tb.Rows[0]["Bairro_Entrega"].ToString();
                    this.Master.MasterEstadoEntrega = tb.Rows[0]["Estado_Entrega"].ToString();
                    this.Master.MasterForm = true;
                    Pergunta.Visible = true;
                    ControleCotacao.Visible = true;
                }
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada.";
            }
        }
        protected void Sim_Click(object sender, EventArgs e)
        {
            Valor.Visible = true;
            Salvar.Visible = true;
            Sim.Visible = false;
            Nao.Visible = false;
        }

        protected void Nao_Click(object sender, EventArgs e)
        {
            MotivoList.Visible = true;
            Salvar.Visible = true;
            Sim.Visible = false;
            Nao.Visible = false;
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                TimeSpan ts = new TimeSpan(3, 0, 0);
                string comando = string.Empty;


                if (MotivoList.SelectedIndex == 1)
                {
                    comando = "UPDATE Pedido SET Status='Aguardando Nota',Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "' WHERE Codigo=" + Codigo.Text;
                    db.Query(comando);
                    RecuperarDados();
                    Erro.Text = "Coleta voltou para emissão de nota.";
                }
                else if (Valor.Text.Trim() == "")
                {
                    Aviso.Visible = true;
                }
                else if (MotivoList.SelectedIndex == 2)
                {    
                    comando = "UPDATE Pedido SET Status='Calote',Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "',Valor='" + Valor.Text + "' WHERE Codigo=" + Codigo.Text;
                    db.Query(comando);
                    RecuperarDados();
                    Erro.Text = "Coleta perdoada.";
                   
                }
                else if (MotivoList.SelectedIndex == 3)
                {
                    comando = "UPDATE Pedido SET Status='Cartorio',Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "',Valor='" + Valor.Text + "' WHERE Codigo=" + Codigo.Text;
                    db.Query(comando);
                    RecuperarDados();
                    Erro.Text = "Coleta movida para cartório.";
                }
                else
                {
                    comando = "UPDATE Pedido SET Status='Coleta Finalizada',Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "',Valor='" + Valor.Text + "' WHERE Codigo=" + Codigo.Text;
                    db.Query(comando);
                    RecuperarDados();
                    Erro.Text = "Coleta Finalizada";
                }
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada.";
            }
        }

        protected void MotivoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MotivoList.SelectedIndex <= 1)
            { 
                Salvar.Visible = true;
                Valor.Visible = false;
            }
            else 
            {
                Salvar.Visible = true;
                Valor.Visible = true;
            }
        }
    }
}