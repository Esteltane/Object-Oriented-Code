using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Person
    {
        /***
         this is my person class that will be used to make a basic human the adding of client and staff will come later
         ive chosen to code this in a java style
         ***/
         //ive chosen to make the constructor with no paramaters as it doesnt take anything it just used methods in other classes 
        public Person()
        {
            //empty constructor used to create a basic person
        }
        private string Fname;
        private string Sname;
        private string Ad1;
        private string Ad2;
        private double lat;
        private double lon;
        // above are all the variables used in person

        public string getfname(string Fname)
        {
            return Fname;
        }
        public string getSname(string Sname)
        {
            return Sname;
        }
        public string getAddress1(string Ad1)
        {
            return Ad1;
        }
        public string getAddress2(string Ad2)
        {
            return Ad2;
        }

        public string getLocation(double lat, double lon)
        {
            string location = lat + " , " + lon;
            return location;
        }

        public void setName(string s)
        {
            Fname = s;
        }

        public void setName2(string s)
        {
            Sname = s;
        }
        public void setAddress1(string s)
        {
            Ad1 = s;
        }
        public void setAddress2(string s)
        {
            Ad2 = s;
        }
        public void setLat(double d)
        {
            lat = d;
        }
        public void setLon(double d)
        {
            lon = d;
        }
        // getters and setters above coded in a java style as thats what im most fimilar with
        public override string ToString()
        {
             return Fname+"," + Sname +","+ Ad1+"," + Ad2+"," + lat+"," + lon;
            // returns the variables WITH commas as it will 
        }
    }
}
