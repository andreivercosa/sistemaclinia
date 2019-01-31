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

    public partial class CidadeCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindEstados();
        }

        public void btnCadastrarCidade(object sender, EventArgs e)
        {
            try
            {
                Cidade cidade = new Cidade();
                cidade.Descricao = descricao.Text;
                cidade.IdEstado = Int32.Parse(idEstado.SelectedValue);

                CidadeDal cidadeDal = new CidadeDal();
                cidadeDal.Salvar(cidade);

                descricao.Text = "";
                idEstado.Text = "";

                string msg = "Cidade " + cidade.Descricao + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;


            }
            catch (Exception erro)
            {
                throw new Exception("Erro");
            }
        }

        public void bindEstados()
        {
            EstadoDal estadoDal = new EstadoDal();
            List<Estado> listaEstado = new List<Estado>();

            listaEstado = estadoDal.Listar();

            foreach(var estado in listaEstado)
            {
                idEstado.Items.Insert(0, new ListItem(estado.Nome, estado.Id.ToString()));
            }


        }
    }
}
