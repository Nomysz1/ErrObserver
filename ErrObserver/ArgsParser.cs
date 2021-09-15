using System;
using System.Collections.Generic;
using System.Text;

namespace ErrObserver
{
    class ArgsParser : IArgs
    {
        private List<Args> args1 { get; set; }
        private string [] Args { get; set; }
        public ArgsParser(ref string [] args)
        {
            args1 = new List<Args>();
            this.Args = args;
        }

        public List<Args> parseInput()
        {
            args1 = new List<Args>();
            var length = Args.Length;
            for(int i = 0; i < length; i += 2)
            {
                var commandTMP = Args[i];
                var valueTMP = Args[i + 1];
                args1.Add(new Args(ref commandTMP, ref valueTMP));
            }
            return args1;
        }
    }
}
