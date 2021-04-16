
namespace SistemaRegistros
{
    partial class FrmContrato
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContrato));
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.RtxtObsContrato = new System.Windows.Forms.RichTextBox();
            this.lblObsContrato = new System.Windows.Forms.Label();
            this.lblNProcesso = new System.Windows.Forms.Label();
            this.gpCobranca = new System.Windows.Forms.GroupBox();
            this.dtpDataContrato = new System.Windows.Forms.DateTimePicker();
            this.lblTotalJaPago = new System.Windows.Forms.Label();
            this.lblDataContrato = new System.Windows.Forms.Label();
            this.txtValorEntrada = new System.Windows.Forms.TextBox();
            this.lblValorEntrada = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtDiaDeVencimento = new System.Windows.Forms.TextBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorDasParcelas = new System.Windows.Forms.TextBox();
            this.lblDiaVencimento = new System.Windows.Forms.Label();
            this.lblValorAParcelar = new System.Windows.Forms.Label();
            this.cbTipoDePagamento = new System.Windows.Forms.ComboBox();
            this.lblDividido = new System.Windows.Forms.Label();
            this.cbDividoEm = new System.Windows.Forms.ComboBox();
            this.lbltipopagamento = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.btnCadastraCobranca = new System.Windows.Forms.Button();
            this.mskNumProcesso = new System.Windows.Forms.MaskedTextBox();
            this.btnAdicionaLinha = new System.Windows.Forms.Button();
            this.btnRemoveLinha = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.gpParcela = new System.Windows.Forms.GroupBox();
            this.DtpDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.lblNomeRequerente = new System.Windows.Forms.Label();
            this.txtNomeRequerente = new System.Windows.Forms.TextBox();
            this.lblCpfRquerente = new System.Windows.Forms.Label();
            this.mskCpf = new System.Windows.Forms.MaskedTextBox();
            this.lbltelefone = new System.Windows.Forms.Label();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.gpRequerente = new System.Windows.Forms.GroupBox();
            this.gpCaptador = new System.Windows.Forms.GroupBox();
            this.txtLocalDescobrimento = new System.Windows.Forms.TextBox();
            this.lblLocalDescobrimento = new System.Windows.Forms.Label();
            this.txtFoiIndicacao = new System.Windows.Forms.TextBox();
            this.lblValorComissao = new System.Windows.Forms.Label();
            this.txtValorComissao = new System.Windows.Forms.TextBox();
            this.txtNomeCaptador = new System.Windows.Forms.TextBox();
            this.lblNomeIndicacao = new System.Windows.Forms.Label();
            this.lblFoiIndicacao = new System.Windows.Forms.Label();
            this.lblObsParcela = new System.Windows.Forms.Label();
            this.RtxtObsParcela = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.gpCobranca.SuspendLayout();
            this.gpParcela.SuspendLayout();
            this.gpRequerente.SuspendLayout();
            this.gpCaptador.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Location = new System.Drawing.Point(12, 551);
            this.dgvParcelas.MultiSelect = false;
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.RowHeadersVisible = false;
            this.dgvParcelas.RowTemplate.Height = 25;
            this.dgvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParcelas.Size = new System.Drawing.Size(279, 108);
            this.dgvParcelas.TabIndex = 9;
            this.dgvParcelas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParcelas_CellClick);
            this.dgvParcelas.DoubleClick += new System.EventHandler(this.dgvParcelas_DoubleClick);
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(12, 533);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(53, 15);
            this.lblParcelas.TabIndex = 10;
            this.lblParcelas.Text = "Parcelas:";
            // 
            // RtxtObsContrato
            // 
            this.RtxtObsContrato.Location = new System.Drawing.Point(597, 69);
            this.RtxtObsContrato.Name = "RtxtObsContrato";
            this.RtxtObsContrato.Size = new System.Drawing.Size(249, 377);
            this.RtxtObsContrato.TabIndex = 11;
            this.RtxtObsContrato.Text = "";
            // 
            // lblObsContrato
            // 
            this.lblObsContrato.AutoSize = true;
            this.lblObsContrato.Location = new System.Drawing.Point(597, 51);
            this.lblObsContrato.Name = "lblObsContrato";
            this.lblObsContrato.Size = new System.Drawing.Size(144, 15);
            this.lblObsContrato.TabIndex = 12;
            this.lblObsContrato.Text = "Observações do Contrato:";
            // 
            // lblNProcesso
            // 
            this.lblNProcesso.AutoSize = true;
            this.lblNProcesso.Location = new System.Drawing.Point(129, 11);
            this.lblNProcesso.Name = "lblNProcesso";
            this.lblNProcesso.Size = new System.Drawing.Size(121, 15);
            this.lblNProcesso.TabIndex = 16;
            this.lblNProcesso.Text = "Número do processo:";
            // 
            // gpCobranca
            // 
            this.gpCobranca.Controls.Add(this.dtpDataContrato);
            this.gpCobranca.Controls.Add(this.lblTotalJaPago);
            this.gpCobranca.Controls.Add(this.lblDataContrato);
            this.gpCobranca.Controls.Add(this.txtValorEntrada);
            this.gpCobranca.Controls.Add(this.lblValorEntrada);
            this.gpCobranca.Controls.Add(this.txtValorTotal);
            this.gpCobranca.Controls.Add(this.txtDiaDeVencimento);
            this.gpCobranca.Controls.Add(this.lblValorTotal);
            this.gpCobranca.Controls.Add(this.txtValorDasParcelas);
            this.gpCobranca.Controls.Add(this.lblDiaVencimento);
            this.gpCobranca.Controls.Add(this.lblValorAParcelar);
            this.gpCobranca.Controls.Add(this.cbTipoDePagamento);
            this.gpCobranca.Controls.Add(this.lblDividido);
            this.gpCobranca.Controls.Add(this.cbDividoEm);
            this.gpCobranca.Controls.Add(this.lbltipopagamento);
            this.gpCobranca.Location = new System.Drawing.Point(12, 244);
            this.gpCobranca.Name = "gpCobranca";
            this.gpCobranca.Size = new System.Drawing.Size(543, 189);
            this.gpCobranca.TabIndex = 20;
            this.gpCobranca.TabStop = false;
            this.gpCobranca.Text = "informações de Cobrança:";
            // 
            // dtpDataContrato
            // 
            this.dtpDataContrato.CustomFormat = "00/00/00";
            this.dtpDataContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataContrato.Location = new System.Drawing.Point(393, 113);
            this.dtpDataContrato.Name = "dtpDataContrato";
            this.dtpDataContrato.Size = new System.Drawing.Size(91, 23);
            this.dtpDataContrato.TabIndex = 37;
            // 
            // lblTotalJaPago
            // 
            this.lblTotalJaPago.AutoSize = true;
            this.lblTotalJaPago.Location = new System.Drawing.Point(308, 157);
            this.lblTotalJaPago.Name = "lblTotalJaPago";
            this.lblTotalJaPago.Size = new System.Drawing.Size(38, 15);
            this.lblTotalJaPago.TabIndex = 36;
            this.lblTotalJaPago.Text = "label1";
            this.lblTotalJaPago.Visible = false;
            // 
            // lblDataContrato
            // 
            this.lblDataContrato.AutoSize = true;
            this.lblDataContrato.Location = new System.Drawing.Point(287, 116);
            this.lblDataContrato.Name = "lblDataContrato";
            this.lblDataContrato.Size = new System.Drawing.Size(106, 15);
            this.lblDataContrato.TabIndex = 33;
            this.lblDataContrato.Text = "*Data do Contrato:";
            // 
            // txtValorEntrada
            // 
            this.txtValorEntrada.Location = new System.Drawing.Point(124, 110);
            this.txtValorEntrada.Name = "txtValorEntrada";
            this.txtValorEntrada.Size = new System.Drawing.Size(100, 23);
            this.txtValorEntrada.TabIndex = 34;
            this.txtValorEntrada.TextChanged += new System.EventHandler(this.FormataTextoEmDinheiro);
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.AutoSize = true;
            this.lblValorEntrada.Location = new System.Drawing.Point(29, 113);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(84, 15);
            this.lblValorEntrada.TabIndex = 33;
            this.lblValorEntrada.Text = "*Valor Entrada:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(124, 71);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(100, 23);
            this.txtValorTotal.TabIndex = 32;
            this.txtValorTotal.TextChanged += new System.EventHandler(this.FormataTextoEmDinheiro);
            // 
            // txtDiaDeVencimento
            // 
            this.txtDiaDeVencimento.Location = new System.Drawing.Point(398, 68);
            this.txtDiaDeVencimento.Name = "txtDiaDeVencimento";
            this.txtDiaDeVencimento.Size = new System.Drawing.Size(41, 23);
            this.txtDiaDeVencimento.TabIndex = 21;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(44, 71);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(69, 15);
            this.lblValorTotal.TabIndex = 31;
            this.lblValorTotal.Text = "*Valor Total:";
            // 
            // txtValorDasParcelas
            // 
            this.txtValorDasParcelas.Location = new System.Drawing.Point(124, 149);
            this.txtValorDasParcelas.Name = "txtValorDasParcelas";
            this.txtValorDasParcelas.Size = new System.Drawing.Size(100, 23);
            this.txtValorDasParcelas.TabIndex = 19;
            this.txtValorDasParcelas.TextChanged += new System.EventHandler(this.FormataTextoEmDinheiro);
            // 
            // lblDiaVencimento
            // 
            this.lblDiaVencimento.AutoSize = true;
            this.lblDiaVencimento.Location = new System.Drawing.Point(283, 71);
            this.lblDiaVencimento.Name = "lblDiaVencimento";
            this.lblDiaVencimento.Size = new System.Drawing.Size(114, 15);
            this.lblDiaVencimento.TabIndex = 20;
            this.lblDiaVencimento.Text = "*Dia de Vencimento:";
            // 
            // lblValorAParcelar
            // 
            this.lblValorAParcelar.AutoSize = true;
            this.lblValorAParcelar.Location = new System.Drawing.Point(28, 152);
            this.lblValorAParcelar.Name = "lblValorAParcelar";
            this.lblValorAParcelar.Size = new System.Drawing.Size(95, 15);
            this.lblValorAParcelar.TabIndex = 18;
            this.lblValorAParcelar.Text = "*Valor a Parcelar:";
            // 
            // cbTipoDePagamento
            // 
            this.cbTipoDePagamento.FormattingEnabled = true;
            this.cbTipoDePagamento.Items.AddRange(new object[] {
            "Cartão",
            "Boleto",
            "À Vista"});
            this.cbTipoDePagamento.Location = new System.Drawing.Point(124, 25);
            this.cbTipoDePagamento.Name = "cbTipoDePagamento";
            this.cbTipoDePagamento.Size = new System.Drawing.Size(121, 23);
            this.cbTipoDePagamento.TabIndex = 17;
            this.cbTipoDePagamento.SelectedIndexChanged += new System.EventHandler(this.cbTipoDePagamento_SelectedIndexChanged);
            // 
            // lblDividido
            // 
            this.lblDividido.AutoSize = true;
            this.lblDividido.Location = new System.Drawing.Point(283, 28);
            this.lblDividido.Name = "lblDividido";
            this.lblDividido.Size = new System.Drawing.Size(74, 15);
            this.lblDividido.TabIndex = 12;
            this.lblDividido.Text = "Dividido em:";
            // 
            // cbDividoEm
            // 
            this.cbDividoEm.AllowDrop = true;
            this.cbDividoEm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDividoEm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDividoEm.FormattingEnabled = true;
            this.cbDividoEm.Items.AddRange(new object[] {
            "3",
            "4",
            "10"});
            this.cbDividoEm.Location = new System.Drawing.Point(363, 25);
            this.cbDividoEm.Name = "cbDividoEm";
            this.cbDividoEm.Size = new System.Drawing.Size(121, 23);
            this.cbDividoEm.TabIndex = 11;
            // 
            // lbltipopagamento
            // 
            this.lbltipopagamento.AutoSize = true;
            this.lbltipopagamento.Location = new System.Drawing.Point(6, 29);
            this.lbltipopagamento.Name = "lbltipopagamento";
            this.lbltipopagamento.Size = new System.Drawing.Size(118, 15);
            this.lbltipopagamento.TabIndex = 0;
            this.lbltipopagamento.Text = "*Tipo de pagamento:";
            // 
            // cbSituacao
            // 
            this.cbSituacao.AllowDrop = true;
            this.cbSituacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSituacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Devendo",
            "Pago"});
            this.cbSituacao.Location = new System.Drawing.Point(349, 27);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(121, 23);
            this.cbSituacao.TabIndex = 16;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.Location = new System.Drawing.Point(6, 57);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(116, 15);
            this.lblDataVencimento.TabIndex = 15;
            this.lblDataVencimento.Text = "Data de Vencimento:";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(288, 30);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(55, 15);
            this.lblSituacao.TabIndex = 13;
            this.lblSituacao.Text = "Situação:";
            // 
            // btnCadastraCobranca
            // 
            this.btnCadastraCobranca.Location = new System.Drawing.Point(640, 535);
            this.btnCadastraCobranca.Name = "btnCadastraCobranca";
            this.btnCadastraCobranca.Size = new System.Drawing.Size(180, 124);
            this.btnCadastraCobranca.TabIndex = 21;
            this.btnCadastraCobranca.Text = "Cadastrar Cobrança";
            this.btnCadastraCobranca.UseVisualStyleBackColor = true;
            this.btnCadastraCobranca.Click += new System.EventHandler(this.btnCadastraCobranca_Click);
            // 
            // mskNumProcesso
            // 
            this.mskNumProcesso.Location = new System.Drawing.Point(256, 8);
            this.mskNumProcesso.Mask = "0000000-00\\.0000\\.0\\.00\\.0000";
            this.mskNumProcesso.Name = "mskNumProcesso";
            this.mskNumProcesso.ReadOnly = true;
            this.mskNumProcesso.Size = new System.Drawing.Size(134, 23);
            this.mskNumProcesso.TabIndex = 26;
            // 
            // btnAdicionaLinha
            // 
            this.btnAdicionaLinha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionaLinha.BackgroundImage")));
            this.btnAdicionaLinha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionaLinha.Location = new System.Drawing.Point(297, 596);
            this.btnAdicionaLinha.Name = "btnAdicionaLinha";
            this.btnAdicionaLinha.Size = new System.Drawing.Size(26, 21);
            this.btnAdicionaLinha.TabIndex = 28;
            this.btnAdicionaLinha.UseVisualStyleBackColor = true;
            this.btnAdicionaLinha.Visible = false;
            this.btnAdicionaLinha.Click += new System.EventHandler(this.btnAdicionaLinha_Click);
            // 
            // btnRemoveLinha
            // 
            this.btnRemoveLinha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveLinha.BackgroundImage")));
            this.btnRemoveLinha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveLinha.Location = new System.Drawing.Point(297, 623);
            this.btnRemoveLinha.Name = "btnRemoveLinha";
            this.btnRemoveLinha.Size = new System.Drawing.Size(26, 21);
            this.btnRemoveLinha.TabIndex = 29;
            this.btnRemoveLinha.UseVisualStyleBackColor = true;
            this.btnRemoveLinha.Visible = false;
            this.btnRemoveLinha.Click += new System.EventHandler(this.btnRemoveLinha_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalva.BackgroundImage")));
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalva.Location = new System.Drawing.Point(297, 569);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(26, 21);
            this.btnSalva.TabIndex = 30;
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Visible = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // gpParcela
            // 
            this.gpParcela.Controls.Add(this.DtpDataVencimento);
            this.gpParcela.Controls.Add(this.txtValorParcela);
            this.gpParcela.Controls.Add(this.lblValorParcela);
            this.gpParcela.Controls.Add(this.cbSituacao);
            this.gpParcela.Controls.Add(this.lblSituacao);
            this.gpParcela.Controls.Add(this.lblDataVencimento);
            this.gpParcela.Location = new System.Drawing.Point(12, 439);
            this.gpParcela.Name = "gpParcela";
            this.gpParcela.Size = new System.Drawing.Size(543, 86);
            this.gpParcela.TabIndex = 31;
            this.gpParcela.TabStop = false;
            this.gpParcela.Text = "Informações de Parcela:";
            this.gpParcela.Visible = false;
            this.gpParcela.Enter += new System.EventHandler(this.gpParcela_Enter);
            // 
            // DtpDataVencimento
            // 
            this.DtpDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDataVencimento.Location = new System.Drawing.Point(123, 54);
            this.DtpDataVencimento.Name = "DtpDataVencimento";
            this.DtpDataVencimento.Size = new System.Drawing.Size(100, 23);
            this.DtpDataVencimento.TabIndex = 38;
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(123, 25);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.Size = new System.Drawing.Size(100, 23);
            this.txtValorParcela.TabIndex = 18;
            this.txtValorParcela.TextChanged += new System.EventHandler(this.FormataTextoEmDinheiro);
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.AutoSize = true;
            this.lblValorParcela.Location = new System.Drawing.Point(28, 28);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(93, 15);
            this.lblValorParcela.TabIndex = 17;
            this.lblValorParcela.Text = "Valor da Parcela:";
            // 
            // lblNomeRequerente
            // 
            this.lblNomeRequerente.AutoSize = true;
            this.lblNomeRequerente.Location = new System.Drawing.Point(4, 44);
            this.lblNomeRequerente.Name = "lblNomeRequerente";
            this.lblNomeRequerente.Size = new System.Drawing.Size(97, 15);
            this.lblNomeRequerente.TabIndex = 0;
            this.lblNomeRequerente.Text = "Nome completo:";
            // 
            // txtNomeRequerente
            // 
            this.txtNomeRequerente.Location = new System.Drawing.Point(104, 39);
            this.txtNomeRequerente.Name = "txtNomeRequerente";
            this.txtNomeRequerente.ReadOnly = true;
            this.txtNomeRequerente.Size = new System.Drawing.Size(192, 23);
            this.txtNomeRequerente.TabIndex = 1;
            // 
            // lblCpfRquerente
            // 
            this.lblCpfRquerente.AutoSize = true;
            this.lblCpfRquerente.Location = new System.Drawing.Point(321, 42);
            this.lblCpfRquerente.Name = "lblCpfRquerente";
            this.lblCpfRquerente.Size = new System.Drawing.Size(31, 15);
            this.lblCpfRquerente.TabIndex = 2;
            this.lblCpfRquerente.Text = "CPF:";
            // 
            // mskCpf
            // 
            this.mskCpf.Location = new System.Drawing.Point(359, 39);
            this.mskCpf.Mask = "000\\.000\\.000-00";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.ReadOnly = true;
            this.mskCpf.Size = new System.Drawing.Size(80, 23);
            this.mskCpf.TabIndex = 10;
            // 
            // lbltelefone
            // 
            this.lbltelefone.AutoSize = true;
            this.lbltelefone.Location = new System.Drawing.Point(44, 76);
            this.lbltelefone.Name = "lbltelefone";
            this.lbltelefone.Size = new System.Drawing.Size(54, 15);
            this.lbltelefone.TabIndex = 11;
            this.lbltelefone.Text = "Telefone:";
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(104, 73);
            this.mskTelefone.Mask = "(99) 00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.ReadOnly = true;
            this.mskTelefone.Size = new System.Drawing.Size(81, 23);
            this.mskTelefone.TabIndex = 12;
            // 
            // gpRequerente
            // 
            this.gpRequerente.Controls.Add(this.mskTelefone);
            this.gpRequerente.Controls.Add(this.lbltelefone);
            this.gpRequerente.Controls.Add(this.mskCpf);
            this.gpRequerente.Controls.Add(this.lblCpfRquerente);
            this.gpRequerente.Controls.Add(this.txtNomeRequerente);
            this.gpRequerente.Controls.Add(this.lblNomeRequerente);
            this.gpRequerente.Location = new System.Drawing.Point(12, 51);
            this.gpRequerente.Name = "gpRequerente";
            this.gpRequerente.Size = new System.Drawing.Size(543, 103);
            this.gpRequerente.TabIndex = 27;
            this.gpRequerente.TabStop = false;
            this.gpRequerente.Text = "informações do Requerente:";
            // 
            // gpCaptador
            // 
            this.gpCaptador.Controls.Add(this.txtLocalDescobrimento);
            this.gpCaptador.Controls.Add(this.lblLocalDescobrimento);
            this.gpCaptador.Controls.Add(this.txtFoiIndicacao);
            this.gpCaptador.Controls.Add(this.lblValorComissao);
            this.gpCaptador.Controls.Add(this.txtValorComissao);
            this.gpCaptador.Controls.Add(this.txtNomeCaptador);
            this.gpCaptador.Controls.Add(this.lblNomeIndicacao);
            this.gpCaptador.Controls.Add(this.lblFoiIndicacao);
            this.gpCaptador.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gpCaptador.Location = new System.Drawing.Point(12, 160);
            this.gpCaptador.Name = "gpCaptador";
            this.gpCaptador.Size = new System.Drawing.Size(543, 78);
            this.gpCaptador.TabIndex = 32;
            this.gpCaptador.TabStop = false;
            this.gpCaptador.Text = "Informações de Captador";
            // 
            // txtLocalDescobrimento
            // 
            this.txtLocalDescobrimento.Location = new System.Drawing.Point(365, 16);
            this.txtLocalDescobrimento.Name = "txtLocalDescobrimento";
            this.txtLocalDescobrimento.ReadOnly = true;
            this.txtLocalDescobrimento.Size = new System.Drawing.Size(100, 23);
            this.txtLocalDescobrimento.TabIndex = 41;
            // 
            // lblLocalDescobrimento
            // 
            this.lblLocalDescobrimento.AutoSize = true;
            this.lblLocalDescobrimento.Location = new System.Drawing.Point(235, 21);
            this.lblLocalDescobrimento.Name = "lblLocalDescobrimento";
            this.lblLocalDescobrimento.Size = new System.Drawing.Size(122, 15);
            this.lblLocalDescobrimento.TabIndex = 40;
            this.lblLocalDescobrimento.Text = "Forma de Descoberta:";
            // 
            // txtFoiIndicacao
            // 
            this.txtFoiIndicacao.Location = new System.Drawing.Point(106, 21);
            this.txtFoiIndicacao.Name = "txtFoiIndicacao";
            this.txtFoiIndicacao.ReadOnly = true;
            this.txtFoiIndicacao.Size = new System.Drawing.Size(58, 23);
            this.txtFoiIndicacao.TabIndex = 39;
            // 
            // lblValorComissao
            // 
            this.lblValorComissao.AutoSize = true;
            this.lblValorComissao.Location = new System.Drawing.Point(287, 48);
            this.lblValorComissao.Name = "lblValorComissao";
            this.lblValorComissao.Size = new System.Drawing.Size(96, 15);
            this.lblValorComissao.TabIndex = 38;
            this.lblValorComissao.Text = "*Valor Comissão:";
            // 
            // txtValorComissao
            // 
            this.txtValorComissao.Location = new System.Drawing.Point(384, 43);
            this.txtValorComissao.Name = "txtValorComissao";
            this.txtValorComissao.Size = new System.Drawing.Size(81, 23);
            this.txtValorComissao.TabIndex = 37;
            this.txtValorComissao.TextChanged += new System.EventHandler(this.FormataTextoEmDinheiro);
            // 
            // txtNomeCaptador
            // 
            this.txtNomeCaptador.Location = new System.Drawing.Point(106, 45);
            this.txtNomeCaptador.Name = "txtNomeCaptador";
            this.txtNomeCaptador.ReadOnly = true;
            this.txtNomeCaptador.Size = new System.Drawing.Size(153, 23);
            this.txtNomeCaptador.TabIndex = 36;
            // 
            // lblNomeIndicacao
            // 
            this.lblNomeIndicacao.AutoSize = true;
            this.lblNomeIndicacao.Location = new System.Drawing.Point(5, 46);
            this.lblNomeIndicacao.Name = "lblNomeIndicacao";
            this.lblNomeIndicacao.Size = new System.Drawing.Size(95, 15);
            this.lblNomeIndicacao.TabIndex = 35;
            this.lblNomeIndicacao.Text = "Nome Captador:";
            // 
            // lblFoiIndicacao
            // 
            this.lblFoiIndicacao.AutoSize = true;
            this.lblFoiIndicacao.Location = new System.Drawing.Point(20, 24);
            this.lblFoiIndicacao.Name = "lblFoiIndicacao";
            this.lblFoiIndicacao.Size = new System.Drawing.Size(80, 15);
            this.lblFoiIndicacao.TabIndex = 33;
            this.lblFoiIndicacao.Text = "Foi indicação:";
            // 
            // lblObsParcela
            // 
            this.lblObsParcela.AutoSize = true;
            this.lblObsParcela.Location = new System.Drawing.Point(326, 533);
            this.lblObsParcela.Name = "lblObsParcela";
            this.lblObsParcela.Size = new System.Drawing.Size(134, 15);
            this.lblObsParcela.TabIndex = 34;
            this.lblObsParcela.Text = "Observações da Parcela:";
            // 
            // RtxtObsParcela
            // 
            this.RtxtObsParcela.Location = new System.Drawing.Point(329, 551);
            this.RtxtObsParcela.Name = "RtxtObsParcela";
            this.RtxtObsParcela.Size = new System.Drawing.Size(235, 108);
            this.RtxtObsParcela.TabIndex = 33;
            this.RtxtObsParcela.Text = "";
            // 
            // FrmContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 695);
            this.Controls.Add(this.lblObsParcela);
            this.Controls.Add(this.RtxtObsParcela);
            this.Controls.Add(this.gpCaptador);
            this.Controls.Add(this.gpParcela);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnRemoveLinha);
            this.Controls.Add(this.btnAdicionaLinha);
            this.Controls.Add(this.mskNumProcesso);
            this.Controls.Add(this.gpRequerente);
            this.Controls.Add(this.btnCadastraCobranca);
            this.Controls.Add(this.gpCobranca);
            this.Controls.Add(this.lblNProcesso);
            this.Controls.Add(this.lblObsContrato);
            this.Controls.Add(this.RtxtObsContrato);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.dgvParcelas);
            this.MaximizeBox = false;
            this.Name = "FrmContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmContrato";
            this.Load += new System.EventHandler(this.FrmContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.gpCobranca.ResumeLayout(false);
            this.gpCobranca.PerformLayout();
            this.gpParcela.ResumeLayout(false);
            this.gpParcela.PerformLayout();
            this.gpRequerente.ResumeLayout(false);
            this.gpRequerente.PerformLayout();
            this.gpCaptador.ResumeLayout(false);
            this.gpCaptador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParcelas;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.RichTextBox RtxtObsContrato;
        private System.Windows.Forms.Label lblObsContrato;
        private System.Windows.Forms.Label lblNProcesso;
        private System.Windows.Forms.GroupBox gpCobranca;
        private System.Windows.Forms.Label lbltipopagamento;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblDividido;
        private System.Windows.Forms.ComboBox cbDividoEm;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Button btnCadastraCobranca;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.MaskedTextBox mskNumProcesso;
        private System.Windows.Forms.ComboBox cbTipoDePagamento;
        private System.Windows.Forms.Label lblValorAParcelar;
        private System.Windows.Forms.TextBox txtValorDasParcelas;
        private System.Windows.Forms.Button btnAdicionaLinha;
        private System.Windows.Forms.Button btnRemoveLinha;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TextBox txtDiaDeVencimento;
        private System.Windows.Forms.Label lblDiaVencimento;
        private System.Windows.Forms.TextBox txtValorEntrada;
        private System.Windows.Forms.Label lblValorEntrada;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.GroupBox gpParcela;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.Label lblNomeRequerente;
        private System.Windows.Forms.TextBox txtNomeRequerente;
        private System.Windows.Forms.Label lblCpfRquerente;
        private System.Windows.Forms.MaskedTextBox mskCpf;
        private System.Windows.Forms.Label lbltelefone;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.GroupBox gpRequerente;
        private System.Windows.Forms.GroupBox gpCaptador;
        private System.Windows.Forms.Label lblValorComissao;
        private System.Windows.Forms.TextBox txtValorComissao;
        private System.Windows.Forms.TextBox txtNomeCaptador;
        private System.Windows.Forms.Label lblNomeIndicacao;
        private System.Windows.Forms.Label lblFoiIndicacao;
        private System.Windows.Forms.Label lblDataContrato;
        private System.Windows.Forms.TextBox txtFoiIndicacao;
        private System.Windows.Forms.Label lblLocalDescobrimento;
        private System.Windows.Forms.TextBox txtLocalDescobrimento;
        private System.Windows.Forms.Label lblObsParcela;
        private System.Windows.Forms.RichTextBox RtxtObsParcela;
        private System.Windows.Forms.Label lblTotalJaPago;
        private System.Windows.Forms.DateTimePicker dtpDataContrato;
        private System.Windows.Forms.DateTimePicker DtpDataVencimento;
    }
}