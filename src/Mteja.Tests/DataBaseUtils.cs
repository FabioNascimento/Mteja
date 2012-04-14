using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMatrix.Data;

namespace Mteja.Tests
{
    public class DataBaseService
    {
        private string _connetionString;
        private string _providerName;

        public DataBaseService(string connetionString, string providerName)
        {
            _providerName = providerName;
            _connetionString = connetionString;
        }

        public void RemoveTabelaCliente()
        {
            var db = Database.OpenConnectionString(_connetionString, _providerName);
            var query = string.Format("Delete From Cliente");

            db.Execute(query);
        }
    }
}
