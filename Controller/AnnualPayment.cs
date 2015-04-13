using System;
using System.Collections.Generic;
using BusinessObjects;
using Data;

namespace Controller
{
    /// <summary>
    /// Class to represent Annual Payment
    /// </summary>
    public class AnnualPayment
    {
        /// <summary>
        /// Field to store the connection string
        /// </summary>
        private string connectionString = string.Empty;

        /// <summary>
        /// Constructor with Connection string
        /// </summary>
        /// <param name="connectionString">Connection String for the database</param>
        public AnnualPayment(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Employee> AnnualPayment_ByEmployee(string Name)
        {
            AnnualPaymentRepository Ap = new AnnualPaymentRepository(this.connectionString);
            return Ap.RetrieveEmployeePayment(Name);
        }

        public List<Employee> LisOfStaffLevel()
        {
            AnnualPaymentRepository Ap = new AnnualPaymentRepository(this.connectionString);
            return Ap.RetrieveStaffLevel();
        }

    }
}
