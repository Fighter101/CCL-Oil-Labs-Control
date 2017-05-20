using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCL_Oil_Labs_Control.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace CCL_Oil_Labs_Control.Model.Tests
{
    [TestClass()]
    public class AnalysisTypeTests
    {
        public void AddingItemTest()
        {
            //Adding a New Item
            ObservableCollection<AnalysisType> analysis = DatabaseEntities.Initiate().AnalysisTypes.Local;
            analysis.Add(new AnalysisType
            {
                TypeName = "Test Analysis Type",
                Type = 4,
                

            });
            DatabaseEntities.Initiate().SaveChanges();

            //Retreving The Item
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Test Analysis Type"
             && testAnalysis.Type == 4
             select testAnalysis).Load();
            Assert.IsNotNull(model.Analyses.Single(testAnalysis=> testAnalysis.TypeName == "Test Analysis Type"
             && testAnalysis.Type == 4));
        }
        [TestMethod]
        public void modifyingItemTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.AnalysisTypes
             where testAnalysis.TypeName == "Test Analysis Type"
             && testAnalysis.Type == 4
             select testAnalysis).Load();
            model.Analyses.Single(testAnalysis => testAnalysis.TypeName == "Test Analysis Type"
             && testAnalysis.Type == 4).TypeName = "Modified Test";
            model.SaveChanges();

            //Checking if modifcation is done right
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 4
             select testAnalysis).Load();
            Assert.IsNotNull(model.Analyses.Single(test => test.Name == "Modified Test" && test.Type == 4));

        }
        [TestMethod]
        public void deletingElementTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 4
             select testAnalysis).Load();
            model.Analyses.Local.Remove(model.Analyses.Single(test => test.Name == "Modified Test" && test.Type == 4));
            model.SaveChanges();
            //checking if deleted
            DatabaseEntities.clearEntity<AnalysisType>();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 4
             select testAnalysis).Load();
            Assert.IsNull(model.Analyses.Local.FirstOrDefault());
        }
    }
}