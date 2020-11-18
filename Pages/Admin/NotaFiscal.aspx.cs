using ADSLIB2020;
using LestoCargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LestoCargo.Admin
{
    public partial class PaidQuotations : System.Web.UI.Page
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
        protected void RecuperarDados()
        {
            try
            {
                string comando = "SELECT Codigo,Nome,Descricao,Atual_Status FROM Pedido WHERE Status='Aguardando Nota' ORDER BY Atual_Status ASC";

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                Pedido.DataSource = tb;
                Pedido.DataBind();
                Pedido.Dispose();
                Pergunta.Visible = false;
                ControleCotacao.Visible = false;
                Aviso.Visible = false;
                this.Master.MasterForm = false;
                Limpar.Visible = false;
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

                if (tb.Rows.Count == 1)
                {

                    Nome.Text += tb.Rows[0]["Nome"].ToString();
                    Data.Text += tb.Rows[0]["Data"].ToString();
                    Status.Text += tb.Rows[0]["Status"].ToString();
                    AtualStatus.Text += tb.Rows[0]["Atual_Status"].ToString();
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

                    ControleCotacao.Visible = true;
                    Pergunta.Visible = true;
                    Limpar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Erro.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }

        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NovaDataPagamento.Text.Length < 10 && NotaFiscal.Text.Trim() == "")
                {
                    Aviso.Visible = true;
                }
                else
                {
                    TimeSpan ts = new TimeSpan(3, 0, 0);
                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    
                    string comando = "UPDATE Pedido SET Status='Agendar Pagamento', Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "', Nota_Fiscal='" + NotaFiscal.Text + "', Data_Pagamento='" + NovaDataPagamento.Text + "' WHERE Codigo=" + Codigo.Text;
                    db.Query(comando);
                    Erro.Text = "Nota salva com sucesso";

                    RecuperarDados();
                }
            }
            catch (Exception ex)
            {
                Erro.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }
        protected void Limpar_Click(object sender, EventArgs e)
        {
            RecuperarDados();
        }
    }
}