using System;
using System.Collections.Generic;
using System.Text;

namespace ErrObserver
{
    interface IEmail
    {
        void send(string dirPath, string filePath);
    }
}
