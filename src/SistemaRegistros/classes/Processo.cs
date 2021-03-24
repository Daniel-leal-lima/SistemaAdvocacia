using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRegistros
{
    public class Processo
    {
        private int _idCliente,_idparteContraria, _idProcesso;
        private string _numProcesso, _andamentoProcesso, _foro, _area, _tipoAcao;
        private string _foiIndicacao,_nomeCaptador,_localDescobrimento;

        public Processo(){}

        public Processo(int idCliente, int idParteContraria, int idProcesso, string numProcesso,
            string andamentoProcesso, string foro, string area, string tipoAcao)
        {
            IdCliente = idCliente;
            IdParteContraria = idParteContraria;
            IdProcesso = idProcesso;
            NumProcesso = numProcesso;
            AndamentoProcesso = andamentoProcesso;
            Foro = foro;
            Area = area;
            TipoAcao = tipoAcao;
        }

        public Processo(int idProcesso)
        {
            IdProcesso = idProcesso;
        }

        public override string ToString()
        {
            string minhaString = "PROCESSO: " + IdCliente.ToString() + "|" + IdParteContraria.ToString()+
                "|" + AndamentoProcesso.ToString()+"|"+Foro.ToString()+"|"+Area.ToString()+"|"+TipoAcao.ToString();
            return minhaString;
        }

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdParteContraria { get => _idparteContraria; set => _idparteContraria = value; }
        public int IdProcesso { get => _idProcesso; set => _idProcesso = value; }
        public string NumProcesso { get => _numProcesso; set => _numProcesso = value; }
        public string AndamentoProcesso { get => _andamentoProcesso; set => _andamentoProcesso = value; }
        public string Foro { get => _foro; set => _foro = value; }
        public string Area { get => _area; set => _area = value; }
        public string TipoAcao { get => _tipoAcao; set => _tipoAcao = value; }
        public string FoiIndicacao { get => _foiIndicacao; set => _foiIndicacao = value; }
        public string NomeCaptador { get => _nomeCaptador; set => _nomeCaptador = value; }
        public string LocalDescobrimento { get => _localDescobrimento; set => _localDescobrimento = value; }
    }
}
