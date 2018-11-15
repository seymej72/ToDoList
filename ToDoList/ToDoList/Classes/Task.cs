using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Task
    {
        protected String taskTitle;
        protected Boolean complete;
        protected Boolean notificationsOn;
        protected String descrip;
        protected DateTime taskDueDate;


        public abstract void setTitle(String theTitle);

        public abstract void setIsComplete(Boolean complete);

        public abstract void setAllowNotifications(Boolean notifications);

        public abstract void setDescription(String descrip);

        public abstract void AddSubtask(SubTask newSubTask);

        public abstract void DeleteSubtask(SubTask subTasktoDelete);

        public abstract void EditSubtask(SubTask oldSubTask, SubTask newSubTask);

        public abstract String getTitle();

        public abstract Boolean getIsComplete();

        public abstract Boolean getAllowNotifications();

        public abstract String getDescription();
    }
}
