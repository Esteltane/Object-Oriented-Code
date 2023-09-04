using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Client : Person
    {
        private int clientID;

        private static Dictionary<int, Client> DicClient= new Dictionary<int, Client>();
        //creation on variables and dictionary used in client

        public Client(int sID, string s, string s2, string a1, string a2, double lat, double lon)// constructor
        {
            setCID(sID);
            setName(s);
            setName2(s2);
            setAddress1(a1);
            setAddress2(a2);
            setLat(lat); // setting all the variables to the passed paramaters 
            setLon(lon);

            if (!DicClient.ContainsKey(sID)) // used to stop an error and my program breaking
            {
                DicClient.Add(clientID, this); // adds this object to the dictionary used to store all
            }

        }

        public static void Wipe() // method for clearing the dictionary, gets called in healthfacade
        {
            DicClient.Clear();
        }
        /***
         * the following code is to set the variables using getters and setters, ive went for a java style as thats what im fimiliar with
         * each class i have created in this has the same style
         * ***/
        public int getCID()
        {
            return clientID;
        }

        public void setCID(int i)
        {
            clientID = i;
        }

        public override string ToString()// my to string method to return the client in a nice text readable way
        {
            return clientID + "," + base.ToString(); // calls the toString() in the person class
        }

        public static string Clientlist() // this is to return all clients by going through the dictionary and calling the toString() on each one
        {
            string c = "";
            foreach (Client entry in DicClient.Values)
            {
                c += entry.ToString() + "\n";

            }
            return c;
        }
    }
}
