using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace View.Pages
{

    public partial class EspecialidadeCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastrarEspecialidade(object sender, EventArgs e)
        {
            try
            {
                Especialidade especialidade = new Especialidade();
                especialidade.Descricao = descricao.Text;
                especialidade.DtCadastro = descricao.Text;

                EspecialidadeDal especialidadeDal = new EspecialidadeDal();
                especialidadeDal.Salvar(especialidade);

                descricao.Text = "";

                string msg = "Especialidade " + especialidade.Descricao + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

                // Response.Redirect("http://127.0.0.1:8080/Pages/EspecialidadeCadastro.aspx");
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
