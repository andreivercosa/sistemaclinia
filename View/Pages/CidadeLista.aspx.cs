﻿using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class CidadeLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnPesquisarCidade(object sender, EventArgs e)
        {
            string nomeCidade = nome.Text;
            CidadeDal cidadeDal = new CidadeDal();

            gridListaCidade.DataSource = cidadeDal.ListarNome(nomeCidade);
            gridListaCidade.DataBind();

        }
    }
}
