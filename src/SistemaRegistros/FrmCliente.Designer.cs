
namespace SistemaRegistros
{
    partial class FrmCliente
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
            this.lblNomeRequerente = new System.Windows.Forms.Label();
            this.txtNomeRequerente = new System.Windows.Forms.TextBox();
            this.lblCpfRquerente = new System.Windows.Forms.Label();
            this.RtxtAndamento = new System.Windows.Forms.RichTextBox();
            this.mskCpf = new System.Windows.Forms.MaskedTextBox();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.dpRequerente = new System.Windows.Forms.GroupBox();
            this.cbFormadescoberta = new System.Windows.Forms.ComboBox();
            this.lblFormaDescoberta = new System.Windows.Forms.Label();
            this.txtNomeCaptador = new System.Windows.Forms.TextBox();
            this.lblNomeIndicacao = new System.Windows.Forms.Label();
            this.cbIndicacao = new System.Windows.Forms.ComboBox();
            this.lblFoiIndicacao = new System.Windows.Forms.Label();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.lbltelefone = new System.Windows.Forms.Label();
            this.gpParteContraria = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbJuridico = new System.Windows.Forms.RadioButton();
            this.rbFisico = new System.Windows.Forms.RadioButton();
            this.mskCpfPContraria = new System.Windows.Forms.MaskedTextBox();
            this.lblCpf_CnpjContraria = new System.Windows.Forms.Label();
            this.txtNomePContraria = new System.Windows.Forms.TextBox();
            this.lblNomePContraria = new System.Windows.Forms.Label();
            this.btnCadastra = new System.Windows.Forms.Button();
            this.lblTipoAcao = new System.Windows.Forms.Label();
            this.cbTipoAcao = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtForo = new System.Windows.Forms.TextBox();
            this.lblForo = new System.Windows.Forms.Label();
            this.mskNumProcesso = new System.Windows.Forms.MaskedTextBox();
            this.lblNProcesso = new System.Windows.Forms.Label();
            this.gpProcesso = new System.Windows.Forms.GroupBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.dpRequerente.SuspendLayout();
            this.gpParteContraria.SuspendLayout();
            this.gpProcesso.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomeRequerente
            // 
            this.lblNomeRequerente.AutoSize = true;
            this.lblNomeRequerente.Location = new System.Drawing.Point(4, 39);
            this.lblNomeRequerente.Name = "lblNomeRequerente";
            this.lblNomeRequerente.Size = new System.Drawing.Size(97, 15);
            this.lblNomeRequerente.TabIndex = 0;
            this.lblNomeRequerente.Text = "Nome completo:";
            // 
            // txtNomeRequerente
            // 
            this.txtNomeRequerente.Location = new System.Drawing.Point(102, 36);
            this.txtNomeRequerente.Name = "txtNomeRequerente";
            this.txtNomeRequerente.Size = new System.Drawing.Size(192, 23);
            this.txtNomeRequerente.TabIndex = 1;
            // 
            // lblCpfRquerente
            // 
            this.lblCpfRquerente.AutoSize = true;
            this.lblCpfRquerente.Location = new System.Drawing.Point(312, 39);
            this.lblCpfRquerente.Name = "lblCpfRquerente";
            this.lblCpfRquerente.Size = new System.Drawing.Size(36, 15);
            this.lblCpfRquerente.TabIndex = 2;
            this.lblCpfRquerente.Text = "*CPF:";
            // 
            // RtxtAndamento
            // 
            this.RtxtAndamento.Location = new System.Drawing.Point(13, 430);
            this.RtxtAndamento.Name = "RtxtAndamento";
            this.RtxtAndamento.Size = new System.Drawing.Size(536, 193);
            this.RtxtAndamento.TabIndex = 9;
            this.RtxtAndamento.Text = "";
            // 
            // mskCpf
            // 
            this.mskCpf.Location = new System.Drawing.Point(350, 36);
            this.mskCpf.Mask = "000\\.000\\.000-00";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.Size = new System.Drawing.Size(98, 23);
            this.mskCpf.TabIndex = 10;
            this.mskCpf.Leave += new System.EventHandler(this.mskCpf_Leave);
            // 
            // lblAndamento
            // 
            this.lblAndamento.AutoSize = true;
            this.lblAndamento.Location = new System.Drawing.Point(13, 412);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(140, 15);
            this.lblAndamento.TabIndex = 11;
            this.lblAndamento.Text = "Andamento do Processo:";
            // 
            // dpRequerente
            // 
            this.dpRequerente.Controls.Add(this.cbFormadescoberta);
            this.dpRequerente.Controls.Add(this.lblFormaDescoberta);
            this.dpRequerente.Controls.Add(this.txtNomeCaptador);
            this.dpRequerente.Controls.Add(this.lblNomeIndicacao);
            this.dpRequerente.Controls.Add(this.cbIndicacao);
            this.dpRequerente.Controls.Add(this.lblFoiIndicacao);
            this.dpRequerente.Controls.Add(this.mskTelefone);
            this.dpRequerente.Controls.Add(this.lbltelefone);
            this.dpRequerente.Controls.Add(this.mskCpf);
            this.dpRequerente.Controls.Add(this.lblCpfRquerente);
            this.dpRequerente.Controls.Add(this.txtNomeRequerente);
            this.dpRequerente.Controls.Add(this.lblNomeRequerente);
            this.dpRequerente.Location = new System.Drawing.Point(13, 106);
            this.dpRequerente.Name = "dpRequerente";
            this.dpRequerente.Size = new System.Drawing.Size(535, 166);
            this.dpRequerente.TabIndex = 12;
            this.dpRequerente.TabStop = false;
            this.dpRequerente.Text = "informações do Requerente:";
            // 
            // cbFormadescoberta
            // 
            this.cbFormadescoberta.FormattingEnabled = true;
            this.cbFormadescoberta.Items.AddRange(new object[] {
            "Whatsapp",
            "Facebook",
            "Instagram"});
            this.cbFormadescoberta.Location = new System.Drawing.Point(350, 76);
            this.cbFormadescoberta.Name = "cbFormadescoberta";
            this.cbFormadescoberta.Size = new System.Drawing.Size(119, 23);
            this.cbFormadescoberta.TabIndex = 19;
            // 
            // lblFormaDescoberta
            // 
            this.lblFormaDescoberta.AutoSize = true;
            this.lblFormaDescoberta.Location = new System.Drawing.Point(226, 79);
            this.lblFormaDescoberta.Name = "lblFormaDescoberta";
            this.lblFormaDescoberta.Size = new System.Drawing.Size(122, 15);
            this.lblFormaDescoberta.TabIndex = 18;
            this.lblFormaDescoberta.Text = "Forma de Descoberta:";
            // 
            // txtNomeCaptador
            // 
            this.txtNomeCaptador.Location = new System.Drawing.Point(324, 118);
            this.txtNomeCaptador.Name = "txtNomeCaptador";
            this.txtNomeCaptador.Size = new System.Drawing.Size(153, 23);
            this.txtNomeCaptador.TabIndex = 16;
            // 
            // lblNomeIndicacao
            // 
            this.lblNomeIndicacao.AutoSize = true;
            this.lblNomeIndicacao.Location = new System.Drawing.Point(226, 121);
            this.lblNomeIndicacao.Name = "lblNomeIndicacao";
            this.lblNomeIndicacao.Size = new System.Drawing.Size(95, 15);
            this.lblNomeIndicacao.TabIndex = 15;
            this.lblNomeIndicacao.Text = "Nome Captador:";
            // 
            // cbIndicacao
            // 
            this.cbIndicacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndicacao.FormattingEnabled = true;
            this.cbIndicacao.Items.AddRange(new object[] {
            "Não",
            "Sim"});
            this.cbIndicacao.Location = new System.Drawing.Point(102, 118);
            this.cbIndicacao.Name = "cbIndicacao";
            this.cbIndicacao.Size = new System.Drawing.Size(68, 23);
            this.cbIndicacao.TabIndex = 14;
            // 
            // lblFoiIndicacao
            // 
            this.lblFoiIndicacao.AutoSize = true;
            this.lblFoiIndicacao.Location = new System.Drawing.Point(19, 121);
            this.lblFoiIndicacao.Name = "lblFoiIndicacao";
            this.lblFoiIndicacao.Size = new System.Drawing.Size(85, 15);
            this.lblFoiIndicacao.TabIndex = 13;
            this.lblFoiIndicacao.Text = "*Foi indicação:";
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(102, 73);
            this.mskTelefone.Mask = "(99) 00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(85, 23);
            this.mskTelefone.TabIndex = 12;
            // 
            // lbltelefone
            // 
            this.lbltelefone.AutoSize = true;
            this.lbltelefone.Location = new System.Drawing.Point(47, 76);
            this.lbltelefone.Name = "lbltelefone";
            this.lbltelefone.Size = new System.Drawing.Size(54, 15);
            this.lbltelefone.TabIndex = 11;
            this.lbltelefone.Text = "Telefone:";
            // 
            // gpParteContraria
            // 
            this.gpParteContraria.Controls.Add(this.lblTipo);
            this.gpParteContraria.Controls.Add(this.rbJuridico);
            this.gpParteContraria.Controls.Add(this.rbFisico);
            this.gpParteContraria.Controls.Add(this.mskCpfPContraria);
            this.gpParteContraria.Controls.Add(this.lblCpf_CnpjContraria);
            this.gpParteContraria.Controls.Add(this.txtNomePContraria);
            this.gpParteContraria.Controls.Add(this.lblNomePContraria);
            this.gpParteContraria.Location = new System.Drawing.Point(13, 288);
            this.gpParteContraria.Name = "gpParteContraria";
            this.gpParteContraria.Size = new System.Drawing.Size(535, 113);
            this.gpParteContraria.TabIndex = 13;
            this.gpParteContraria.TabStop = false;
            this.gpParteContraria.Text = "informações da Parte Contrária:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(23, 30);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(38, 15);
            this.lblTipo.TabIndex = 13;
            this.lblTipo.Text = "*Tipo:";
            // 
            // rbJuridico
            // 
            this.rbJuridico.AutoSize = true;
            this.rbJuridico.Location = new System.Drawing.Point(136, 28);
            this.rbJuridico.Name = "rbJuridico";
            this.rbJuridico.Size = new System.Drawing.Size(66, 19);
            this.rbJuridico.TabIndex = 12;
            this.rbJuridico.TabStop = true;
            this.rbJuridico.Text = "Jurídico";
            this.rbJuridico.UseVisualStyleBackColor = true;
            this.rbJuridico.CheckedChanged += new System.EventHandler(this.MudaRadioButton);
            // 
            // rbFisico
            // 
            this.rbFisico.AutoSize = true;
            this.rbFisico.Location = new System.Drawing.Point(75, 28);
            this.rbFisico.Name = "rbFisico";
            this.rbFisico.Size = new System.Drawing.Size(55, 19);
            this.rbFisico.TabIndex = 11;
            this.rbFisico.TabStop = true;
            this.rbFisico.Text = "Físico";
            this.rbFisico.UseVisualStyleBackColor = true;
            this.rbFisico.CheckedChanged += new System.EventHandler(this.MudaRadioButton);
            // 
            // mskCpfPContraria
            // 
            this.mskCpfPContraria.Location = new System.Drawing.Point(350, 63);
            this.mskCpfPContraria.Mask = "000\\.000\\.000-00";
            this.mskCpfPContraria.Name = "mskCpfPContraria";
            this.mskCpfPContraria.Size = new System.Drawing.Size(94, 23);
            this.mskCpfPContraria.TabIndex = 10;
            this.mskCpfPContraria.Leave += new System.EventHandler(this.mskCpfPContraria_Leave);
            // 
            // lblCpf_CnpjContraria
            // 
            this.lblCpf_CnpjContraria.AutoSize = true;
            this.lblCpf_CnpjContraria.Location = new System.Drawing.Point(313, 66);
            this.lblCpf_CnpjContraria.Name = "lblCpf_CnpjContraria";
            this.lblCpf_CnpjContraria.Size = new System.Drawing.Size(31, 15);
            this.lblCpf_CnpjContraria.TabIndex = 2;
            this.lblCpf_CnpjContraria.Text = "CPF:";
            // 
            // txtNomePContraria
            // 
            this.txtNomePContraria.Location = new System.Drawing.Point(112, 63);
            this.txtNomePContraria.Name = "txtNomePContraria";
            this.txtNomePContraria.Size = new System.Drawing.Size(192, 23);
            this.txtNomePContraria.TabIndex = 1;
            // 
            // lblNomePContraria
            // 
            this.lblNomePContraria.AutoSize = true;
            this.lblNomePContraria.Location = new System.Drawing.Point(4, 66);
            this.lblNomePContraria.Name = "lblNomePContraria";
            this.lblNomePContraria.Size = new System.Drawing.Size(102, 15);
            this.lblNomePContraria.TabIndex = 0;
            this.lblNomePContraria.Text = "*Nome completo:";
            // 
            // btnCadastra
            // 
            this.btnCadastra.Location = new System.Drawing.Point(196, 640);
            this.btnCadastra.Name = "btnCadastra";
            this.btnCadastra.Size = new System.Drawing.Size(165, 50);
            this.btnCadastra.TabIndex = 16;
            this.btnCadastra.Text = "Cadastrar";
            this.btnCadastra.UseVisualStyleBackColor = true;
            this.btnCadastra.Click += new System.EventHandler(this.btnCadastra_Click);
            // 
            // lblTipoAcao
            // 
            this.lblTipoAcao.AutoSize = true;
            this.lblTipoAcao.Location = new System.Drawing.Point(289, 64);
            this.lblTipoAcao.Name = "lblTipoAcao";
            this.lblTipoAcao.Size = new System.Drawing.Size(84, 15);
            this.lblTipoAcao.TabIndex = 23;
            this.lblTipoAcao.Text = "*Tipo de Ação:";
            // 
            // cbTipoAcao
            // 
            this.cbTipoAcao.AllowDrop = true;
            this.cbTipoAcao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTipoAcao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTipoAcao.FormattingEnabled = true;
            this.cbTipoAcao.Items.AddRange(new object[] {
            "irmao",
            "irmã",
            "",
            "ima",
            "imu"});
            this.cbTipoAcao.Location = new System.Drawing.Point(379, 61);
            this.cbTipoAcao.Name = "cbTipoAcao";
            this.cbTipoAcao.Size = new System.Drawing.Size(121, 23);
            this.cbTipoAcao.TabIndex = 22;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(101, 64);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 15);
            this.lblArea.TabIndex = 21;
            this.lblArea.Text = "*Area:";
            // 
            // txtForo
            // 
            this.txtForo.Location = new System.Drawing.Point(333, 24);
            this.txtForo.Name = "txtForo";
            this.txtForo.Size = new System.Drawing.Size(198, 23);
            this.txtForo.TabIndex = 27;
            // 
            // lblForo
            // 
            this.lblForo.AutoSize = true;
            this.lblForo.Location = new System.Drawing.Point(293, 27);
            this.lblForo.Name = "lblForo";
            this.lblForo.Size = new System.Drawing.Size(39, 15);
            this.lblForo.TabIndex = 26;
            this.lblForo.Text = "*Foro:";
            // 
            // mskNumProcesso
            // 
            this.mskNumProcesso.Location = new System.Drawing.Point(141, 24);
            this.mskNumProcesso.Mask = "0000000-00\\.0000\\.0\\.00\\.0000";
            this.mskNumProcesso.Name = "mskNumProcesso";
            this.mskNumProcesso.Size = new System.Drawing.Size(125, 23);
            this.mskNumProcesso.TabIndex = 25;
            // 
            // lblNProcesso
            // 
            this.lblNProcesso.AutoSize = true;
            this.lblNProcesso.Location = new System.Drawing.Point(14, 27);
            this.lblNProcesso.Name = "lblNProcesso";
            this.lblNProcesso.Size = new System.Drawing.Size(126, 15);
            this.lblNProcesso.TabIndex = 24;
            this.lblNProcesso.Text = "*Número do processo:";
            // 
            // gpProcesso
            // 
            this.gpProcesso.Controls.Add(this.txtForo);
            this.gpProcesso.Controls.Add(this.lblForo);
            this.gpProcesso.Controls.Add(this.mskNumProcesso);
            this.gpProcesso.Controls.Add(this.lblNProcesso);
            this.gpProcesso.Controls.Add(this.lblTipoAcao);
            this.gpProcesso.Controls.Add(this.cbTipoAcao);
            this.gpProcesso.Controls.Add(this.lblArea);
            this.gpProcesso.Controls.Add(this.cbArea);
            this.gpProcesso.Location = new System.Drawing.Point(13, -2);
            this.gpProcesso.Name = "gpProcesso";
            this.gpProcesso.Size = new System.Drawing.Size(535, 102);
            this.gpProcesso.TabIndex = 28;
            this.gpProcesso.TabStop = false;
            this.gpProcesso.Text = "Infromações do Processo:";
            // 
            // cbArea
            // 
            this.cbArea.AllowDrop = true;
            this.cbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "irmao",
            "irmã",
            "",
            "ima",
            "imu"});
            this.cbArea.Location = new System.Drawing.Point(141, 60);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 23);
            this.cbArea.TabIndex = 20;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(572, 695);
            this.Controls.Add(this.gpProcesso);
            this.Controls.Add(this.btnCadastra);
            this.Controls.Add(this.gpParteContraria);
            this.Controls.Add(this.dpRequerente);
            this.Controls.Add(this.lblAndamento);
            this.Controls.Add(this.RtxtAndamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRequerente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.dpRequerente.ResumeLayout(false);
            this.dpRequerente.PerformLayout();
            this.gpParteContraria.ResumeLayout(false);
            this.gpParteContraria.PerformLayout();
            this.gpProcesso.ResumeLayout(false);
            this.gpProcesso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeRequerente;
        private System.Windows.Forms.TextBox txtNomeRequerente;
        private System.Windows.Forms.Label lblCpfRquerente;
        private System.Windows.Forms.RichTextBox RtxtAndamento;
        private System.Windows.Forms.MaskedTextBox mskCpf;
        private System.Windows.Forms.Label lblAndamento;
        private System.Windows.Forms.GroupBox dpRequerente;
        private System.Windows.Forms.GroupBox gpParteContraria;
        private System.Windows.Forms.RadioButton rbFisico;
        private System.Windows.Forms.Label lblCpf_CnpjContraria;
        private System.Windows.Forms.TextBox txtNomePContraria;
        private System.Windows.Forms.Label lblNomePContraria;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rbJuridico;
        private System.Windows.Forms.Button btnCadastra;
        private System.Windows.Forms.MaskedTextBox mskCpfPContraria;
        private System.Windows.Forms.Label lblTipoAcao;
        private System.Windows.Forms.ComboBox cbTipoAcao;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtForo;
        private System.Windows.Forms.Label lblForo;
        private System.Windows.Forms.MaskedTextBox mskNumProcesso;
        private System.Windows.Forms.Label lblNProcesso;
        private System.Windows.Forms.GroupBox gpProcesso;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.Label lbltelefone;
        private System.Windows.Forms.Label lblFormaDescoberta;
        private System.Windows.Forms.TextBox txtNomeCaptador;
        private System.Windows.Forms.Label lblNomeIndicacao;
        private System.Windows.Forms.Label lblFoiIndicacao;
        private System.Windows.Forms.ComboBox cbFormadescoberta;
        private System.Windows.Forms.ComboBox cbIndicacao;
        private System.Windows.Forms.ComboBox cbArea;
    }
}