using SistemaRegistros.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            Usuaria usuaria = new Usuaria(txtNomeUsuaria.Text, txtSenha.Text);


            if(sqlAux.LoginExiste(usuaria))
            {
                ValidaLogin(usuaria);
            }
            else
            {
                MessageBox.Show("USUARIA NÃO CADASTRADA NO SISTEMA!");
            }
        }
        public void ValidaLogin(Usuaria usuaria)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            if (sqlAux.LoginConfere(usuaria))
            {
                FrmConsultaClientes frmConsultaClientes = new FrmConsultaClientes(usuaria);
                this.Hide();
                frmConsultaClientes.Show();
                frmConsultaClientes.FormClosed+= new FormClosedEventHandler(fechaForm);
            }
            else
            {
                MessageBox.Show("DADOS NAO CONFEREM!");
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        void fechaForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
