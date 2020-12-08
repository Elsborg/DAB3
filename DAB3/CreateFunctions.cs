using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;
using DAB3.Services;
using System.IO;

namespace DAB3
{
    class CreateFunctions
    {
        public void citizenCreation(CitizenService cs)
        {
            Console.Clear();
            Console.WriteLine("Type firstname of citizen: ");
            string Firstname = Console.ReadLine();

            Console.WriteLine("Type lastname of citizen: ");
            string Lastname = Console.ReadLine();


            Console.WriteLine("Type age of citizen: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Type sex of citizen (male/female: ");
            string sex = Console.ReadLine();

            Console.WriteLine("Type Social Security Number of citizen (10 digits): ");
            string ssn = Console.ReadLine().Trim();

            Console.WriteLine("Type municipality Id where the citizen live: ");
            int municipalityId = int.Parse(Console.ReadLine());

            var addCitizen = new Citizen()
            {
                FirstName = Firstname,
                LastName = Lastname,
                Age = age,
                Sex = sex,
                SSN = ssn,
                MunicipalityId = municipalityId
            };
            cs.Create(addCitizen);
            Console.WriteLine("Citizen was added!\n");
        }

        public void TestCenterCreation(TestCenterService tcs)
        {
            Console.WriteLine("Enter ID for the testcenter: ");
            int TestCenterId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter opening hours of the testcenter (fx. 8-16): ");
            string hours = Console.ReadLine();

            Console.WriteLine("Enter MunicipalityID for the municipality in which the testcenter is: ");
            int municipalityId = int.Parse(Console.ReadLine());

            var AddTestCenter = new TestCenter()
            {
                TestCenterId = TestCenterId,
                OpenHours = hours,
                MunicipalityId = municipalityId
            };

            tcs.Create(AddTestCenter);

            Console.WriteLine("TestCenter added!\n");
        }
        public void ManagementCreation(TestCenterManagementService tcms, TestCenterService tcs)
        {
            Console.Clear();
            Console.WriteLine("Enter TestCenterManagements PhoneNumber:(8 digits): ");
            int phonenumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter TestCenterManagements Email address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter TestCenterID by the managened TestCenter: ");
            int testcenterid = int.Parse(Console.ReadLine());

            var AddTestCenterManagement = new TestCenterManagement()
            {
                PhoneNumber = phonenumber,
                Email = email,
                TestCenterId = testcenterid,
                testcenter = tcs.Get(testcenterid)
            };

            tcms.Create(AddTestCenterManagement);

            Console.WriteLine("TestCenterManagement added!\n");
        }

        public void LocationCreation(LocationService ls)
        {
            Console.Clear();
            Console.WriteLine("Enter address for the location: ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Municipality ID which the municipality is located: ");
            int municipalityid = int.Parse(Console.ReadLine());

            var AddLocation = new Location()
            {
                Address = address,
                MunicipalityId = municipalityid
            };

            ls.Create(AddLocation);

            Console.WriteLine("Location added!\n");

        }

        public void LocationCitizenCreation(LocationCitizenService lcs, CitizenService cs, LocationService ls)
        {
            Console.Clear();
            Console.WriteLine("Enter address for the location: ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter SocialSecurityNumber for the citizen: ");
            string ssn = (Console.ReadLine());

            Console.WriteLine("Enter the date ");
            string date = (Console.ReadLine());

            var cit = cs.Get(ssn);
            var loc = ls.GetAddress(address);

            var LocationCitizenAdd = new LocationCitizen()
            {
                Address = address,
                SSN = ssn,
                date = date,
                citizen = cit,
                location = loc
            };

            lcs.Create(LocationCitizenAdd);

            Console.WriteLine("Location added!\n");
        }
        public void TestCaseCreation(CitizenService cs, TestCenterService tcs, TestCenterCitizenService tccs, LocationCitizenService lcs)
        {
            Console.Clear();
            Console.WriteLine("Enter Social sericurity number for a citizen: ");
            string tempSSN = Console.ReadLine();
            string ssn = tempSSN.Trim();

            Console.Clear();
            Console.WriteLine("Enter TestCenterId for where the testcenter occured: ");
            string tempTest = Console.ReadLine();
            int tcid = int.Parse(tempTest);

            var cit = cs.Get(ssn);
            var tcr = tcs.Get(tcid);

            var tcc = new TestCenterCitizen();
            tcc.SSN = cit.SSN;
            tcc.TestCenterId = tcr.TestCenterId;
            tcc.citizen = cit;
            tcc.testCenter = tcr;

            Console.Clear();
            Console.WriteLine("Enter date for the test in the format (ddmmyy): ");
            string tempDate = Console.ReadLine();
            tcc.Date = tempDate;

            Console.Clear();
            Console.WriteLine("Enter status for the test either ready, done or not done: ");
            string statusOfTest = Console.ReadLine();
            tcc.Status = statusOfTest;

            Console.Clear();
            Console.WriteLine("Enter test result, P = Positve and N = Negative\n");
            string tempResult = Console.ReadLine();
            if (tempResult == "P")
            {
                tcc.Result = true;
            }
            else if (tempResult == "N")
            {
                tcc.Result = false;
            }

            tccs.Create(tcc);
            Console.WriteLine("Test case added\n");
        }
           
    }
}
