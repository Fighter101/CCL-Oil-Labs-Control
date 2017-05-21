using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCL_Oil_Labs_Control.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
namespace CCL_Oil_Labs_Control.Model.Tests
{
    [TestClass()]
    public class ConnectivityTest
    {
        [TestMethod()]
        public void testDBConnection()
        {
            var model = DatabaseEntities.Initiate();
            Assert.IsNotNull(model);
        }
    }
}
