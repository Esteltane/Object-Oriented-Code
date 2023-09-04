using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BusinessLayer
{
    public static class visitTypes
        {
            public const int assessment = 0;
            public const int medication = 1;
            public const int bath = 2;
            public const int meal = 3;

        }

    public class HealthFacade
    {
       

        public Boolean addStaff(int id, string firstName, string surname, string address1, string address2, string category, double baseLocLat, double baseLocLon)
        {
            Staff staff = new Staff(id, firstName, surname, address1, address2, category, baseLocLat, baseLocLon);
            
            return true;
        }

        public Boolean addClient(int id, string firstName, string surname, string address1, string address2, double locLat, double locLon)
        {
            Client client1 = new Client(id, firstName, surname, address1, address2, locLat, locLon);
           
            return true;
        }

        public Boolean addVisit(int[] staff, int patient, int type, string dateTime)
        {
            Visit visit1 = new Visit(staff, patient, type, Convert.ToDateTime(dateTime));
            //throw new Exception("Error - add visit not yet implemented (Patient "+ patient +" @" + dateTime+")\n");

            return true;//If no errors thrown, assum OK
        }


        public String getStaffList()
        {
            return "<Staff>" + "\n" + Staff.Stafflist(); // returns the staff list in a nice structured way with a header
            
        }

        public String getClientList()
        {
            return "<Clients>" +"\n" + Client.Clientlist();// returns the clients staff list in a nice structured way with a header
        }

        public String getVisitList()
        {
            return "<Vitit>" + "\n" + Visit.AllVisits(); // returns the visit list in a nice structured way with a header
        }

        public void clear()
        {
            Staff.Wipe();
            Client.Wipe();
            Visit.Wipe();
            Console.WriteLine("Neil Look the Data been Cleared"); //calls each wipe method in the following classes and prints a messaage to show they have been cleared
            
        }


        public Boolean load()
        {
            LoadSingleton load = LoadSingleton.Instance; // calls the load singleton
            return true;
        }

        public bool save()
        {
            SaveSingelton save = SaveSingelton.Instance; // calls the save singleton     
            

            return true;
        }

        

    }
}
