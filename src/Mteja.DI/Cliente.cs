using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mteja.DI
{
    public class Cliente
    {
        public string Nome { get; set; }

        public void VerificarSeNomeEhVazio()
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new Exception("Nome do Cliente é obrigatório.");
            }
        }
    }
}
