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
        public string Name;
        public int UserId;
        public List<TaskList> UserToDoList = new List<TaskList>();
        public int PasswordValue;
        ToDoDB db = new ToDoDB();


        public ToDoUser()
        {
            UserToDoList.Add(new TaskList());
        }
        /// <summary>
        /// Constructor for a new User
        /// Sets the Username of the user, puts them in the Database
        /// Sets their ID from the database, and creates an empty list and stores that in the Database
        /// </summary>
        /// <param name="inUser">The name for the new user</param>
        /// <param name="inPasswordVal">The users desired password</param>
        public ToDoUser(string inUserName, int inPasswordVal)
        {
            this.Name = inUserName;
            this.PasswordValue = inPasswordVal;
            this.UserId = this.db.CreateToDoUser(this.Name, this.PasswordValue);
            this.UserToDoList = new List<TaskList>();

            UserToDoList.Add(new TaskList());
        }

        public void setName(String inName){
            Name = inName;
        }
        public String getName(){
            return this.Name;
        }

        public List<TaskList> getUserToDoList(){
            return UserToDoList;
        }

        public void SaveUser()
        {
            foreach (var task in UserToDoList[0].getTaskListList())
            {
                task.SaveTask();
            }
        }


        /// <summary>
        /// Sets the users name to something new and updates it in the database
        /// </summary>
        /// <param name="newName">The users preferred name</param>
        /// <returns>True if update successful or False if it failed</returns>
        public bool SetName(string newName)
        {
            if(this.db.UpdateUsername(this.UserId, newName))
            {
                this.Name = newName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a brand new list, adds it to the users current list of TaskLists
        /// </summary>
        /// <param name="inList">The List of Tasks that are to be constructed</param>
        /// <returns>The new TaskList that was just added</returns>
        public TaskList CreateNewList(List<Task> inList)
        {
            TaskList newList = new TaskList(inList);
            this.UserToDoList.Add(newList);
            return newList;
        }

        /// <summary>
        /// Function to get a users To Do List from the MySQL database
        /// </summary>
        /// <param name="UserId">The ID of the user</param>
        public List<TaskList> LoadList(int UserId)
        {
            //this.UserToDoList = this.db.LoadList(UserId);
            return this.UserToDoList;
        }

        /// <summary>
        /// Changes the Users password
        /// </summary>
        /// <param name="newPassword">The Users desired password</param>
        /// <returns>True if the update was successful otherwise False if it failed</returns>
        public bool ChangePassword(int newPasswordVal)
        {
            if (this.db.UpdatePasswordVal(this.UserId, newPasswordVal))
            {
                this.PasswordValue = newPasswordVal;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
