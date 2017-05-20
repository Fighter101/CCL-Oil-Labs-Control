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
    public class AnalysisTypeTests
    {
        [TestMethod()]
        public void AddingItemTest()
        {
            //Adding a New Item
            ObservableCollection<AnalysisType> analysis = DatabaseEntities.Initiate().AnalysisTypes.Local;
            analysis.Add(new AnalysisType
            {
                TypeName = "Test Analysis Type"
            });
            DatabaseEntities.Initiate().SaveChanges();

            //Retreving The Item
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Test Analysis Type"
             select testAnalysis).Load();
            Assert.IsNotNull(model.AnalysisTypes.Single(testAnalysis => testAnalysis.TypeName == "Test Analysis Type"));
        }
        [TestMethod]
        public void modifyingItemTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Test Analysis Type"
             select testAnalysis).Load();
            model.AnalysisTypes.Single(testAnalysis => testAnalysis.TypeName == "Test Analysis Type").TypeName = "Modified Test";
            model.SaveChanges();

            //Checking if modifcation is done right
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Modified Test"
             select testAnalysis).Load();
            Assert.IsNotNull(model.AnalysisTypes.Single(test => test.TypeName == "Modified Test"));

        }
        [TestMethod]
        public void deletingElementTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Modified Test"
             select testAnalysis).Load();
            model.AnalysisTypes.Local.Remove(model.AnalysisTypes.Single(test => test.TypeName == "Modified Test"));
            model.SaveChanges();
            //checking if deleted
            DatabaseEntities.clearEntity<AnalysisType>();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Modified Test"
             select testAnalysis).Load();
            Assert.IsNull(model.Analyses.Local.FirstOrDefault());
        }
    }
}