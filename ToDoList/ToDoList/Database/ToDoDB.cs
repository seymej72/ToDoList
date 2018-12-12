using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Classes;

namespace ToDoList
{
    public class ToDoDB
    {
        private string connectionString = "Server=localhost; Database=team3; Uid=team3; Pwd=x143";

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

            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "INSERT INTO `UserInfo` (`name`, `password`) " +
                    "VALUES(@newUsername, @newPassword);" +
                    "SELECT `userId` AS `id` FROM `UserInfo` WHERE `name` = @newUsername;",
                    conn
                );

                command.Parameters.AddWithValue("@newUsername", username);
                command.Parameters.AddWithValue("@newPassword", passwordVal);

                MySqlDataReader reader = command.ExecuteReader();
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
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
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

            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
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
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "SELECT * FROM `Task` WHERE `taskFKey` = @userId;",
                    conn
                );

                command.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = command.ExecuteReader();
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

            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "SELECT `password` AS `password` FROM `UserInfo` WHERE `name` = @user;",
                    conn
                );

                command.Parameters.AddWithValue("@user", username);

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String actualPasswordVal = reader.GetValue(0).ToString();
                if (actualPasswordVal.Equals(enteredPasswordVal))
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

        #region DisposableTask Based Queries

        //Fetch existing DT from Database based on taskId and update this instance with its info
        public DisposableTask FetchDisposableTask(int taskId)
        {
            MySqlConnection conn = null;
            DisposableTask myDisposableTask = new DisposableTask();

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                cmd.Parameters.Add(new MySqlParameter("taskId", taskId));
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                myDisposableTask.setTaskId((int)reader.GetValue(0)); //TaskId
                myDisposableTask.setTitle((String)reader.GetValue(1)); //Title
                myDisposableTask.setDescription((String)reader.GetValue(2)); //Notes
                myDisposableTask.setAllowNotifications((Boolean)reader.GetValue(3)); //allowNotifications
                myDisposableTask.setIsComplete((Boolean)reader.GetValue(4)); //isComplete
                myDisposableTask.setRepeatability((Boolean)reader.GetValue(5)); //isRepeatable
                myDisposableTask.setTaskFKey((int)reader.GetValue(6)); //taskFKey
            }
            catch (Exception ex)
            {
                Console.WriteLine("FetchDisposableTask Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            myDisposableTask.setSubTasks(FetchAllSubTasks(taskId));
            return myDisposableTask;
        }

        public Boolean CheckTaskExistsInDB(int taskId)
        {
            MySqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                cmd.Parameters.Add(new MySqlParameter("taskId", taskId));
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows && reader.GetValue(0) != DBNull.Value)
                {
                    returnBool = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckTaskExistsInDB Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return returnBool;
        }

        //Inserts the new row into the TASK table and returns the new Task ID it gets auto assigned 
        public int InsertDisposableTask(DisposableTask disposableTask)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
           
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand("INSERT INTO `Task` (`title`,`notes`,`allowNotifications`, `isComplete`,`isRepeatable`, `taskFKey`) " +
                    "VALUES(@title, @notes, @allowNotifications, @isComplete, @isRepeatable, @taskFKey);", conn);

                command.Parameters.AddWithValue("@title", disposableTask.getTitle());
                command.Parameters.AddWithValue("@notes", disposableTask.getDescription());
                command.Parameters.AddWithValue("@allowNotifications", disposableTask.getAllowNotifications());
                command.Parameters.AddWithValue("@isComplete", disposableTask.getIsComplete());
                command.Parameters.AddWithValue("@isRepeatable", 0); //0 for not repeatable
                command.Parameters.AddWithValue("@taskFKey", disposableTask.getTaskFKey());
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertDisposableTask: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            int highestId = GetNextTaskId();
            disposableTask.setTaskId(highestId);
            UpdateTask(disposableTask);
            return highestId;
        }

        //Update or Save Task 
        public void UpdateTask(DisposableTask disposableTask)
        {
            if (CheckTaskExistsInDB(disposableTask.getTaskId()))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `Task` SET `title` = @title, `notes` = @notes," +
                                       "`allowNotifications` = @allowNotifications, `isComplete` = @isComplete, `isRepeatable` = @isRepeatable, `taskFKey` = @taskFKey" +
                                       " WHERE `taskId` =  @taskId", conn);
                    cmd.Parameters.AddWithValue("taskId", disposableTask.getTaskId());
                    cmd.Parameters.AddWithValue("title", disposableTask.getTitle());
                    cmd.Parameters.AddWithValue("notes", disposableTask.getDescription());
                    cmd.Parameters.AddWithValue("allowNotifications", disposableTask.getAllowNotifications());
                    cmd.Parameters.AddWithValue("isComplete", disposableTask.getIsComplete());
                    cmd.Parameters.AddWithValue("isRepeatable", false);
                    cmd.Parameters.AddWithValue("taskFKey", disposableTask.getTaskFKey());

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UpdateTask Failure!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public int GetNextTaskId()
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "SELECT max(taskId) FROM Task;",
                    conn);
                reader = command.ExecuteReader();
                reader.Read();

                if (!DBNull.Value.Equals((reader.GetValue(0))))
                {
                    return (int)reader.GetValue(0);
                }
                else
                {
                    return 0;

                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("this is not supposed to happen: " + ex);
                return -1;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        #endregion

        #region SubTask Based Queries
        //returns all subtasks with the subtaskFKey to match the parameter taskId
        public Dictionary<int, SubTask> FetchAllSubTasks(int taskId)
        {
            Dictionary<int, SubTask> returnedSubTasks = new Dictionary<int, SubTask>();
            SubTask tempSubTask;
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Subtask` WHERE `subtaskFKey` =  @taskId", conn);
                cmd.Parameters.Add(new MySqlParameter("subtaskFKey", taskId)); 
                MySqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;

                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        tempSubTask = new SubTask();
                        SubTask temp = FetchSubTask(((int)reader.GetValue(i)));
                        temp.setId((int)reader.GetValue(0)); //subtaskId
                        temp.setDueDate((DateTime)reader.GetValue(1)); //dueDate
                        temp.setTitle((String)reader.GetValue(2)); //title
                        temp.setNotes((String)reader.GetValue(3)); //description

                        //TODO THIS WON'T WORK
                        //TODO THIS WON'T WORK


                        temp.setRepeatFrom((DateTime)reader.GetValue(5)); //repeatFrom
                        temp.setTaskComplete((Boolean)reader.GetValue(6)); //isComplete
                        temp.setSubtaskFKey((int)reader.GetValue(7)); //subTaskFKey
                        returnedSubTasks.Add(((int)reader.GetValue(i)), temp);
                    }
                }
                //Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("fetchAllSubTasks: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return returnedSubTasks;
        }

        //Returns a Subtask object for the passed in id
        public SubTask FetchSubTask(int SubtaskId)
        {
            MySqlConnection conn = null;
            SubTask mySubTask = new SubTask();
            if (CheckSubTaskExistsInDB(SubtaskId))
            {
                try
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT* from `Subtask` WHERE `subtaskId` =  @SubtaskId", conn);
                    cmd.Parameters.Add(new MySqlParameter("SubtaskId", SubtaskId));
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int count = reader.FieldCount;

                    //Database columns:
                    //subtaskId dueDate title description filePath repeatFrom isComplete subtaskFKey

                    mySubTask.setId((int)reader.GetValue(0)); //subtaskId
                    mySubTask.setDueDate((DateTime)reader.GetValue(1)); //dueDate
                    mySubTask.setTitle((String)reader.GetValue(2)); //title
                    mySubTask.setNotes((String)reader.GetValue(3)); //description

                    //TODO THIS WON'T WORK
                    //TODO THIS WON'T WORK


                    mySubTask.setRepeatFrom((DateTime)reader.GetValue(5)); //repeatFrom
                    mySubTask.setTaskComplete((Boolean)reader.GetValue(6)); //isComplete
                    mySubTask.setSubtaskFKey((int)reader.GetValue(7)); //subTaskFKey
                    //Console.WriteLine("Result: Success!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("fetchSubTask: Failure!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            return mySubTask;
        }

        public void InsertSubTask(SubTask subTask)
        {
            addSubTask(subTask);
        }

        public void UpdateSubTask(SubTask subTask)
        {
            if (CheckTaskExistsInDB(subTask.getId()))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `SubTask` SET `DueDate` = @DueDate, `isComplete` = @isComplete," +
                                       "`FilePath` = @FilePath, `Title` = @Title, `Description` = @Description," +
                                       "`RepeatFrom` = @RepeatFrom WHERE `SubTaskID` =  @SubTaskID", conn);

                    cmd.Parameters.Add(new SqlParameter("DueDate", subTask.getDueDate()));
                    cmd.Parameters.Add(new SqlParameter("isComplete", subTask.getTaskComplete()));
                    cmd.Parameters.Add(new SqlParameter("Title", subTask.getTitle()));
                    cmd.Parameters.Add(new SqlParameter("Description", subTask.getNotes()));
                    cmd.Parameters.Add(new SqlParameter("RepeatFrom", subTask.getRepeatFrom()));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UpdateSubTask Failure!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }

        }

        public Boolean CheckSubTaskExistsInDB(int SubtaskId)
        {
            MySqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* from `Subtask` WHERE `subtaskId` =  @SubtaskId", conn);
                cmd.Parameters.Add(new MySqlParameter("SubtaskId", SubtaskId));
                MySqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;
                if (reader.FieldCount > 0)
                {
                    returnBool = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckSubTaskExistsInDB Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return returnBool;
        }
        

        public SubTask getSubTask(int inId){
            SubTask task = new SubTask();
            task.setId(inId);
            MySqlConnection conn = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;

            try{
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "SELECT * FROM `SubTask` WHERE `SubTaskId` = @inId;",
                    conn);
                command.Parameters.AddWithValue("@inId", inId);

                reader = command.ExecuteReader();
                reader.Read();
                task.setDueDate((DateTime)reader.GetValue(1));
                task.setTitle((String)reader.GetValue(4));
                task.setNotes((String)reader.GetValue(5));
                return task;
            }catch(Exception ex){
                Console.WriteLine("this is not supposed to happen: " + ex);
                return null;
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
        }

        public bool editSubTask(SubTask newTask, int oldTask){
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try{
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "INSERT INTO 'SubTask' (SubTaskID, DueDate, isComplete, FilePath, Title, Description, RepeatFrom) VALUES (@subTaskID, @dueDate, @isComplete, @filePath, @title, @description, @repeatFrom", conn
                );

                command.Parameters.AddWithValue("@subTaskId", newTask.getId());
                command.Parameters.AddWithValue("@dueDate", newTask.getDueDate());
                command.Parameters.AddWithValue("@isComplete", newTask.isComplete());
                command.Parameters.AddWithValue("@title", newTask.getTitle());
                command.Parameters.AddWithValue("@description", newTask.getNotes());
                command.Parameters.AddWithValue("@repeatfrom", null);

                command.ExecuteNonQuery();

                MySqlCommand deletecmd = new MySqlCommand("DELETE FROM 'SubTask' WHERE 'SubTaskID' = @oldId", conn);
                deletecmd.Parameters.AddWithValue("@oldId", oldTask);
                deletecmd.ExecuteNonQuery();
            }catch(Exception ex){
               Console.WriteLine("this is not supposed to happen" + ex);
                return false;
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
            return true;
        }

        public bool addSubTask(SubTask inTask){
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try{
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "INSERT INTO 'SubTask' (SubTaskID, DueDate, isComplete, FilePath, Title, Description, RepeatFrom) VALUES (@subTaskID, @dueDate, @isComplete, @filePath, @title, @description, @repeatFrom", conn
                );

                command.Parameters.AddWithValue("@subTaskId", inTask.getId());
                command.Parameters.AddWithValue("@dueDate", inTask.getDueDate());
                command.Parameters.AddWithValue("@isComplete", inTask.isComplete());
                command.Parameters.AddWithValue("@title", inTask.getTitle());
                command.Parameters.AddWithValue("@description", inTask.getNotes());
                command.Parameters.AddWithValue("@repeatfrom", null);

                command.ExecuteNonQuery();

            }catch(Exception ex){
               Console.WriteLine("this is not supposed to happen" + ex);
                return false;
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
            return true;
        }

        public int getNextId()
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand(
                    "SELECT 'SubTaskId' FROM `SubTask` WHERE `SubTaskId` = (SELECT max(id) from SubTask;",
                    conn);
                reader = command.ExecuteReader();
                reader.Read();
                return (int)reader.GetValue(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("this is not supposed to happen: " + ex);
                return -1;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        #endregion

        #region RepeatableTask Based Queries

        //Pulls Repeatable task from db
        public RepeatableTask retrieveRepeatTask(int taskId)
        {
            MySqlConnection conn = null;
            RepeatableTask repeatTask = null;
            if (doesTaskExist(taskId))
            {
                try
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                    cmd.Parameters.Add(new MySqlParameter("taskId", taskId));
                    MySqlDataReader reader = cmd.ExecuteReader();

                    repeatTask.setTaskId((int)reader.GetValue(0)); //TaskId
                    repeatTask.setTitle((String)reader.GetValue(1)); //Title
                    repeatTask.setDescription((String)reader.GetValue(2)); //Description
                    repeatTask.setAllowNotifications((Boolean)reader.GetValue(3)); //allowNotifications
                    repeatTask.setIsComplete((Boolean)reader.GetValue(4)); //isComplete
                }
                catch (Exception ex)
                {
                    Console.WriteLine("retrieveRepeatTask Failed!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                repeatTask.setSubTasks(FetchAllSubTasks(taskId));
            }
            return repeatTask;
        }

        public Boolean doesTaskExist(int taskId)
        {
            MySqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* from `Task` WHERE `TaskId`= @taskId", conn);
                cmd.Parameters.Add(new MySqlParameter("taskId", taskId));
                MySqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;
                if (reader.FieldCount > 0)
                {
                    returnBool = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("doesTaskExist Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return returnBool;
        }

        //Inserts new Repeatable task into the table
        public int InsertRepeatTask(RepeatableTask newTask)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            int taskId = 0;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                command = new MySqlCommand("INSERT INTO `Task` (`title`,`notes`,`allowNotifications`, `isComplete`,`isRepeatable`) " +
                    "VALUES(@title, @notes, @allowNotifications, @isComplete, @isRepeatable);" +
                    "SELECT `taskId` AS `taskId` FROM `Task` WHERE `taskId` = @@Identity;", conn);

                command.Parameters.AddWithValue("@title", newTask.getTitle());
                command.Parameters.AddWithValue("@notes", newTask.getDescription());
                command.Parameters.AddWithValue("@allowNotifications", newTask.getAllowNotifications());
                command.Parameters.AddWithValue("@isComplete", newTask.getIsComplete());
                command.Parameters.AddWithValue("@isRepeatable", 1);

                MySqlDataReader reader = command.ExecuteReader();
                taskId = (int)reader.GetValue(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertDisposableTask: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return taskId;
        }

        //Saves Task, used by RepeatableTask.SaveTask()
        public void SaveRepeatTask(RepeatableTask savedTask)
        {
            if (doesTaskExist(savedTask.getTaskId()))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `Task` SET `title` = @title, `notes` = @notes," +
                                       "`allowNotifications` = @allowNotifications, `isComplete` = @isComplete, `isRepeatable` = @isRepeatable," +
                                       "`taskFKey` = @taskFKey WHERE `taskId` =  @taskId", conn);
                    cmd.Parameters.Add(new MySqlParameter("taskId", savedTask.getTaskId()));
                    cmd.Parameters.Add(new MySqlParameter("title", savedTask.getTitle()));
                    cmd.Parameters.Add(new MySqlParameter("notes", savedTask.getDescription()));
                    cmd.Parameters.Add(new MySqlParameter("allowNotifications", savedTask.getAllowNotifications()));
                    cmd.Parameters.Add(new MySqlParameter("isComplete", savedTask.getIsComplete()));
                    cmd.Parameters.Add(new MySqlParameter("isRepeatable", false));
                    cmd.Parameters.Add(new MySqlParameter("taskFKey", savedTask.getTaskId()));
                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SaveRepeatTask Failure!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        #endregion

    }
}
