using SistemaRegistros.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros
{
    public partial class FrmCliente : Form
    {
        Cliente cliente = new Cliente();
        ParteContraria parteContraria = new ParteContraria();
        Processo processo = new Processo();
        bool NovoCliente = false;          //VARIAVEIS PRA CONTROLAR CASO QUEIRA UM NOVO REGISTRO NA ALTERAÇÃO
        bool NovaParteContraria = false;
        string tag = string.Empty;
        int contadorRb = 0;

        public string FormataTexto(string conteudo)
        {
            return conteudo.Replace(".", "")
                 .Replace("-", "")
                 .Replace(" ", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "");
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
                            TextBox obj =(TextBox)elemento;
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

        public void InsereDadosNasClasses()//Serve pra Inserção
        {
            //CLIENTE
            cliente.Nome = txtNomeRequerente.Text.ToUpper();
            cliente.Cpf = FormataTexto(mskCpf.Text);
            cliente.Telefone = FormataTexto(mskTelefone.Text);
            //PARTE CONTRÁRIA
            parteContraria.Nome = txtNomePContraria.Text.ToUpper();
            if (rbFisico.Checked) {                                     //Se for Pessoa Física
                parteContraria.Tipo = "F";
                parteContraria.Cnpj = "";
                parteContraria.Cpf = FormataTexto(mskCpfPContraria.Text);
            }
            else {                                                     //Se for Pessoa Juridica
                parteContraria.Tipo = "J";
                parteContraria.Cpf = "";
                parteContraria.Cnpj = FormataTexto(mskCpfPContraria.Text);
                
            }
            //PROCESSO
            processo.NumProcesso = FormataTexto(mskNumProcesso.Text);
            processo.Foro = txtForo.Text;
            processo.TipoAcao = cbTipoAcao.Text;
            processo.Area = cbArea.Text;
            processo.AndamentoProcesso = RtxtAndamento.Text;
            processo.IdCliente = cliente.IdCliente;
            processo.IdParteContraria = parteContraria.IdParteContraria;
            switch (cbIndicacao.SelectedIndex)
            {
                case 0:
                    processo.FoiIndicacao = "N";
                    processo.NomeCaptador = "";
                    processo.LocalDescobrimento = "";
                    break;
                case 1:
                    processo.FoiIndicacao = "S";
                    
                    processo.NomeCaptador = txtNomeCaptador.Text.ToUpper();
                    processo.LocalDescobrimento = cbFormadescoberta.Text;
                    break;
            }
        }
        public void Arranja() //Serve pra consulta
        {
            //CLIENTE
            txtNomeRequerente.Text = cliente.Nome;
            mskCpf.Text = cliente.Cpf;
            mskTelefone.Text = cliente.Telefone;
            //PARTE CONTRÁRIA
            txtNomePContraria.Text = parteContraria.Nome;
            switch (parteContraria.Tipo)
            {
                case "F": //Se for Pessoa Física
                    rbFisico.Checked = true;
                    mskCpfPContraria.Text = parteContraria.Cpf;
                    break;
                case "J": //Se for Pessoa Juridica
                    rbJuridico.Checked = true;
                    mskCpfPContraria.Text = parteContraria.Cnpj;
                    break;
            }
            //PROCESSO
            mskNumProcesso.Text = processo.NumProcesso;
            txtForo.Text = processo.Foro;
            cbTipoAcao.Text = processo.TipoAcao;
            cbArea.Text = processo.Area;
            RtxtAndamento.Text = processo.AndamentoProcesso;
            processo.IdCliente = cliente.IdCliente;
            processo.IdParteContraria = parteContraria.IdParteContraria;
            switch (processo.FoiIndicacao)
            {
                case "S":
                    cbIndicacao.SelectedIndex = 1; // ITEM : SIM
                    txtNomeCaptador.Text = processo.NomeCaptador;
                    cbFormadescoberta.Text =processo.LocalDescobrimento;
                    break;
                case "N":
                    cbIndicacao.SelectedIndex = 0; // ITEM : NÃO
                    txtNomeCaptador.Text = "";
                    cbFormadescoberta.Text = "";
                    break;
            }
        }
    

        public void MudaPfPraPe()
        {
            bool tipoFisico = rbFisico.Checked;
            if (tipoFisico)
            {
                lblNomePContraria.Text = "*Nome completo:";
                lblCpf_CnpjContraria.Text = "CPF:";
                mskCpfPContraria.Mask = "000\\.000\\.000-00";
            }
            else
            {
                lblNomePContraria.Text = "*Nome da Empresa:";
                lblCpf_CnpjContraria.Text = "CNPJ:";
                mskCpfPContraria.Mask = "00\\.000\\.000\\/0000\\-00";
            }
        }
        public FrmCliente()
        {
            InitializeComponent();
            InsereDadosNasClasses();
            cbIndicacao.SelectedIndex = 0;
            cbFormadescoberta.SelectedItem = 0;
        }

        public FrmCliente(Cliente cliente, ParteContraria parteContraria, Processo processo,char tag)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.parteContraria = parteContraria;
            this.processo = processo;
            LocalizaProcesso();
            Arranja();
            if (tag.Equals('A'))
            {
                btnCadastra.Text = "Alterar";
            }
            else
            {
                btnCadastra.Visible = false;
                TrancaFormularioPraConsulta();
            }
            this.tag = tag.ToString();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            rbFisico.Checked = true;
            MudaPfPraPe();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            try
            {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            bool insercaoValida = FormataTexto(mskNumProcesso.Text).Length>0 &&
                FormataTexto(cbArea.Text).Length > 0 && FormataTexto(txtForo.Text).Length > 0 &&
                FormataTexto(cbTipoAcao.Text).Length > 0 &&
                FormataTexto(mskCpf.Text).Length > 0 && FormataTexto(cbIndicacao.Text).Length > 0 &&
                (rbFisico.Checked || rbJuridico.Checked) &&
                FormataTexto(txtNomePContraria.Text).Length > 0;

                if (insercaoValida)
                {
                    InsereDadosNasClasses();
                    if (btnCadastra.Text.Equals("Cadastrar"))
                    {
                        //CADASTRA 

                        sqlAux.CadastraProcesso(cliente, parteContraria, processo,
                            NovoCliente, NovaParteContraria);
                        MessageBox.Show("CADASTRADO com sucesso!", "MENSAGEM",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //ALTERA

                        sqlAux.AlteraProcesso(cliente, parteContraria, processo,
                            NovoCliente, NovaParteContraria);
                        MessageBox.Show("ALTERADO com sucesso!", "MENSAGEM",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                    /*MessageBox.Show(cliente.ToString() + "\n" + //    --------LOG PRA VER SE O VALOR ESTÁ INDO PRAS CLASSES
                            parteContraria.ToString() + "\n" +           
                            processo.ToString());*/
                }
                else
                {
                    MessageBox.Show("VERIFIQUE SE INSERIU OS DADOS CORRETAMENTE", "MENSAGEM",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void MudaRadioButton(object sender, EventArgs e)
        {
            MudaPfPraPe();
            if (contadorRb > 0)
            {
                ValidaCpfeCnpj();
            }
            contadorRb++;
        }

        private void ValidaCpfeCnpj()
        {
            if (FormataTexto(mskCpfPContraria.Text).Length>0)
            {
                if (rbFisico.Checked)
                {
                    bool cpfValido = Validacao.ValidaCpf(mskCpfPContraria.Text);
                    if (cpfValido)
                    {
                        String texto = FormataTexto(mskCpfPContraria.Text);
                        if (texto.Length > 0)
                        {
                            IdentificaParteContraria();
                        }
                    }
                    else { MessageBox.Show("CPF INVÁLIDO"); }
                }
                else
                {
                    bool cnpjValido = Validacao.ValidaCnpj(mskCpfPContraria.Text);
                    if (cnpjValido)
                    {
                        String texto = FormataTexto(mskCpfPContraria.Text);
                        if (texto.Length > 0)
                        {
                            IdentificaParteContraria();
                        }
                    }
                    else { MessageBox.Show("CNPJ INVÁLIDO"); }
                }
            }
        }

        private void LocalizaProcesso()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            sqlAux.LocalizaProcesso(cliente,parteContraria,processo);
            Arranja();
        }
        private void IdentificaCliente()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            if (tag.Equals(string.Empty) || tag.Equals("A")) // SÓ IDENTIFICA SE FOR CADASTRAR OU ALTERAR REGISTRO
            {
                if (sqlAux.IsClienteNovo(cliente))              //CASO SEJA UM NOVO CLIENTE
                {
                    sqlAux.PegaUltimoIdCliente(cliente);
                    NovoCliente = true;
                }
                else
                {
                    MessageBox.Show("Requerente já cadastrado no sistema! Completando informações");
                    Arranja();
                }
            }
        }
        private void IdentificaParteContraria()
        {
            SqlAuxiliar sqlAux = new SqlAuxiliar();
            InsereDadosNasClasses();
            if (tag.Equals(string.Empty) || tag.Equals("A")) // SÓ IDENTIFICA SE FOR CADASTRAR OU ALTERAR REGISTRO
            {
                if (sqlAux.IsParteContrariaNovo(parteContraria)) //CASO SEJA UM NOVA PARTE CONTRÁRIA
                {
                    sqlAux.PegaUltimoIdParteContraria(parteContraria);
                    NovaParteContraria = true;
                }
                else
                {
                    MessageBox.Show("Parte Contrária já cadastrado no sistema! Completando informações");
                    Arranja();
                }
            }
        }

        private void mskCpf_Leave(object sender, EventArgs e)
        {
            bool cpfValido = Validacao.ValidaCpf(mskCpf.Text);
            if (cpfValido)
            {
                String texto = FormataTexto(mskCpf.Text);

                if (texto.Length > 0)
                {
                    IdentificaCliente();
                }
            }
            else
            {
                MessageBox.Show("CPF INVALIDO");
            }
        }

        private void mskCpfPContraria_Leave(object sender, EventArgs e)
        {
            ValidaCpfeCnpj();
        }
    }
}
