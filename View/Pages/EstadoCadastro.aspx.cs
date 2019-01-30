using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{
    public partial class EstadoCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o cadastro";
        }
        protected void btnCadastrarEstado(object sender, EventArgs e)
        {
            try
            {
                Estado estado = new Estado();
                estado.Nome = nome.Text;
                estado.Sigla = sigla.Text;

                EstadoDal estadoDal = new EstadoDal();
                estadoDal.Salvar(estado);

                nome.Text = "";
                sigla.Text = "";

                string msg = "Estado " + estado.Nome + "-" + estado.Sigla + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

               // Response.Redirect("http://127.0.0.1:8080/Pages/EstadoCadastro.aspx");
            }
            catch (Exception erro)
            {
                throw new Exception("Erro");
            }
            finally
            {

            }
        }
    }
   
}
