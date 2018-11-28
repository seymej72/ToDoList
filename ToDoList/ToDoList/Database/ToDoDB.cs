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

        #region DisposableTask Based Queries

        //Fetch existing DT from Database based on taskId and update this instance with its info
        public DisposableTask fetchDisposableTask(int taskId)
        {
            SqlConnection conn = null;
            DisposableTask myDisposableTask = null;
            if (checkTaskExistsInDB(taskId))
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                    cmd.Parameters.Add(new SqlParameter("taskId", taskId));
                    SqlDataReader reader = cmd.ExecuteReader();

                    myDisposableTask.setTaskId((int)reader.GetValue(0)); //TaskId
                    myDisposableTask.setTitle((String)reader.GetValue(1)); //Title
                    myDisposableTask.setDescription((String)reader.GetValue(2)); //Notes
                    myDisposableTask.setAllowNotifications((Boolean)reader.GetValue(3)); //allowNotifications
                    myDisposableTask.setIsComplete((Boolean)reader.GetValue(4)); //isComplete

                    //if ((Boolean)reader.GetValue(5)) //isRepeatable NEEDS TO BE FALSE
                    myDisposableTask.setTaskFKey((int)reader.GetValue(6)); //taskFKey
                    
                                                                                   //Console.WriteLine("Result: Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fetchDisposableTask Failure!" + ex);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                myDisposableTask.setSubTasks(FetchAllSubTasks(taskId));
            }
            return myDisposableTask;
        }

        public Boolean checkTaskExistsInDB(int taskId)
        {
            SqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                cmd.Parameters.Add(new SqlParameter("taskId", taskId));
                SqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;
                if(reader.FieldCount > 0)
                {
                    returnBool = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("checkTaskExistsInDB Failure!" + ex);
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
        //TODO Cannot upload DATETIME
        public int InsertDisposableTask(DisposableTask disposableTask)
        {
            SqlConnection conn = null;
            SqlCommand command = null;
            int taskId = 0;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                //command executes an insert and a select in order to return the taskId from that insertion
                command = new SqlCommand("INSERT INTO `Task` (`title`,`notes`,`allowNotifications`, `isComplete`,`isRepeatable`) " +
                    "VALUES(@title, @notes, @allowNotifications, @isComplete, @isRepeatable);" +
                    "SELECT `taskId` AS `taskId` FROM `Task` WHERE `taskId` = @@Identity;", conn);

                command.Parameters.AddWithValue("@title", disposableTask.getTitle());
                command.Parameters.AddWithValue("@notes", disposableTask.getDescription());
                command.Parameters.AddWithValue("@allowNotifications", disposableTask.getAllowNotifications());
                command.Parameters.AddWithValue("@isComplete", disposableTask.getIsComplete());
                command.Parameters.AddWithValue("@isRepeatable", 1);
                //command.Parameters.AddWithValue("@taskFKey", );// Won't have this before you insert for the first time
                //command.Parameters.AddWithValue("@taskDueDate", new DateTime()); //Doesn't work

                SqlDataReader reader = command.ExecuteReader();
                //Console.WriteLine("Result: Success!");
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

        //Update or Save Task //TODO Save Subtasks
        public void UpdateTask(DisposableTask disposableTask)
        {
            if (checkTaskExistsInDB(disposableTask.getTaskId()))
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE `Task` SET `title` = @title, `notes` = @notes," +
                                       "`allowNotifications` = @allowNotifications, `isComplete` = @isComplete, `isRepeatable` = @isRepeatable," +
                                       "`taskFKey` = @taskFKey WHERE `taskId` =  @taskId", conn);
                    cmd.Parameters.Add(new SqlParameter("taskId", disposableTask.getTaskId()));
                    cmd.Parameters.Add(new SqlParameter("title", disposableTask.getTitle()));
                    cmd.Parameters.Add(new SqlParameter("notes", disposableTask.getDescription()));
                    cmd.Parameters.Add(new SqlParameter("allowNotifications", disposableTask.getAllowNotifications()));
                    cmd.Parameters.Add(new SqlParameter("isComplete", disposableTask.getIsComplete()));
                    cmd.Parameters.Add(new SqlParameter("isRepeatable", false));
                    cmd.Parameters.Add(new SqlParameter("taskFKey", disposableTask.getTaskId()));
                    //cmd.Parameters.Add(new SqlParameter("taskDueDate",  disposableTask.getTaskDueDate()));

                    cmd.ExecuteNonQuery();
                    //Console.WriteLine("Result: Success!");
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
        #endregion

        #region SubTask Based Queries
        //returns all subtasks with the subtaskFKey to match the parameter taskId
        public Dictionary<int, SubTask> FetchAllSubTasks(int taskId)
        {
            Dictionary<int, SubTask> returnedSubTasks = new Dictionary<int, SubTask>();
            SubTask tempSubTask;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM `Subtask` WHERE `subtaskFKey` =  @taskId", conn);
                cmd.Parameters.Add(new SqlParameter("subtaskFKey", taskId)); 
                SqlDataReader reader = cmd.ExecuteReader();
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
                        //mySubTask.setFiles( = (LinkedList<String>)reader.GetValue(4); //filePath  
                        //TODO THIS WON'T WORK

                        temp.setFiles(new LinkedList<String>());
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
            SqlConnection conn = null;
            SubTask mySubTask = new SubTask();
            if (CheckSubTaskExistsInDB(SubtaskId))
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT* from `Subtask` WHERE `subtaskId` =  @SubtaskId", conn);
                    cmd.Parameters.Add(new SqlParameter("SubtaskId", SubtaskId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    int count = reader.FieldCount;

                    //Database columns:
                    //subtaskId dueDate title description filePath repeatFrom isComplete subtaskFKey

                    mySubTask.setId((int)reader.GetValue(0)); //subtaskId
                    mySubTask.setDueDate((DateTime)reader.GetValue(1)); //dueDate
                    mySubTask.setTitle((String)reader.GetValue(2)); //title
                    mySubTask.setNotes((String)reader.GetValue(3)); //description

                    //TODO THIS WON'T WORK
                    //mySubTask.setFiles( = (LinkedList<String>)reader.GetValue(4); //filePath  
                    //TODO THIS WON'T WORK


                    mySubTask.setFiles(new LinkedList<String>());
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
            //TODO
        }

        public void UpdateSubTask(SubTask subTask)
        {
            //TODO
        }

        public Boolean CheckSubTaskExistsInDB(int SubtaskId)
        {
            SqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT* from `Subtask` WHERE `subtaskId` =  @SubtaskId", conn);
                cmd.Parameters.Add(new SqlParameter("SubtaskId", SubtaskId));
                SqlDataReader reader = cmd.ExecuteReader();
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
                task.setDueDate((DateTime)reader.GetValue(1));
                task.setFiles((LinkedList<String>)reader.GetValue(3));
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
                return false;
            }
            finally{
                  if (conn != null)
                    conn.Close();  
            }
            return true;
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

                command.Parameters.AddWithValue("@subTaskId", inTask.getId());
                command.Parameters.AddWithValue("@dueDate", inTask.getDueDate());
                command.Parameters.AddWithValue("@isComplete", inTask.isComplete());
                command.Parameters.AddWithValue("@filePath", inTask.getFiles());
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
            SqlConnection conn = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand(
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

        #region RepeatableTask Based Queries

        //Fetch existing DT from Database based on taskId and update this instance with its info
        public RepeatableTask retrieveRepeatTask(int taskId)
        {
            SqlConnection conn = null;
            RepeatableTask repeatTask = null;
            if (doesTaskExist(taskId))
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                    cmd.Parameters.Add(new SqlParameter("taskId", taskId));
                    SqlDataReader reader = cmd.ExecuteReader();

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
            SqlConnection conn = null;
            Boolean returnBool = false;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT* from `Task` WHERE `TaskId`= @taskId", conn);
                cmd.Parameters.Add(new SqlParameter("taskId", taskId));
                SqlDataReader reader = cmd.ExecuteReader();
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
            SqlConnection conn = null;
            SqlCommand command = null;
            int taskId = 0;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                command = new SqlCommand("INSERT INTO `Task` (`title`,`notes`,`allowNotifications`, `isComplete`,`isRepeatable`) " +
                    "VALUES(@title, @notes, @allowNotifications, @isComplete, @isRepeatable);" +
                    "SELECT `taskId` AS `taskId` FROM `Task` WHERE `taskId` = @@Identity;", conn);

                command.Parameters.AddWithValue("@title", newTask.getTitle());
                command.Parameters.AddWithValue("@notes", newTask.getDescription());
                command.Parameters.AddWithValue("@allowNotifications", newTask.getAllowNotifications());
                command.Parameters.AddWithValue("@isComplete", newTask.getIsComplete());
                command.Parameters.AddWithValue("@isRepeatable", 1);

                SqlDataReader reader = command.ExecuteReader();
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
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE `Task` SET `title` = @title, `notes` = @notes," +
                                       "`allowNotifications` = @allowNotifications, `isComplete` = @isComplete, `isRepeatable` = @isRepeatable," +
                                       "`taskFKey` = @taskFKey WHERE `taskId` =  @taskId", conn);
                    cmd.Parameters.Add(new SqlParameter("taskId", savedTask.getTaskId()));
                    cmd.Parameters.Add(new SqlParameter("title", savedTask.getTitle()));
                    cmd.Parameters.Add(new SqlParameter("notes", savedTask.getDescription()));
                    cmd.Parameters.Add(new SqlParameter("allowNotifications", savedTask.getAllowNotifications()));
                    cmd.Parameters.Add(new SqlParameter("isComplete", savedTask.getIsComplete()));
                    cmd.Parameters.Add(new SqlParameter("isRepeatable", false));
                    cmd.Parameters.Add(new SqlParameter("taskFKey", savedTask.getTaskId()));
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
