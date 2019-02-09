using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class PacienteLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnPesquisarPaciente(object sender, EventArgs e)
        {
            string nomePaciente = nome.Text;
            PacienteDal pacienteDal = new PacienteDal();

            gridListaPaciente.DataSource = pacienteDal.ListarNome(nomePaciente);
            gridListaPaciente.DataBind();

        }
    }
}
