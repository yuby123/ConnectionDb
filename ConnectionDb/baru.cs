/*using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace ConnectionDb
{

    class Program
    {
        static void Main(string[] args)
        {
            var region = new Region();
            var country = new Country();
            var location = new Location();
            var job = new Job();
            while (true)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Manage Region");
                Console.WriteLine("2. Manage Country");
                Console.WriteLine("3. Manage Location");
                Console.WriteLine("4. Manage Job");
                Console.WriteLine("5. Exit");
                Console.Write("Pilih menu : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageRegion(region);
                        break;
                    case "2":
                        ManageCountry(country);
                        break;
                    case "3":
                        ManageLocation(location);
                        break;
                    case "4":
                        ManageJob(job);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }

        static void ManageRegion(Region region)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. CREATE Region");
                Console.WriteLine("2. READ All Regions");
                Console.WriteLine("3. READ Region by ID");
                Console.WriteLine("4. UPDATE Region");
                Console.WriteLine("5. DELETE Region");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID for new Region: ");
                        int newId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name for new Region: ");
                        string newName = Console.ReadLine();
                        string createResult = region.Insert(newId, newName);
                        Console.WriteLine("CREATE Result: " + createResult);
                        break;

                    case "2":
                        List<Region> allRegions = region.GetAll();
                        Console.WriteLine("READ All Regions:");
                        foreach (var r in allRegions)
                        {
                            Console.WriteLine($"Id: {r.Id}, Name: {r.Name}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter ID to fetch Region: ");
                        int idToFetch = int.Parse(Console.ReadLine());
                        Region retrievedRegion = region.GetById(idToFetch);
                        if (retrievedRegion != null)
                        {
                            Console.WriteLine("READ Region by ID:");
                            Console.WriteLine($"Id: {retrievedRegion.Id}, Name: {retrievedRegion.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Region not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter ID to update Region: ");
                        int idToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Enter updated Name: ");
                        string updatedName = Console.ReadLine();
                        string updateResult = region.Update(idToUpdate, updatedName);
                        Console.WriteLine("UPDATE Result: " + updateResult);
                        break;

                    case "5":
                        Console.Write("Enter ID to delete Region: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        string deleteResult = region.Delete(idToDelete);
                        Console.WriteLine("DELETE Result: " + deleteResult);
                        break;

                    case "6":
                        Environment.Exit(0); // Keluar dari program
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-6).");
                        break;
                }
            }
        }

        static void ManageCountry(Country country)
        {
            while (true)
            {
                Console.WriteLine("===== Manage Country =====");
                Console.WriteLine("1. View All Countries");
                Console.WriteLine("2. View Country by ID");
                Console.WriteLine("3. Add New Country");
                Console.WriteLine("4. Update Country");
                Console.WriteLine("5. Delete Country");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option (1/2/3/4/5/6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Country> allCountries = country.GetAll();
                        Console.WriteLine("===== All Countries =====");
                        foreach (var c in allCountries)
                        {
                            Console.WriteLine($"ID: {c.ID}, Name: {c.Name}, Region ID: {c.Regions_ID}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Country ID: ");
                        if (int.TryParse(Console.ReadLine(), out int idToFetch))
                        {
                            Country retrievedCountry = country.GetById(idToFetch);
                            if (retrievedCountry != null)
                            {
                                Console.WriteLine($"ID: {retrievedCountry.ID}, Name: {retrievedCountry.Name}, Region ID: {retrievedCountry.Regions_ID}");
                            }
                            else
                            {
                                Console.WriteLine("Country not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Country ID: ");
                        if (int.TryParse(Console.ReadLine(), out int newId))
                        {
                            Console.Write("Enter Country Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter Region ID: ");
                            if (int.TryParse(Console.ReadLine(), out int regionId))
                            {
                                string createResult = country.Insert(newId, newName, regionId);
                                Console.WriteLine("Create Result: " + createResult);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Region ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Country ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Enter New Country Name: ");
                            string updatedName = Console.ReadLine();
                            Console.Write("Enter New Region ID: ");
                            if (int.TryParse(Console.ReadLine(), out int updatedRegionId))
                            {
                                string updateResult = country.Update(idToUpdate, updatedName, updatedRegionId);
                                Console.WriteLine("Update Result: " + updateResult);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Region ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Country ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            string deleteResult = country.Delete(idToDelete);
                            Console.WriteLine("Delete Result: " + deleteResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "6":
                        return; // Kembali ke menu utama
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ManageLocation(Location location)
        {
            while (true)
            {
                Console.WriteLine("===== Manage Location =====");
                Console.WriteLine("1. View All Locations");
                Console.WriteLine("2. View Location by ID");
                Console.WriteLine("3. Add New Location");
                Console.WriteLine("4. Update Location");
                Console.WriteLine("5. Delete Location");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option (1/2/3/4/5/6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Location> allLocations = location.GetAll();
                        Console.WriteLine("===== All Locations =====");
                        foreach (var loc in allLocations)
                        {
                            Console.WriteLine($"ID: {loc.Id}, Street Address: {loc.Street_Address}, Postal Code: {loc.Postal_Code}, City: {loc.City}, State/Province: {loc.State_Province}, Country ID: {loc.Country_Id}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Location ID: ");
                        if (int.TryParse(Console.ReadLine(), out int idToFetch))
                        {
                            Location retrievedLocation = location.GetById(idToFetch);
                            if (retrievedLocation != null)
                            {
                                Console.WriteLine($"ID: {retrievedLocation.Id}, Street Address: {retrievedLocation.Street_Address}, Postal Code: {retrievedLocation.Postal_Code}, City: {retrievedLocation.City}, State/Province: {retrievedLocation.State_Province}, Country ID: {retrievedLocation.Country_Id}");
                            }
                            else
                            {
                                Console.WriteLine("Location not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Location ID: ");
                        if (int.TryParse(Console.ReadLine(), out int newId))
                        {
                            Console.Write("Enter Street Address: ");
                            string newStreetAddress = Console.ReadLine();
                            Console.Write("Enter Postal Code: ");
                            string newPostalCode = Console.ReadLine();
                            Console.Write("Enter City: ");
                            string newCity = Console.ReadLine();
                            Console.Write("Enter State/Province: ");
                            string newStateProvince = Console.ReadLine();
                            Console.Write("Enter Country ID: ");
                            if (int.TryParse(Console.ReadLine(), out int newCountryId))
                            {
                                string createResult = location.Create(newId, newStreetAddress, newPostalCode, newCity, newStateProvince, newCountryId);
                                Console.WriteLine("Create Result: " + createResult);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Country ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Location ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Enter New Street Address: ");
                            string updatedStreetAddress = Console.ReadLine();
                            Console.Write("Enter New Postal Code: ");
                            string updatedPostalCode = Console.ReadLine();
                            Console.Write("Enter New City: ");
                            string updatedCity = Console.ReadLine();
                            Console.Write("Enter New State/Province: ");
                            string updatedStateProvince = Console.ReadLine();
                            Console.Write("Enter New Country ID: ");
                            if (int.TryParse(Console.ReadLine(), out int updatedCountryId))
                            {
                                string updateResult = location.Update(idToUpdate, updatedStreetAddress, updatedPostalCode, updatedCity, updatedStateProvince, updatedCountryId);
                                Console.WriteLine("Update Result: " + updateResult);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Country ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Location ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            string deleteResult = location.Delete(idToDelete);
                            Console.WriteLine("Delete Result: " + deleteResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "6":
                        return; // Kembali ke menu utama
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ManageJob(Job job)
        {
            while (true)
            {
                Console.WriteLine("===== Manage Job =====");
                Console.WriteLine("1. View All Jobs");
                Console.WriteLine("2. View Job by ID");
                Console.WriteLine("3. Add New Job");
                Console.WriteLine("4. Update Job");
                Console.WriteLine("5. Delete Job");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option (1/2/3/4/5/6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Job> allJobs = job.GetAll();
                        Console.WriteLine("===== All Jobs =====");
                        foreach (var j in allJobs)
                        {
                            Console.WriteLine($"ID: {j.Id}, Title: {j.Job_Title}, Min Salary: {j.Min_Salary}, Max Salary: {j.Max_Salary}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Job ID: ");
                        if (int.TryParse(Console.ReadLine(), out int idToFetch))
                        {
                            Job retrievedJob = job.GetById(idToFetch);
                            if (retrievedJob != null)
                            {
                                Console.WriteLine($"ID: {retrievedJob.Id}, Title: {retrievedJob.Job_Title}, Min Salary: {retrievedJob.Min_Salary}, Max Salary: {retrievedJob.Max_Salary}");
                            }
                            else
                            {
                                Console.WriteLine("Job not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Job ID: ");
                        if (int.TryParse(Console.ReadLine(), out int newId))
                        {
                            Console.Write("Enter Job Title: ");
                            string newTitle = Console.ReadLine();
                            Console.Write("Enter Min Salary: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal newMinSalary))
                            {
                                Console.Write("Enter Max Salary: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newMaxSalary))
                                {
                                    string createResult = job.Create(newId, newTitle, newMinSalary, newMaxSalary);
                                    Console.WriteLine("Create Result: " + createResult);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Max Salary.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Min Salary.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Job ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Enter New Job Title: ");
                            string updatedTitle = Console.ReadLine();
                            Console.Write("Enter New Min Salary: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal updatedMinSalary))
                            {
                                Console.Write("Enter New Max Salary: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal updatedMaxSalary))
                                {
                                    string updateResult = job.Update(idToUpdate, updatedTitle, updatedMinSalary, updatedMaxSalary);
                                    Console.WriteLine("Update Result: " + updateResult);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Max Salary.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Min Salary.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Job ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            string deleteResult = job.Delete(idToDelete);
                            Console.WriteLine("Delete Result: " + deleteResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "6":
                        return; // Kembali ke menu utama
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ManageEmployee(Employee employee)
        {
            while (true)
            {
                Console.WriteLine("===== Manage Employee =====");
                Console.WriteLine("1. View All Employees");
                Console.WriteLine("2. View Employee by ID");
                Console.WriteLine("3. Add New Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option (1/2/3/4/5/6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Employee> allEmployees = employee.GetAll();
                        Console.WriteLine("===== All Employees =====");
                        foreach (var emp in allEmployees)
                        {
                            Console.WriteLine($"ID: {emp.Id}, First Name: {emp.First_Name}, Last Name: {emp.Last_Name}, Email: {emp.Email}, Phone Number: {emp.Phone_Number}, Hire Date: {emp.Hire_Date}, Salary: {emp.Salary}, Commission Pct: {emp.Commission_Pct}, Manager ID: {emp.Manager_Id}, Department ID: {emp.Department_Id}, Job ID: {emp.Job_Id}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Employee ID: ");
                        if (int.TryParse(Console.ReadLine(), out int idToFetch))
                        {
                            Employee retrievedEmployee = employee.GetById(idToFetch);
                            if (retrievedEmployee != null)
                            {
                                Console.WriteLine($"ID: {retrievedEmployee.Id}, First Name: {retrievedEmployee.First_Name}, Last Name: {retrievedEmployee.Last_Name}, Email: {retrievedEmployee.Email}, Phone Number: {retrievedEmployee.Phone_Number}, Hire Date: {retrievedEmployee.Hire_Date}, Salary: {retrievedEmployee.Salary}, Commission Pct: {retrievedEmployee.Commission_Pct}, Manager ID: {retrievedEmployee.Manager_Id}, Department ID: {retrievedEmployee.Department_Id}, Job ID: {retrievedEmployee.Job_Id}");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Employee ID: ");
                        if (int.TryParse(Console.ReadLine(), out int newId))
                        {
                            Console.Write("Enter First Name: ");
                            string newFirstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string newLastName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string newEmail = Console.ReadLine();
                            Console.Write("Enter Phone Number: ");
                            string newPhoneNumber = Console.ReadLine();
                            Console.Write("Enter Hire Date (yyyy-MM-dd): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime newHireDate))
                            {
                                Console.Write("Enter Salary: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newSalary))
                                {
                                    Console.Write("Enter Commission Pct: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal newCommissionPct))
                                    {
                                        Console.Write("Enter Manager ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int newManagerId))
                                        {
                                            Console.Write("Enter Department ID: ");
                                            if (int.TryParse(Console.ReadLine(), out int newDepartmentId))
                                            {
                                                Console.Write("Enter Job ID: ");
                                                if (int.TryParse(Console.ReadLine(), out int newJobId))
                                                {
                                                    string createResult = employee.Create(newId, newFirstName, newLastName, newEmail, newPhoneNumber, newHireDate, newSalary, newCommissionPct, newManagerId, newDepartmentId, newJobId);
                                                    Console.WriteLine("Create Result: " + createResult);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Job ID.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Department ID.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Manager ID.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Commission Pct.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Salary.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Hire Date.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Employee ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                        {
                            Console.Write("Enter New First Name: ");
                            string updatedFirstName = Console.ReadLine();
                            Console.Write("Enter New Last Name: ");
                            string updatedLastName = Console.ReadLine();
                            Console.Write("Enter New Email: ");
                            string updatedEmail = Console.ReadLine();
                            Console.Write("Enter New Phone Number: ");
                            string updatedPhoneNumber = Console.ReadLine();
                            Console.Write("Enter New Hire Date (yyyy-MM-dd): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime updatedHireDate))
                            {
                                Console.Write("Enter New Salary: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal updatedSalary))
                                {
                                    Console.Write("Enter New Commission Pct: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal updatedCommissionPct))
                                    {
                                        Console.Write("Enter New Manager ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int updatedManagerId))
                                        {
                                            Console.Write("Enter New Department ID: ");
                                            if (int.TryParse(Console.ReadLine(), out int updatedDepartmentId))
                                            {
                                                Console.Write("Enter New Job ID: ");
                                                if (int.TryParse(Console.ReadLine(), out int updatedJobId))
                                                {
                                                    string updateResult = employee.Update(idToUpdate, updatedFirstName, updatedLastName, updatedEmail, updatedPhoneNumber, updatedHireDate, updatedSalary, updatedCommissionPct, updatedManagerId, updatedDepartmentId, updatedJobId);
                                                    Console.WriteLine("Update Result: " + updateResult);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Job ID.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Department ID.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Manager ID.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Commission Pct.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Salary.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Hire Date.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Employee ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            string deleteResult = employee.Delete(idToDelete);
                            Console.WriteLine("Delete Result: " + deleteResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "6":
                        return; // Kembali ke menu utama
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }



    }
}*/