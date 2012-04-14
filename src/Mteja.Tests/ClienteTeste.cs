using System;
using System.Collections.Generic;
using Mteja.Domain;
using Mteja.Infra;
using NUnit.Framework;

namespace Mteja.Tests
{
    [TestFixture]
    public class ClienteTeste
    {
        string connectionString = @"Data Source=localhost\AGRO_CO; User=sa; password=sap@123; Initial Catalog=App";
        string provider = @"System.Data.SqlClient";

        [SetUp]
        public void Setup()
        {
            var databaseService = new DataBaseService(connectionString, provider);
            databaseService.RemoveTabelaCliente();
        }

        [Test]
        public void Posso_Ter_Um_Cliente()
        {
            var cliente = new Cliente();
            Assert.Pass();
        }

        [Test]
        public void Todo_Cliente_Tem_Um_Nome()
        {
            //Arrange
            var cliente = new Cliente();

            //Act
            cliente.Nome = "Fabio Nascimento";

            //Asset
            Assert.AreEqual("Fabio Nascimento", cliente.Nome);
        }

        [Test]
        public void Nome_Do_Cliente_Deve_Ser_Preenchido()
        {
            var cliente = new Cliente();

            cliente.Nome = "Fabio Nascimento";
            cliente.VerificarSeNomeEhVazio();

            Assert.Pass();
        }

        [Test]
        public void Nome_Do_Cliente_Nao_Pode_Ter_Espacos_Em_Branco()
        {
            var cliente = new Cliente();

            cliente.Nome = "   ";
            Assert.Throws<Exception>(cliente.VerificarSeNomeEhVazio, "Nome do Cliente é obrigatório.");
        }

        [Test]
        public void Nome_Do_Cliente_Nao_Pode_Ser_Nulo()
        {
            var cliente = new Cliente();

            cliente.Nome = null;

            Assert.Throws<Exception>(cliente.VerificarSeNomeEhVazio, "Nome do Cliente é obrigatório.");
        }

        [Test]
        public void Nome_Do_Cliente_Nao_Pode_Ser_Vazio()
        {
            var cliente = new Cliente();

            cliente.Nome = "";

            Assert.Throws<Exception>(cliente.VerificarSeNomeEhVazio, "Nome do Cliente é obrigatório.");
        }

        [Test]
        public void Todo_Cliente_Tem_Uma_Data_Cadastro()
        {
            var cliente = new Cliente();

            var dataAgora = DateTime.Now;

            cliente.DataCadastro = dataAgora;

            Assert.AreEqual(dataAgora, cliente.DataCadastro);
        }

        [Test]
        public void Data_De_Cadastro_Do_Cliente_Nao_Pode_Ser_Nulo()
        {
            var cliente = new Cliente();

            Assert.Throws<Exception>(cliente.VerificarSeDataEhNula, "Data de Cadastro do cliente é obrigatório.");
        }

        [Test]
        public void Posso_Enviar_Cliente_Para_Ser_Armazenado()
        {
            //Arrange
            //var todosClientes = new TodosClientesBanco(connectionString, provider);
            var todosClientesFake = new TodosClientesTestMock();
            var clienteServico = new ClienteServico(todosClientesFake);

            //Act
            var cliente = new Cliente();            
            cliente.Nome = "Fábio Nascimento";
            clienteServico.Salvar(cliente);            

            //Assert
            var clientes = clienteServico.ObjterTodos();

            Assert.NotNull(clientes);
            Assert.AreEqual(1, clientes.Count);
        }
    }
}