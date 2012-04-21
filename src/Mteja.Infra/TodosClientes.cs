using System;
using System.Collections.Generic;
using System.Linq;
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

            cliente.Codigo = db.GetLastInsertId();

            //var id = int;
            //db.QuerySingle("Select @@IDENTITY as LastIdentity").LastIdentity;
            //cliente.Codigo = Convert.ToInt32(id);

            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var db = ObterBancoDados();
            var query = "Select Codigo,Nome,DataCadastro From Cliente";
            var queryResult = db.Query(query);
            var clientes = ConveterParaCliente(queryResult);

            return clientes;
        }

        public Cliente ObterPor(int id)
        {
            var db = ObterBancoDados();
            var query = "Select Codigo,Nome,DataCadastro From Cliente Where Codigo = @0";
            var queryResult = db.Query(query, id);

            return ConveterParaCliente(queryResult).FirstOrDefault();
        }

        private Database ObterBancoDados()
        {
            return Database.OpenConnectionString(_connetionString, _providerName);
        }

        private static List<Cliente> ConveterParaCliente(IEnumerable<dynamic> queryResult)
        {
            var clientes = new List<Cliente>();

            foreach (var linha in queryResult)
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
