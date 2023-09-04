using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;
using System.IO;

namespace PersonTest
{
    [TestClass]
    public class ClientTest
    {
            const int Identification = 4;
            const string FirstName = "Charlotte";
            const string SecondName = "Smith";
            const string address_1 = "23 big street";
            const string address_2 = "Edinbrugh";
            const double latituade = 55.924814;
            const double longitude = -3.170490;
            const string expected_output = "4,Charlotte,Smith,23 big street,Edinbrugh,55.924814,-3.170490";


        [TestMethod]
        public void TestMethod1()
        {


            try
            {
                HealthFacade hs = new HealthFacade();
                hs.addClient(Identification, FirstName, SecondName, address_1, address_2, latituade, longitude);
                string output = hs.getClientList();
                if (output == expected_output)
                {
                    Console.WriteLine("test Successful");
                }
                else
                {
                    Console.WriteLine("Error test failed");
                    throw new Exception("test failed");
                }

                hs.clear();
            }catch(System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                //File.Create(e.FileName);
            }
        }
    }
}