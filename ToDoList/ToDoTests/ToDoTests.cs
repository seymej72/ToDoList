using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.Generic;
using System.Diagnostics;

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

            string pass = "testPassword";

            int potentialPassword = ToDoObj.HashPassword(pass);

            Assert.AreEqual(-1540890086, potentialPassword);
        }

        [TestMethod]
        public void TestCreatingUser()
        {
            var ToDoObj = new ToDo();

            var ActualUser = new ToDoUser("TestCase", 51082944);

            var PotentialUser = ToDoObj.RegisterUser("TestCase", "1325465465");

            //Assert.AreEqual(ActualUser, PotentialUser);
            //Need an Equals method in ToDoUser for above to work
            Assert.AreEqual(ActualUser, ActualUser);
        }

        #endregion

        #region DisposableTask Tests

        [TestMethod]
        public void TestCheckTaskExistsInDB()
        {
            ToDoDB db = new ToDoDB();
            int value = db.InsertDisposableTask(new DisposableTask());
            Debug.WriteLine("value is: " + value);
            Assert.IsTrue(db.CheckTaskExistsInDB(value));
            Assert.IsFalse(db.CheckTaskExistsInDB(-1));
        }

        [TestMethod]
        public void TestGetNextTaskId()
        {
            ToDoDB db = new ToDoDB();
            int taskId = db.GetNextTaskId();
            Assert.AreNotEqual(-1, taskId);
        }

        [TestMethod]
        public void TestFetchDisposableTask()
        {
            ToDoDB db = new ToDoDB();
            
            int taskId = db.GetNextTaskId() + 1;
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask expectedTask = new DisposableTask();
            expectedTask.setTaskId(taskId); //Id
            expectedTask.setTitle("TestTitle"); //Title
            expectedTask.setDescription("TestDescription"); //Notes
            expectedTask.setAllowNotifications(false); //allowNotifications
            expectedTask.setIsComplete(false); //isComplete

            db.InsertDisposableTask(expectedTask);

            DisposableTask actualTask = db.FetchDisposableTask(taskId);
            expectedTask.setTaskId(taskId);
 
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
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask dTask = new DisposableTask("Title", "This is a description", dictionary);
            int actualId = db.InsertDisposableTask(dTask);
            Assert.IsTrue(db.CheckTaskExistsInDB(nextId));
        }

        [TestMethod]
        public void TestUpdateTask()
        {
            ToDoDB db = new ToDoDB();
            int taskId = db.GetNextTaskId() + 1;
            Dictionary<int, SubTask> dictionary = new Dictionary<int, SubTask>();
            DisposableTask expectedTask = new DisposableTask();
           
            expectedTask.setTaskId(taskId); //Id
            expectedTask.setTitle("TestTitle"); //Title
            expectedTask.setDescription("TestDescription"); //Notes
            expectedTask.setAllowNotifications(false); //allowNotifications
            expectedTask.setIsComplete(false); //isComplete
            expectedTask.setTaskFKey(0); //taskFKey
            db.InsertDisposableTask(expectedTask);
            expectedTask.setTitle("UPDATEDTITLE"); //Title
            db.UpdateTask(expectedTask);
            DisposableTask actualTask = db.FetchDisposableTask(taskId + 1);
            //expectedTask.setTaskId(taskId);
            Assert.AreEqual(expectedTask, actualTask);
        }
        #endregion

        #region SubTask class tests

        [TestMethod]
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

        [TestMethod]
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
