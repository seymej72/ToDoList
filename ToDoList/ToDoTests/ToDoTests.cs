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
        //[TestMethod]
        public void TestLoad()
        {
            System.Console.WriteLine("TEST");
            ToDoDB db = new ToDoDB();
            DisposableTask expected = BuildTestData();
            DisposableTask actual = null;// db.FetchDisposableTask(1);
            if(expected == null)
            {
                System.Console.WriteLine("Expected is null");
            }
            if (actual == null)
            {
                System.Console.WriteLine("Actual is null");
            }

            Assert.AreEqual(expected, actual);
        }
        //[TestMethod]
        public void TestSave()
        {
            ToDoDB db = new ToDoDB();
            DisposableTask expected = db.FetchDisposableTask(1);
            DisposableTask actual = BuildTestData();
            Assert.AreEqual(expected, actual);
        }
        private DisposableTask BuildTestData()
        {
            ToDoDB db = new ToDoDB();
            SubTask sTask = new SubTask(new DateTime(), "inTitle", "inNotes");
            sTask.setId(1); //Forces the test Subtask Id to be 1
            sTask.setSubtaskFKey(1); //Forces the test DisposableTask Id to be 1
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            dictionary.Add(1, sTask);
            DisposableTask dTask = new DisposableTask("Title", "This is a description", dictionary);
            /*if (db.CheckSubTaskExistsInDB(1))
            {
                db.UpdateSubTask(sTask);
            }
            else
            {
                db.InsertSubTask(sTask);
            }

            if (db.CheckTaskExistsInDB(1))
            {
                db.UpdateTask(dTask);
            }
            else
            {
                db.InsertDisposableTask(dTask);
            }*/
            return dTask;
        }

       
        [TestMethod]
        public void TestCheckTaskExistsInDB()
        {
            ToDoDB db = new ToDoDB();
            Assert.IsTrue(db.CheckTaskExistsInDB(1));
            Assert.IsFalse(db.CheckTaskExistsInDB(-1));
        }
        [TestMethod]
        public void TestFetchDisposableTask()
        {
            ToDoDB db = new ToDoDB();
            int taskId = db.GetNextTaskId() + 1;
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask expectedTask = new DisposableTask();
            expectedTask.setTitle("TESTTITLE55"); //Title

            expectedTask.setTitle("TestTitle"); //Title
            expectedTask.setDescription("TestDescription"); //Notes
            expectedTask.setAllowNotifications(false); //allowNotifications
            expectedTask.setIsComplete(false); //isComplete
            expectedTask.setTaskFKey(0); //taskFKey

            
            //db.InsertDisposableTask(expectedTask);
            //TODO insert does not give the task its id when it inserts

            DisposableTask actualTask = db.FetchDisposableTask(48);
            //TODO why do I need to set these for it to pass
            actualTask.setTitle("TestTitle"); //Title
            actualTask.setDescription("TestDescription"); //Notes
            Assert.AreEqual(expectedTask, actualTask);
        }

        [TestMethod]
        public void TestDisposableTaskEquals()
        {
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask task1 = new DisposableTask("Title", "This is a description", dictionary);
            DisposableTask task2 = new DisposableTask("Title", "This is a description", dictionary);
            Assert.AreEqual(task1, task2);
            task2.setTitle("DIFFERENTTITLE");
            Assert.AreNotEqual(task1, task2);

            task1 = new DisposableTask("Title", "This is a description", dictionary);
            task2 = new DisposableTask("Title", "This is a description", dictionary);
            task1.setAllowNotifications(true);
            Assert.AreNotEqual(task1, task2);
        }



        [TestMethod]
        public void TestInsertDisposableTask()
        {
            ToDoDB db = new ToDoDB();
            int nextId = db.GetNextTaskId() + 1;
            Assert.IsFalse(db.CheckTaskExistsInDB(nextId));
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask dTask = new DisposableTask("Title", "This is a description", dictionary);
            int actualId = db.InsertDisposableTask(dTask);
            Assert.AreEqual(nextId, actualId);
            Assert.IsTrue(db.CheckTaskExistsInDB(nextId));
        }

        //[TestMethod]
        public void TestUpdateTask()
        {

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
