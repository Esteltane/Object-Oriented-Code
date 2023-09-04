using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using System.IO;

namespace DataLayer
{
    class LoadSingleton
    {
        private LoadSingleton()
        {
            //private constructor 
        }
        /***
         * i made a singleton for both the saving and loading operations, this made it easier as it was only one connection to a file that i needed.
         * i then just needed a way to open and read in  the files, so i read up on the Stream reader class which i found when messing about with
         * the stream writer class i used in the save singleton, and came up with something
         * ***/

        private static LoadSingleton instance;
        public static LoadSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoadSingleton();
                    using (var open = new StreamReader(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Staff.csv")) //used to get the staff file
                    {

                        while (!open.EndOfStream)
                        {
                            var line = open.ReadLine(); // takes in each line
                            var values = line.Split(','); // splits each line

                            //System.Diagnostics.Debug.WriteLine(values[3]); <- i used this to test and figure out what was what inside the Value var
                            if (!(line == ""))// had to add this in as if i remove it it causes an error 
                            {
                                  Staff s = new Staff(Convert.ToInt32(values[0]), Convert.ToString(values[2]), Convert.ToString(values[3]), Convert.ToString(values[4]), Convert.ToString(
                                    values[5]), Convert.ToString(values[1]), Convert.ToDouble(values[6]), Convert.ToDouble(values[7])); // creates a new staff object for each staff member in the file
                            }
                        }

                    }

                    using (var open = new StreamReader(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Client.csv"))//used to get the client file
                    {
                        while (!open.EndOfStream)
                        {
                            var line = open.ReadLine();
                            var values = line.Split(',');

                            //System.Diagnostics.Debug.WriteLine(values[3]);
                            if (!(line == ""))
                            {
                                //creates a new client object for each client
                                Client c = new Client(Convert.ToInt32(values[0]), values[1], values[2], values[3], values[4], Convert.ToDouble(values[5]), Convert.ToDouble(values[6]));
                            }
                        }

                    }

                    using (var open = new StreamReader(@"H:\Year2\cw2\cw2\PresentationLayer\FileDump\Visit.csv"))//used to get the visit file
                    {

                        while (!open.EndOfStream)
                        {
                            var line = open.ReadLine();
                            var values = line.Split(',');

                            //System.Diagnostics.Debug.WriteLine(values[3]);
                            if (!(line == ""))
                            {
                                /***
                                 * the following code i made because i remembered that when creating the visit object it needs an array of ints to be passed into it
                                 * so i decided to make a tempory array called staff and i'd add both of the staff ids into it, id then when making the visit object
                                 * i passed it that array instead of the two staff id that get read in.
                                 * ***/
        int[] staff = { Convert.ToInt32(values[0]), Convert.ToInt32(values[1]) };
                                Visit v = new Visit(staff, Convert.ToInt32(values[2]), Convert.ToInt32(values[3]), Convert.ToDateTime(values[4]));
                            }
                        }

                    }

                }
                return instance;
            }
        }

    }
}
