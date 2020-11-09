using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADSLIB2020;

namespace LestoCargo
{
    public partial class Contato : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Enviar_Click(object sender, EventArgs e)
        {
            string validaEmail = Email.Text.Trim();
            bool valida = validaEmail.Contains("@") && validaEmail.Contains(".com"); 
            if(Nome.Text.Trim() == "")
            {
                Erro.Text = "Preencha o campo nome";
            }
            else if(Email.Text.Trim() == "")
            {
                Erro.Text = "Preencha o campo email";
            }
            else if(Mensagem.Text.Trim() == ""){
                Erro.Text = "Preencha o campo mensagem";
            }
            else if (!valida)
            {
            Erro.Text = "Insira um email válido";
            }
            else
            {
                try
                {
                    /* MailMessage email = new MailMessage();
                    SmtpClient smtp = new SmtpClient();

                    email.Subject = "Fale Conosco";
                    email.To.Add(Email.Text);
                    MailAddress from = new MailAddress("seuemail@email.com");
                    email.From = from;
                    email.Body = "Olá, " + Nome.Text + "\n";
                    email.Body += "Recebemos a sua mensagem do formulário de contato da Lesto Cargo.\n" +
                        "Em breve estaremos entrando em contato para responder sua mensagem.\n";
                    email.Body += "Dados da Mensagem:";
                    email.Body += "Nome: " + Nome.Text + "\n";
                    email.Body += "Email: " + Email.Text + "\n";
                    email.Body += "Mensagem: " + Mensagem.Text + "\n";
                    email.Body += "\n\nEste é um email automático. Por favor, não responda.";
                    email.IsBodyHtml = false;

                    // PASSO 2 - ENVIAR A MENSAGEM POR SMTP (SEND EMAIL TRANSFER PROTOCOL)

                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("seuemail@email.com", "suasenha");
                    smtp.Send(email);
                    */
                    Erro.Text = "Mensagem enviada com sucesso.";
                    Nome.Text = "";
                    Mensagem.Text = "";
                    Email.Text = "";
                    
                }
                catch (Exception ex)
                {
                    RecoverExceptions re = new RecoverExceptions();
                    re.SaveException(ex);
                    Erro.Text = "Houve uma falha inesperada.";
                }
            }
        }
    }
}