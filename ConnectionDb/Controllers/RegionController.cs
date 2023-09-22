using ConnectionDb.Models;
using ConnectionDb.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Controllers;

public class RegionController
{
    private Region _region;
    private RegionView _regionView;

    public RegionController(Region region, RegionView regionView)
    {
        _region = region;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var results = _region.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _regionView.List(results, "regions");
        }
    }

    public void Insert()
    {
        Region regionInput = _regionView.InsertInput();
        if (regionInput == null || string.IsNullOrEmpty(regionInput.Name))
        {
            Console.WriteLine("Region name cannot be empty");
            return;
        }

        var result = _region.Insert(regionInput);
        _regionView.Transaction(result);
    }


    public void Update()
    {
        var region = new Region();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                region = _regionView.UpdateRegion();
                if (string.IsNullOrEmpty(region.Name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Update(region);
        _regionView.Transaction(result);
    }
    public void Delete()
    {
        Console.WriteLine("Enter the ID of the region to delete:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var result = _region.Delete(id);
            _regionView.Transaction(result);
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
        }
    }

}



