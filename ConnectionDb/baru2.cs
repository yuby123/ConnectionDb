/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb
{
    internal class baru2
    {
   
        
            static void Main3(string[] args)
            {
                var regionManager = new EntityManager<Region>();
                var countryManager = new EntityManager<Country>();
                var locationManager = new EntityManager<Location>();
                var jobManager = new EntityManager<Job>();

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
                            regionManager.ManageEntities();
                            break;
                        case "2":
                            countryManager.ManageEntities();
                            break;
                        case "3":
                            locationManager.ManageEntities();
                            break;
                        case "4":
                            jobManager.ManageEntities();
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
        }

        class EntityManager<T> where T : IDbEntity, new()
        {
            private readonly List<T> entities = new List<T>();

            public void ManageEntities()
            {
                while (true)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. CREATE");
                    Console.WriteLine("2. READ All");
                    Console.WriteLine("3. READ by ID");
                    Console.WriteLine("4. UPDATE");
                    Console.WriteLine("5. DELETE");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice (1-6): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Enter data:");
                            T newEntity = InputEntityData();
                            entities.Add(newEntity);
                            Console.WriteLine("CREATE Result: Success");
                            break;

                        case "2":
                            Console.WriteLine($"READ All {typeof(T).Name}s:");
                            foreach (var e in entities)
                            {
                                Console.WriteLine(e.ToString());
                            }
                            break;

                        case "3":
                            Console.Write("Enter ID to fetch: ");
                            int idToFetch = int.Parse(Console.ReadLine());
                            T retrievedEntity = entities.FirstOrDefault(e => e.Id == idToFetch);
                            if (retrievedEntity != null)
                            {
                                Console.WriteLine($"READ {typeof(T).Name} by ID:");
                                Console.WriteLine(retrievedEntity.ToString());
                            }
                            else
                            {
                                Console.WriteLine($"{typeof(T).Name} not found.");
                            }
                            break;

                        case "4":
                            Console.Write("Enter ID to update: ");
                            int idToUpdate = int.Parse(Console.ReadLine());
                            T updatedEntity = InputEntityData();
                            int indexToUpdate = entities.FindIndex(e => e.Id == idToUpdate);
                            if (indexToUpdate != -1)
                            {
                                entities[indexToUpdate] = updatedEntity;
                                Console.WriteLine("UPDATE Result: Success");
                            }
                            else
                            {
                                Console.WriteLine($"{typeof(T).Name} not found.");
                            }
                            break;

                        case "5":
                            Console.Write("Enter ID to delete: ");
                            int idToDelete = int.Parse(Console.ReadLine());
                            int indexToDelete = entities.FindIndex(e => e.Id == idToDelete);
                            if (indexToDelete != -1)
                            {
                                entities.RemoveAt(indexToDelete);
                                Console.WriteLine("DELETE Result: Success");
                            }
                            else
                            {
                                Console.WriteLine($"{typeof(T).Name} not found.");
                            }
                            break;

                        case "6":
                            return; // Keluar dari menu ini
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-6).");
                            break;
                    }
                }
            }

            private T InputEntityData()
            {
                // Implementasi input data sesuai dengan atribut entitas T
                // Anda dapat menambahkan logika input sesuai dengan jenis entitas yang dikelola
                // Misalnya, input atribut Region, Country, dsb.
                // Kemudian, buat objek T dengan data yang diinputkan
                // Return objek T yang baru dibuat

                T newEntity = new T();

                Console.Write("Enter ID: ");
                newEntity.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                newEntity.Name = Console.ReadLine();

                return newEntity;
            }
        }

        // Interface IDbEntity dan implementasi sederhana Region, Country, Location, dan Job
        interface IDbEntity
        {
            int Id { get; set; }
            string Name { get; set; }
        }

        *//*    class Region : IDbEntity
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }*//*

        class Country : IDbEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Location : IDbEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Job : IDbEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
*/