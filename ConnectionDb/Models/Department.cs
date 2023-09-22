using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Models
{
    internal class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public int LocationId { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {ManagerId} - {LocationId}";
        }

        public List<Department> GetAll()
        {
            var regions = new List<Department>();

            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_departments";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new Department
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ManagerId = reader.GetInt32(2),
                            LocationId = reader.GetInt32(3)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return regions;
                }
                reader.Close();
                connection.Close();

                return new List<Department>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Department>();
        }

        // GET BY ID: Region
        public Department GetById(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_departments WHERE id =@id";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new Department()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ManagerId = reader.GetInt32(2),
                            LocationId = reader.GetInt32(3)
                        };

                    }
                    reader.Close();
                    connection.Close();

                    return new Department();

                }
                reader.Close();
                connection.Close();

                return new Department();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Department();


        }

        // INSERT: Region
        public string Insert(int id, string name, int managerId, int locationId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_departments VALUES (@id, @name, @managerId, @locationId);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@managerId", managerId));
                command.Parameters.Add(new SqlParameter("@locationId", locationId));

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
        public string Update(int id, string name, int managerId, int locationId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "UPDATE tbl_departments SET name = @name, managerId = @managerId, locationID = @locationId WHERE @id = id";

            try
            {

                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@managerId", managerId));
                command.Parameters.Add(new SqlParameter("@locationId", locationId));

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
            command.CommandText = "DELETE tbl_departments WHERE @id = id";

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
    }
}

