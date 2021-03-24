using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemaRegistros
{
    class Parcelas
    {
        private int _idParcela,_idCliente, _idContrato;
        private string _dataPagamento,_situacao,_observacao;
        private double _valor;

        public Parcelas(){}

        public Parcelas(int idParcela)
        {
            _idParcela = idParcela;
        }

        public override string ToString()
        {
            string minhaString = "Parcela:" + IdParcela.ToString()+"|"+DataPagamento.ToString()+ "|" +Valor.ToString("C", CultureInfo.CurrentCulture);
            return minhaString;
        }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdContrato { get => _idContrato; set => _idContrato = value; }
        public string DataPagamento { get => _dataPagamento; set => _dataPagamento = value; }
        public string Situacao { get => _situacao; set => _situacao = value; }
        public int IdParcela { get => _idParcela; set => _idParcela = value; }
        public double Valor { get => _valor; set => _valor = value; }
        public string Observacao { get => _observacao; set => _observacao = value; }

        public Double DivideEmXVezes(Double valorOriginal,int qtdVezes)
        {
            return valorOriginal/qtdVezes;
        }
    }
}
