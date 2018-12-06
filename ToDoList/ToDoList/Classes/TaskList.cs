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

        public void switchTaskType(int index)
        {
            Task testTask = null;
            Console.WriteLine("got there");
            if (ToDoList[index].getRepeatability() == true)
            {
                testTask = (Task)ToDoList[index];
                DisposableTask newTestTask = (DisposableTask)testTask;
                newTestTask.setRepeatability(false);
                ToDoList[index] = newTestTask;
                Console.WriteLine("got there");
            }
            else
            {
                testTask = (Task)ToDoList[index];
                RepeatableTask newTestTask = (RepeatableTask)testTask;
                newTestTask.setRepeatability(true);
                ToDoList[index] = newTestTask;
            }
        }
    }
}
