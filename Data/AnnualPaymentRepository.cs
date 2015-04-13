using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Class to represent Annual Payment Repository
    /// </summary>
    public class AnnualPaymentRepository
    {
        /// <summary>
        /// Field to store the connection String
        /// </summary>
        private string connectionString = string.Empty;

        /// <summary>
        /// Constructor with connection string
        /// </summary>
        /// <param name="connectionString">Connection String to database</param>
        public AnnualPaymentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// search by employee name and return how much paying in the employees local currency, and
        ///of course in GBP.
        /// </summary>
        #region retrive Payment in GBP
        public IList<Employee> RetrieveEmployeePayment(String Name)
        {
            // Create the instance of the Employee class
            var employees = new List<Employee>();

            // Code that retrieves how much paying in the employees local currency,and of course in GBP
            // for the employee.
            try
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    // create a command object identifying
                    // the stored procedure
                    var command = new SqlCommand("AnnualAmountRetrieve_GBP", connection);

                    // set the command object so it knows
                    // to execute a stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    //add parameter to command, which
                    // will be passed to the stored procedure
                    command.Parameters.AddWithValue("@name", Name);

                    // Open the connection
                    connection.Open();

                    // Get the data reader
                    SqlDataReader rdr = command.ExecuteReader();

                    // Process each result
                    while (rdr.Read())
                    {
                        var e = new Employee
                        {
                            Name = rdr["name"].ToString(),
                            Salary = new Salary
                            {
                                Unit = rdr["unit"].ToString(),
                                AnnualAmount = Convert.ToInt64(rdr["Annual_Amount"]),
                                AmountGBP = Convert.ToDouble(rdr["Amount In GBP"])
                            }
                        };

                        employees.Add(e);
                    }
                }
            }
            catch (Exception ex)
            {
                // Print error message;
                throw ex;
            }
            return employees;

        }
        #endregion

        /// <summary>
        /// display a list of the staff level employees in order of who is paid the most.
        /// </summary>
        public List<Employee> RetrieveStaffLevel()
        {
            // Create the instance of the Employee class
            var employees = new List<Employee>();

            // Code that display a list of the staff level employees in order of who is paid the most

            using (var connection = new SqlConnection(this.connectionString))
            {
                // set the command object so it knows
                // to execute a stored procedure
                var command = new SqlCommand("StaffLevel", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Open the connection
                connection.Open();

                // Get the data reader
                SqlDataReader rdr = command.ExecuteReader();

                // Process each result
                while (rdr.Read())
                {
                    var e = new Employee
                    {
                        Name = rdr["Employee Name"].ToString(),
                        Role = new Role
                        {
                            Name = rdr["Role Name"].ToString()
                        },
                        Salary = new Salary
                        {
                            Unit = rdr["Currencies"].ToString(),
                            AnnualAmount = Convert.ToInt64(rdr["Annual Salary"]),
                            AmountGBP = Convert.ToDouble(rdr["Amount In GBP"])
                        }

                    };
                    employees.Add(e);
                }
                return employees;
            }
        }
    }
}
