using ConnectionDb.Models;
using ConnectionDb.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Controllers;

public class LocationController
{
    private Location _location;
    private LocationView _locationView;

    public LocationController(Location location, LocationView locationView)
    {
        _location = location;
        _locationView = locationView;
    }

    public void GetAll()
    {
        var results = _location.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _locationView.List(results, "location");
        }
    }

    public void Insert()
    {
        Location locationInput = _locationView.InsertInput();
        if (locationInput == null)
        {
            Console.WriteLine("Location name cannot be empty");
            return;
        }

        var result = _location.Insert(locationInput);
        _locationView.Transaction(result);
    }


    public void Update()
    {
        var location = new Location();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                location = _locationView.UpdateLocation();
                if (string.IsNullOrEmpty(location.Street_Address))
                {
                    Console.WriteLine("Location name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Update(location);
        _locationView.Transaction(result);
    }
    public void Delete()
    {
        Console.WriteLine("Enter the ID of the Location to delete:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var result = _location.Delete(id);
            _locationView.Transaction(result);
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
        }
    }
}

