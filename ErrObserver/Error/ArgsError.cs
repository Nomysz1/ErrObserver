using System;
using System.Collections.Generic;
using System.Text;

namespace ErrObserver.Error
{
    class ArgsError : IError
    {
        public void InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==>Input is wrong<==");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
