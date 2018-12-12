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
        /// <summary>
        /// Switches task type from repeatable to disposable and vice versa 
        /// </summary>
        /// <param name="index"></param>
        public void switchTaskType(int index)
            {
            bool repeating = ToDoList[index].getRepeatability();
            if (repeating == false)
                {
                RepeatableTask newTask = new RepeatableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                newTask.setTaskId(ToDoList[index].getTaskId());
                ToDoList[index] = newTask;
                ToDoList[index].SaveTask();
                }
            else 
                {
                DisposableTask newTask = new DisposableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                newTask.setTaskId(ToDoList[index].getTaskId());
                ToDoList[index] = newTask;
                ToDoList[index].SaveTask();
            }
            }
        }
    }
