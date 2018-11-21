using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    class SubTask
    {
        DateTime dueDate;
        bool complete;
        File[] files;
        String title;
        String notes;
        int subtaskId; //Key for subtask ID for subtask table of DB - Added by Jake

        public SubTask(DateTime inDueDate, File[] inFiles, String inTitle, String inNotes)
        {
            dueDate = inDueDate;
            complete = false;
            files = inFiles;
            title = inTitle;
            notes = inNotes;
        }

        public SubTask()
        {
            dueDate = null;
            complete = false;
            files = null;
            title = null;
            notes = null;
        }

        public void setDueDate(int month, int day, int year)
        {
            dueDate = new DateTime(year, month, day);
        }

        public DateTime getDueDate()
        {
            return dueDate;
        }

        public void markComplete()
        {
            isComplete = true;
        }

        public bool isComplete()
        {
            return isComplete;
        }

        public void setFiles(Files[] inFiles)
        {
            files = inFiles;
        }

        public void addFile(File inFile)
        {
            files.add(inFile);
        }

        public File[] getFiles()
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

        public String toString()
        {
            String tmp = title + " " + notes + " due " + dueDate.toString() + " done:";
            if (isComplete)
            {
                return tmp + "yes";
            }
            return tmp + "no";
        }
    }
}
subtasks.txt
Displaying subtasks.txt.