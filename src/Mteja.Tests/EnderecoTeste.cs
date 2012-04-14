using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mteja.Domain;
using NUnit.Framework;

namespace Mteja.Tests
{
    [TestFixture]
    public class EnderecoTeste
    {
        [Test]
        public void Deve_Existir_Endereco()
        {
            var endereco = new Endereco();
            Assert.Pass();
        }

        [Test]
        public void Todo_Endereco_Deve_Ter_Um_Tipo()
        {
            //Arrange 
            var endereco = new Endereco();

            //Act
            endereco.Tipo = "Rua";

            //Assert
            Assert.AreEqual(endereco.Tipo, "Rua");
        }

        [Test]
        public void O_Tipo_De_Endereco_Deve_Conter_Valor()
        {
            var endereco = new Endereco();

            Assert.Throws<Exception>(endereco.CheckSeTipoTemValor, "O tipo de endereço não pode ser vazio");

            endereco.Tipo = "Rua";

            endereco.CheckSeTipoTemValor();

            Assert.AreEqual(endereco.Tipo, "Rua");
        }

        [Test]
        public void Todo_Endereço_Deve_Ter_Um_Nome()
        {
            var endereco = new Endereco();

            endereco.Nome = "Nadra Bufaiçal";

            Assert.AreEqual(endereco.Nome, "Nadra Bufaiçal");
        }

        [Test]
        public void Todo_Endereço_Deve_Ter_Um_Bairro()
        {
            var endereco = new Endereco();

            endereco.Bairro = "FaiçalVille";

            Assert.AreEqual(endereco.Bairro, "FaiçalVille");
        }

        [Test]
        public void Todo_Endereço_Deve_Ter_Uma_Cidade()
        {
            var endereço = new Endereco();

            endereço.Cidade = "Goiânia";

            Assert.AreEqual(endereço.Cidade, "Goiânia");
        }

        [Test]
        [Category("Deploy")]
        public void Endereco_Deve_Ser_Valido()
        {
            Todo_Endereco_Deve_Ter_Um_Tipo();
            O_Tipo_De_Endereco_Deve_Conter_Valor();
            Todo_Endereço_Deve_Ter_Um_Bairro();
            Todo_Endereço_Deve_Ter_Um_Nome();
            Todo_Endereço_Deve_Ter_Uma_Cidade();

            Assert.Pass();
        }

    }
}
