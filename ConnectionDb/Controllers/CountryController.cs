using ConnectionDb.Models;
using ConnectionDb.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Controllers;

public class CountryController
{
    private Country _country;
    private CountryView _countryView;

    public CountryController(Country country, CountryView countryView)
    {
        _country = country;
        _countryView = countryView;
    }

    public void GetAll()
    {
        var results = _country.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _countryView.List(results, "Countrys");
        }
    }

    public void Insert()
    {
        Country countryInput = _countryView.InsertInput();
        if (countryInput == null)
        {
            Console.WriteLine("Country name cannot be empty");
            return;
        }

        var result = _country.Insert(countryInput);
        _countryView.Transaction(result);
    }


    public void Update()
    {
        var country = new Country();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                country = _countryView.UpdateCountry();
                if (string.IsNullOrEmpty(country.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Update(country);
        _countryView.Transaction(result);
    }
    public void Delete()
    {
        Console.WriteLine("Enter the ID of the Country to delete:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var result = _country.Delete(id);
            _countryView.Transaction(result);
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
        }
    }
}

