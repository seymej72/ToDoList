using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    public class SubTask
    {
        ToDoDB db = new ToDoDB();
        DateTime dueDate;
        bool complete;
        LinkedList<String> files;
        String title;
        String notes;
        int subtaskId; //Key for subtask ID for subtask table of DB - Added by Jake
        DateTime repeatFrom;
        Boolean taskComplete;
        int subtaskFKey;

        public SubTask(DateTime inDueDate, String inTitle, String inNotes)
        {
            dueDate = inDueDate;
            complete = false;
            //files = inFiles;
            title = inTitle;
            notes = inNotes;
        }

        public SubTask()
        {
            dueDate = DateTime.MinValue;
            complete = false;
            files = null;
            title = null;
            notes = null;
        }

        public void SaveSubTask()
        {
            if (db.CheckSubTaskExistsInDB(subtaskId))
            {
                //Update Table Row
                db.UpdateSubTask(this);
            }
            else
            {
                //Insert new Table Row
                db.InsertSubTask(this);
            }
        }

        public int getNextId()
        {
            return db.getNextId();
        }
        public void setRepeatFrom(DateTime date)
        {
            this.repeatFrom = date;
        }

        public void setSubtaskFKey(int FKey)
        {
            this.subtaskFKey = FKey;
        }

        public DateTime getRepeatFrom()

        {
            return this.repeatFrom;
        }

        public int getSubtaskFKey()

        {
            return this.subtaskFKey;
        }

        public Boolean getTaskComplete()
        {
            return this.taskComplete;
        }

        public void setTaskComplete(Boolean complete)
        {
            this.taskComplete = complete;
        }

        public void setId(int inId)
        {
            subtaskId = inId;
        }

        public  int getId()
        {
            return subtaskId;
        }
        public void setDueDate(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        public DateTime getDueDate()
        {
            return dueDate;
        }

        public void markComplete()
        {
            complete = true;
        }

        public bool isComplete()
        {
            return complete;
        }

        public void setFiles(LinkedList<String> inFiles)
        {
            files = inFiles;
        }

        public void addFile(String inFile)
        {
            files.AddLast(inFile);
        }

        public LinkedList<String> getFiles()
        {
            return files;
        }

        public void setTitle(String inTitle)
        {
            title = inTitle;
        }

        public String getTitle()
        {
            return title;
        }

        public void setNotes(String inNotes)
        {
            notes = inNotes;
        }

        public void addToNotes(String inNotes)
        {
            notes = notes + inNotes;
        }

        public String getNotes()
        {
            return notes;
        }

        public void addtoDB(){
            db.addSubTask(this);
        }

        public void editInDB(int oldTask){
            db.editSubTask(this, oldTask);
        }

        public void getFromDB(int inId){
            SubTask temp = db.getSubTask(inId);
            this.complete = temp.complete;
            this.dueDate = temp.dueDate;
            this.files = temp.files;
            this.subtaskId = temp.subtaskId;
            this.title = temp.title;
            this.notes = temp.notes;
        }

        public String toString()
        {
            //String tmp = title + " " + notes + " due " + dueDate.toString() + " done:";
            String tmp = ""; //Done to compile
            if (complete)
            {
                return tmp + "yes";
            }
            return tmp + "no";
        }

        public override Boolean Equals(Object obj)
        {
            Boolean returnBool = false;
            if (obj is SubTask)
            {
                SubTask temp = (SubTask)obj;
                if (this.dueDate.Equals(temp.dueDate) &&
                    this.complete.Equals(temp.complete) &&
                    this.files.Equals(temp.files) &&
                    this.title.Equals(temp.title) &&
                    this.notes.Equals(temp.notes) &&
                    this.subtaskId.Equals(temp.subtaskId) &&
                    this.repeatFrom.Equals(temp.repeatFrom) &&
                    this.subtaskFKey.Equals(temp.subtaskFKey))
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }


        //Believe that this works?
        public override int GetHashCode()
        {
            unchecked
            { 
            int hash = 13;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.dueDate) ? this.dueDate.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.complete) ? this.complete.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.files) ? this.files.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.title) ? this.title.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.notes) ? this.notes.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.subtaskId) ? this.subtaskId.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.repeatFrom) ? this.repeatFrom.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, this.subtaskFKey) ? this.subtaskFKey.GetHashCode() : 0);
            return hash;
            }
        }
    }
}