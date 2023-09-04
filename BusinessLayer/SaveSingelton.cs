using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using System.IO;

namespace DataLayer
{
    class SaveSingelton
    {
        private SaveSingelton()
        {
            //private constructor
        }
        /***
         * i made a singleton for both the saving and loading operations, this made it easier as it was only one connection to a file that i needed.
         * i then just needed a way to create the files, so i went to google to find out how to create files and found the following code marked with a //* 
         * from microsoft documents, i then put it into my code and changed it to match what i needed, the url to where i found the code is below
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
         * ***/
        private static SaveSingelton instance;
        public static SaveSingelton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveSingelton();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Staff.csv"))//*
                    {
                        file.WriteLine(Staff.Stafflist());
                    }


                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Client.csv"))//*
                    {
                        file.WriteLine(Client.Clientlist());
                    }


                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Visit.csv"))//*
                    {
                        file.WriteLine(Visit.AllVisits());
                    }

                }
                return instance;
            }
        }




    }
}
