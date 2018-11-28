using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    
    class RepeatableTask : Task
    {
        List<DisposableTask> copiesOfRepeatableTask;
        // map of subtasks
        //List<SubTask> listOfSubtasks;
        DateTime firstEvent;
        DateTime repeatOccurance;


        public RepeatableTask(String title, String descrip, Boolean allowNotifications, Boolean isComplete, DateTime taskDueDate)
        {

            this.taskTitle = title;
            this.complete = false;
            this.notificationsOn = allowNotifications;
            this.descrip = descrip;
            // need to input list of disposable tasks as well
            // need to then store new repeatable task in DB
            // also need to create repeatable list of disposable tasks.
        }
       
        private void createListOfFutureTasks()
        {
            // will have to go through and create copies, 30 or so future tasks and put them in list.
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
            foreach (DisposableTask current in copiesOfRepeatableTask)
            {
                if (current.getIsComplete() == false)
                {
                    current.setTitle(theTitle);
                }
            }
        }

        public override void setIsComplete(Boolean complete)
        {

        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
            foreach(DisposableTask current in copiesOfRepeatableTask)
            {
                if (current.getIsComplete() == false)
                {
                    current.setAllowNotifications(notifications);
                }
            }
        }


        public override void setDescription(String descri)
        {
            this.descrip = descri;
            foreach (DisposableTask current in copiesOfRepeatableTask)
            {
                if (current.getIsComplete() == false)
                {
                    current.setDescription(descrip);
                }
            }
        }

        public override void setTaskFKey(int taskFKey)
        {
            
        }

        public override void setTaskDueDate(DateTime taskDueDate)
        {
            this.taskDueDate = taskDueDate;
            foreach (DisposableTask current in copiesOfRepeatableTask)
            {
                if (current.getIsComplete() == false)
                {
                   // current.setTaskDueDate(taskDueDate); // do not want to set all disposable tasks to same date, want them offset
                }
            }
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

        public override DateTime getTaskDueDate()
        {
            return this.taskDueDate;
        }

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }
    }
}
