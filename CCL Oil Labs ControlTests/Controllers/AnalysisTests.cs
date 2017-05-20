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
    public class AnalysisTests
    {
        [TestMethod]
        public void AddingItemTest()
        {
            //Adding a New Item
            ObservableCollection<AnalysisType> analysis = DatabaseEntities.Initiate().Analyses.Local;
            analysis.Add(new AnalysisType
            {
                Name = "Test Analysis",
                Type = 2,

            });
            DatabaseEntities.Initiate().SaveChanges();

            //Retreving The Item
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Test Analysis"
             && testAnalysis.Type == 2
             select testAnalysis).Load();
            Assert.IsNotNull(model.Analyses.Single(test => test.Name == "Test Analysis" && test.Type == 2));
        }
        [TestMethod]
        public void modifyingItemTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Test Analysis"
             && testAnalysis.Type == 2
             select testAnalysis).Load();
            model.Analyses.Single(test => test.Name == "Test Analysis" && test.Type == 2).Name = "Modified Test";
            model.SaveChanges();

            //Checking if modifcation is done right
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 2
             select testAnalysis).Load();
            Assert.IsNotNull(model.Analyses.Single(test => test.Name == "Modified Test" && test.Type == 2));

        }
        [TestMethod]
        public void deletingElementTest()
        {
            var model = DatabaseEntities.Initiate();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 2
             select testAnalysis).Load();
            model.Analyses.Local.Remove(model.Analyses.Single(test => test.Name == "Modified Test" && test.Type == 2));
            model.SaveChanges();
            //checking if deleted
            DatabaseEntities.clearEntity<AnalysisType>();
            (from testAnalysis in model.Analyses
             where testAnalysis.Name == "Modified Test"
             && testAnalysis.Type == 2
             select testAnalysis).Load();
            Assert.IsNull(model.Analyses.Local.FirstOrDefault());
        }
    }
}