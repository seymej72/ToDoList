using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public abstract class Task
    {
        protected int taskId;
        protected String taskTitle;
        protected Boolean complete;
        protected Boolean notificationsOn;
        protected String descrip;
        protected int taskFKey; //Add getters and setters
        protected bool isRepeatable;
        protected Dictionary<int, SubTask> subTasks;

        public abstract void setTaskId(int taskId);

        public abstract void setTitle(String theTitle);

        public abstract void setIsComplete(Boolean complete);

        public abstract void setAllowNotifications(Boolean notifications);

        public abstract void setDescription(String descrip);

        public abstract void setTaskFKey(int taskFKey);

        public abstract void setRepeatability(Boolean isRepeatable);

        public abstract void AddSubtask(int subTaskId);

        //Marks Subtask Complete
        public abstract void DeleteSubtask(int subTaskId);

        //Edit Subtask: Should this be done through task or through subtask setters?
        public abstract void EditSubtask(int oldSubTaskId, int newSubTaskId);


        public abstract void SaveTask();

        public abstract int getTaskId();

        public abstract String getTitle();

        public abstract Boolean getIsComplete();

        public abstract Boolean getAllowNotifications();

        public abstract String getDescription();

        public abstract int getTaskFKey();

        public abstract Boolean getRepeatability();

        public abstract Dictionary<int, SubTask> getSubTask();

        public override Boolean Equals(Object obj)
        {
            Boolean returnBool = false;
            if (obj is Task)
            {
                Task temp = (Task)obj;
                if (this.taskId.Equals(temp.taskId) &&
                    this.taskTitle.Equals(temp.taskTitle) &&
                    this.complete.Equals(temp.complete) &&
                    this.notificationsOn.Equals(temp.notificationsOn) &&
                    this.descrip.Equals(temp.descrip) &&
                    this.taskFKey.Equals(temp.taskFKey) &&
                    this.isRepeatable.Equals(temp.isRepeatable) &&

                    //Compares the two dictionarys:
                    this.subTasks.Count == temp.subTasks.Count && !this.subTasks.Except(temp.subTasks).Any())
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }

        //Believe that this works?
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.taskId) ? this.taskId.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.taskTitle) ? this.taskTitle.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.complete) ? this.complete.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.notificationsOn) ? this.notificationsOn.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.descrip) ? this.descrip.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.taskFKey) ? this.taskFKey.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, this.isRepeatable) ? this.isRepeatable.GetHashCode() : 0);
                return hash;
            }
        }

    }
}
