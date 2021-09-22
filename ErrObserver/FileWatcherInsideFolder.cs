using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Security;

namespace ErrObserver
{
    class FileWatcherInsideFolder : IFolder, Iinfo
    {
        public string dirPath { get; private set; }
        public string Extension { get; private set; }

        public Email email;
        public FileWatcherInsideFolder(string filePath, string extension)
        {
            this.dirPath = filePath;
            this.Extension = extension;

        }
        private string returnPattern()
        {
            return String.Concat("*." + this.Extension);
        }

        public void createInstanceOfEmailAccount(string emailAddr, SecureString secureString)
        {
            email = new Email(ref emailAddr, ref secureString);
        }

        public void WatchFilesInsideFolder()
        {
            var isDirectoryStillAvaliable = Directory.Exists(this.dirPath);
            if (isDirectoryStillAvaliable)
            {
                var pattern = returnPattern();
                var dirWatcher = new FileSystemWatcher(this.dirPath, pattern);
                dirWatcher.Created += FileWatcher_Created;
                dirWatcher.EnableRaisingEvents = true;
            }
            else
                Console.WriteLine("The directory doesn't exist");
        }

        private void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string FullPath = e.FullPath;

            NewFileInfo(e);
            email.send(this.dirPath, FullPath);
        }

        public void Show()
        {
            Console.WriteLine("Folder to watch {" + this.dirPath + "}");
        }

        public void NewFileInfo(FileSystemEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Utworzono plik o nazwie {0}", e.Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
