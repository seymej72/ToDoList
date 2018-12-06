using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    // have to add calls to database throughout.
    public class RepeatableTask : Task
    {
        ToDoDB db = new ToDoDB();
        

        public RepeatableTask(String title, String descrip, Dictionary<int,SubTask> subTaskss)
        {

            this.taskTitle = title;
            this.complete = false;
            this.notificationsOn = false;
            this.descrip = descrip;
            this.subTasks = subTaskss;
            this.isRepeatable = true;
            db.InsertRepeatTask(this);
        }
       
        
        public override void AddSubtask(int  subTaskId)
        {
            subTasks.Add(subTaskId, db.FetchSubTask(subTaskId));
            db.SaveRepeatTask(this);
        }



        public override void DeleteSubtask(int subTaskId)
        {
            subTasks.Remove(subTaskId);
            db.SaveRepeatTask(this);
        }

      
        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {
                subTasks.Remove(oldSubTaskId);
                subTasks.Add(newSubTaskId, db.FetchSubTask(newSubTaskId));
                db.SaveRepeatTask(this);
        }
      
        public override void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }
        public override void setRepeatability(Boolean isRepeatable)
        {
            this.isRepeatable = isRepeatable;
        }

        public override void setTitle(String theTitle)
        {
            this.taskTitle = theTitle;
            db.SaveRepeatTask(this);
        }

        // Is called when all subtasks have been marked complete.
        public override void setIsComplete(Boolean complete)
        {
            foreach( KeyValuePair<int, SubTask> entry in subTasks)
            {
               entry.Value.setDueDate(entry.Value.getDueDate().AddDays(7));
            }
            db.SaveRepeatTask(this);

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

        public void setSubTasks(Dictionary<int, SubTask> subTasks)
        {
            this.subTasks = subTasks;
        }
        ///////////////////////////////////////////////Getters are below///////////////////////////////////////
        public override Boolean getRepeatability()
        {
            return this.isRepeatable;
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

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }
        //////////////////////////////////////

        public override void SaveTask()
        {
            if(db.doesTaskExist(this.taskId) == false)
            {
                db.InsertRepeatTask(this);
            }
            else
            {
                db.SaveRepeatTask(this);
            }
            
        }

        public override Dictionary<int, SubTask> getSubTask()
        {
            return subTasks;
        }
    }
}
