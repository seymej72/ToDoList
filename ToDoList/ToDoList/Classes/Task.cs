using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Task
    {
        private String taskTitle;
        private Boolean complete;
        private Boolean notificationsOn;
        private String descrip;

        public abstract void title(String theTitle);

        public abstract void isComplete(Boolean complete);

        public abstract void allowNotifications(Boolean notifications);

        public abstract void description(String descrip);

        public abstract void AddSubtask(SubTask newSubTask);

        public abstract void DeleteSubtask(SubTask subTasktoDelete);

        public abstract void EditSubtask(SubTask oldSubTask, SubTask newSubTask);

    }
}
