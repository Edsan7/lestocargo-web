using ADSLIB2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LestoCargo.Admin
{
    public partial class SiteAdmin : System.Web.UI.MasterPage
    {

        public string MasterNome { get { return NomeCompleto.Text; } set { NomeCompleto.Text = value; } }
        public string MasterEmail { get { return Email.Text; } set { Email.Text = value; } }
        public string MasterTelefone { get { return Telefone.Text; } set { Telefone.Text = value; } }
        public string MasterComprimento { get { return Comprimento.Text; } set { Comprimento.Text = value; } }
        public string MasterLargura { get { return Largura.Text; } set { Largura.Text = value; } }
        public string MasterAltura { get { return Altura.Text; } set { Altura.Text = value; } }
        public string MasterPeso { get { return Peso.Text; } set { Peso.Text = value; } }
        public string MasterDescricao { get { return Descricao.Text; } set { Descricao.Text = value; } }
        public string MasterCepColeta { get { return CEP_Coleta.Text; } set { CEP_Coleta.Text = value; } }
        public string MasterCidadeColeta { get { return Cidade_Coleta.Text; } set { Cidade_Coleta.Text = value; } }
        public string MasterRuaColeta { get { return Rua_Coleta.Text; } set { Rua_Coleta.Text = value; } }
        public string MasterNumeroColeta { get { return Numero_Coleta.Text; } set { Numero_Coleta.Text = value; } }
        public string MasterBairroColeta { get { return Bairro_Coleta.Text; } set { Bairro_Coleta.Text = value; } }
        public string MasterEstadoColeta { get { return Estado_Coleta.Text; } set { Estado_Coleta.Text = value; } }
        public string MasterCepEntrega { get { return CEP_Entrega.Text; } set { CEP_Entrega.Text = value; } }
        public string MasterCidadeEntrega { get { return Cidade_Entrega.Text; } set { Cidade_Entrega.Text = value; } }
        public string MasterRuaEntrega { get { return Rua_Entrega.Text; } set { Rua_Entrega.Text = value; } }
        public string MasterNumeroEntrega { get { return Numero_Entrega.Text; } set { Numero_Entrega.Text = value; } }
        public string MasterBairroEntrega { get { return Bairro_Entrega.Text; } set { Bairro_Entrega.Text = value; } }
        public string MasterEstadoEntrega { get { return Estado_Entrega.Text; } set { Estado_Entrega.Text = value; } }
        public string MasterObservacao { get { return Observacao.Text; } set { Observacao.Text = value; } }
        public string Codigo { set { codigo.Text = value; } }

        public bool MasterForm { get { return MasterForm; } set { Formulario.Visible = value; } }

        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nome"] != null)
            {
                Nome.Text = "Olá, " + Session["Nome"].ToString();
                dropbtn.Visible = true;
                Login.Visible = false;
                Logout.Visible = true;               
            }
            else
            {
                dropbtn.Visible = false;
                Login.Visible = true;
                Logout.Visible = false;             
            }
        }
        protected void Observacao_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string comando = "UPDATE Pedido SET Observacao='" + Observacao.Text + "'WHERE Codigo=" + codigo.Text;
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                db.Query(comando);
                Obs.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alert", "HideLabel();", true);
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Obs.Text = "Houve uma falha inesperada";
            }
        }
    }
}