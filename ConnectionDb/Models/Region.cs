using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConnectionDb.Models;
public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
    // GET ALL: Region
    public List<Region> GetAll()
    {
        var regions = new List<Region>();

        using var connection = Provider.GetConnection();
        using var command = Provider.GetCommand();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_regions";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regions.Add(new Region
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
                connection.Close();

                return regions;
            }
            reader.Close();
            connection.Close();

            return new List<Region>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return new List<Region>();
    }

    // GET BY ID: Region
    public Region GetById(int id)
    {
        using var connection = Provider.GetConnection();
        using var command = Provider.GetCommand();

        command.Connection = connection;
        command.CommandText = "SELECT Id, Name FROM tbl_regions WHERE Id = @id;";
        command.Parameters.Add(new SqlParameter("@id", id));

        try
        {
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                int regionId = reader.GetInt32(0);
                string regionName = reader.GetString(1);

                // Buat objek Region berdasarkan hasil query
                Region region = new Region
                {
                    Id = regionId,
                    Name = regionName
                };

                return region;
            }
            else
            {
                // Tidak ada data yang sesuai dengan ID, kembalikan null atau throw exception sesuai kebutuhan Anda
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            // Tangani pengecualian sesuai kebutuhan Anda, misalnya lempar kembali pengecualian
            throw;
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }



    // INSERT: Region
    public string Insert(Region region)
    {
        using var connection = Provider.GetConnection();
        using var command = Provider.GetCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_regions VALUES (@id, @name);";

        try
        {
            command.Parameters.Add(new SqlParameter("@id", region.Id));
            command.Parameters.Add(new SqlParameter("@name", region.Name));

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
    public string Update(Region region)
    {
        using var connection = Provider.GetConnection();
        using var command = Provider.GetCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_regions SET name = @name WHERE @id = id";

        try
        {
            command.Parameters.Add(new SqlParameter("@id", region.Id));
            command.Parameters.Add(new SqlParameter("@name", region.Name));

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
        command.CommandText = "DELETE FROM tbl_regions WHERE Id = @id;";
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