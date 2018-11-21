using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace ToDoList
{
    class DisposableTask : Task
    {
        private string connectionStringToDB = "server =localhost; user=team3; password=x143; database=team3";
        private Dictionary<int,SubTask> subTasks { get; set; } //subTaskId maps to subTask

        //Creates new Disposable Task
        public DisposableTask(DateTime firstOccurrance, String title, Boolean isComplete, Boolean allowNotifications, String descrip)
        {
            subTasks = new Dictionary<int, SubTask>();
            this.taskDueDate = firstOccurrance;
            this.taskTitle = title;
            this.complete = isComplete;
            this.notificationsOn = allowNotifications;
            this.descrip = descrip;
        }

        //Fetch existing DT from Database based on taskId
        public DisposableTask fetchDisposableTask(int taskId)
        {
            subTasks = fetchSubTasks();

            //TODO DB CALL
            List<Object> DBReturn = new List<Object>(); //This is the return object from querying the DB for this task
            //TODO DB CALL

            this.taskDueDate = (DateTime)DBReturn[0];
            this.taskTitle = (String)DBReturn[0];
            this.complete = (Boolean)DBReturn[0];
            this.notificationsOn = (Boolean)DBReturn[0];
            this.descrip = (String)DBReturn[0];
            return this;
        }

        public Dictionary<int, SubTask> fetchSubTasks()
        {
            //Check TasktoSubtask table and grab all subtask ids for this task
            //Then add them to dictionary
            return new Dictionary<int, SubTask>();
        }

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

        //Adds a subtask to a task: the subtask must already exist in the DB
        public override void AddSubtask(int subTaskId)
        {
            if (subTasks.ContainsKey(subTaskId))
            {
                throw new SubTaskAlreadyExistsException();
            }
            else
            {
                //SubTask newSubTask = fetchSubTask(subTaskId); //Need get method from DB in Subtask implemented
                SubTask newSubTask = new SubTask();
                subTasks.Add(subTaskId, newSubTask);
                //AddTasktoSubtask(subTaskId, taskId); Add subtask id and task id to task to subtask table
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
            /* Do you want to edit subtask through Task or directly?
             * 
             * 
             * 
             * 
             * 
             * 
            if (subTasks.ContainsKey(oldSubTaskId))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks.Remove(oldSubTaskId);
                //SubTask newSubTask = fetchSubTask(subTaskId); //Need get method from DB in Subtask implemented
                SubTask newSubTask = new SubTask();
                subTasks.Add(newSubTaskId, newSubTask);
                //TODO update DB
            }*/

        }



        //Draft DB Connection Examples:
        //----------------------------------------------------------------------------------------------------------------------------------------
        private void ReadUserInfoRowFromDB()
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connectionStringToDB);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from UserInfo", conn);
                cmd.Parameters.Add(new MySqlParameter("uName", "TextToADD"));
                MySqlDataReader reader = cmd.ExecuteReader();
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
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionStringToDB);
                conn.Open();
                command = new MySqlCommand("INSERT INTO `UserInfo` (`name`,`password`,`userFKey`) VALUES(@name, @password, @userFKey);", conn);
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
            MySqlConnection conn = null;
            MySqlCommand command = null;

            try
            {
                conn = new MySqlConnection(connectionStringToDB);
                conn.Open();
                command = new MySqlCommand("UPDATE `UserInfo` SET name = @nameParam WHERE `userId` = 1;", conn);
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
