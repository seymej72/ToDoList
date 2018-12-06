using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.Generic;

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

        #region DisposableTask Tests
        [TestMethod]
        public void TestLoad()
        {
            ToDoDB db = new ToDoDB();
            DisposableTask expected = BuildTestData();
            DisposableTask actual = db.fetchDisposableTask(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSave()
        {
            ToDoDB db = new ToDoDB();
            DisposableTask expected = db.fetchDisposableTask(1);
            DisposableTask actual = BuildTestData();
            Assert.AreEqual(expected, actual);
        }
        private DisposableTask BuildTestData()
        {
            ToDoDB db = new ToDoDB();
            SubTask sTask = new SubTask(new DateTime(12, 1, 2018), "inTitle", "inNotes");
            sTask.setId(1); //Forces the test Subtask Id to be 1
            sTask.setSubtaskFKey(1); //Forces the test DisposableTask Id to be 1
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            dictionary.Add(1, sTask);
            DisposableTask dTask = new DisposableTask("Title", "This is a description", dictionary);
            if (db.CheckSubTaskExistsInDB(1))
            {
                db.UpdateSubTask(sTask);
            }
            else
            {
                db.InsertSubTask(sTask);
            }

            if (db.checkTaskExistsInDB(1))
            {
                db.UpdateTask(dTask);
            }
            else
            {
                db.InsertDisposableTask(dTask);
            }
            return dTask;
        }
        #endregion

        #region SubTask class tests
        public void TestCreatingSubTask()
        {
            System.Console.WriteLine("~~~Testing creating SubTasks~~~");

            DateTime actualDueDate = new DateTime(2019, 1, 1);
            String actualTitle = "W2";
            String actualNotes = "Do your W2's before its due";

            SubTask test = new SubTask(actualDueDate, actualTitle, actualNotes);

            DateTime dueDate = test.getDueDate();
            String title = test.getTitle();
            String notes = test.getNotes();

            if (dueDate.Equals(actualDueDate))
            {
                System.Console.WriteLine("###DateTime is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***DateTime is WRONG!!***");
            }
            if (title.Equals(actualTitle))
            {
                System.Console.WriteLine("###Title is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***Title is WRONG!!***");
            }
            if (notes.Equals(actualNotes))
            {
                System.Console.WriteLine("###Notes is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***Notes is WRONG!!***");
            }
        }

        public void TestEditingSubTask()
        {
            System.Console.WriteLine("~~~Testing editing SubTasks~~~");

            DateTime actualDueDate = new DateTime(2019, 1, 1);
            String actualTitle = "W2";
            String actualNotes = "Do your W2's before its due";

            SubTask test = new SubTask(actualDueDate, actualTitle, actualNotes);

            DateTime newDueDate = new DateTime(2019, 4, 1);
            String newTitle = "W3";
            String newNotes = "we had to change this to W3 now because W2's no longer exist";

            test.setDueDate(newDueDate);
            test.setTitle(newTitle);
            test.setNotes(newNotes);

            DateTime dueDate = test.getDueDate();
            String title = test.getTitle();
            String notes = test.getNotes();

            if (dueDate.Equals(newDueDate))
            {
                System.Console.WriteLine("###DateTime is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***DateTime is WRONG!!***");
            }
            if (title.Equals(newTitle))
            {
                System.Console.WriteLine("###Title is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***Title is WRONG!!***");
            }
            if (notes.Equals(newNotes))
            {
                System.Console.WriteLine("###Notes is correct!!###");
            }
            else
            {
                System.Console.WriteLine("***Notes is WRONG!!***");
            }
        }

        #endregion
    }
}
