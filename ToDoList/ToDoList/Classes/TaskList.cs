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
            if (ToDoList[index].getRepeatability() == true)
            {
                DisposableTask newTask = new DisposableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                newTask.setTaskId(ToDoList[index].getTaskId());
                ToDoList[index] = newTask;
                ToDoList[index].SaveTask();
            }
            else if (ToDoList[index].getRepeatability() == false)
            {
                
                    RepeatableTask newTask = new RepeatableTask(ToDoList[index].getTitle(), ToDoList[index].getDescription(), ToDoList[index].getSubTask());
                    newTask.setTaskId(ToDoList[index].getTaskId());
                    ToDoList[index] = newTask;
                    ToDoList[index].SaveTask();
                }
            }
        }
    }
