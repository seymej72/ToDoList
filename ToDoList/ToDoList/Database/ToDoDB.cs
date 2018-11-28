using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Classes;

namespace ToDoList
{
    class ToDoDB
    {
        private string connectionString = "server =localhost; user=team3; password=x143; database=team3";

        #region User Based Queries

        /// <summary>
        /// Stores a new user in the database
        /// </summary>
        /// <param name="username">the users username</param>
        /// <param name="passwordVal">the users password</param>
        /// <returns>The users Id in the database</returns>
        public int CreateToDoUser(string username, int passwordVal)
        {
            string hashedPassword = passwordVal.ToString();

            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "INSERT INTO `UserInfo` (`name`, `password`) " +
                    "VALUES(@newUsername, @newPassword);" +
                    "SELECT `userId` AS `id` FROM `UserInfo` WHERE `name` = @newUsername;",
                    conn
                );

                command.Parameters.AddWithValue("@newUsernam", username);
                command.Parameters.AddWithValue("@newPassword", passwordVal);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String userIdString = reader.GetValue(0).ToString();
                return Int32.Parse(userIdString);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went horribly wrong! " + ex);
                return 0;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// Updates the username for the appropriate user in the database
        /// </summary>
        /// <param name="userId">The ID assosciated with the user for which their name is changing</param>
        /// <param name="newUsername">The new desired username</param>
        /// <returns>True if successful, false if not</returns>
        public bool UpdateUsername(int userId, string newUsername)
        {
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "UPDATE `UserInfo` " +
                    "SET `name` = @newUsername" +
                    "WHERE `userId` = @userId;",
                    conn
                );

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@newUsername", newUsername);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went horribly wrong! " + ex);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// Updates the hashed password for the appropriate user in the database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPasswordVal"></param>
        /// <returns>True if successful, false if not</returns>
        public bool UpdatePasswordVal(int userId, int newPasswordVal)
        {
            string hashedNewPassword = newPasswordVal.ToString();

            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "UPDATE `UserInfo` " +
                    "SET `password` = @newPassword" +
                    "WHERE `userId` = @userId;",
                    conn
                );

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@newPassword", hashedNewPassword);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went horribly wrong! " + ex);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public List<TaskList> LoadList(int userId)
        {
            List<TaskList> taskList = new List<TaskList>();
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "SELECT * FROM `Task` WHERE `taskFKey` = @userId;",
                    conn
                );

                command.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if(reader.GetValue(5).Equals(1))
                    {
                        //RepeatableTask currentTask = new RepeatableTask(reader.GetValue(1), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(7));
                    }
                    else
                    {

                    }

                }
                return taskList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went horribly wrong! " + ex);
                return new List<TaskList>();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        #endregion

        #region ToDo General Queries

        /// <summary>
        /// Verifies that the user entered correct login info
        /// </summary>
        /// <param name="username">the username of the user logging in</param>
        /// <param name="passwordVal">the entered password value from the user logging in</param>
        /// <returns>True if the login credentials are correct and false if not</returns>
        public bool VerifyLogin(string username, int passwordVal)
        {
            string enteredPasswordVal = passwordVal.ToString();

            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "SELECT `password` AS `password` FROM `UserInfo` WHERE `name` = @user;",
                    conn
                );

                command.Parameters.AddWithValue("@user", username);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String actualPasswordVal = reader.GetValue(0).ToString();
                if (actualPasswordVal == enteredPasswordVal)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went horribly wrong! " + ex);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        #endregion

        public SubTask getSubTask(int inId){
            SubTask task = new SubTask();
            task.setId(inId);
            SqlConnection conn = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try{
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "SELECT * FROM `SubTask` WHERE `SubTaskId` = @inId;",
                    conn);
                command.Parameters.AddWithValue("@inId", inId);

                reader = command.ExecuteReader();
                reader.Read();
                task.setDueDate(reader.GetValue(1));
                task.setFiles(reader.GetValue(3));
                task.setTitle(reader.GetValue(4));
                task.setNotes(reader.GetValue(5));
                return task;
            }catch(Exception ex){
                Console.WriteLine("this is not supposed to happen: " + ex);
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
        }

        public bool editSubTask(SubTask newTask, int oldTask){
            SqlConnection conn = null;
            SqlCommand command = null;

            try{
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "INSERT INTO 'SubTask' (SubTaskID, DueDate, isComplete, FilePath, Title, Description, RepeatFrom) VALUES (@subTaskID, @dueDate, @isComplete, @filePath, @title, @description, @repeatFrom", conn
                );

                command.Parameters.AddWithValue("@subTaskId", newTask.getId());
                command.Parameters.AddWithValue("@dueDate", newTask.getDueDate());
                command.Parameters.AddWithValue("@isComplete", newTask.isComplete());
                command.Parameters.AddWithValue("@filePath", newTask.getFiles());
                command.Parameters.AddWithValue("@title", newTask.getTitle());
                command.Parameters.AddWithValue("@description", newTask.getNotes());
                command.Parameters.AddWithValue("@repeatfrom", null);

                command.ExecuteNonQuery();

                SqlCommand deletecmd = new SqlCommand("DELETE FROM 'SubTask' WHERE 'SubTaskID' = @oldId", conn);
                deletecmd.Parameters.AddWithValue("@oldId", oldTask);
                deletecmd.ExecuteNonQuery();
            }catch(Exception ex){
               Console.WriteLine("this is not supposed to happen" + ex);
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
        }

        public bool addSubTask(SubTask inTask){
            SqlConnection conn = null;
            SqlCommand command = null;

            try{
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
                    "INSERT INTO 'SubTask' (SubTaskID, DueDate, isComplete, FilePath, Title, Description, RepeatFrom) VALUES (@subTaskID, @dueDate, @isComplete, @filePath, @title, @description, @repeatFrom", conn
                );

                command.Parameters.AddWithValue("@subTaskId", newTask.getId());
                command.Parameters.AddWithValue("@dueDate", newTask.getDueDate());
                command.Parameters.AddWithValue("@isComplete", newTask.isComplete());
                command.Parameters.AddWithValue("@filePath", newTask.getFiles());
                command.Parameters.AddWithValue("@title", newTask.getTitle());
                command.Parameters.AddWithValue("@description", newTask.getNotes());
                command.Parameters.AddWithValue("@repeatfrom", null);

                command.ExecuteNonQuery();

            }catch(Exception ex){
               Console.WriteLine("this is not supposed to happen" + ex);
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
        }
    }
}
