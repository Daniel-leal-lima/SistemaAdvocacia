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
        string tag = string.Empty;
        int contadorClickCelula = 0;
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
            cbDividoEm.SelectedIndex = 0;
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
                TrancaFormularioPraConsulta();
            }
            this.tag = tag.ToString();
        }
        public void TrancaFormularioPraConsulta()
        {
            foreach (Control objeto in this.Controls)
            {
                if (objeto is GroupBox)
                {
                    foreach (Control elemento in objeto.Controls)
                    {
                        if (elemento is TextBox)
                        {
                            TextBox obj = (TextBox)elemento;
                            obj.ReadOnly = true;
                        }
                        if (elemento is MaskedTextBox)
                        {
                            MaskedTextBox obj = (MaskedTextBox)elemento;
                            obj.ReadOnly = true;
                        }
                        if (elemento is RadioButton)
                        {
                            RadioButton obj = (RadioButton)elemento;
                            obj.Enabled = false;
                        }
                        if (elemento is ComboBox)
                        {
                            ComboBox obj = (ComboBox)elemento;
                            obj.DropDownStyle = ComboBoxStyle.Simple;
                            obj.KeyPress += Obj_KeyPress;
                            obj.BackColor = Control.DefaultBackColor;
                        }
                    }
                }
                if (objeto is RichTextBox)
                {
                    RichTextBox obj = (RichTextBox)objeto;
                    obj.ReadOnly = true;

                }
            }
        }
        private void Obj_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            if (tag.Equals(string.Empty))
                parcela.Valor = double.Parse(txtValorDasParcelas.Text);
            else
                parcela.Valor = double.Parse(txtValorParcela.Text);
            parcela.DataVencimento = DtpDataVencimento.Value.ToShortDateString();
            switch (cbSituacao.Text)
            {
                case "Pago":
                    parcela.Situacao = "P";
                    break;
                case "Devendo":
                    parcela.Situacao = "D";
                    break;
            }
            parcela.Observacao = RtxtObsParcela.Text;
            //CONTRATO
            contrato.IdProcesso = processo.IdProcesso;
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
            contrato.Observacoes = RtxtObsContrato.Text;
            contrato.DiaVencimento = txtDiaDeVencimento.Text;
            contrato.DataContrato = dtpDataContrato.Value.ToShortDateString();
            contrato.ValorTotal = double.Parse(txtValorTotal.Text);
            contrato.ValorEntrada = double.Parse(txtValorEntrada.Text);
            contrato.ValorComissao=double.Parse(txtValorComissao.Text);
            
        }
        public void Arranja(){
            //CLIENTE
            txtNomeRequerente.Text = cliente.Nome;
            mskTelefone.Text = cliente.Telefone;
            mskCpf.Text = cliente.Cpf;
            //PROCESSO
            mskNumProcesso.Text = processo.NumProcesso;
            switch (processo.FoiIndicacao)
            {
                case "S":
                    txtFoiIndicacao.Text = "Sim";
                    break;
                case "N":
                    txtFoiIndicacao.Text = "Não";
                    break;
            }
            txtNomeCaptador.Text = processo.NomeCaptador;
            txtLocalDescobrimento.Text = processo.LocalDescobrimento;
            processo.IdCliente = cliente.IdCliente;
            //PARCELA
            if (parcela.DataVencimento != null)
            {
                DtpDataVencimento.Value = DateTime.Parse(parcela.DataVencimento);
            }
            txtValorParcela.Text = parcela.Valor.ToString();
            switch (parcela.Situacao)
            {
                case "P":
                    cbSituacao.SelectedIndex = 1; //PAGO
                    break;
                case "D":
                    cbSituacao.SelectedIndex = 0; //DEVENDO
                    break;
            }
            RtxtObsParcela.Text = parcela.Observacao;
            //CONTRATO
            contrato.IdProcesso = processo.IdProcesso;
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
            RtxtObsContrato.Text = contrato.Observacoes;
            txtDiaDeVencimento.Text = contrato.DiaVencimento;
            if (contrato.DataContrato != null)
            {
                dtpDataContrato.Value = DateTime.Parse(contrato.DataContrato);
            }
            cbDividoEm.Text = contrato.QtdVezes.ToString();
            txtValorTotal.Text = contrato.ValorTotal.ToString();
            txtValorEntrada.Text = contrato.ValorEntrada.ToString();
            txtValorComissao.Text = contrato.ValorComissao.ToString();
            
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

        private void FrmContrato_Load(object sender, EventArgs e)
        {   
            cbSituacao.SelectedIndex = 0;
            cbDividoEm.SelectedIndex = 0;
            cbTipoDePagamento.SelectedIndex = 0;
            ToMoney(txtValorDasParcelas, "N2");
            ToMoney(txtValorParcela, "N2");
            ToMoney(txtValorTotal, "N2");
            ToMoney(txtValorEntrada, "N2");
            ToMoney(txtValorComissao, "N2");
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
            try
            {
                bool insercaoValida = ((txtFoiIndicacao.Text.Equals("Sim") &&
                                         double.Parse(txtValorComissao.Text) > 0) //VERIFICA SE FOI INDICACAO
                                        ||
                                        (txtFoiIndicacao.Text.Equals("Não"))
                                            ) &&
                    cbTipoDePagamento.Text.Length > 0 &&
                    double.Parse(txtValorTotal.Text) > 0 &&
                    txtDiaDeVencimento.Text.Replace(" ", "").Length > 0 &&
                    double.Parse(txtValorEntrada.Text) > 0 &&
                    dtpDataContrato.Text.Length > 0 &&
                                        ((double.Parse(txtValorDasParcelas.Text) > 0
                                            &&
                                            (double.Parse(txtValorEntrada.Text) <
                                            double.Parse(txtValorTotal.Text))))
                                        ||                       //VERIFICA SE O VALOR DA ENTRADA É IGUAL O TOTAL 
                                        (double.Parse(txtValorEntrada.Text) >=
                                        double.Parse(txtValorTotal.Text)) &&
                   int.Parse(cbDividoEm.Text) > 0;

                if (insercaoValida)
                {
                    InsereDadosNasClasses();

                    SqlAuxiliar sqlAux = new SqlAuxiliar();
                    if (btnCadastraCobranca.Text.Equals("Alterar Cobrança"))
                    {
                        //ALTERA
                        sqlAux.AlteraContrato(contrato);
                        MessageBox.Show("COBRANÇA ALTERADA!");
                        this.Close();
                    }
                    else
                    {
                        //CADASTRA
                        DtpDataVencimento.Value = dtpDataContrato.Value;
                        sqlAux.CadastraDivida(contrato, parcela, DtpDataVencimento);
                        MessageBox.Show("COBRANÇA CADASTRADA, VERIFIQUE A SITUAÇÃO DAS PARCELAS SE NECESSÁRIO!");

                        //A PARTIR DO MOMENTO QUE CADASTRA PODE ALTERAR
                        tag = "A";
                        btnCadastraCobranca.Text = "Alterar Cobrança";
                        btnAdicionaLinha.Visible = true;
                        btnRemoveLinha.Visible = true;
                        btnSalva.Visible = true;
                    }
                    RefreshDgv();
                }
                else
                {
                    MessageBox.Show("VERIFIQUE SE INSERIU OS DADOS CORRETAMENTE", "MENSAGEM",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void RefreshDgv()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            sqlAux.RefreshDivida(contrato,dgvParcelas);

            //ALEM DE DAR REFRESH NO DGV
            //TAMBÉM PEGAMOS O TOTAL DO QUANTO O CLIENTE JÁ PAGOU
            lblTotalJaPago.Visible = true;
            double totalAPagar = contrato.ValorTotal - sqlAux.SomaParcelas(contrato);
            if (totalAPagar > 0)
                lblTotalJaPago.Text = "TOTAL A PAGAR:" + "\n" +
                    totalAPagar.ToString("C", CultureInfo.CurrentCulture);
            else
                lblTotalJaPago.Text = "SITUAÇÃO:" + "\n" +
                    "QUITADO";
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            ToMoney(txtValorDasParcelas, "N2");
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
                cbDividoEm.SelectedIndex = 0;
            }
            else {
                lblDividido.Enabled = false;
                cbDividoEm.Text = "1";
                cbDividoEm.Enabled = false;
            }
        }


        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                contadorClickCelula++;
                parcela.IdParcela = int.Parse(dgvParcelas.CurrentRow.Cells[3].Value.ToString());
                parcela.Valor = Double.Parse(dgvParcelas.CurrentRow.Cells[4].Value.ToString());
                parcela.DataVencimento = dgvParcelas.CurrentRow.Cells[5].Value.ToString();
                parcela.Situacao = dgvParcelas.CurrentRow.Cells[6].Value.ToString();
                parcela.Observacao = dgvParcelas.CurrentRow.Cells[7].Value.ToString();
                Arranja();
                gpParcela.Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO!");
            }
        }

        private void btnAdicionaLinha_Click(object sender, EventArgs e)
        {
            if (gpParcela.Visible)
            {
                var dialogoConfirmacao =
                    MessageBox.Show("TEM CERTEZA QUE QUER ADICIONAR UMA NOVA PARCELA?",
                                         "CAIXA DE CONFIRMAÇÃO",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Information);
                if (dialogoConfirmacao == DialogResult.Yes)
                {
                    SqlAuxiliar sqlAux = new SqlAuxiliar();
                    InsereDadosNasClasses();
                    sqlAux.CadastraParcela(parcela);
                    RefreshDgv();
                }
            }
            else
            {
                gpParcela.Visible = true;
            }
        }

        private void btnRemoveLinha_Click(object sender, EventArgs e)
        {
            var dialogoConfirmacao = 
                MessageBox.Show("TEM CERTEZA QUE QUER DELETAR ESSA PARCELA?",
                                     "CAIXA DE CONFIRMAÇÃO",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);
            if (dialogoConfirmacao == DialogResult.Yes)
            {
                SqlAuxiliar sqlAux = new SqlAuxiliar();
                InsereDadosNasClasses();
                sqlAux.RemoveParcela(parcela);
                RefreshDgv();
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            sqlAux.AlteraParcela(parcela);
            RefreshDgv();
        }

        private void FormataTextoEmDinheiro(object sender, EventArgs e)
        {
            TextBox caixaTexto = (TextBox)sender;
            ToMoney(caixaTexto, "N2");
        }

        private void gpParcela_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (!dtpDataContrato.Value.Day.ToString().Equals("5"))
            {
                dtpDataContrato.Value = dtpDataContrato.Value.AddDays(1);
            }
            
        }

        private void dgvParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (tag.Equals("A"))
            {
                parcela.IdParcela = int.Parse(dgvParcelas.CurrentRow.Cells[3].Value.ToString());
                parcela.Valor = Double.Parse(dgvParcelas.CurrentRow.Cells[4].Value.ToString());
                parcela.DataVencimento = dgvParcelas.CurrentRow.Cells[5].Value.ToString();

                switch (parcela.Situacao = dgvParcelas.CurrentRow.Cells[6].Value.ToString())
                {
                    case "Pago":
                        parcela.Situacao = "D";
                        break;
                    case "Devendo":
                        parcela.Situacao = "P";
                        break;
                }
                parcela.Observacao = dgvParcelas.CurrentRow.Cells[7].Value.ToString();
                Arranja();
                gpParcela.Visible = true;
                SqlAuxiliar sqlAux = new SqlAuxiliar();
                sqlAux.AlteraParcelaRapido(parcela);
                RefreshDgv();
            }
        }
    }
}
