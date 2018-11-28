using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Classes
{
    public class TaskList
    {
        List<Task> ToDoList = new List<Task>();

        public TaskList()
        {

        }

        public TaskList(List<Task> inList)
        {
            this.ToDoList = inList;
        }

        public void addTask(Task newTask)
        {
            ToDoList.Add(newTask);
        }

        public List<Task> getTaskListList()
        {
            return ToDoList;
        }

    }
}
