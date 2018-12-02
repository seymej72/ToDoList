using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;

namespace ToDoTests
{
    [TestClass]
    public class ToDoTests
    {

        #region ToDo class Tests
        [TestMethod]
        public void TestHashing()
        {
            var ToDoObj = new ToDo();

            string pass = "1325465465";

            int potentialPassword = ToDoObj.HashPassword(pass);

            Assert.AreEqual(51082944, potentialPassword);
        }

        [TestMethod]
        public void TestCreatingUser()
        {
            var ToDoObj = new ToDo();

            var ActualUser = new ToDoUser("TestCase", 51082944);

            var PotentialUser = ToDoObj.RegisterUser("TestCase", "1325465465");

            Assert.AreEqual(ActualUser, PotentialUser);
        }

        #endregion
    }
}
