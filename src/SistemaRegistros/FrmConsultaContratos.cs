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
    public partial class FrmConsultaContratos : Form
    {
        Usuaria usuaria = new Usuaria();
        public FrmConsultaContratos()
        {
            InitializeComponent();
            RefreshDgv();
        }
        public FrmConsultaContratos(Usuaria usuaria)
        {
            InitializeComponent();
            RefreshDgv();
            this.usuaria = usuaria;
        }

        private void RefreshDgv()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.RefreshContratos(dgvContratos);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(dgvContratos.CurrentRow.Cells[0].Value.ToString());
                int idProcesso = int.Parse(dgvContratos.CurrentRow.Cells[1].Value.ToString());

                Cliente cliente = new Cliente(idCliente);
                Processo processo = new Processo(idProcesso);
                FrmContrato frmCadastraContrato = new FrmContrato(cliente, processo);

                frmCadastraContrato.Text = "Cadastra Contrato";
                frmCadastraContrato.ShowDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show("SELECIONE UM REGISTRO PRIMEIRO!", "Erro", MessageBoxButtons.OK);
            }
        }

        private void FrmConsultaContratos_Load(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = false;
            cbFiltros.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDgv();
            cbFiltros.SelectedIndex = 0;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.PesquisaContrato(dgvContratos, cbFiltros.Text,txtPesquisa.Text,
                cbFiltros.SelectedIndex);
        }

        private void cbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
                SqlAuxiliar sqlAux = new SqlAuxiliar();
                switch (cb.SelectedIndex)
                {
                    
                    case 5: // ITEM : PROCESSOS NÃO REGISTRADOS
                        btnCadastrar.Enabled = true;
                        btnVer.Enabled = false;
                        btnAlterar.Enabled = false;
                        
                        sqlAux.PesquisaContrato(dgvContratos, cb.Text, string.Empty, cb.SelectedIndex);
                        break;
                    default:
                        btnCadastrar.Enabled = false;
                        btnVer.Enabled = true;
                        btnAlterar.Enabled = true;
                        break;

                }                
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(dgvContratos.CurrentRow.Cells[0].Value.ToString());
                int idProcesso = int.Parse(dgvContratos.CurrentRow.Cells[1].Value.ToString());
                int idContrato = int.Parse(dgvContratos.CurrentRow.Cells[2].Value.ToString());

                Cliente cliente = new Cliente(idCliente);
                Processo processo = new Processo(idProcesso);
                Contrato contrato = new Contrato(idContrato);
                FrmContrato frmAlteraContrato = new FrmContrato(cliente, processo,
                    contrato, 'A');
                frmAlteraContrato.Text = "Altera Contrato";
                frmAlteraContrato.ShowDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show("SELECIONE UM REGISTRO PRIMEIRO!", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(dgvContratos.CurrentRow.Cells[0].Value.ToString());
                int idProcesso = int.Parse(dgvContratos.CurrentRow.Cells[1].Value.ToString());
                int idContrato = int.Parse(dgvContratos.CurrentRow.Cells[2].Value.ToString());

                Cliente cliente = new Cliente(idCliente);
                Processo processo = new Processo(idProcesso);
                Contrato contrato = new Contrato(idContrato);
                FrmContrato frmVisualizaContrato = new FrmContrato(cliente, processo,
                    contrato, 'C');
                frmVisualizaContrato.Text = "Consulta Contrato";
                frmVisualizaContrato.ShowDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show("SELECIONE UM REGISTRO PRIMEIRO!", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmConsultaClientes frmConsultaClientes = new FrmConsultaClientes(usuaria);
            this.Hide();
            frmConsultaClientes.FormClosed += new FormClosedEventHandler(fechaForm);
            frmConsultaClientes.ShowDialog();
        }

        public void fechaForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void FrmConsultaContratos_Activated(object sender, EventArgs e)
        {
            //cbFiltros.SelectedIndex = 0;
            //RefreshDgv();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRelatorio = new FrmRelatorio();
            frmRelatorio.ShowDialog();
        }
    }
}
