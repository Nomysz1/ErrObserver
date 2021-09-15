using System;
using System.Collections.Generic;
using System.Text;

namespace ErrObserver
{
    class Args
    {
        public string command { get; set; }
        public string value { get; set; }
       
        public Args(ref string command, ref string value)
        {
            this.command = command;
            this.value = value;
        }

        public override string ToString()
        {
            return String.Concat(this.command + ";" + this.value);
        }
    }
}
