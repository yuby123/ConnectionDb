using ConnectionDb;
using ConnectionDB;
using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity;

public class Program
{
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. List all countries");
            Console.WriteLine("3. List all locations");
            Console.WriteLine("4. List all departemens");
            Console.WriteLine("5. List all jobs");
            Console.WriteLine("6. List all jobhistorys");
            Console.WriteLine("7. List all employees");
            Console.WriteLine("8. join soal 1");
            Console.WriteLine("9. join soal 2");
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
                var region = new Region();
                var regions = region.GetAll();
                GeneralMenu.List(regions, "regions");
                break;
            case "2":
                var country = new Country();
                var countries = country.GetAll();
                GeneralMenu.List(countries, "countries");
                break;
            case "3":
                var location = new Location();
                var locations = location.GetAll();
                GeneralMenu.List(locations, "locations");
                break;
            case "4":
                var departemen = new Department();
                var departemens = departemen.GetAll();
                GeneralMenu.List(departemens, "departemens");
                break;
            case "5":
                var job = new Job();
                var jobs = job.GetAll();
                GeneralMenu.List(jobs, "jobs");
                break;
            case "6":
                var jobhistory = new Department();
                var jobhistorys = jobhistory.GetAll();
                GeneralMenu.List(jobhistorys, "jobhistorys");
                break;

            case "7":
                var employee = new Employees();
                var employees = employee.GetAll();
                GeneralMenu.List(employees, "employees");
                break;

            case "8":
                var employee1 = new Employees();
                var employees1 = employee1.GetJoin();
                GeneralMenu.List(employees1, "soal 1");
                break;

            case "9":
                var employee2 = new Employees();
                var employees2 = employee2.GetJoin3();
                GeneralMenu.List(employees2, "soal 2");
                break;

            case "10":
                return false;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }
}