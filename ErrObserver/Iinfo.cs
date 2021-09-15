using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ErrObserver
{
    interface Iinfo
    {
        public void Show();
        public void NewFileInfo(FileSystemEventArgs e);
    }
}
