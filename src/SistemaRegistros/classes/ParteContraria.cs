using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRegistros
{
    public class ParteContraria
    {
        private int _idParteContraria;
        private string _nome, _cpf,_cnpj,_tipo;
        

        public ParteContraria(){}

        public ParteContraria(int idParteContraria, string nome, string cpf, string cnpj, string tipo)
        {
            IdParteContraria = idParteContraria;
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Tipo = tipo;
        }

        public ParteContraria(int idParteContraria)
        {
            IdParteContraria = idParteContraria;
        }

        public override string ToString()
        {
            string minhaString = "PARTE CONTRARIA: "+ IdParteContraria.ToString()+"|" + Nome.ToString() + "|" + Cpf.ToString()+
                "|"+Cnpj.ToString()+"|"+Tipo.ToString();
            return minhaString;
        }

        public int IdParteContraria { get => _idParteContraria; set => _idParteContraria = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Cnpj { get => _cnpj; set => _cnpj = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
    }
}
