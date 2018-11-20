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
        List<SubTask> listOfSubtasks;
        DateTime firstEvent;
        DateTime repeatOccurance;


        RepeatableTask(DateTime firstOccurance, DateTime repeatOccur, String newTitle, Boolean allowNotif, String description)
        {

            taskTitle = newTitle;
            complete = false;
            notificationsOn = allowNotif;
            descrip = description;
            firstEvent = firstOccurance;
            repeatOccurance = repeatOccur;

            // need to then store new repeatable task in DB
            // also need to create repeatable list of disposable tasks.
        }
       

        
        public override void AddSubtask(SubTask newSubTask)
        {

        }

        

        
        public override void DeleteSubtask(SubTask subTasktoDelete)
        {

        }

      
        public override void EditSubtask(SubTask oldSubTask, SubTask newSubTask)
        {

        }
        public override void setTitle(String theTitle)
        {
            
        }

        public override void setIsComplete(Boolean complete)
        {

        }

        public override void setAllowNotifications(Boolean notifications)
        {

        }

        public override void setDescription(String descrip)
        {

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
            return "dkjfd";
        }
    }
}
