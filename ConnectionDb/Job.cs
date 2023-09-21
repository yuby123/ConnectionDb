using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionDb
{
    public class Job
    {
        public int Id { get; set; }
        public string Job_Title { get; set; }
        public decimal Min_Salary { get; set; }
        public decimal Max_Salary { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Job_Title} - {Min_Salary} - {Max_Salary}";
        }

        // CREATE: Job
        public string Create(int id, string job_title, decimal min_salary, decimal max_salary)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_jobs (Id, Job_Title, Min_Salary, Max_Salary) VALUES (@id, @job_title, @min_salary, @max_salary);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@job_title", job_title));
                command.Parameters.Add(new SqlParameter("@min_salary", min_salary));
                command.Parameters.Add(new SqlParameter("@max_salary", max_salary));

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

        // READ: All Jobs
        public List<Job> GetAll()
        {
            var jobs = new List<Job>();

            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_jobs";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        jobs.Add(new Job
                        {
                            Id = reader.GetInt32(0),
                            Job_Title = reader.GetString(1),
                            Min_Salary = reader.GetInt32(2),
                            Max_Salary = reader.GetInt32(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return jobs;
        }

        // READ: Job by ID
        public Job GetById(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "SELECT Id, Job_Title, Min_Salary, Max_Salary FROM tbl_jobs WHERE Id = @id;";
            command.Parameters.Add(new SqlParameter("@id", id));

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    int jobId = reader.GetInt32(0);
                    string jobTitle = reader.GetString(1);
                    decimal minSalary = reader.GetInt32(2);
                    decimal maxSalary = reader.GetInt32(3);

                    Job job = new Job
                    {
                        Id = jobId,
                        Job_Title = jobTitle,
                        Min_Salary = minSalary,
                        Max_Salary = maxSalary
                    };

                    return job;
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

        // UPDATE: Job
        public string Update(int id, string job_title, decimal min_salary, decimal max_salary)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "UPDATE tbl_jobs SET Job_Title = @job_title, Min_Salary = @min_salary, Max_Salary = @max_salary WHERE Id = @id;";
            command.Parameters.Add(new SqlParameter("@id", id));
            command.Parameters.Add(new SqlParameter("@job_title", job_title));
            command.Parameters.Add(new SqlParameter("@min_salary", min_salary));
            command.Parameters.Add(new SqlParameter("@max_salary", max_salary));

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

        // DELETE: Job
        public string Delete(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "DELETE FROM tbl_jobs WHERE Id = @id;";
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
