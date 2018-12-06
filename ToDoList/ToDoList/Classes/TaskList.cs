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

            if (ToDoList[index].getRepeatability() == true)
            {
                testTask = ToDoList[index];
                DisposableTask newTestTask = (DisposableTask)testTask;
                newTestTask.setRepeatability(false);
                ToDoList[index] = newTestTask;
            }
            else
            {
                testTask = ToDoList[index];
                RepeatableTask newTestTask = (RepeatableTask)testTask;
                newTestTask.setRepeatability(true);
                ToDoList[index] = newTestTask;
            }
        }
    }
}
