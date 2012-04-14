using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mteja.Domain;

namespace Mteja.Tests
{
    public class TodosClientesTestMock : ITodosClientes
    {
        List<Cliente>  clientes = new List<Cliente>();

        public Cliente Inserir(Cliente cliente)
        {
            //cliente.Codigo == 0 ? 1 : clientes.Max(c => c.Codigo) 
            cliente.Codigo = clientes.Count + 1;

            clientes.Add(cliente);
            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            return clientes;
        }
    }
}
