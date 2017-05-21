using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCL_Oil_Labs_Control.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Data.Entity;

namespace CCL_Oil_Labs_Control.Model.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void loginTest()
        {
            SecureString x = new SecureString();
            "root".ToCharArray().ToList().ForEach(p => x.AppendChar(p));

            User user = new User("root", x);
            Assert.AreEqual(true, user.login());
        }

        [TestMethod()]
        public void wrongLoginTest()
        {
            SecureString x = new SecureString();
            "toor".ToCharArray().ToList().ForEach(p => x.AppendChar(p));

            User user = new User("root", x);
            Assert.AreEqual(false, user.login());
        }
        [TestMethod()]
        public void RegisterTest()
        {
            SecureString x = new SecureString();
            "12345".ToCharArray().ToList().ForEach(p => x.AppendChar(p));

            User user = new User("Test User", x);
            user.Register();

            var model = DatabaseEntities.Initiate();
            (from selection in model.Users where selection.Username == "Test User" select selection).Load();
            Assert.IsNotNull(model.Users.Local.Single(selection => selection.Username == "Test User"));
        }
    }
}