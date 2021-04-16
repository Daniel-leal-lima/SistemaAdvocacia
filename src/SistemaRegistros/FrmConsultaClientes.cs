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
    public partial class FrmConsultaClientes : Form
    {
        Usuaria usuaria = new Usuaria();
        public FrmConsultaClientes()
        {
            InitializeComponent();
            RefreshDgv();
        }

        public FrmConsultaClientes(Usuaria usuaria)
        {
            InitializeComponent();
            this.usuaria = usuaria;
            if (usuaria.TipoAcessoUsuaria.Equals("A"))
            {
                btnContratos.Visible = true;
            }
            else
            {
                btnContratos.Visible = false;
            }
            RefreshDgv();
        }

        private void brncadastrar_Click(object sender, EventArgs e)
        {
            FrmCliente frmRequerente = new FrmCliente();
            frmRequerente.ShowDialog();
        }

        public void RefreshDgv()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.RefreshClientes(dgvClientes);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dgvClientes.CurrentRow.Cells[0].Value.ToString()); -- LOG PRA VER SE ESTÁ PEGANDO OS VALORES DA CÉLULA
            //Retorna valores do Id's Cliente, ParteContraria e Processo
            try
            {
                int idCliente = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                int idParteContraria = int.Parse(dgvClientes.CurrentRow.Cells[1].Value.ToString());
                int idProcesso = int.Parse(dgvClientes.CurrentRow.Cells[2].Value.ToString());

                Cliente cliente = new Cliente(idCliente);
                ParteContraria parteContraria = new ParteContraria(idParteContraria);
                Processo processo = new Processo(idProcesso);

                FrmCliente frmAlteraCliente = new FrmCliente(cliente, parteContraria, processo, 'A');

                frmAlteraCliente.Text = "Altera Cliente";
                frmAlteraCliente.ShowDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show("SELECIONE UM REGISTRO PRIMEIRO!", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDgv();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                int idParteContraria = int.Parse(dgvClientes.CurrentRow.Cells[1].Value.ToString());
                int idProcesso = int.Parse(dgvClientes.CurrentRow.Cells[2].Value.ToString());

                Cliente cliente = new Cliente(idCliente);
                ParteContraria parteContraria = new ParteContraria(idParteContraria);
                Processo processo = new Processo(idProcesso);

                FrmCliente frmConsultaCliente = new FrmCliente(cliente, parteContraria, processo, 'C');

                frmConsultaCliente.Text = "Consulta Cliente";
                frmConsultaCliente.ShowDialog();
            }
            catch(Exception Err)
            {
                MessageBox.Show("SELECIONE UM REGISTRO PRIMEIRO!", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.PesquisaProcesso(dgvClientes,cbFiltros.Text,txtPesquisa.Text);
        }

        private void FrmConsultaClientes_Load(object sender, EventArgs e)
        {
            cbFiltros.SelectedIndex = 0;
           
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            FrmConsultaContratos frmConsultaContratos = new FrmConsultaContratos(usuaria);
            this.Hide();
            frmConsultaContratos.FormClosed += new FormClosedEventHandler(fechaForm);
            frmConsultaContratos.ShowDialog();
        }

        void fechaForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void FrmConsultaClientes_Activated(object sender, EventArgs e)
        {
            RefreshDgv();
        }
    }
}
