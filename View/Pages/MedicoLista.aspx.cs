using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class MedicoLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnPesquisarMedico(object sender, EventArgs e)
        {
            string nomeMedico = nome.Text;
            MedicoDal medicoDal = new MedicoDal();

            gridListaMedico.DataSource = medicoDal.ListarNome(nomeMedico);
            gridListaMedico.DataBind();

        }
    }
}
