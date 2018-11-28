﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace ToDoList
{
    class DisposableTask : Task
    {
        private string connectionStringToDB = "server =localhost; user=team3; password=x143; database=team3";
        protected Dictionary<int,SubTask> subTasks { get; set; } //subTaskId maps to subTask

        //Creates new Disposable Task and Inserts it in the database
        public DisposableTask(String title, String descrip, Boolean allowNotifications, Boolean isComplete, DateTime taskDueDate)
        {
            subTasks = new Dictionary<int, SubTask>();
            this.taskDueDate = taskDueDate;
            this.taskTitle = title;
            this.complete = isComplete;
            this.notificationsOn = allowNotifications;
            this.descrip = descrip;
            this.taskId = InsertDisposableTask(); //Adds new DTask to the Task Table in DB
        }

        //Default Constructor (Used to create empty object for manual constructor with setters)
        public DisposableTask()
        {
            subTasks = new Dictionary<int, SubTask>();
        }

        //Fetch existing DT from Database based on taskId and update this instance with its info
        public DisposableTask fetchDisposableTask(int taskId)
        {
            SqlConnection conn = null;
            DisposableTask myDisposableTask = null;
            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                //SELECT* from `Task` WHERE `TaskId` = 1
                SqlCommand cmd = new SqlCommand("SELECT* from `Task` WHERE `TaskId` =  @taskId", conn);
                cmd.Parameters.Add(new SqlParameter("taskId", 1));
                SqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;

                this.taskId = (int)reader.GetValue(0); //TaskId
                this.taskTitle = (String)reader.GetValue(1); //Title
                this.descrip = (String)reader.GetValue(2); //Notes
                this.notificationsOn = (Boolean)reader.GetValue(3); //allowNotifications
                this.complete = (Boolean)reader.GetValue(4); //isComplete

                if ((Boolean)reader.GetValue(5)) //isRepeatable NEEDS TO BE FALSE
                {
                    throw new Exception();
                }
                      
                this.taskFKey = (int)reader.GetValue(6); //taskFKey
                this.taskDueDate = (DateTime)reader.GetValue(7); //DueDate
                Console.WriteLine("Result: Success!");
 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            subTasks = fetchSubTasksMaster();
            return myDisposableTask;
        }

        //Inserts the new row into the TASK table and returns the new Task ID it gets auto assigned 
        //TODO Cannot upload DATETIME
        public int InsertDisposableTask()
        {
            SqlConnection conn = null;
            SqlCommand command = null;
            int taskId = 0;
            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();

                //command executes an insert and a select in order to return the taskId from that insertion
                command = new SqlCommand("INSERT INTO `Task` (`title`,`notes`,`allowNotifications`, `isComplete`,`isRepeatable`) " +
                    "VALUES(@title, @notes, @allowNotifications, @isComplete, @isRepeatable);" +
                    "SELECT `taskId` AS `taskId` FROM `Task` WHERE `taskId` = @@Identity;", conn);

                command.Parameters.AddWithValue("@title", "Task2");
                command.Parameters.AddWithValue("@notes", "descrip2");
                command.Parameters.AddWithValue("@allowNotifications", 1);
                command.Parameters.AddWithValue("@isComplete", 1);
                command.Parameters.AddWithValue("@isRepeatable", 1);
                //command.Parameters.AddWithValue("@taskFKey", );// Won't have this before you insert for the first time
                //command.Parameters.AddWithValue("@taskDueDate", new DateTime()); //Doesn't work

                SqlDataReader reader = command.ExecuteReader();
                //Console.WriteLine("Result: Success!");
                taskId =  (int)reader.GetValue(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
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

        //Inserts the new Row into the TasktoSubTask table and assigns the new FKey ID it gets auto assigned 
        //Maps this task Id to each of its subtasks
        public void InsertNewTasktoSubTask(int TaskId, int SubtaskId)
        {
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                Dictionary<int, SubTask>.KeyCollection SubTaskIdCollection = subTasks.Keys;
                foreach (int i in SubTaskIdCollection)
                {
                    command = new SqlCommand("INSERT INTO `TaskToSubtask` (`TaskFKey`,`SubtaskId`) " +
                    "VALUES(@TaskFKey, @SubTaskId);", conn);
                    command.Parameters.AddWithValue("@TaskFKey", TaskId);
                    command.Parameters.AddWithValue("@SubtaskId", SubtaskId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Result: Success!");
                }
                Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        //Update or Save Task //TODO does not work for DateTime
        public void UpdateTask()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE `Task` SET `title` = @title, `notes` = @notes," +
                                   "`allowNotifications` = @allowNotifications, `isComplete` = @isComplete, `isRepeatable` = @isRepeatable," +
                                   "`taskFKey` = @taskFKey WHERE `taskId` =  @taskId", conn);
                cmd.Parameters.Add(new SqlParameter("taskId", 1));
                cmd.Parameters.Add(new SqlParameter("title", "TEST"));
                cmd.Parameters.Add(new SqlParameter("notes", "TEST"));
                cmd.Parameters.Add(new SqlParameter("allowNotifications", 1));
                cmd.Parameters.Add(new SqlParameter("isComplete", 1));
                cmd.Parameters.Add(new SqlParameter("isRepeatable", false));
                cmd.Parameters.Add(new SqlParameter("taskFKey", 200));
                //cmd.Parameters.Add(new MySqlParameter("taskDueDate", this.taskId));

                cmd.ExecuteNonQuery();
                Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        //TODO need to grab the subtasks for each subtaskID I have
        public Dictionary<int, SubTask> fetchSubTasksMaster()
        {
            //Check TasktoSubtask table and grab all subtask ids for this task
            //Then add them to dictionary
            Dictionary<int, SubTask> returnedSubTasks = new Dictionary<int, SubTask>();

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT`SubtaskId` FROM `TaskToSubtask` WHERE `TaskFKey` =  @TaskFKey", conn);
                cmd.Parameters.Add(new SqlParameter("TaskFKey", this.taskFKey)); //TODO what if taskFKEY is still null
                SqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;

                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        //returnedSubTasks.Add(((int)reader.GetValue(i)),null); //Adds all the subtasks pared with null to the dictionary
                        SubTask temp = fetchSubTask(((int)reader.GetValue(i)));
                        returnedSubTasks.Add(((int)reader.GetValue(i)), temp);
                    }
                }
                Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            //TODO linkSubtasksToIds(returnedSubTasks); //Dictionary just has keys need to get values aka subtasks
            return returnedSubTasks;

        }

        //Returns a Subtask object for the passed in id
        public SubTask fetchSubTask(int SubtaskId)
        {
            SqlConnection conn = null;
            SubTask mySubTask = null;
            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT* from `Subtask` WHERE `subtaskId` =  @SubtaskId", conn);
                cmd.Parameters.Add(new SqlParameter("SubtaskId", SubtaskId));
                SqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;


                int inId;
                DateTime inDueDate;
                String inTitle;
                String inNotes;
                LinkedList<String> inFiles;
                DateTime repeatFrom;
                Boolean isComplete;

                //public SubTask(DateTime inDueDate, LinkedList<String> inFiles, String inTitle, String inNotes, int inId)
                //subtaskId dueDate title description filePath repeatFrom isComplete
                inId = (int)reader.GetValue(0); //subtaskId
                inDueDate = (DateTime)reader.GetValue(1); //dueDate
                inTitle = (String)reader.GetValue(2); //title
                inNotes = (String)reader.GetValue(3); //description
                inFiles = (LinkedList<String>)reader.GetValue(4); //filePath  //TODO THIS WON'T WORK
                inFiles = new LinkedList<String>();
                repeatFrom = (DateTime)reader.GetValue(5); //repeatFrom
                isComplete = (Boolean)reader.GetValue(6); //isComplete
                Console.WriteLine("Result: Success!");
                mySubTask = new SubTask( inDueDate,  inFiles,  inTitle,  inNotes,  inId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return mySubTask;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// SubTask Modifiers
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Adds a subtask to a task: the subtask must already exist in the DB
        public override void AddSubtask(int subTaskId)
        {
            if (subTasks.ContainsKey(subTaskId))
            {
                throw new SubTaskAlreadyExistsException();
            }
            else
            {
                SubTask newSubTask = fetchSubTask(subTaskId);
                subTasks.Add(subTaskId, newSubTask);
                InsertNewTasktoSubTask(subTaskId, taskId); //Add subtask id and task id to task to subtask table
            }
        }

        public override void DeleteSubtask(int subTaskId)
        {
            if (subTasks.ContainsKey(subTaskId))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks[subTaskId].markComplete();
            }
        }

        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {
            if (subTasks.ContainsKey(oldSubTaskId))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks.Remove(oldSubTaskId);
                SubTask newSubTask = fetchSubTask(newSubTaskId);
                subTasks.Add(newSubTaskId, newSubTask);
                InsertNewTasktoSubTask(newSubTaskId, taskId); //Add subtask id and task id to task to subtask table
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Setters
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public override void setTitle(String theTitle)
        {
            this.taskTitle = theTitle;
        }

        public override void setIsComplete(Boolean complete)
        {
            this.complete = complete;
        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
        }

        public override void setDescription(String descrip)
        {
            this.descrip = descrip;
        }

        public override void setTaskFKey(int taskFKey)
        {
            this.taskFKey = taskFKey;
        }

        public override void setTaskDueDate(DateTime taskDueDate)
        {
            this.taskDueDate = taskDueDate;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// Getters
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override int getTaskId()
        {
            return this.taskId;
        }

        public override String getTitle()
        {
            return this.taskTitle;
        }

        public override Boolean getIsComplete()
        {
            return this.complete;
        }

        public override Boolean getAllowNotifications()
        {
            return this.notificationsOn;
        }

        public override String getDescription()
        {
            return this.descrip;
        }

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }

        public override DateTime getTaskDueDate()
        {
            return this.taskDueDate;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        //Draft DB Connection Examples:
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ReadUserInfoRowFromDB()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from UserInfo", conn);
                cmd.Parameters.Add(new SqlParameter("uName", "TextToADD"));
                SqlDataReader reader = cmd.ExecuteReader();
                int count = reader.FieldCount;
                StringBuilder str = new StringBuilder("");
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        str.Append(reader.GetValue(i) + " ");
                    }
                    str.Append(Environment.NewLine);
                }
                Console.WriteLine("Result: Success!");
                Console.WriteLine(str.ToString());
                //MessageBox.Show(str.ToString());
                //txtOut.Text = "Successful";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void InsertUserInfoRowtoDB()
        {
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                command = new SqlCommand("INSERT INTO `UserInfo` (`name`,`password`,`userFKey`) VALUES(@name, @password, @userFKey);", conn);
                command.Parameters.AddWithValue("@name", "jake");
                command.Parameters.AddWithValue("@password", "passWORD");
                command.Parameters.AddWithValue("@userFkey", 1000);
                command.ExecuteNonQuery();
                Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUserInfoRowinDB()
        {
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(connectionStringToDB);
                conn.Open();
                command = new SqlCommand("UPDATE `UserInfo` SET name = @nameParam WHERE `userId` = 1;", conn);
                command.Parameters.AddWithValue("nameParam", "NEW NAME");
                command.ExecuteNonQuery();
                Console.WriteLine("Result: Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: Failure!" + ex);
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
}
