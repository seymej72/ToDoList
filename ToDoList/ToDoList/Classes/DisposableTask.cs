using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace ToDoList
{
    public class DisposableTask : Task
    {
        ToDoDB db = new ToDoDB();
        

        /// <summary>
        /// Constructor for a new DisposableTask
        /// </summary>
        /// <param name="title">The title of the Task</param>
        /// <param name="descrip">The description aka notes for the Task</param>
        /// <param name="subTasks">A dictionary that maps SubTask database keys to SubTask Objects</param>
        public DisposableTask(String title, String descrip, Dictionary<int, SubTask> subTasks)
        {
            this.taskTitle = title;
            this.subTasks = subTasks;
            this.descrip = descrip;
            this.complete = false;
            this.isRepeatable = false;
        }


        /// <summary>
        /// Default Constructor (Used to create empty object for manual constructor with setters)
        /// </summary>
        public DisposableTask()
        {
            subTasks = new Dictionary<int, SubTask>();
            this.isRepeatable = false;
        }

        /// <summary>
        /// Stores this Disposable Task object to the database
        /// </summary>
        public override void SaveTask()
        {
            if (db.checkTaskExistsInDB(taskId))
            {
                db.UpdateTask(this);
            }
            else
            {
                taskId = db.InsertDisposableTask(this);
                db.UpdateTask(this); //Needed to update for taskId
            }
            //Save SubTasks
            Dictionary<int, SubTask>.KeyCollection SubTaskIdCollection = subTasks.Keys;
            foreach (int i in SubTaskIdCollection)
            {
                subTasks[i].SaveSubTask();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// SubTask Modifiers
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Takes a SubTask Key and adds it to this Task and then saves this change to the database
        /// The subtask passed in must already be in the database
        /// </summary>
        /// <param name="subTaskId">The database key for the Subtask</param>
        public override void AddSubtask(int subTaskId)
        {
            if (subTasks.ContainsKey(subTaskId))
            {
                throw new SubTaskAlreadyExistsException();
            }
            else
            {
                subTasks.Add(subTaskId, db.FetchSubTask(subTaskId));
                SaveTask();
            }
        }

        /// <summary>
        /// Takes a SubTask Key and marks it as completed and then saves this change to the database
        /// The subtask passed in must already be associated with this task
        /// </summary>
        /// <param name="subTaskId">The database key for the Subtask</param>
        public override void DeleteSubtask(int subTaskId)
        {
            if (subTasks.ContainsKey(subTaskId))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks[subTaskId].markComplete();
                SaveTask();
            }
        }


        /// <summary>
        /// Takes 2 SubTask Keys. It removes the old one from the task and adds in the new one. 
        /// Note that they will have seperate keys and must both already exist in the database.
        /// </summary>
        /// <param name="oldSubTaskId">The database key for the Subtask to replace</param>
        /// <param name="newSubTaskId">The database key for the new Subtask</param>
        public override void EditSubtask(int oldSubTaskId, int newSubTaskId)
        {
            if (subTasks.ContainsKey(oldSubTaskId))
            {
                throw new SubTaskDoesntExistException();
            }
            else
            {
                subTasks.Remove(oldSubTaskId);
                subTasks.Add(newSubTaskId, db.FetchSubTask(newSubTaskId));
                SaveTask();
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Setters
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override void setRepeatability(Boolean isRepeatable)
        {
            this.isRepeatable = isRepeatable;
        }

        public override void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public override void setTitle(String theTitle)
        {
            this.taskTitle = theTitle;
        }

        public override void setIsComplete(Boolean complete)
        {
            this.complete = complete;
        }

        public override void setAllowNotifications(Boolean notifications)
        {
            this.notificationsOn = notifications;
        }

        public override void setDescription(String descrip)
        {
            this.descrip = descrip;
        }

        public override void setTaskFKey(int taskFKey)
        {
            this.taskFKey = taskFKey;
        }

        public void setSubTasks(Dictionary<int, SubTask> subTasks)
        {
            this.subTasks = subTasks;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// Getters
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public override int getTaskId()
        {
            return this.taskId;
        }

        public override String getTitle()
        {
            return this.taskTitle;
        }

        public override Boolean getIsComplete()
        {
            return this.complete;
        }

        public override Boolean getAllowNotifications()
        {
            return this.notificationsOn;
        }

        public override String getDescription()
        {
            return this.descrip;
        }

        public override int getTaskFKey()
        {
            return this.taskFKey;
        }

        public override Boolean getRepeatability()
        {
            return this.isRepeatable;
        }

        public override Dictionary<int, SubTask> getSubTask()
        {
            return subTasks;
        }
    }
    }
