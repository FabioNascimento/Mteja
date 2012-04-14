using System;

namespace Mteja.Domain
{
    public class Cliente
    {
        public int Codigo { get; set; }
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
