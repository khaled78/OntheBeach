using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BusinessObjects;
using Controller;

namespace MainApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                /// search by employee name and returns them how much we're paying in the employees local currency, and
                ///of course in GBP.
                AnnualPayment AP = PaymentsByEmployee();

                //display a list of the staff level employees
                StaffLevelList(AP);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured. Exception : " + ex.Message + Environment.NewLine + "Stack Trace : " + ex.StackTrace);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// display a list of the staff level employees in order of who is paid the most.
        /// </summary>
        private static void StaffLevelList(AnnualPayment AP)
        {
            Console.WriteLine("\n List of the staff level employees in order of who is paid the most Y/N \n \n");

            var response = Console.ReadLine();
            if (response == "y" || response == "Y")
            {
                var stafflist = AP.LisOfStaffLevel();
                if (stafflist.Any())
                {
                    stafflist.ToList().ForEach(e =>
                    {
                        Console.WriteLine("\n \n Emp Name  | Role Name | Unit | Amount | Amount In GBP \n {0} | {1} | {2} |{3} |{4} ", e.Name, e.Role.Name, e.Salary.Unit, e.Salary.AnnualAmount.ToString(), e.Salary.AmountGBP.ToString());
                    });
                }
                else
                {
                    Console.Write("Can't find Employee.");
                }
            }
        }

        /// <summary>
        /// search by employee name and returns how much paying in the employees local currency, and
        ///of course in GBP.
        /// </summary>
        private static AnnualPayment PaymentsByEmployee()
        {
            // Setup Connection
            string connectionString = ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"].ConnectionString;
            AnnualPayment AP = new AnnualPayment(connectionString);
            Console.WriteLine("Enter Employee Name");
            var name = Console.ReadLine();
            var employees = AP.AnnualPayment_ByEmployee(name);
            if (employees.Any())
            {
                employees.ToList().ForEach(e =>
                {
                    Console.WriteLine("Emp Name | Unit | Amount | Amount In GBP \n \n {0} | {1} | {2} |{3} ", e.Name, e.Salary.Unit, e.Salary.AnnualAmount.ToString(), e.Salary.AmountGBP.ToString());
                });
            }
            else
            {
                Console.WriteLine("Can't find Employee.");
            }
            return AP;
        }
    }
}
