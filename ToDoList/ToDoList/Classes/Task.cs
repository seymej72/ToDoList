using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Task
    {
        String taskTitle;
        private Boolean complete;
        private Boolean notificationsON;

        public abstract void title(String theTitle);

        public abstract void isComplete(Boolean complete);

        public abstract void allowNotifications(Boolean notifications);

        public string notes { get; set; }

        public abstract void AddSubtask(SubTask newSubTask);

        public abstract void DeleteSubtask(SubTask subTasktoDelete);

        public abstract void EditSubtask(SubTask oldSubTask, SubTask newSubTask);

    }
}
