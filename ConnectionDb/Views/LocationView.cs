using ConnectionDb.Models;
using ConnectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConnectionDb.Views;

    public class LocationView : GeneralView
{
    public Location InsertInput()
    {
        Console.WriteLine("Insert Location Id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Street_Address");
        var street = Console.ReadLine();
        Console.WriteLine("Insert Postal_Code");
        var postal = Console.ReadLine();
        Console.WriteLine("Insert City");
        var city = Console.ReadLine();
        Console.WriteLine("Insert State_Province");
        var state = Console.ReadLine();
        Console.WriteLine("Insert Country_Id");
        var countryid = Convert.ToInt32(Console.ReadLine());

        return new Location
        {
            Id = id,
            Street_Address = street,
            Postal_Code = postal,
            City = city,
            State_Province = state,
            Country_Id = countryid
        };
    }

    public Location UpdateLocation()
    {
        Console.WriteLine("Insert Location Id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Street_Address");
        var street = Console.ReadLine();
        Console.WriteLine("Insert Postal_Code");
        var postal = Console.ReadLine();
        Console.WriteLine("Insert City");
        var city = Console.ReadLine();
        Console.WriteLine("Insert State_Province");
        var state = Console.ReadLine();
        Console.WriteLine("Insert Country_Id");
        var countryid = Convert.ToInt32(Console.ReadLine());
        return new Location
        {
            Id = id,
            Street_Address = street,
            Postal_Code = postal,
            City = city,
            State_Province = state,
            Country_Id = countryid
        };
    }

    public Location DeleteLocation()
    {
        Console.WriteLine("Enter the ID of the region to delete:");
        var id = Convert.ToInt32(Console.ReadLine());

        return new Location
        {
            Id = id
        };
    }


}


