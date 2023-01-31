using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Entities;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "employees.txt";
            string[] lines= File.ReadAllLines(path);
            List<Employee> employees = new List<Employee>();

            double salarySum = 0;
            double wagePaySum = 0;
            double parttimePaySum = 0;
            double salariedCount = 0; // to hold the salaried employee number
            double wageCount = 0;  // to hold the wage employee number
            double partTimeCount = 0; // to hold the part-time employee number

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                string id = parts[0];
                string name = parts[1];
                string address = parts[2];
                


                string firstDigit = id.Substring(0, 1);
                int firstDigitNum = int.Parse(firstDigit);
                if(firstDigitNum>=0 && firstDigitNum<=4)
                {
                    double salary = double.Parse(parts[7]);
                    Salaried salaried = new Salaried(id, name, address, salary); 
                    employees.Add(salaried);
                    salarySum += salary;
                }
                else if(firstDigitNum>=5 && firstDigitNum<=7)
                {
                    double rate = double.Parse(parts[7]);
                    double hour = double.Parse(parts[8]);
                    Wages wages = new Wages(id, name, address, rate, hour);
                    employees.Add(wages);          
                    double pay = wages.CalcPay();
                    wagePaySum += pay;
                }
                else if(firstDigitNum>=8 && firstDigitNum<=9) 
                {
                    double rate = double.Parse(parts[7]);
                    double hour = double.Parse(parts[8]);
                    PartTime partTime = new PartTime(id, name, address, rate, hour);
                    employees.Add(partTime);
                    parttimePaySum += rate * hour;

                }                                
            }
            double averageSalary = (salarySum + wagePaySum + parttimePaySum) / employees.Count;
            Console.WriteLine(string.Format("The average weekly pay is: ${0:N2}",averageSalary));       

            double highestWagePay = 0;
            Employee highestWageEmployee = null;
            double lowestSalary = double.MaxValue;
            Employee lowestSalaryEmployee = null;   
            foreach(Employee employee in employees)
            {
                if(employee is Wages wages)
                {
                    double pay = wages.CalcPay();
                    if (pay > highestWagePay) 
                    { 
                        highestWagePay = pay;
                        highestWageEmployee= employee;
                    }
                    wageCount++;
                }
                if(employee is Salaried salaried)
                {
                    double salary = salaried.Salary;
                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        lowestSalaryEmployee = employee;
                    }
                    salariedCount++;
                }
                if(employee is PartTime partTime)
                {
                    partTimeCount++;
                }
            }
            double salariedPercentage = salariedCount/ employees.Count;
            double wagePercentage = wageCount/ employees.Count;
            double partTimePercentage = partTimeCount/ employees.Count;

            Console.WriteLine("The highest weekly wage pay is:$ "+highestWagePay);
            Console.WriteLine("The highest weekly wage paied employee is "+highestWageEmployee.Name);
            Console.WriteLine("The lowest salary is:$ " + lowestSalary);
            Console.WriteLine("The lowest salaried employee is "+lowestSalaryEmployee.Name);

            Console.WriteLine(string.Format("The salaried employee percentage is: {0:p2}", salariedPercentage));
            Console.WriteLine(string.Format("The wage employee percentage is: {0:p2}", wagePercentage));
            Console.WriteLine(string.Format("The part-time employee percentage is: {0:p2}", partTimePercentage));
        }
    }
}
