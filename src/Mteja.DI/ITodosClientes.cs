using System.Collections.Generic;

namespace Mteja.Domain
{
    public interface ITodosClientes
    {
        Cliente Inserir(Cliente cliente);

        List<Cliente> ObterTodos();

        Cliente ObterPor(int id);
    }
}
