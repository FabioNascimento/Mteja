using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mteja.Domain;
using WebMatrix.Data;

namespace Mteja.Infra
{
    public class TodosClientesBanco : ITodosClientes
    {
        private string _connetionString;
        private string _providerName;

        public TodosClientesBanco(string connetionString, string providerName)
        {
            _providerName = providerName;
            _connetionString = connetionString;
        }

        public Cliente Inserir(Cliente cliente)
        {
            var db = ObterBancoDados();

            var query = "Insert Into Cliente (Nome, DataCadastro) values (@0,@1)";

            db.Execute(query, cliente.Nome, cliente.DataCadastro);

            var id = db.QuerySingle("Select @@IDENTITY as LastIdentity").LastIdentity;

            cliente.Codigo = Convert.ToInt32(id);

            return cliente;
        }

        private Database ObterBancoDados()
        {
            return Database.OpenConnectionString(_connetionString, _providerName);
        }


        public List<Cliente> ObterTodos()
        {
            var db = ObterBancoDados();
            var query = "Select Codigo,Nome,DataCadastro From Cliente";
            var clientes = new List<Cliente>();

            foreach (var linha in db.Query(query))
            {
                var cliente = new Cliente();

                cliente.Codigo = linha.Codigo;
                cliente.Nome = linha.Nome;
                cliente.DataCadastro = linha.DataCadastro;

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
