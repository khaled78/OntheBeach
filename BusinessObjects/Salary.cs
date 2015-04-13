using System;

namespace BusinessObjects
{
    /// <summary>
    /// Class to represent Salary object
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Gets or sets Salary in local currency
        /// </summary>
        public Currency SalaryIn { get; set; }

        /// <summary>
        /// Gets or sets Annual salary
        /// </summary>
        public long AnnualAmount { get; set; }

        /// <summary>
        /// Gets or sets Annual salary in GBP
        /// </summary>
        public double AmountGBP { get; set; }

        /// <summary>
        /// Gets or sets the local currency 
        /// </summary>
        public string Unit { get; set; }
    }
}
