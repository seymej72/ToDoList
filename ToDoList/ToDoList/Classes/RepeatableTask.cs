using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    
    class RepeatableTask : Task
    {
        DateTime firstEvent;
        DateTime repeatOccurance;
        protected Dictionary<int, SubTask> subTasks { get; set; } //subTaskId maps to subTask

        RepeatableTask(String newTitle, String description, Boolean allowNotif, Boolean isComplete, DateTime taskDueDate)
        {

            taskTitle = newTitle;
            complete = false;
            notificationsOn = allowNotif;
            descrip = description;
            firstEvent = taskDueDate;
 
            // copiesOfRepeatable will be null if this is a new task

            // need to input list of disposable tasks as well
            // need to then store new repeatable task in DB
            // also need to create repeatable list of disposable tasks.
        }
             
        public override void AddSubtask(int  subTaskId)
        {

        }

        

        
        public override void DeleteSubtask(int subTaskId)
        {

        }

      
        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {

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
            foreach( KeyValuePair<int, SubTask> entry in subTasks)
            {
               // entry.Value.dueDate = entry.Value.dueDate.AddDays(7);
            }
            
        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
        }


        public override void setDescription(String descri)
        {
            this.descrip = descri;
        }

        public override void setTaskFKey(int taskFKey)
        {
            
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
            return true;
        }

        public override String getDescription()
        {
            return this.descrip;
        }

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }
    }
}
