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
            bool repeating = ToDoList[index].getRepeatability();
            Console.WriteLine("/n This is some message in front of it, quite a long message, hopefully it sticks out, a bit" + repeating);
            if (repeating == true)
                {
                DisposableTask newTask = new DisposableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                newTask.setTaskId(ToDoList[index].getTaskId());
                ToDoList[index] = newTask;
                ToDoList[index].SaveTask();
            }
            else 
            {
                
                    RepeatableTask newTask = new RepeatableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                    newTask.setTaskId(ToDoList[index].getTaskId());
                    ToDoList[index] = newTask;
                    ToDoList[index].SaveTask();
                }
            }
        }
    }
