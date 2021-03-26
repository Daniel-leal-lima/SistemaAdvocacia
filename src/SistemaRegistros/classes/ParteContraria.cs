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
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
