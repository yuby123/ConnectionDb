using ConnectionDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Views;

public class CountryView : GeneralView
{
        public Country InsertInput()
        {
        Console.WriteLine("Insert Country Id   :");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Country Name :");
        var name = Console.ReadLine();
        Console.WriteLine("Insert Region Id :");
        var IdRegion = Convert.ToInt32(Console.ReadLine());
        return new Country
            {
            Id = id,
            Name = name,
            RegionsId = IdRegion

        };
        }

        public Country UpdateCountry()
        {
            Console.WriteLine("Update Country Id   :");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Update Country Name :");
            var name = Console.ReadLine();
            Console.WriteLine("Update Region Id :");
        var IdRegion = Convert.ToInt32(Console.ReadLine());

        return new Country
            {
                Id = id,
                Name = name,
                RegionsId = IdRegion
        };
        }

        public Country DeleteRegion()
        {
            Console.WriteLine("Enter the ID of the region to delete:");
            var id = Convert.ToInt32(Console.ReadLine());

            return new Country
            {
                Id = id
            };
        }
    }


