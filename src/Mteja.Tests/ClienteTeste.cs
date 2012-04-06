using System;
using Mteja.DI;
using NUnit.Framework;

namespace Mteja.Tests
{
    [TestFixture]
    public class ClienteTeste
    {
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
            Assert.Throws<Exception>(() => cliente.VerificarSeNomeEhVazio(), "Nome do Cliente é obrigatório.");
        }

        [Test]
        public void Nome_Do_Cliente_Nao_Pode_Ser_Nulo()
        {
            var cliente = new Cliente();

            cliente.Nome = null;

            Assert.Throws<Exception>(() => cliente.VerificarSeNomeEhVazio(), "Nome do Cliente é obrigatório.");
        }

        [Test]
        public void Nome_Do_Cliente_Nao_Pode_Ser_Vazio()
        {
            var cliente = new Cliente();

            cliente.Nome = "";

            Assert.Throws<Exception>(() => cliente.VerificarSeNomeEhVazio(), "Nome do Cliente é obrigatório.");
        }
    }
}