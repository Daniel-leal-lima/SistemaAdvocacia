using SistemaRegistros.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros
{
    public partial class FrmContrato : Form
    {
        Cliente cliente = new Cliente();
        Processo processo = new Processo();
        Contrato contrato = new Contrato();
        Parcelas parcela = new Parcelas();
        public FrmContrato()
        {
            InitializeComponent();
        }
        public FrmContrato(Cliente cliente,Processo processo)
        {
            InitializeComponent();
            this.processo = processo;
            this.cliente = cliente;
            LocalizaProcessoDoCliente();
            Arranja();
            IdentificaContrato();

        }

        public FrmContrato(Cliente cliente,
            Processo processo, Contrato contrato, char tag) 
        {
            InitializeComponent();
            this.processo = processo;
            this.cliente = cliente;
            this.contrato = contrato;
            LocalizaProcessoDoCliente();
            LocalizaContrato();
            Arranja();
            if (tag.Equals('A')) {                              //CASO A USUARIA FOR ALTERAR ALGUM REGISTRO
                btnCadastraCobranca.Text = "Alterar Cobrança";
                btnAdicionaLinha.Visible = true;
                btnRemoveLinha.Visible = true;
                btnSalva.Visible = true;
            }
            else                                                //CASO A USUARIA FOR cONSULTAR ALGUM REGISTRO
            {
                btnCadastraCobranca.Visible = false;
                PegaIndiceParcelas();
            }   
        }

        public void LocalizaProcessoDoCliente()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.LocalizaProcesso(cliente, processo);
        }
        public void InsereDadosNasClasses() {
            //CLIENTE
            cliente.Nome = txtNomeRequerente.Text;
            cliente.Telefone = mskTelefone.Text ;
            cliente.Cpf = mskCpf.Text;
            //PROCESSO
            processo.NumProcesso = mskNumProcesso.Text;
            processo.IdCliente = cliente.IdCliente;
            //PARCELA
            parcela.IdContrato = contrato.IdContrato;
            parcela.IdCliente = cliente.IdCliente;
            parcela.DataPagamento = mskDataVencimento.Text.Replace(" ","");
            parcela.Valor = double.Parse(txtValor.Text);
            //parcela.Observacao = ?
            switch (cbSituacao.Text)
            {
                case "Pago":
                    parcela.Situacao = "P";
                    break;
                case "Devendo":
                    parcela.Situacao = "D";
                    break;
            }
            //CONTRATO
            contrato.IdProcesso = processo.IdProcesso;
            contrato.Observacoes = RtxtObs.Text;
            contrato.DataContrato = mskDataContrato.Text.Replace(" ","");
            contrato.ValorTotal = double.Parse(txtValorTotal.Text);
            contrato.ValorEntrada = double.Parse(txtValorEntrada.Text);
            contrato.ValorComissao=double.Parse(txtValorComissao.Text);
            
            switch (cbTipoDePagamento.Text)
            {
                case "Cartão":
                    contrato.TipoPagamento = "C";
                    contrato.QtdVezes = int.Parse(cbDividoEm.Text);
                    break;
                case "Boleto":
                    contrato.TipoPagamento = "B";
                    contrato.QtdVezes = int.Parse(cbDividoEm.Text);
                    break;
                case "À Vista":
                    contrato.TipoPagamento = "A";
                    contrato.QtdVezes = 1;
                    break;
            }
        }
        public void Arranja(){
            //CLIENTE
            txtNomeRequerente.Text = cliente.Nome;
            mskTelefone.Text = cliente.Telefone;
            mskCpf.Text = cliente.Cpf;
            //PROCESSO
            mskNumProcesso.Text = processo.NumProcesso;
            //cbTipoAcao.Text = processo.TipoAcao;
            //cbArea.Text = processo.Area;
            processo.IdCliente = cliente.IdCliente;
            //PARCELA
            mskDataVencimento.Text = parcela.DataPagamento;
            txtValor.Text = parcela.Valor.ToString();
            switch (parcela.Situacao)
            {
                case "P":
                    cbSituacao.SelectedIndex = 0;
                    break;
                case "D":
                    cbSituacao.SelectedIndex = 1;
                    break;
            }
            //CONTRATO
            contrato.IdProcesso = processo.IdProcesso;
            RtxtObs.Text = contrato.Observacoes;
            switch (contrato.TipoPagamento)
            {
                case "C":
                    cbTipoDePagamento.SelectedIndex = 0;
                    break;
                case "B":
                    cbTipoDePagamento.SelectedIndex = 1;
                    break;
                case "A":
                    cbTipoDePagamento.SelectedIndex = 2;
                    break;
            }
        }
        public void IdentificaContrato() {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.PegaUltimoIdContrato(contrato);
        }
        public void LocalizaContrato() {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.LocalizaContrato(contrato);
            RefreshDgv();
        }
        public void PegaIndiceParcelas() {
            int numero = dgvParcelas.Rows.Count-1;
            if (numero == 1 )
            {
                cbDividoEm.Enabled = false;
            }
            else
            {
                cbDividoEm.Text = numero.ToString();
            }
        }

        private void FrmContrato_Load(object sender, EventArgs e)
        {   
            cbSituacao.SelectedIndex = 0;
            cbDividoEm.SelectedIndex = 0;
            cbTipoDePagamento.SelectedIndex = 0;
            ToMoney(txtValor, "N2");
            Arranja();
            mskDataVencimento.Text = DateTime.Today.ToString("dd/MM/yy");
        }

        public void ToMoney(TextBox text, string format = "C2")
        {
            double value;
            if (double.TryParse(text.Text, out value))
            {
                text.Text = value.ToString(format);
            }
            else
            {
                text.Text = "0,00";
            }
        }

        private void btnCadastraCobranca_Click(object sender, EventArgs e)
        {
            
            InsereDadosNasClasses();
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            if (btnCadastraCobranca.Text.Equals("Alterar Cobrança")) {
                //ALTERA
                sqlAux.AlteraContrato(contrato);
            }
            else {
            //CADASTRA
                if (!cbDividoEm.Enabled)
                {
                    sqlAux.CadastraDivida(contrato, parcela, 1);
                }
                else
                {
                    int qtdVezes = int.Parse(cbDividoEm.Text);
                    sqlAux.CadastraDivida(contrato, parcela, qtdVezes);
                }
            }
            RefreshDgv();
            /*MessageBox.Show(contrato.ToString()+"\n"+
                parcela.ToString());*/
        }

        private void RefreshDgv()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.RefreshDivida(contrato,dgvParcelas);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            ToMoney(txtValor, "N2");
        }

        private void mskDataCobranca_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbTipoDePagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if ((cb.SelectedIndex == 0) || (cb.SelectedIndex == 1))
            {
                lblDividido.Enabled = true;
                cbDividoEm.Enabled = true;
            }
            else {
                lblDividido.Enabled = false;
                cbDividoEm.Text = "1";
                cbDividoEm.Enabled = false;
            }
        }

        private void dgvParcelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                parcela.IdParcela = int.Parse(dgvParcelas.CurrentRow.Cells[3].Value.ToString());
                parcela.Valor = Double.Parse(dgvParcelas.CurrentRow.Cells[4].Value.ToString());
                parcela.DataPagamento = dgvParcelas.CurrentRow.Cells[5].Value.ToString();
                parcela.Situacao = dgvParcelas.CurrentRow.Cells[6].Value.ToString();
                Arranja();
            }
            catch (Exception err)
            {
                MessageBox.Show("Você só poderá alterar um registro quando tiver um!");
            }
        }

        private void btnAdicionaLinha_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            sqlAux.CadastraParcela(parcela);
            RefreshDgv();
        }

        private void btnRemoveLinha_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            sqlAux.RemoveParcela(parcela);
            RefreshDgv();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            sqlAux.AlteraParcela(parcela);
            RefreshDgv();
        }
    }
}
