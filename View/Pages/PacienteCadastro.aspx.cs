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

    public partial class PacienteCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindCidade();
        }

        public void btnCadastrarPaciente(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                paciente.nome = nome.Text;
                paciente.idCidade = Int32.Parse(idCidade.SelectedValue);

                PacienteDal pacienteDal = new PacienteDal();
                pacienteDal.Salvar(paciente);

                nome.Text = "";
                idCidade.Text = "";

                string msg = "Paciente " + paciente.nome + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindCidade()
        {
            CidadeDal cidadeDal = new CidadeDal();
            List<Cidade> listaCidade = new List<Cidade>();

            listaCidade = cidadeDal.Listar();

            foreach (var cidade in listaCidade)
            {
                idCidade.Items.Insert(0, new ListItem(cidade.Descricao, cidade.Id.ToString()));
            }


        }
    }
}
