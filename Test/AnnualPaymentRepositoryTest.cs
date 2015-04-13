using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using BusinessObjects;
using System.Configuration;
using System.Collections.Generic;
namespace Test
{
    [TestClass]
    public class AnnualPaymentRepositoryTest
    {
        //Test to Retrive empolyment payment In GBP 
        [TestMethod]
        [Priority(0)]
        [TestCategory("Happy Path")]
        public void ReterviewEmploymentPayment()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"].ConnectionString;
            var AP = new AnnualPaymentRepository(connectionString);
            var e = new Employee()
           {
               Name = "khaled",
               Salary = new Salary
               {
                   Unit = "Credits",
                   AnnualAmount = 5000000000,
                   AmountGBP = 40000000000000

               }
           };


            var actual = AP.RetrieveEmployeePayment("khaled");
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"]);
            foreach (var i in actual)
            {
                Assert.AreEqual(e.Name, i.Name);
                Assert.AreEqual(e.Salary.Unit, i.Salary.Unit);
                Assert.AreEqual(e.Salary.AnnualAmount, i.Salary.AnnualAmount);
                Assert.AreEqual(e.Salary.AmountGBP, i.Salary.AmountGBP);
            }

        }
        // Testing Database Connection
        [TestMethod]
        public void VerifyThatMyDatabaseConnectionStringExists()
        {
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"]);
        }

        // Test to Staff Level Based on payment

        [TestMethod]
        [Priority(0)]
        [TestCategory("Happy Path")]
        public void ReterviewStaffLevelList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"].ConnectionString;
            var AP = new AnnualPaymentRepository(connectionString);
            List<Employee> expected = new List<Employee>
            {
                new Employee(){Name="khaled",
                 Role=new Role{Name="Owner"},
                 Salary=new Salary{AnnualAmount=5000000000,Unit="Credits",AmountGBP=40000000000000}
                },
                new Employee(){
                    Name="Fred Flintstone",
                 Role=new Role{Name="Manager"},
                 Salary=new Salary{AnnualAmount=900000,Unit="Rocks",AmountGBP=9000000}
                },
                new Employee(){
                    Name="Sterling Archer",
                 Role=new Role{Name="Staff"},
                 Salary=new Salary{AnnualAmount=150000,Unit="USD",AmountGBP=231000}
                },
                new Employee(){
                    Name="Eric Cartman",
                 Role=new Role{Name="Staff"},
                 Salary=new Salary{AnnualAmount=60000,Unit="Sweets",AmountGBP=720000}
                },
                new Employee(){
                    Name="Homer Simpson",
                 Role=new Role{Name="Staff"},
                 Salary=new Salary{AnnualAmount=22000,Unit="USD",AmountGBP=33880}
                }
            };


            List<Employee> actual = AP.RetrieveStaffLevel();

            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["MainApplication.Properties.Settings.Connectionstr"]);
            // CollectionAssert.AreEqual(expected,actual); 


            for (int i = 0; i < expected.Count - 1; i++)
            {

                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Role.Name, actual[i].Role.Name);
                Assert.AreEqual(expected[i].Salary.AnnualAmount, actual[i].Salary.AnnualAmount);
                Assert.AreEqual(expected[i].Salary.Unit, actual[i].Salary.Unit);
                Assert.AreEqual(expected[i].Salary.AmountGBP, actual[i].Salary.AmountGBP);
            }


        }


    }
}
