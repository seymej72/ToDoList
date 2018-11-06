using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Classes;

namespace ToDoList
{
    public class ToDoUser
    {
        string Name;
        int UserId;
        List<TaskList> UserToDoList;
        //string Password; <--Is this stored here??

        /// <summary>
        /// Constructor for a new User
        /// Sets the Username of the user, puts them in the Database
        /// Sets their ID from the database, and creates an empty list and stores that in the Database
        /// </summary>
        /// <param name="inUser">The name for the new user</param>
        public ToDoUser(string inUserName)
        {
            this.Name = inUserName;
            //TODO: Put them in the database and set their ID to the ID assigned to them by MySQL
            this.UserToDoList = new List<TaskList>();
            //TODO: Store the List in the Database??
        }

        /// <summary>
        /// Sets the users name to something new and updates it in the database
        /// </summary>
        /// <param name="newName">The users preferred name</param>
        /// <returns>True if update successful or False if it failed</returns>
        public bool SetName(string newName)
        {
            this.Name = newName;
            //TODO: Update the name of the user in the Database
            return true;
        }

        /// <summary>
        /// Creates a brand new list, adds it to the users current list of TaskLists and updates the Database
        /// </summary>
        /// <returns>The new TaskList that was just created</returns>
        public TaskList CreateNewList()
        {
            //TODO: Create a new Task List, add it to the users list of Lists and update the DB
            return null;
        }

        /// <summary>
        /// Function to get a users To Do List from the MySQL database
        /// </summary>
        /// <param name="UserId">The ID of the user</param>
        public void LoadList(int UserId)
        {
            //TODO: Set this.UserToDoList to the return of the Database call
        }

        /// <summary>
        /// Changes the Users password
        /// </summary>
        /// <param name="newPassword">The Users desired password</param>
        /// <returns>True if the update was successful otherwise False if it failed</returns>
        public bool ChangePassword(string newPassword)
        {
            //this.Password = newPassword <--Only applicable if you store it in the User Object
            //TODO:Update the users password in the database if you store it there
            return true;
        }

        //TODO: Various functions to call ToDoDB for queries required for a user as they come up

    }
}
