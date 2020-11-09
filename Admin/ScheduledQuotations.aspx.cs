using System;
using System.Web;
using ADSLIB2020;

namespace LestoCargo.Admin
{
    public partial class ScheduledCotations : System.Web.UI.Page
    {
        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";
        static bool Reagendou = false;

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
                string comando = "SELECT Codigo,Nome,Descricao,Data_Agendamento AS Data,Hora_Agendamento AS Hora FROM Pedido WHERE Status='Agendado' ORDER BY Data_Agendamento,Hora_Agendamento DESC";

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                Pedido.DataSource = tb;
                Pedido.DataBind();
                Pedido.Dispose();

                ControleCotacao.Visible = false;
                this.Master.MasterForm = false;
                Limpar.Visible = false;
            }
            catch (Exception ex)
            {
                Erro.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
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
                DataColeta.Text = "Data de agendamento da coleta: ";
                HoraColeta.Text = "Horário da coleta: ";

                if (tb.Rows.Count == 1)
                {
                    Nome.Text += tb.Rows[0]["Nome"].ToString();
                    Data.Text += tb.Rows[0]["Data"].ToString();
                    Status.Text += tb.Rows[0]["Status"].ToString();
                    AtualStatus.Text += tb.Rows[0]["Atual_Status"].ToString();
                    DataColeta.Text += tb.Rows[0]["Data_Agendamento"].ToString().Remove(11);
                    HoraColeta.Text += tb.Rows[0]["Hora_Agendamento"].ToString();
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

        
        protected void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;

                if (MotivoList.SelectedIndex == 0)
                {
                    ErroMotivo.InnerText = "Informe o motivo";
                }
                else if(MotivoList.SelectedIndex == 3 &&  Reagendou == true)
                {
                    if (HoraAgendamento.Text.Trim() == "" || DataAgendamento.Text.Trim() == "")
                    {
                        ErroMotivo.InnerText = "Preencha todos os campos";
                    }
                    else
                    {
                        string comando = "UPDATE Pedido SET Data_Agendamento='" + DataAgendamento.Text + "',Hora_Agendamento='" + HoraAgendamento.Text + "' WHERE Codigo=" + Codigo.Text;
                        db.Query(comando);
                        Erro.Text = "Coleta reagendada com sucesso";
                        RecuperarDados();
                    }
                }
                else
                {
                    string comando = "INSERT INTO CotNaoAceitas(Motivo,Razao) VALUES('" + MotivoList.SelectedValue.ToString() + "','" + "Coleta nao realizada" + "');";
                    string commando = "DELETE * FROM Pedido WHERE Codigo=" + Codigo.Text;

                    db.Query(comando);
                    db.Query(commando);

                    Erro.Text = "Coleta Removida com sucesso";

                    RecuperarDados();
                }
                
               
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada";
            }
        }

        protected void NaoRealizada_Click(object sender, EventArgs e)
        {
            Realizada.Visible = false;
            NaoRealizada.Visible = false;
            MotivoList.Visible = true;
        }

        protected void Realizada_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = new TimeSpan(3, 0, 0);
                string comando = "UPDATE Pedido SET Status='Aguardando Nota',Atual_Status='" + DateTime.UtcNow.Subtract(ts).ToString() + "' WHERE Codigo=" + Codigo.Text;
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                db.Query(comando);
                Erro.Text = "Transporte atualizado com sucesso";
                RecuperarDados();
            }
            catch(Exception ex)
            {
                Erro.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }


        protected void Limpar_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            MotivoList.Visible = false;
            DataAgendamento.Visible = false;
            HoraAgendamento.Visible = false;
            Aviso.Visible = false;
            Excluir.Visible = false;
            Realizada.Visible = true;
            NaoRealizada.Visible = true;
        }

        protected void MotivoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(MotivoList.SelectedIndex == 3)
            {
                Excluir.Visible = false;
                Aviso.Visible = true;
                Reagendar.Visible = true;
                NaoReagendar.Visible = true;   
            }
            else
            {
                Excluir.Visible = true;
                DataAgendamento.Visible = false;
                HoraAgendamento.Visible = false;
                Reagendar.Visible = false;
                Aviso.Visible = false;
                NaoReagendar.Visible = false;
            }
        }

        protected void Reagendar_Click(object sender, EventArgs e)
        {
            Reagendar.Visible = false;
            NaoReagendar.Visible = false;
            Excluir.Text = "Reagendar Coleta";
            Excluir.Visible = true;
            DataAgendamento.Visible = true;
            HoraAgendamento.Visible = true;
            Reagendou = true;
        }
        protected void NaoReagendar_Click(object sender, EventArgs e)
        {
            Aviso.Visible = false;
            Reagendar.Visible = false;
            NaoReagendar.Visible = false;
            Excluir.Text = "Remover Coleta";
            Excluir.Visible = true;
        }
    }
}
