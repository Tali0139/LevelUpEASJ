
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelUpEASJ.ViewModel;
using LevelUpEASJ.Model;

namespace UnitTestLevelUpEASJ
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCountOfClients()
        {
            LevelUpViewModel lv = new LevelUpViewModel();
            Assert.AreEqual(3, lv.ClientCount);
        }
    }


    //[TestClass]
    //public class UnitTest2
    //{
    //    [TestMethod]
    //    public void TestIdNameOfClients()
    //    {
    //        LevelUpViewModel lv = new LevelUpViewModel();

    //        Assert.AreEqual(3, lv.FirstName);
    //    }
    //}


    //[TestClass]
    //public class UnitTest3
    //{
    //    [TestMethod]
    //    public void TestAddOfClients()
    //    {
    //        LevelUpViewModel lv = new LevelUpViewModel();

    //        Client c1 = new Client(99, "Kon", "test", "test", "1234", 10, 10.2, 10, 10.8, "mand", 10, 60);
            
    //        lv.ToAddNewClient(c1);
    //        Assert.AreEqual(4, lv.ClientCount)




    //         [TestMethod]
    //    public void TestAdd_Tour()
    //        {
    //            TourCatalog tc = new TourCatalog();
    //            Display tour = new Display();

    //            tc.addTour1(tour);
    //            Assert.AreEqual(1, tc.Tour1.Count);
    //        }
    //    }
    //}


}
