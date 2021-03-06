﻿
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelUpEASJ.ViewModel;
using LevelUpEASJ.Model;

namespace UnitTestLevelUpEASJ
{
    [TestClass]
    public class UnitTest1

    {
        LevelUpViewModel luvm = new LevelUpViewModel();


        [TestMethod]
        public void TestCountOfClients()
        {
            Assert.AreEqual(8, luvm.ClientCount);
        }



        [TestMethod]
        public void TestIdNameOfClients()
        {
            string s = luvm.all_Clients[2].FirstName;

            Assert.AreEqual("Omar", s);
        }

        [TestMethod]
        public void TestAddOfClients()
        {


            Client c1 = new Client(99, "Kon", "test", 22334455, "test",
                "1234","../Assets/mand1.png", 10, 10.2, 10, 10.8, "mand", 10, 60,870, "Vil Løbe húrtigere");
            ClientCatalogSingleton.ClientInstance.AddClient(c1);

            Assert.AreEqual(8, luvm.ClientCount);
            string s = luvm.all_Clients[4].FirstName;
            Assert.AreEqual("John", s);

        }


        //[TestMethod]
        //public void TestDeleteClient()
        //{


        //    Client c2 = new Client(98, "delete", "test", 22334445, "delete", "12345","picture", 10, 10.2, 10, 10.8, "mand", 10, 60);
        //    ClientCatalogSingleton.ClientInstance.AddClient(c2);
        //    ClientCatalogSingleton.ClientInstance.DeleteClient(c2);

        //    Assert.AreEqual(6, lv.ClientCount);

        //}


        //[TestMethod]
        //public void TestUpdateClient()
        //{
        //    Client client = new Client(2,"OwnsaBeach", "Eierstrand", 12345678, "oliver", "1234","picture", 24, 70, 196, 15.9, "mand", 30,45);
        //    string s = lv.all_Clients[1].FirstName;
        //    lv.ToUpdateClient();
        //    Assert.AreEqual("OwnsaBeach", s);
        //}




        [TestMethod]
        public void TestCountOfTrainers()
        {
            Trainer t1 = new Trainer(1, "Træner", "trænersen", 12345678, "træner", "1234","picture", 8);
            TrainerCatalogSingleton.TrainerInstance.AddTrainer(t1);
            Assert.AreEqual(2, luvm.TrainerCount);
        }


        [TestMethod]
        public void TestIdNameOfTrainers()
        {
            string s = luvm.all_Trainers[0].FirstName;

            Assert.AreEqual("Træner", s);
        }


        [TestMethod]
        public void TestAddOfTrainers()
        {


            Trainer t2 = new Trainer(2, "Træner2", "trænersen2", 45678932, "træner2", "1234","picture" ,44);
            TrainerCatalogSingleton.TrainerInstance.AddTrainer(t2);

            Assert.AreEqual(2, luvm.TrainerCount);
            string s = luvm.all_Trainers[1].FirstName;
            Assert.AreEqual("Træner2", s);

        }


        //    //[TestMethod]
        //    //public void TestDeleteTrainer()
        //    //{


        //    //    Trainer t3 = new Trainer(3,"Træner3", "trænersen3", 88888888, "træner3", "1234", 12);
        //    //    LevelCatalogSingleton.TrainerInstance.AddTrainer(t3);
        //    //    LevelCatalogSingleton.TrainerInstance.DeleteTrainer(t3);

        //    //    Assert.AreEqual(2, lv.TrainerCount);

        //}


    }
}
