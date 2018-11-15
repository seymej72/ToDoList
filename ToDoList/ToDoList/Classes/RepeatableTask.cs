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
        String repeatableTitle;


        RepeatableTask(DateTime firstOccurance, DateTime repeatOccurance, String newTitle, Boolean allowNotif, String note)
        {

            
            repeatableTitle = newTitle;


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
            this.taskTitle = "dfojdfjd";
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

        public override void getAllowNotifications(Boolean notifications)
        {

        }

        public override void getDescription(String descrip)
        {

        }
    }
}
