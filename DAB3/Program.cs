using DAB3.Services;
using System;

namespace DAB3
{
    class Program
    {
        static void Main(string[] args)
        {
            CitizenService cs = new CitizenService();
            LocationService ls = new LocationService();
            MunicipalityService ms = new MunicipalityService();
            CountryService ns = new CountryService();
            TestCenterService tcs = new TestCenterService();
            TestCenterManagementService tcms = new TestCenterManagementService();

            LocationCitizenService lcs = new LocationCitizenService();
            TestCenterCitizenService tccs = new TestCenterCitizenService();

            MongoFunctions cf = new MongoFunctions();

            int choice;
            bool done = false;

            do
            {
                Console.WriteLine("Time to choose \n"
                    + " 1: to add a new citizen\n"
                    + " 2: to add Testcenter\n"
                    + " 3: to add Management\n"
                    + " 4: to add Testcase\n"
                    + " 5: to a add location\n"
                    + " 6: to add Location Citizen\n"
                    + " 0: to exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        cf.citizenCreation(cs);
                        break;

                    case 2:
                        cf.TestCenterCreation(tcs);
                        break;

                    case 3:
                        cf.ManagementCreation(tcms, tcs);
                        break;

                    case 4:
                        cf.TestCaseCreation(cs, tcs, tccs, lcs);
                        break;

                    case 5:
                        cf.LocationCreation(ls);
                        break;
                    case 6:
                        cf.LocationCitizenCreation(lcs, cs, ls);
                        break;

                   
                    case 0:
                        done = true;
                        break;
                }

            } while (true);
        }
    }
}
