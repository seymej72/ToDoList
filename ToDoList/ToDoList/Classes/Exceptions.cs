using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    //Thrown when trying to add a subtask when that name is already taken 
    public class SubTaskAlreadyExistsException : Exception
    {
        public SubTaskAlreadyExistsException()
        {
        }

        public SubTaskAlreadyExistsException(string message)
            : base(message)
        {
        }

        public SubTaskAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    //Thrown when trying to delete/edit a subtask that doesn't exist 
    public class SubTaskDoesntExistException : Exception
    {
        public SubTaskDoesntExistException()
        {
        }

        public SubTaskDoesntExistException(string message)
            : base(message)
        {
        }

        public SubTaskDoesntExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
