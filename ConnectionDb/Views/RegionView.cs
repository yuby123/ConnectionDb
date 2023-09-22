using ConnectionDb.Models;
using ConnectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Views
{
    public class RegionView : GeneralView
    {

        public Region InsertInput()
        {
            Console.WriteLine("Insert Region Id");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Region Name");
            var name = Console.ReadLine();
            return new Region
            {
                Id = id,
                Name = name
            };
        }

        public Region UpdateRegion()
        {
            Console.WriteLine("Insert Region Id   :");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Region Name :");
            var name = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = name
            };
        }

        public Region DeleteRegion()
        {
            Console.WriteLine("Enter the ID of the region to delete:");
            var id = Convert.ToInt32(Console.ReadLine());

            return new Region
            {
                Id = id
            };
        }


    }
}