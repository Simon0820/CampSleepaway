using System;
using System.Collections.Generic;
using System.Linq;
using CampSleepawayAssey.DataBaseCamp;
using Microsoft.EntityFrameworkCore;

namespace CampSleepawayAssey
{
    class Program
    {

        private static dbContext database;

        public static void Main(string[] args)
        {
            using (database = new dbContext())
            {
                Console.WriteLine("--Welcome to Camp Sleepaway--");
                Console.WriteLine("\n1. Search for campers by counselor or cabinname" +
                    "\n2. Search for campers with eventual relatives" +
                    "\n3. Add new camper, relative, counselor or cabin" +
                    "\n4. Update camper, relative, counselor or cabin" +
                    "\n5. Delete camper, relative, counselor or cabin" +
                    "\n6. Register camper departure");
                int answer = int.Parse(Console.ReadLine());


                while (true)
                {
                    switch (answer)
                    {
                        case 1:
                            SearchCamp();
                            Console.ReadLine();
                            break;
                        case 2:
                            RelativeSearch();
                            Console.ReadLine();
                            break;
                        case 3:
                            Add();
                            Console.ReadLine();
                            break;
                        case 4:
                            Update();
                            Console.ReadLine();
                            break;
                        case 5:
                            Delete();
                            Console.ReadLine();
                            break;
                        case 6:
                            Register();
                            Console.ReadLine();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        //SEARCH CAMPER WITH COUNSELOR OR CABINNAME
        public static void SearchCamp()
        {
            Console.WriteLine("\nType in Cabin Name or Counselor Name: ");
            string answer = Console.ReadLine();
            var cabin = database.Cabins
                .Where(c => c.CabinName == answer || c.Counselor.Name == answer)
                .FirstOrDefault();
            var camperID = database.CabinStatuses
                .Where(camper => camper.CabinID == cabin.ID)
                .Select(camper => camper.CamperID)
                .ToList();


            foreach (var camper in database.Campers)
            {
                if (camperID.Contains(camper.ID))
                {
                    Console.WriteLine("\n--Name / Age--");
                    Console.WriteLine("*" + camper.Name + " / " + camper.Age);
                }
            }


        }

        //SEARCH CAMPER WITH RELATIVE
        public static void RelativeSearch()
        {
            Console.WriteLine("\nType in Cabin Name: ");
            string answer = Console.ReadLine();
            var cabin = database.Cabins
                .Where(c => c.CabinName == answer)
                .FirstOrDefault();
            var camperID = database.CabinStatuses
                .Where(camper => camper.CabinID == cabin.ID)
                .Select(camper => camper.ID)
                .ToList();
            Console.WriteLine("\nCampers with relatives in cabin:");
            foreach (var camper in database.CampersRelatives)
            {
                if (camperID.Contains(camper.ID))
                {
                    Console.WriteLine("\n--CamperName / Relative--");
                    Console.WriteLine("*" + camper.CamperName + " / " + camper.RelativeName);
                }
            }

            var camperName = database.Campers
                .Where(camperN => camperN.Name == cabin.CabinName)
                .Select(camperN => camperN.ID)
                .ToList();

            Console.WriteLine("\nRest of campers without relative");
            foreach (var cID in database.Campers)
            {
                Console.WriteLine("*" + cID.Name + " / " + "No relative assigned");
            }

        }

        //ADD CAMPER, RELATIVE, COUNSELOR, CABINS
        public static void Add()
        {
            Console.WriteLine("\nWhat do you want to add?; " +
                "\n1. Camper" +
                "\n2. Relative" +
                "\n3. Counselor" +
                "\n4. Cabin" +
                "\n0. Exit");
            int add = int.Parse(Console.ReadLine());

            if (add == 1)
            {
                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                Console.WriteLine("Year of arrival: ");
                string year = Console.ReadLine();
                Console.WriteLine("Month of arrival: ");
                string month = Console.ReadLine();
                Console.WriteLine("Day of arrival: ");
                string day = Console.ReadLine();
                Camper camper = new Camper
                {
                    Name = name,
                    PhoneNumber = number,
                    Age = age,
                    Adress = adress,
                    ArrivalDate = year + "-" + month + "-" + day,
                };
                database.Add(camper);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (add == 2)
            {
                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                NextOfKin relative = new NextOfKin
                {
                    Name = name,
                    PhoneNumber = number,
                    Age = age,
                    Adress = adress
                };
                database.Add(relative);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (add == 3)
            {
                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                Counselor counselor = new Counselor
                {
                    Name = name,
                    PhoneNumber = number,
                    Age = age,
                    Adress = adress
                };
                database.Add(counselor);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (add == 4)
            {
                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("CounselorID: ");
                int id = int.Parse(Console.ReadLine());
                Cabin cabin = new Cabin
                {
                    CabinName = name,
                    CounselorID = id,
                };
                database.Add(cabin);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (add == 0)
            {
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Type in 1,2,3 or 4");
            }
            Console.ReadKey();
        }

        //UPDATE CAMPER, RELATIVE, COUNSELOR, CABINS
        public static void Update()
        {
            Console.WriteLine("\nWhat do you want to update?; " +
                "\n1. Camper" +
                "\n2. Relative" +
                "\n3. Counselor" +
                "\n4. Cabin");
            int update = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (update == 1)
            {
                foreach (var camper in database.Campers)
                {
                    Console.WriteLine(camper.Name);
                }
                Console.WriteLine("\nType in name for update");
                string selectedName = Console.ReadLine();

                var Camper = database.Campers
                    .Where(c => c.Name == selectedName)
                    .SingleOrDefault();

                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                Camper.Name = name;
                Camper.PhoneNumber = number;
                Camper.Age = age;
                Camper.Adress = adress;
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (update == 2)
            {
                foreach (var relative in database.Relatives)
                {
                    Console.WriteLine(relative.Name);
                }
                Console.WriteLine("\nType in name for update");
                string selectedName = Console.ReadLine();

                var NextOfKin = database.Relatives
                    .Where(c => c.Name == selectedName)
                    .SingleOrDefault();

                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                NextOfKin.Name = name;
                NextOfKin.PhoneNumber = number;
                NextOfKin.Age = age;
                NextOfKin.Adress = adress;
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (update == 3)
            {
                foreach (var counselor in database.Counselors)
                {
                    Console.WriteLine(counselor.Name);
                }
                Console.WriteLine("\nType in name for update");
                string selectedName = Console.ReadLine();

                var Counselor = database.Counselors
                    .Where(c => c.Name == selectedName)
                    .SingleOrDefault();

                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string number = Console.ReadLine();
                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Adress: ");
                string adress = Console.ReadLine();
                Counselor.Name = name;
                Counselor.PhoneNumber = number;
                Counselor.Age = age;
                Counselor.Adress = adress;
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (update == 4)
            {
                foreach (var cabin in database.Cabins)
                {
                    Console.WriteLine(cabin.CabinName);
                }
                Console.WriteLine("\nType in name for update");
                string selectedName = Console.ReadLine();

                var Cabin = database.Cabins
                    .Where(c => c.CabinName == selectedName)
                    .SingleOrDefault();

                Console.WriteLine("\nName: ");
                string name = Console.ReadLine();
                Cabin.CabinName = name;
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else
            {
                Console.WriteLine("Type in 1,2,3 or 4");
            }
            Console.ReadKey();
        }

        //DELETE CAMPER, RELATIVE, COUNSELOR, CABINS
        public static void Delete()
        {
            Console.WriteLine("\nWhat do you want to delete?; " +
                "\n1. Camper" +
                "\n2. Relative" +
                "\n3. Counselor" +
                "\n4. Cabin");
            int delete = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (delete == 1)
            {
                foreach (var camper in database.Campers)
                {
                    Console.WriteLine(camper.Name);
                }
                Console.WriteLine("\nType in name for removal");
                string selectedName = Console.ReadLine();

                var Camper = database.Campers
                    .Where(c => c.Name == selectedName)
                    .SingleOrDefault();
                database.Campers.Remove(Camper);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (delete == 2)
            {
                foreach (var relative in database.Relatives)
                {
                    Console.WriteLine(relative.Name);
                }
                Console.WriteLine("\nType in name for removal");
                string selectedName = Console.ReadLine();

                var Relative = database.Relatives
                    .Where(r => r.Name == selectedName)
                    .SingleOrDefault();

                database.Relatives.Remove(Relative);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (delete == 3)
            {
                foreach (var counselor in database.Counselors)
                {
                    Console.WriteLine(counselor.Name);
                }
                Console.WriteLine("\nType in name for removal");
                string selectedName = Console.ReadLine();

                var Counselor = database.Counselors
                    .Where(c => c.Name == selectedName)
                    .SingleOrDefault();

                database.Counselors.Remove(Counselor);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else if (delete == 4)
            {
                foreach (var cabin in database.Cabins)
                {
                    Console.WriteLine(cabin.CabinName);
                }
                Console.WriteLine("\nType in name for removal");
                string selectedName = Console.ReadLine();

                var Cabin = database.Cabins
                    .Where(c => c.CabinName == selectedName)
                    .SingleOrDefault();

                database.Cabins.Remove(Cabin);
                database.SaveChanges();
                Console.WriteLine("press enter to continue");
            }
            else
            {
                Console.WriteLine("Type in 1,2,3 or 4");
            }
        }

        public static void Register()
        {
            Console.WriteLine("");
            foreach (var camper in database.Campers)
            {
                Console.WriteLine(camper.ID + " / " + camper.Name);
            }
            Console.WriteLine("\nEnter leaving campers ID: ");
            int leave = int.Parse(Console.ReadLine());

            var Camper = database.Campers
                .Where(c => c.ID == leave)
                .SingleOrDefault();
            var CabinStatus = database.CabinStatuses
                .Where(t => t.CamperID == Camper.ID)
                .SingleOrDefault();

            Console.WriteLine("Year of departure: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Month of departure: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Day of departure: ");
            int day = int.Parse(Console.ReadLine());

            Camper.DepartureDate = year + "-" + month + "-" + day;
            CabinStatus.CabinDeparture = year + "-" + month + "-" + day;
            database.SaveChanges();
            Console.WriteLine("Press enter to continue");
        }
    }
}
