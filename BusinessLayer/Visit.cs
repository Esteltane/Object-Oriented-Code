using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public static class ListStaff
    {
        public static ArrayList GP = new ArrayList();
        public static ArrayList Social_Worker = new ArrayList();
        public static ArrayList Community_Nurse = new ArrayList();
        public static ArrayList C_Worker = new ArrayList();

       /***
        * i made this inner class have a place to store all my staff members and what job they have, each array list gets filled in the constructor with each member
        * of staffs id for the correct job
        * ***/

    }
    class Visit
    {
        private Visit()
        {

        }
        private int clientID;
        private int[] staffID;
        private int visittype;
        private DateTime dt;
        private int s1id;
        private int s2id;
        private string temp;
        private static ArrayList Avisit = new ArrayList();
        private static ArrayList dtlist = new ArrayList();
        //above is all the variables used
        public Visit(int[] i, int ci, int vt, DateTime d) // constructor
        {
            
            SetStaffID(i);
            SetClientID(ci);
            SetVType(vt); // sets all variables
            SetDatetime(d);
            /***
             * the following code is used to get each staff with the following jobs and put their id into the 
             * correct arraylist for that job, i then use the arraylists in my validation so im not having to hard code
             * in values
             * ***/
            foreach(Staff index in Staff.Slist().Values)
            {
                if(index.getCategory() == "General Practitioner")
                {
                    if (!ListStaff.GP.Contains(index.getSID())) // stops the same staff being added twice
                    {
                        ListStaff.GP.Add(index.getSID());
                    }
                    }
                if(index.getCategory() == "Social Worker")
                {
                    if (!ListStaff.Social_Worker.Contains(index.getSID()))
                    {
                        ListStaff.Social_Worker.Add(index.getSID());
                    }
                }
                if(index.getCategory() == "Community Nurse")
                {
                    if (!ListStaff.Community_Nurse.Contains(index.getSID()))
                    {
                        ListStaff.Community_Nurse.Add(index.getSID());
                    }
                }
                if(index.getCategory() == "Care Worker")
                {
                    if (!ListStaff.C_Worker.Contains(index.getSID()))
                    {
                        ListStaff.C_Worker.Add(index.getSID());
                    }
                }
            }
            if ((visittype >= 0 && visittype < 4)  && (clientID >=1 && clientID <=3))// start of validation used to check if visit type and client id are valid
            {
                if(visittype == 3)// used to check if type is a meal
                {
                    if ((ListStaff.C_Worker.Contains(s1id)) && s2id == 0)//looks through the correct staff arraylist and checks if the temp variables i made are stored inside
                    {
                       
                        temp += s1id + Convert.ToString(dt);// made a tempory string to store the date and the staff id which will make validation of the time easier
                        if(!dtlist.Contains(temp))//checks if the arraylist contains the same values
                        {
                           //adds the temp string into a arraylist called "dtlist" which if the temp already exists in there then it will throw an error because those
                           // staff are already out on a job at that time
                            Avisit.Add(this);
                            dtlist.Add(temp);
                            temp = ""; // clears the temp variable
                          
                        }
                        else
                        {
                            temp = "";
                            throw new Exception("An apppointment already exists with that time \n");
                        }
                    }
                    else
                    {
                        throw new Exception("Incorrect staff\n");
                    }
                }
                if (visittype == 2)
                {
                    if(ListStaff.C_Worker.Contains(s1id) && ListStaff.C_Worker.Contains(s2id))
                    {
                        
                        temp += s1id + s2id + Convert.ToString(dt);
                        if (!dtlist.Contains(temp))
                        {
                            
                            Avisit.Add(this);
                            dtlist.Add(temp);
                            temp = "";
                        }
                        else
                        {
                            temp = "";
                            throw new Exception("an apppointment already exists with that time\n");
                        }
                    }
                    else
                    {
                        throw new Exception("incorrect staff\n");
                    }
                }
                if (visittype == 1)
                {
                    if (ListStaff.Community_Nurse.Contains(s1id) && s2id == 0)
                    {
                       
                        temp += s1id + Convert.ToString(dt);
                        if (!dtlist.Contains(temp))
                        {
                            Avisit.Add(this);
                            dtlist.Add(temp);
                            temp = "";
                           
                        }
                        else
                        {
                            temp = "";
                            throw new Exception("an apppointment already exists with that time\n");
                        }
                    }
                    else
                    {
                        throw new Exception("incorrect staff\n");
                    }
                }
                if (visittype == 0)
                {
                    if (ListStaff.GP.Contains(s1id) && ListStaff.Social_Worker.Contains(s2id))
                    {

                        temp += s1id + s1id + Convert.ToString(dt);
                        if (!dtlist.Contains(temp))
                        {
                            Avisit.Add(this);
                            dtlist.Add(temp);
                            temp = "";
                            
                        }
                        else
                        {
                            temp = "";
                            throw new Exception("an apppointment already exists with that time\n");
                        }
                    }
                    else
                    {
                        throw new Exception("incorrect staff\n");
                    }
                }
                
                
            }
            else
            {
                throw new Exception("Incorrect visit or incorrect Client\n");
            }
            
            
        }

        public static void Wipe() // clear method used to wipe the two main arraylists
        {
            Avisit.Clear();
            dtlist.Clear();
        }
        /***
         * getters and setters used to set the visit
         * ***/

        public int GetClient()
        {
            return clientID;
        }

        public int[] GetStaff()
        {
            return staffID;
        }

        public int GetVT()
        {
            return visittype;
        }

        public DateTime Getdt()
        {
            return dt;
        }

        public void SetClientID(int i)
        {
            clientID = i;
        }

        public void SetStaffID(int[] ai)
        {
            staffID = ai;
            try
            {
                s1id = staffID[0]; // this code will take in the array and assign my temp variables each with one index of that array
                s2id = staffID[1];
            }
            catch
            {
                
            }
        }

        public void SetVType(int vi)
        {
            visittype = vi;
        }

        public void SetDatetime(DateTime d)
        {
            dt = d;
        }

        public override string ToString()
        {
            if (s2id == 0)// my toString method for visit is different from client and staff, this will check if the second index of the staff array is null
            {
                string visity = s1id + ","  + "Null" + "," + clientID + "," + visittype + "," + dt; // if it is null it will not add it into the tostring
                return visity;
            }
            else // i had to put this into the override as if i didnt my program would break
            {
                string visity = s1id + "," + s2id + "," + clientID + "," + visittype + "," + dt;// if it isnt null it gets added
                return visity;
            }
        }


        public static string AllVisits() // method used to loop through the arraylist storing the visit 
        {
            string v = "";

            foreach(var item in Avisit)
            {
                v += item.ToString() + "\n";
            }

            return v;
        }



    }
}
