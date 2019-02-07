using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EspecialidadeLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            //gridListaEspecialidade.DataSource = especialidadeDal.Listar();
            //gridListaEspecialidade.DataBind();
        }
        public void btnPesquisarEspecialidade(object sender, EventArgs e)
        {
            string nomeEspecialidade = nome.Text;
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();

            gridListaEspecialidade.DataSource = especialidadeDal.ListarNome(nomeEspecialidade);
            gridListaEspecialidade.DataBind();

        }
    }
}
