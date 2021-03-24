using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRegistros
{
    public class Cliente
    {
        private int _idCliente;
        private string _nome, _cpf,_telefone;

        public Cliente(){}
        

        public Cliente(int idCliente)
        {
            IdCliente = idCliente;
        }

        public Cliente(int idCliente, string nome, string cpf, string telefone) : this(idCliente)
        {
            _nome = nome;
            _cpf = cpf;
            _telefone = telefone;
        }

        public override string  ToString()
        {
            string minhaString = "CLIENTE: "+IdCliente.ToString()+"|"+ Nome.ToString()+"|"+Cpf.ToString()+"|"+Telefone.ToString();
            return minhaString;
        }

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
    }
}
