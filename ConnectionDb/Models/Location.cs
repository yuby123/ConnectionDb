using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionDb.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Street_Address { get; set; }
        public string Postal_Code { get; set; }
        public string City { get; set; }
        public string State_Province { get; set; }
        public int Country_Id { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Street_Address} - {Postal_Code} - {City} - {State_Province} - {Country_Id}";
        }
        // CREATE: Location
        public string Insert(Location location)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_locations VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", location.Id));
                command.Parameters.Add(new SqlParameter("@street_address", location.Street_Address));
                command.Parameters.Add(new SqlParameter("@postal_code", location.Postal_Code));
                command.Parameters.Add(new SqlParameter("@city", location.City));
                command.Parameters.Add(new SqlParameter("@state_province", location.State_Province));
                command.Parameters.Add(new SqlParameter("@country_id", location.Country_Id));

                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();

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

        // READ: All Locations
        public List<Location> GetAll()
        {
            var locations = new List<Location>();

            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_locations";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        locations.Add(new Location
                        {
                            Id = reader.GetInt32(0),
                            Street_Address = reader.GetString(1),
                            Postal_Code = reader.GetString(2),
                            City = reader.GetString(3),
                            State_Province = reader.GetString(4),
                            Country_Id = reader.GetInt32(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return locations;
        }

        // READ: Location by ID
        public Location GetById(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "SELECT Id, Street_Address, Postal_Code, City, State_Province, Country_Id FROM tbl_locations WHERE Id = @id;";
            command.Parameters.Add(new SqlParameter("@id", id));

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    int locationId = reader.GetInt32(0);
                    string streetAddress = reader.GetString(1);
                    string postalCode = reader.GetString(2);
                    string city = reader.GetString(3);
                    string stateProvince = reader.GetString(4);
                    int countryId = reader.GetInt32(5);

                    Location location = new Location
                    {
                        Id = locationId,
                        Street_Address = streetAddress,
                        Postal_Code = postalCode,
                        City = city,
                        State_Province = stateProvince,
                        Country_Id = countryId
                    };

                    return location;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // UPDATE: Location
        public string Update(Location location)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "UPDATE tbl_locations SET Street_Address = @street_address, Postal_Code = @postal_code, City = @city, State_Province = @state_province, Country_Id = @country_id WHERE Id = @id;";
            command.Parameters.Add(new SqlParameter("@id", location.Id));
            command.Parameters.Add(new SqlParameter("@street_address", location.Street_Address));
            command.Parameters.Add(new SqlParameter("@postal_code", location.Postal_Code));
            command.Parameters.Add(new SqlParameter("@city", location.City));
            command.Parameters.Add(new SqlParameter("@state_province", location.State_Province));
            command.Parameters.Add(new SqlParameter("@country_id", location.Country_Id));

            try
            {
                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();

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

        // DELETE: Location
        public string Delete(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "DELETE FROM tbl_locations WHERE Id = @id;";
            command.Parameters.Add(new SqlParameter("@id", id));

            try
            {
                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();

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
    }
}
