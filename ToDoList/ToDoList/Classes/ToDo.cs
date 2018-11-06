using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDo
    {
        ToDoUser CurrentUser;
        
        /// <summary>
        /// Good ole main
        /// </summary>
        /// <param name="args"></param>
        public void Main(String[] args)
        {
            //TODO: Literally everything
        }

        /// <summary>
        /// Function to display the main login in screen
        /// </summary>
        private void DisplayLogin()
        {
            //TODO: Hookup with Sara's GUI to display the main login screen
        }

        /// <summary>
        /// Validates the users input, cross checking with the Database
        /// </summary>
        /// <returns>True if the input passes and False if it does not</returns>
        private bool CheckInput()
        {
            //TODO: Add some Parameters and query the DB to check the input
            return true;
        }

        /// <summary>
        /// Method called to construct a new User
        /// </summary>
        /// <returns>True if the user was registered/created succesfully or False if not</returns>
        private bool RegisterUser()
        {
            //TODO: Construct a new user (see ToDoUser)
            return true;
        }

        /// <summary>
        /// Gathers all the pertinent data for a user and displays the main page
        /// </summary>
        /// <param name="User">The User being logged in</param>
        private void LoginUser(ToDoUser User)
        {
            //TODO: Display the main page after successful login after querying the DB for all the required info
        }

        //TODO: Various functions to call the DB class to query data for a user from MySQL
    }
}
