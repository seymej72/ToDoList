using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDo
    {
        public ToDoUser CurrentUser;
        private ToDoDB db = new ToDoDB();
        
        /// <summary>
        /// Good ole main
        /// </summary>
        /// <param name="args"></param>
        public void Main(String[] args)
        {

        }
        /// <summary>
        /// Validates the users input, cross checking with the Database
        /// </summary>
        /// <returns>True if the input passes and False if it does not</returns>
        public bool CheckInput(string enteredUsername, string enteredPassword)
        {
            int enteredPasswordVal = HashPassword(enteredPassword);

            if (this.db.VerifyLogin(enteredUsername, enteredPasswordVal))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Method called to construct a new User
        /// </summary>
        /// <param name="desiredUsernam">The desired username of the user</param>
        /// <param name="desiredPassword">The desired password of the user</param>
        /// <returns>True if the user was registered/created succesfully or False if not</returns>
        public ToDoUser RegisterUser(string desiredUsername, string desiredPassword)
        {
            int passwordVal = HashPassword(desiredPassword);

            CurrentUser = new ToDoUser(desiredUsername, passwordVal);
            LoginUser(CurrentUser);
            return CurrentUser;
        }

        /// <summary>
        /// Gathers all the pertinent data for a user and displays the main page
        /// </summary>
        /// <param name="User">The User being logged in</param>
        private ToDoUser LoginUser(ToDoUser User)
        {
            User.LoadList(User.UserId);
            return CurrentUser;
        }

        /// <summary>
        /// Simple algorithm used to hash the passed in password
        /// </summary>
        /// <param name="inPassword">the password to be hashed</param>
        /// <returns>The hashed password value</returns>
        public int HashPassword(string inPassword)
        { 
            return inPassword.GetHashCode();
        }

    }
}
