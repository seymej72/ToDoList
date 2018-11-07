using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    abstract class Task
    {
        public string title { get; set; }
  
        public Boolean isComplete { get; set; }

        public Boolean allowNotifications { get; set; }

        public string notes { get; set; }

        public abstract void AddSubtask(SubTask newSubTask);

        public abstract void DeleteSubtask(SubTask subTasktoDelete);

        public abstract void EditSubtask(SubTask oldSubTask, SubTask newSubTask);

    }
}
