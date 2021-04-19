using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SistemaRegistros.classes
{
    class SqlAuxiliar
    {

        private SqlConnection con = null;

        public bool IsParteContrariaNovoCPFOuCNPJ(ParteContraria parteContraria) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsParteContrariaNova", con.GetConexao());
            cmd.Parameters.AddWithValue("@CPF", parteContraria.Cpf);
            cmd.Parameters.AddWithValue("@CNPJ", parteContraria.Cnpj);
            cmd.Parameters.AddWithValue("@Tipo", parteContraria.Tipo);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                { return true; }
                else
                {
                    IdentificaParteContraria(parteContraria);
                    return false;
                }
            }
            con.FechaConexao();
        }
        public bool IsParteContrariaNovoNome(ParteContraria parteContraria)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsParteContrariaNovaPeloNome", con.GetConexao());
            cmd.Parameters.AddWithValue("@Nome", parteContraria.Nome);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                { return true; }
                else
                {
                    IdentificaParteContrariaNome(parteContraria);
                    return false;
                }
            }
            con.FechaConexao();
        }

        

        public void GeraRelatorio(string nomeCaptador, string mes, string ano)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spPesquisaRelatorio", con.GetConexao());
            cmd.Parameters.AddWithValue("@NomeCaptador", nomeCaptador);
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Ano", ano);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //GERA RELATORIO
                    using (SaveFileDialog sfd = new SaveFileDialog() {Filter="ARQUIVO EXCEL|*.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                using (XLWorkbook workbook = new XLWorkbook())
                                {
                                    workbook.Worksheets.Add(dt, "TESTE");
                                    workbook.SaveAs(sfd.FileName);
                                }
                                MessageBox.Show("ARQUIVO EXPORTADO COM SUCESSO!");
                            }
                            catch (Exception err)
                            {

                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                }
            }
            con.FechaConexao();
        }

        public void ListaCaptadores(ComboBox cbNomeCaptadores)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spListaNomesCaptadores", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cbNomeCaptadores.DataSource = dt;
                    cbNomeCaptadores.DisplayMember = "NomeItem";
                    cbNomeCaptadores.ValueMember = "NomeCaptador";
                }
            }
            con.FechaConexao();
        }

        public bool LoginExiste(Usuaria usuaria)
        {
                FabricaConexao con = new FabricaConexao();
                con.AbreConexao();
                SqlCommand cmd = new SqlCommand("spGetUsuario ", con.GetConexao());
                cmd.Parameters.AddWithValue("@Nome", usuaria.NomeUsuaria);
                cmd.Parameters.AddWithValue("@Senha", usuaria.Senha);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                con.FechaConexao();
            
        }
        public bool LoginConfere(Usuaria usuaria)
        {
                FabricaConexao con = new FabricaConexao();
                con.AbreConexao();
                SqlCommand cmd = new SqlCommand("spGetUsuario ", con.GetConexao());
                cmd.Parameters.AddWithValue("@Nome", usuaria.NomeUsuaria);
                cmd.Parameters.AddWithValue("@Senha", usuaria.Senha);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (usuaria.NomeUsuaria.Equals(dt.Rows[0][1].ToString())
                        && usuaria.Senha.Equals(dt.Rows[0][2].ToString()))
                    {
                        usuaria.Idusuaria = int.Parse(dt.Rows[0][0].ToString());
                        usuaria.NomeUsuaria = dt.Rows[0][1].ToString();
                        usuaria.TipoAcessoUsuaria = dt.Rows[0][3].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                con.FechaConexao();
        }



        public bool IsClienteNovo(Cliente cliente) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsClienteNovo", con.GetConexao());
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count<=0)
                { return true; }
                else
                {
                    IdentificaCliente(cliente);
                    return false;
                }
            }
            con.FechaConexao();
        }
        public void IdentificaCliente(Cliente cliente)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsClienteNovo", con.GetConexao());
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count >0)
                {
                    cliente.IdCliente = int.Parse(dt.Rows[0][0].ToString());
                    cliente.Cpf = dt.Rows[0][1].ToString();
                    cliente.Nome = dt.Rows[0][2].ToString();
                    cliente.Telefone = dt.Rows[0][3].ToString();
                }
            }
            con.FechaConexao();
        }
        public void IdentificaParteContraria(ParteContraria parteContraria)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsParteContrariaNova", con.GetConexao());
            cmd.Parameters.AddWithValue("@CPF", parteContraria.Cpf);
            cmd.Parameters.AddWithValue("@CNPJ", parteContraria.Cnpj);
            cmd.Parameters.AddWithValue("@Tipo", parteContraria.Tipo);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    parteContraria.IdParteContraria = int.Parse(dt.Rows[0][0].ToString());
                    parteContraria.Nome = dt.Rows[0][1].ToString();
                    parteContraria.Tipo = dt.Rows[0][2].ToString();
                    parteContraria.Cpf = dt.Rows[0][3].ToString();
                    parteContraria.Cnpj = dt.Rows[0][4].ToString();
                }
            }
            con.FechaConexao();
        }
        private void IdentificaParteContrariaNome(ParteContraria parteContraria)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spIsParteContrariaNovaPeloNome", con.GetConexao());
            cmd.Parameters.AddWithValue("@Nome", parteContraria.Nome);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    parteContraria.IdParteContraria = int.Parse(dt.Rows[0][0].ToString());
                    parteContraria.Nome = dt.Rows[0][1].ToString();
                    parteContraria.Tipo = dt.Rows[0][2].ToString();
                    parteContraria.Cpf = dt.Rows[0][3].ToString();
                    parteContraria.Cnpj = dt.Rows[0][4].ToString();
                }
            }
            con.FechaConexao();
        }


        public void LocalizaContrato(Contrato contrato)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetConsultaContrato", con.GetConexao());
            cmd.Parameters.AddWithValue("@IdContrato", contrato.IdContrato);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    contrato.IdContrato  = int.Parse(dt.Rows[0][0].ToString());
                    contrato.TipoPagamento = dt.Rows[0][1].ToString();
                    contrato.Observacoes = dt.Rows[0][2].ToString();
                    contrato.DiaVencimento = dt.Rows[0][3].ToString();
                    contrato.DataContrato = dt.Rows[0][4].ToString();
                    contrato.QtdVezes = int.Parse(dt.Rows[0][5].ToString());
                    contrato.ValorTotal = double.Parse(dt.Rows[0][6].ToString());
                    contrato.ValorEntrada = double.Parse(dt.Rows[0][7].ToString());
                    contrato.ValorComissao = double.Parse(dt.Rows[0][8].ToString());

                }
            }
            con.FechaConexao();
        }

        public void LocalizaProcesso(Cliente cliente, ParteContraria parteContraria, Processo processo)
            {
            //CLIENTE-CONSULTA
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetProcessoCliente", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@IdParteContraria", parteContraria.IdParteContraria);
            cmd.Parameters.AddWithValue("@IdProcesso", processo.IdProcesso);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    processo.IdProcesso = int.Parse(dt.Rows[0][0].ToString());
                    cliente.IdCliente = int.Parse(dt.Rows[0][1].ToString());
                    processo.IdCliente = int.Parse(dt.Rows[0][1].ToString());        //PEGA O ID DO CLIENTE PARA CASO DE 
                    parteContraria.IdParteContraria = int.Parse(dt.Rows[0][2].ToString());
                    processo.IdParteContraria = int.Parse(dt.Rows[0][2].ToString());        //PEGA O ID DA PARTE CONTRARIA PARA CASO DE 

                    processo.NumProcesso = dt.Rows[0][3].ToString();
                    processo.Foro = dt.Rows[0][4].ToString();
                    processo.TipoAcao = dt.Rows[0][5].ToString();
                    processo.Area = dt.Rows[0][6].ToString();
                    processo.FoiIndicacao = dt.Rows[0][7].ToString();
                    processo.NomeCaptador = dt.Rows[0][8].ToString();
                    processo.LocalDescobrimento = dt.Rows[0][9].ToString();
                    processo.AndamentoProcesso = dt.Rows[0][10].ToString();

                    cliente.Nome = dt.Rows[0][11].ToString();
                    cliente.Cpf = dt.Rows[0][12].ToString();
                    cliente.Telefone = dt.Rows[0][13].ToString();

                    parteContraria.Nome = dt.Rows[0][14].ToString();
                    parteContraria.Cpf = dt.Rows[0][15].ToString();
                    parteContraria.Cnpj = dt.Rows[0][16].ToString();
                    parteContraria.Tipo = dt.Rows[0][17].ToString();

                }
            }
            con.FechaConexao();
        }
        
        public void LocalizaProcesso(Cliente cliente,Processo processo)
        {
            //CONTRATO-CONSULTA
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetProcessoContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@IdProcesso", processo.IdProcesso);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    processo.IdProcesso = int.Parse(dt.Rows[0][0].ToString());
                    cliente.IdCliente= int.Parse(dt.Rows[0][1].ToString());
                    processo.IdCliente = int.Parse(dt.Rows[0][1].ToString());        //PEGA O ID DO CLIENTE PARA CASO DE 
                    processo.NumProcesso = dt.Rows[0][2].ToString();
                    processo.FoiIndicacao = dt.Rows[0][3].ToString();
                    processo.NomeCaptador = dt.Rows[0][4].ToString();
                    processo.LocalDescobrimento = dt.Rows[0][5].ToString();
                    cliente.Nome = dt.Rows[0][6].ToString();
                    cliente.Cpf = dt.Rows[0][7].ToString();
                    cliente.Telefone = dt.Rows[0][8].ToString();

                }
            }
            con.FechaConexao();
        }

        public void CadastraCliente(Cliente cliente)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spCadastraCliente", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.ExecuteNonQuery();
            con.FechaConexao();
        }
        public void CadastraParteContraria(ParteContraria parteContraria)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spCadastraParteContraria", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", parteContraria.Nome);
            cmd.Parameters.AddWithValue("@CPF", parteContraria.Cpf);
            cmd.Parameters.AddWithValue("@CNPJ", parteContraria.Cnpj);
            cmd.Parameters.AddWithValue("@Tipo", parteContraria.Tipo);
            cmd.ExecuteNonQuery();
            con.FechaConexao();
        }
        public void CadastraProcesso( Cliente cliente, ParteContraria parteContraria,Processo processo,
            bool novoCliente, bool novaParteContraria) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            if(novoCliente)
                CadastraCliente(cliente);                                                   //CADASTROU CLIENTE

            if(novaParteContraria)
                CadastraParteContraria(parteContraria);                                     //CADASTROU PARTE CONTRARIA

            SqlCommand cmd = new SqlCommand("spCadastraProcesso", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", processo.IdCliente);
            cmd.Parameters.AddWithValue("@IdParteContraria", processo.IdParteContraria);
            cmd.Parameters.AddWithValue("@NumeroProcesso", processo.NumProcesso);
            cmd.Parameters.AddWithValue("@Foro", processo.Foro);
            cmd.Parameters.AddWithValue("@TipoAcao",processo.TipoAcao);
            cmd.Parameters.AddWithValue("@Area", processo.Area);
            cmd.Parameters.AddWithValue("@AndamentoProcesso", processo.AndamentoProcesso);
            cmd.Parameters.AddWithValue("@FoiIndicacao", processo.FoiIndicacao);
            cmd.Parameters.AddWithValue("@NomeCaptador", processo.NomeCaptador);
            cmd.Parameters.AddWithValue("@LocalDescobrimento", processo.LocalDescobrimento);
            cmd.ExecuteNonQuery();                                                      //CADASTROU PROCESSO

            con.FechaConexao();
        }

        public void CadastraContrato(Contrato contrato)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();

            SqlCommand cmd = new SqlCommand("spCadastraContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProcesso", contrato.IdProcesso);
            cmd.Parameters.AddWithValue("@TipoPagamento", contrato.TipoPagamento);
            cmd.Parameters.AddWithValue("@Observacao", contrato.Observacoes);
            cmd.Parameters.AddWithValue("@DiaVencimento", contrato.DiaVencimento);
            cmd.Parameters.AddWithValue("@DataContrato", contrato.DataContrato);
            cmd.Parameters.AddWithValue("@QtdVezes", contrato.QtdVezes);
            cmd.Parameters.AddWithValue("@ValorTotal", contrato.ValorTotal);
            cmd.Parameters.AddWithValue("@ValorEntrada", contrato.ValorEntrada);
            cmd.Parameters.AddWithValue("@ValorComissao", contrato.ValorComissao);

            cmd.ExecuteNonQuery();                                                      //CADASTROU CONTRATO

            con.FechaConexao();
        }

        public void CadastraParcela(Parcelas parcelas)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();

            SqlCommand cmd = new SqlCommand("spCadastraParcela", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", parcelas.IdCliente);
            cmd.Parameters.AddWithValue("@IdContrato", parcelas.IdContrato);
            cmd.Parameters.AddWithValue("@Valor", parcelas.Valor);
            cmd.Parameters.AddWithValue("@DataVencimento", parcelas.DataVencimento);
            cmd.Parameters.AddWithValue("@Situacao", parcelas.Situacao);
            cmd.Parameters.AddWithValue("@Observacao", parcelas.Observacao);


            cmd.ExecuteNonQuery();                                                      //CADASTROU PARCELA

            con.FechaConexao();
        }
        public void CadastraEntradaParcela(Parcelas parcelas,Contrato contrato)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();

            SqlCommand cmd = new SqlCommand("spCadastraParcela", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", parcelas.IdCliente);
            cmd.Parameters.AddWithValue("@IdContrato", parcelas.IdContrato);
            cmd.Parameters.AddWithValue("@Valor", contrato.ValorEntrada);
            cmd.Parameters.AddWithValue("@DataVencimento", parcelas.DataVencimento);
            cmd.Parameters.AddWithValue("@Situacao", parcelas.Situacao);
            cmd.Parameters.AddWithValue("@Observacao", parcelas.Observacao);


            cmd.ExecuteNonQuery();                                                      //CADASTROU ENTRADA PARCELA

            con.FechaConexao();
        }

        public void RemoveParcela(Parcelas parcela)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();

            SqlCommand cmd = new SqlCommand("spDeletaParcela", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdParcela",parcela.IdParcela);

            cmd.ExecuteNonQuery();                                                      //DELETOU PARCELA

            con.FechaConexao();
        }

        public void CadastraDivida(Contrato contrato,Parcelas parcelas,
            DateTimePicker dtpParcela) {
            int VezesDpsEntrada = contrato.QtdVezes - 1;
            CadastraContrato(contrato);
            while (!dtpParcela.Value.Day.ToString().Equals(contrato.DiaVencimento)) // CHECA SE É O DIA DE VENCIMENTO
            {
                dtpParcela.Value = dtpParcela.Value.AddDays(1);
            }
            parcelas.DataVencimento = dtpParcela.Value.ToShortDateString();

            CadastraEntradaParcela(parcelas, contrato);

            if (contrato.QtdVezes > 1)
            {
                for(int contador = 0; contador < VezesDpsEntrada; contador++)
                {
                    dtpParcela.Value = dtpParcela.Value.AddMonths(1);
                    parcelas.DataVencimento = dtpParcela.Value.ToShortDateString();
                    CadastraParcela(parcelas);
                }
            }
                                                                                        //CADASTROU DIVIDA
        }


        public void AlteraProcesso(Cliente cliente, ParteContraria parteContraria,
            Processo processo, bool novoCliente, bool novaParteContraria)           //USANDO VARIAVEIS DE CONTROLE PARA SABER SE VAI INSERIR UM NOVO REGISTRO NO UPDATE
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            if (!novoCliente)
            {
                //ALTERA CLIENTE
                SqlCommand cmd1 = new SqlCommand("spUpdateCliente ", con.GetConexao());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                cmd1.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd1.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd1.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd1.ExecuteNonQuery();
            }
            else { CadastraCliente(cliente); }

            if (!novaParteContraria)
            {
                //ALTERA PARTE CONTRARIA
                SqlCommand cmd2 = new SqlCommand("spUpdateParteContraria", con.GetConexao());
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@IdParteContraria", parteContraria.IdParteContraria);
                cmd2.Parameters.AddWithValue("@Nome", parteContraria.Nome);
                cmd2.Parameters.AddWithValue("@CPF", parteContraria.Cpf);
                cmd2.Parameters.AddWithValue("@CNPJ", parteContraria.Cnpj);
                cmd2.Parameters.AddWithValue("@Tipo", parteContraria.Tipo);
                cmd2.ExecuteNonQuery();
            }
            else { CadastraParteContraria(parteContraria); }

                //ALTERA PROCESSO
            SqlCommand cmd = new SqlCommand("spUpdateProcesso", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProcesso", processo.IdProcesso);
            cmd.Parameters.AddWithValue("@IdCliente", processo.IdCliente);
            cmd.Parameters.AddWithValue("@IdParteContraria", processo.IdParteContraria);
            cmd.Parameters.AddWithValue("@NumeroProcesso", processo.NumProcesso);
            cmd.Parameters.AddWithValue("@Foro", processo.Foro);
            cmd.Parameters.AddWithValue("@TipoAcao", processo.TipoAcao);
            cmd.Parameters.AddWithValue("@Area", processo.Area);
            cmd.Parameters.AddWithValue("@AndamentoProcesso", processo.AndamentoProcesso);
            cmd.Parameters.AddWithValue("@FoiIndicacao", processo.FoiIndicacao);
            cmd.Parameters.AddWithValue("@NomeCaptador", processo.NomeCaptador);
            cmd.Parameters.AddWithValue("@LocalDescobrimento", processo.LocalDescobrimento);
            cmd.ExecuteNonQuery();
            
            con.FechaConexao();
        }
        public void AlteraContrato(Contrato contrato)   
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spUpdateContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdContrato", contrato.IdContrato);
            cmd.Parameters.AddWithValue("@TipoPagamento", contrato.TipoPagamento);
            cmd.Parameters.AddWithValue("@Observacao", contrato.Observacoes);
            cmd.Parameters.AddWithValue("@DiaVencimento", contrato.DiaVencimento);
            cmd.Parameters.AddWithValue("@DataContrato", contrato.DataContrato);
            cmd.Parameters.AddWithValue("@QtdVezes", contrato.QtdVezes);
            cmd.Parameters.AddWithValue("@ValorTotal", contrato.ValorTotal);
            cmd.Parameters.AddWithValue("@ValorEntrada ", contrato.ValorEntrada);
            cmd.Parameters.AddWithValue("@ValorComissao", contrato.ValorComissao);
            cmd.ExecuteNonQuery();

            con.FechaConexao();
        }
        public void AlteraParcela(Parcelas parcela)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spUpdateParcela", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdParcela", parcela.IdParcela);
            cmd.Parameters.AddWithValue("@Valor", parcela.Valor);
            cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
            cmd.Parameters.AddWithValue("@Situacao", parcela.Situacao);
            cmd.Parameters.AddWithValue("@Observacao", parcela.Observacao);
            cmd.ExecuteNonQuery();

            con.FechaConexao();
        }

        public Double SomaParcelas(Contrato contrato)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spSomaParcelas", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdContrato", contrato.IdContrato);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    return 0;
                }
                else
                {
                    if (dt.Rows[0][0].ToString() != "")
                        return double.Parse(dt.Rows[0][0].ToString());
                    else
                        return 0;
                }
            }
            con.FechaConexao();
        }
        public void AlteraParcelaRapido(Parcelas parcela)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spUpdateParcela", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdParcela", parcela.IdParcela);
            cmd.Parameters.AddWithValue("@Valor", parcela.Valor);
            cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
            cmd.Parameters.AddWithValue("@Situacao", parcela.Situacao);
            cmd.Parameters.AddWithValue("@Observacao", parcela.Observacao);
            cmd.ExecuteNonQuery();

            con.FechaConexao();
        }
        public void PegaUltimoIdCliente(Cliente cliente) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spPegaUltimoIdCliente", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    cliente.IdCliente = 1;
                }
                else
                {
                    cliente.IdCliente = int.Parse(dt.Rows[0][0].ToString());
                }
            }
            con.FechaConexao();

        }
        public void PegaUltimoIdParteContraria(ParteContraria parteContraria) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spPegaUltimoIdParteContraria", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    parteContraria.IdParteContraria = 1;
                }
                else
                {
                    parteContraria.IdParteContraria = int.Parse(dt.Rows[0][0].ToString());
                }
            }
            con.FechaConexao();

        }
        public void PegaUltimoIdContrato(Contrato contrato)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spPegaUltimoIdContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    contrato.IdContrato = 1;
                }
                else
                {
                    contrato.IdContrato = int.Parse(dt.Rows[0][0].ToString());
                }
            }
            con.FechaConexao();
        }
        public void RefreshClientes(DataGridView dgv) {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetFiltragemSimplesProcesso", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].Visible = false;
            }
            con.FechaConexao();
        }
        public void RefreshContratos(DataGridView dgv)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetFiltragemSimplesContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = true;
                dgv.Columns[1].Visible = true;
                dgv.Columns[2].Visible = true;

                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].Visible = false;
            }
            con.FechaConexao();
        }
        public void RefreshDivida(Contrato contrato,DataGridView dgv)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetContrato", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdContrato", contrato.IdContrato);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
                dgv.Columns[7].Visible = false;
            }
            con.FechaConexao();
        }
        public void PesquisaProcesso(DataGridView dgv, string filtro, string texto)
        {
            FabricaConexao con = new FabricaConexao();
            con.AbreConexao();
            SqlCommand cmd = new SqlCommand("spGetFiltragemAvancadaProcesso", con.GetConexao());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Filtro", filtro);
            cmd.Parameters.AddWithValue("@Texto", texto);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgv.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Visible = false;
                    dgv.Columns[2].Visible = false;
                }
            }
            con.FechaConexao();
        }
        public void PesquisaContrato(DataGridView dgv, string filtro, string texto,
            int filtroIndex)
        {
            try
            {
                FabricaConexao con = new FabricaConexao();
                con.AbreConexao();
                SqlCommand cmd = new SqlCommand("spGetFiltragemAvancadaContrato", con.GetConexao());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filtro", filtro);
                cmd.Parameters.AddWithValue("@Texto", texto);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        if (filtroIndex<=4) // LIMITE DO INDICE- PARA COBRIR COLUNAS
                        {
                            dgv.Columns[0].Visible = false;
                            dgv.Columns[1].Visible = false;
                            dgv.Columns[2].Visible = false;
                        }
                        else
                        {
                            dgv.Columns[0].Visible = false;
                            dgv.Columns[1].Visible = false;
                        }

                    }
                    else
                    {
                        dgv.DataSource = null;
                    }
                }
                con.FechaConexao();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
