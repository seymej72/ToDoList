using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace ToDoList
{
    class DisposableTask : Task
    {
        private string connectionStringToDB = "server =localhost; user=team3; password=x143; database=team3";
        private List<SubTask> subTasks { get; set; }

        public DisposableTask(DateTime firstOccurrance, String title, Boolean isComplete, Boolean allowNotifications, String descrip)
        {
            subTasks = new List<SubTask>();
            this.taskDueDate = firstOccurrance;
            this.taskTitle = title;
            this.complete = isComplete;
            this.notificationsOn = allowNotifications;
            this.descrip = descrip;
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

        public override void AddSubtask(SubTask newSubTask)
        {
            if (subTasks.Contains(newSubTask))
            {
                throw new SubTaskAlreadyExistsException();
            }
            else
            {
                subTasks.Add(newSubTask);
                //TODO update DB
            }
        }

        public override void DeleteSubtask(SubTask subTasktoDelete)
        {
            if (subTasks.Contains(subTasktoDelete))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks.Remove(subTasktoDelete);
                //TODO update DB
            }
        }

        public override void EditSubtask(SubTask oldSubTask, SubTask newSubTask)
        {
            if (subTasks.Contains(oldSubTask))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks.Insert(subTasks.BinarySearch(oldSubTask), newSubTask);
                //TODO update DB
            }

        }



        //Draft DB Connection Examples:
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
                Console.WriteLine("Result: Failure!");
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
                Console.WriteLine("Result: Failure!");
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
                Console.WriteLine("Result: Failure!");
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
