using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mteja.DI
{
    public class Cliente
    {
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public void VerificarSeNomeEhVazio()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new Exception("Nome do Cliente é obrigatório.");
            }
        }

        public void VerificarSeDataEhNula()
        {
            if(DataCadastro == DateTime.MinValue)
            {
                throw new Exception("Data de Cadastro do cliente é obrigatório.");
            }
        }
    }
}
