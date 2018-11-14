using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    
    class RepeatableTask : Task
    {
        List<DisposableTask> copiesOfRepeatableTask;
        List<SubTask> listOfSubtasks;
        String repeatableTitle;


        RepeatableTask(DateTime firstOccurance, DateTime repeatOccurance, String newTitle, Boolean allowNotif, String note)
        {
            repeatableTitle = newTitle;
            isComplete = false;
            allowNotifications = allowNotif;
            notes = note;

        }
       
        public override void title(String theTitle)
        {
            repeatableTitle = theTitle;
        }

        public Boolean isComplete { get; set; }

        public Boolean allowNotifications { get; set; }

        public override void notes (String newNote)
        {

        }

        override
        public void AddSubtask(SubTask newSubTask)
        {

        }

        override
        public void DeleteSubtask(SubTask subTasktoDelete)
        {

        }

        override
        public void EditSubtask(SubTask oldSubTask, SubTask newSubTask)
        {

        }
    }
}
