using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;


namespace ToDoList
{
    class DisposableTask : Task
    {
        //private string connectionString = "server =localhost; user=team3; password=x143; database=team3";
        ToDoDB db = new ToDoDB();
        protected Dictionary<int, SubTask> subTasks; //subTaskId maps to subTask

        //Creates new Disposable Task and Inserts it in the database
        public DisposableTask(String title, String descrip, Boolean allowNotifications, Boolean isComplete, DateTime taskDueDate)
        {
            subTasks = new Dictionary<int, SubTask>();
            this.taskDueDate = taskDueDate;
            this.taskTitle = title;
            this.complete = isComplete;
            this.notificationsOn = allowNotifications;
            this.descrip = descrip;
            this.taskId = 0; //Adds new DTask to the Task Table in DB
        }

        //Default Constructor (Used to create empty object for manual constructor with setters)
        public DisposableTask()
        {
            subTasks = new Dictionary<int, SubTask>();
        }

        //Inserts the new row into the TASK table and returns the new Task ID it gets auto assigned 
        public void SaveDisposableTask()
        {
            if (db.checkTaskExistsInDB(taskId))
            {
                //Update Table Row
                db.UpdateTask(this);
            }
            else
            {
                //Insert new Table Row
                taskId = db.InsertDisposableTask(this);
                db.UpdateTask(this); //Need to update for taskId
            }
            //Save SubTasks
            Dictionary<int, SubTask>.KeyCollection SubTaskIdCollection = subTasks.Keys;
            foreach (int i in SubTaskIdCollection)
            {
                subTasks[i].SaveSubTask();
            }
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
                subTasks.Add(subTaskId, db.FetchSubTask(subTaskId));
                SaveDisposableTask();
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
                SaveDisposableTask();
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
                subTasks.Add(newSubTaskId, db.FetchSubTask(newSubTaskId));
                SaveDisposableTask();
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

        public void setSubTasks(Dictionary<int, SubTask> subTasks)
        {
            this.subTasks = subTasks;
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
        /*
        private void ReadUserInfoRowFromDB()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
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
                conn = new SqlConnection(connectionString);
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
                conn = new SqlConnection(connectionString);
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
    
    */

    }
}
