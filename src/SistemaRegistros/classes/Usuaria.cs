using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRegistros.classes
{
    public class Usuaria
    {
        private int _idUsuaria;
        private string _nomeUsuaria, _senha,_tipoAcessoUsuaria;

        public Usuaria()
        {
        }

        public Usuaria(string tipoAcessoUsuaria)
        {
            _tipoAcessoUsuaria = tipoAcessoUsuaria;
        }

        public Usuaria(string nomeUsuaria, string senha)
        {
            _nomeUsuaria = nomeUsuaria;
            _senha = senha;
        }

        public string NomeUsuaria { get => _nomeUsuaria; set => _nomeUsuaria = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public int Idusuaria { get => _idUsuaria; set => _idUsuaria = value; }
        public string TipoAcessoUsuaria { get => _tipoAcessoUsuaria; set => _tipoAcessoUsuaria = value; }
    }
}
