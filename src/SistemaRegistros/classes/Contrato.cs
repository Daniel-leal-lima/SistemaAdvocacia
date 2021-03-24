using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRegistros
{
    public class Contrato
    {
        private int _idProcesso, _idContrato, _QtdVezes;
        private string _observacoes, _tipoPagamento, _diaVencimento,_dataContrato;
        private double _valorEntrada, _valorComissao,_valorTotal;

        public Contrato(){}

        public Contrato(int idProcesso, int idContrato, string observacoes, string tipoPagamento)
        {
            IdProcesso = idProcesso;
            IdContrato = idContrato;
            Observacoes = observacoes;
            TipoPagamento = tipoPagamento;
        }

        public Contrato(int idContrato)
        {
            IdContrato = idContrato;
        }

        public override string ToString()
        {
            string minhaString = "Contrato:"+IdContrato+"|"+TipoPagamento.ToString()+"|"+Observacoes.ToString();
            return minhaString;
        }
        public int IdProcesso { get => _idProcesso; set => _idProcesso = value; }
        public int IdContrato { get => _idContrato; set => _idContrato = value; }
        public string Observacoes { get => _observacoes; set => _observacoes = value; }
        public string TipoPagamento { get => _tipoPagamento; set => _tipoPagamento = value; }
        public int QtdVezes { get => _QtdVezes; set => _QtdVezes = value; }
        public string DiaVencimento { get => _diaVencimento; set => _diaVencimento = value; }
        public double ValorEntrada { get => _valorEntrada; set => _valorEntrada = value; }
        public double ValorComissao { get => _valorComissao; set => _valorComissao = value; }
        public string DataContrato { get => _dataContrato; set => _dataContrato = value; }
        public double ValorEntrada1 { get => _valorEntrada; set => _valorEntrada = value; }
        public double ValorComissao1 { get => _valorComissao; set => _valorComissao = value; }
        public double ValorTotal { get => _valorTotal; set => _valorTotal = value; }
    }
}
