using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.Models
{
    public class JobHistory
    {

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }

        public override string ToString()
        {
            return $"{EmployeeId} - {StartDate} - {EndDate} - {DepartmentId} - {JobId}";
        }

        public List<JobHistory> GetAll()
        {
            var regions = new List<JobHistory>();

            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_job_history";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new JobHistory
                        {
                            EmployeeId = reader.GetInt32(0),
                            StartDate = reader.GetDateTime(1),
                            EndDate = reader.GetDateTime(2),
                            DepartmentId = reader.GetInt32(3),
                            JobId = reader.GetInt32(4)

                        });
                    }
                    reader.Close();
                    connection.Close();

                    return regions;
                }
                reader.Close();
                connection.Close();

                return new List<JobHistory>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<JobHistory>();
        }

        // GET BY ID: Region
        public JobHistory GetById(int employeeId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_job_history WHERE id =@id";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", employeeId));

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new JobHistory()
                        {
                            EmployeeId = reader.GetInt32(0),
                            StartDate = reader.GetDateTime(1),
                            EndDate = reader.GetDateTime(2),
                            DepartmentId = reader.GetInt32(3),
                            JobId = reader.GetInt32(4)
                        };

                    }
                    reader.Close();
                    connection.Close();

                    return new JobHistory();

                }
                reader.Close();
                connection.Close();

                return new JobHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new JobHistory();


        }

        // INSERT: Region
        public string Insert(int employeeId, DateTime startDate, DateTime endDate, int departmentId, int jobId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "INSERT INTO tbl_job_history VALUES (@employee_id, @start_date, @end_date, @department_id, @job_id);";

            try
            {
                command.Parameters.Add(new SqlParameter("@employee_id", employeeId));
                command.Parameters.Add(new SqlParameter("@start_date", startDate));
                command.Parameters.Add(new SqlParameter("@end_date", endDate));
                command.Parameters.Add(new SqlParameter("@department_id", departmentId));
                command.Parameters.Add(new SqlParameter("@job_id", jobId));

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
        public string Update(int employeeId, DateTime startDate, DateTime endDate, int departmentId, int jobId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "UPDATE tbl_job_history SET name = @name, employeeId = @employee_id , startDate = @start_date , endDate = @end_date, departmentId = @department_id, jobId = @job_id WHERE @id = id";

            try
            {
                command.Parameters.Add(new SqlParameter("@employee_id", employeeId));
                command.Parameters.Add(new SqlParameter("@start_date", startDate));
                command.Parameters.Add(new SqlParameter("@end_date", endDate));
                command.Parameters.Add(new SqlParameter("@department_id", departmentId));
                command.Parameters.Add(new SqlParameter("@job_id", jobId));

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
        public string Delete(int employeeId)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();


            command.Connection = connection;
            command.CommandText = "DELETE tbl_job_history WHERE @id = employeeId";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", employeeId));

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
