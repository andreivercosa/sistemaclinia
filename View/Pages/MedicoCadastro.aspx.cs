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

    public partial class MedicoCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindEspecialidade();
        }

        public void btnCadastrarMedico(object sender, EventArgs e)
        {
            try
            {
                Medico medico = new Medico();
                medico.IdEspecialidade = Int32.Parse(idEspecialidade.SelectedValue);
                medico.Nome = nome.Text;
                medico.CRM = crm.Text;


                MedicoDal medicoDal = new MedicoDal();
                medicoDal.Salvar(medico);

                nome.Text = "";
                crm.Text = "";


                string msg = "Medico " + medico.Nome + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;


            }
            catch (Exception erro)
            {
                throw new Exception("Erro");
            }
        }

        public void bindEspecialidade()
        {
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            List<Especialidade> listaEspecialidade = new List<Especialidade>();

            listaEspecialidade = especialidadeDal.Listar();

            foreach (var especialidade in listaEspecialidade)
            {
                idEspecialidade.Items.Insert(0, new ListItem(especialidade.Descricao, especialidade.Id.ToString()));
            }


        }
    }
}
