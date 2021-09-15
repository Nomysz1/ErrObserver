using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
//Custom import
using ErrObserver.Error;

namespace ErrObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            var ArgsErr = new ArgsError();

            var argsCondition = args.Length > 0 && args.Length % 2 == 0;
            if (argsCondition)
            {
                var test = new ArgsParser(ref args);
                List<Args> tmp = test.parseInput();
                //-------
                var dirPath = default(string);
                var extension = default(string);
                var emailAddr = default(string);
                var smtpPort = default(int);
                var smtpHost = default(string);
                var ssl = default(bool);
                var to = default(string);
                //------
                foreach(Args element in tmp)
                {
                    if(element.command == "--filepath")
                        dirPath = element.value != ""? element.value: "";
                    if (element.command == "--extension")
                        extension = element.value;
                    if (element.command == "--emailAddr")
                        emailAddr = element.value;
                    if (element.command == "--smtpPort")
                        smtpPort = Convert.ToInt32(element.value);
                    if (element.command == "--smtpHost")
                        smtpHost = element.value;
                    if (element.command == "--ssl")
                        ssl = Convert.ToBoolean(Convert.ToInt32(element.value));
                    if (element.command == "--to")
                        to = element.value;
                }

                SecureString secureString = new SecureString();

                Console.WriteLine("Wprowadź hasło email: ");
                string pass = Console.ReadLine();
                secureString =  SecureStr.encrypt(ref pass);
                pass = "";

                if (dirPath != "" && extension != "")
                {
                    var files = new FileWatcherInsideFolder(dirPath, extension);
                    //====================
                    files.createInstanceOfEmailAccount(emailAddr, secureString);
                    files.email.addSMTPHost(ref smtpHost);
                    files.email.addSMTPPort(ref smtpPort);
                    files.email.addSSL(ref ssl);
                    files.email.addTo(ref to);
                    //====================
                    files.Show();
                    Task.Run(() =>
                    {
                        files.WatchFilesInsideFolder();
                    });
                }
                else
                    ArgsErr.InvalidInput();
            }
            else
                ArgsErr.InvalidInput();
            Console.ReadKey();
        }
    }
}
