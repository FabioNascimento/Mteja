using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mteja.DI
{
    public class Endereco
    {

        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public void CheckSeTipoTemValor()
        {
            if (string.IsNullOrWhiteSpace(Tipo))
                throw new Exception("O tipo de endereço não pode ser vazio");
        }
    }
}
