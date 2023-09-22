using ConnectionDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionsId { get; set; }

        public static Country country = new Country();

        public override string ToString()
        {
            return $"{Id} - {Name} - {RegionsId}";
        }

        public List<Country> GetAll()
        {
            var regions = new List<Country>();

            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_countries";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new Country
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            RegionsId = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return regions;
                }
                reader.Close();
                connection.Close();

                return new List<Country>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Country>();
        }

        // GET BY ID: Region
        public Country GetById(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_countries WHERE id =@id";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new Country()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            RegionsId = reader.GetInt32(2)

                        };

                    }
                    reader.Close();
                    connection.Close();

                    return new Country();

                }
                reader.Close();
                connection.Close();

                return new Country();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Country();


        }

        // INSERT: Region
        public string Insert(Country country)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_countries VALUES (@id, @name, @regionsid);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", country.Id));
                command.Parameters.Add(new SqlParameter("@name", country.Name));
                command.Parameters.Add(new SqlParameter("@regionsid", country.RegionsId));

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // UPDATE: Region
        public string Update(Country country)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "UPDATE tbl_countries SET name = @name, regions_id = @regions_id  WHERE @id = id";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", country.Id));
                command.Parameters.Add(new SqlParameter("@name", country.Name));
                command.Parameters.Add(new SqlParameter("@regions_id", country.RegionsId));

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }

        }

        // DELETE: Region
        public string Delete(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "DELETE tbl_countries WHERE @id = id";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }


        }
        public void View()
        {
            var getAllRegion = GetAll();

            if (getAllRegion.Count > 0)
            {
                foreach (var region1 in getAllRegion)
                {
                    Console.WriteLine($"Id: {region1.Id}, Name: {region1.Name}, Regions Id : {region1.RegionsId}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

    }
}
