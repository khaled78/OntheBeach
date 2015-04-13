using System;


namespace BusinessObjects
{
    /// <summary>
    /// Class to represent Employee object
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets Salary
        /// </summary>
        public Salary Salary { get; set; }

    }
}
