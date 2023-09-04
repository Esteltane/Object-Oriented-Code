using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace BusinessLayer
{
    class Staff : Person // inheritance from person
    {

        private int staffID;
        private string category;
        private static Dictionary<int, Staff> DicStaff = new Dictionary<int, Staff>();
        // above is the 2 variables i used and the dictionary
        private Staff()
        {

        }

        public Staff(int sID, string s, string s2, string a1, string a2, string cat, double lat, double lon)
        {
            setSID(sID);
            setName(s);
            setName2(s2);
            setAddress1(a1);
            setAddress2(a2);
            setCategory(cat);
            setLat(lat);
            setLon(lon);
            //above sets all the staff variables of this object to the paramaters passed
            if (!DicStaff.ContainsKey(sID)) // used to stop an error my code breaking
            {
                DicStaff.Add(sID, this); // adds to the dictionary
            }

        }



        public static void Wipe()
        {
            DicStaff.Clear(); // my method for clearing the dictionary, calls the .clear premade function for dictionarys
        }
        public static Dictionary<int,Staff> Slist() // this method returns the full dictionary, its used in visit to get all staff into correct arraylist
        {
            return DicStaff;
        }
        // below getters and setters
        public int getSID()
        {
            return staffID;
        }
        private void setSID(int i)
        {
            this.staffID = i;
        }

        public string getCategory()
        {
            return this.category;
        }

        public void setCategory(string s)
        {
            this.category = s;
        }

        public override string ToString()
        {
            return staffID + "," + category +","+ base.ToString(); // called the tostring in person
        }
        public static string Stafflist() // gets each staff object and calls the toString method to return each one nicely
        {
            string s = "";
            foreach (Staff entry in DicStaff.Values) {
                s+= entry.ToString() + "\n";

            }
                return s;
        }
       
    }
}
