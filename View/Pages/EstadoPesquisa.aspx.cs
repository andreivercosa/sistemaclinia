using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{

    public partial class EstadoPesquisa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPesquisarEstado(object sender, EventArgs e)
        {
            try
            {

                Estado estado = new Estado();
                estado.Id =Convert.ToInt32(id.Text);

                lblMensagem.Text = "";
                EstadoDal estadoDal = new EstadoDal();
                estado = estadoDal.pesquisarEstado(estado.Id);
                if (estado.Id !=0)
                {
                nome.Text = estado.Nome;
                sigla.Text = estado.Sigla;
                

                }
                else
                {
                    nome.Text = "";
                    sigla.Text = "";
                    lblMensagem.Text = "Estado nao encontrado";
                }

             
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
