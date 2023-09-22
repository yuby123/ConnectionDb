using ConnectionDb.Controllers;
using ConnectionDb.Models;
using ConnectionDb.Views;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConnectionDb;

class Program
{
   
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. Regions CRUD");
            Console.WriteLine("2. Country CRUD");
            Console.WriteLine("3. Location CRUD");
            Console.WriteLine("4. List all Job");
            Console.WriteLine("5. List all Job History");
            Console.WriteLine("6. List all Employees");
            Console.WriteLine("7. List all Departments");
            Console.WriteLine("8. Join EmpolyeeDkk");
            Console.WriteLine("9. Join Employee dan Dept");
            Console.WriteLine("10. Exit");

            Console.Write("Enter your choice: ");


            var input = Console.ReadLine();
            choice = Menu(input);
        }

    }

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                //var manageDatabase = new ManageDatabase();
                //var regions = manageDatabase.GetAll("tbl_regions");
                var manageDatabase = new Region();
                var regions = manageDatabase.GetAll();
                RegionMenu();


                break;
            case "2":
                var country = new Country();
                var countries = country.GetAll();
                CountryMenu();
                //GeneralMenu.List(countries, "countries");
                break;
            case "3":
                var location = new Location();
                var locations = location.GetAll();
                // GeneralMenu.List(locations, "locations");
                LocationMenu();
                break;

            case "4":
                var job = new Job();
                var jobs = job.GetAll();
                //GeneralMenu.List(jobs, "Job");
                break;

            case "5":
                var jobHis = new JobHistory();
                var jobHist = jobHis.GetAll();
                //GeneralMenu.List(jobHist, "JobHistory");
                break;

            case "6":
                var employees = new Employees();
                var emp = employees.GetAll();
                // GeneralMenu.List(emp, "Employees");
                break;

            case "7":
                var departments = new Department();
                var dept = departments.GetAll();
                //GeneralMenu.List(dept, "Departments");
                break;
            case "8":
                var join = new Employees();
                var joins = join.GetJoin();
                //GeneralMenu.List(joins, "Join ");
                break;
            case "9":
                var join1 = new Employees();
                var joins1 = join1.GetJoin3();
                //GeneralMenu.List(joins1, "Join ");
                break;
            case "10":
                return false;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }

    public static void RegionMenu()
    {
        var region = new Region();
        var regionView = new RegionView();

        var regionController = new RegionController(region, regionView);

        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. Insert new region");
            Console.WriteLine("3. Update region");
            Console.WriteLine("4. Delete region");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    regionController.GetAll();
                    break;
                case "2":
                    regionController.Insert();
                    break;
                case "3":
                    regionController.Update();
                    break;
                case "4":
                    regionController.Delete();
                    break;
                case "10":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void CountryMenu()
    {
        var country = new Country();
        var countryView = new CountryView();

        var countryController = new CountryController(country, countryView);

        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("1. List all country");
            Console.WriteLine("2. Insert new country");
            Console.WriteLine("3. Update country");
            Console.WriteLine("4. Delete country");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    countryController.GetAll();
                    break;
                case "2":
                    countryController.Insert();
                    break;
                case "3":
                    countryController.Update();
                    break;
                case "4":
                    countryController.Delete();
                    break;
                case "10":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
    public static void LocationMenu()
    {
        var location = new Location();
        var locationView = new LocationView();

        var locationController = new LocationController(location, locationView);

        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("1. List all location");
            Console.WriteLine("2. Insert new location");
            Console.WriteLine("3. Update location");
            Console.WriteLine("4. Delete location");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    locationController.GetAll();
                    break;
                case "2":
                    locationController.Insert();
                    break;
                case "3":
                    locationController.Update();
                    break;
                case "4":
                    locationController.Delete();
                    break;
                case "10":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}






