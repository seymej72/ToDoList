using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//using MySql.Data.MySqlClient;

namespace ToDoList
{
    class DisposableTask : Task
    {
        //private string connectionStringToDB = "server=softeng.cs.uwosh.edu; user=team3; password=x143; database=team3; port=1022";
        private List<SubTask> subTasks { get; set; }

        public DisposableTask(String title, Boolean isComplete, Boolean allowNotifications, String notes)
        {
            subTasks = new List<SubTask>();
            this.taskTitle = title;
            this.complete = isComplete;
            this.notificationsOn = allowNotifications;
            this.notes = notes;
        }
        
        public override void title(string theTitle)
        {
            this.taskTitle = theTitle;
        }

        public override void isComplete(bool complete)
        {
            this.complete = complete;
        }

        public override void allowNotifications(Boolean notifications)
        {
            notificationsOn = notifications;
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


        //TODO// INPROGRESS to connect to DB and insert a line
        /*private void AddtoDB()
        {
            String txtOut= "TEST";
            MySqlConnection conn = new MySqlConnection(connectionStringToDB);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from UserInfo", conn);
            //MySqlCommand cmd = new MySqlCommand("update Customer  set user_name=@uName where order_id=3", conn);
            cmd.Parameters.Add(new MySqlParameter("uName", txtOut));

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
            conn.Close();
        }
        */

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
                subTasks.Insert(subTasks.BinarySearch(oldSubTask),newSubTask);
                //TODO update DB
            }

        }
    }
}
