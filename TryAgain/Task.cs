using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryAgain
{
    class Task
    {
        private string details;
        private bool complete;

        public Task(string d)
        {
            details = d;
            complete = false;
        }

        public Task(string d, bool c)
        {
            details = d;
            complete = c;

        }

        public string Details { get => details; set => details = value; }
        public bool Complete { get => complete; set => complete = value; }
    }
}
