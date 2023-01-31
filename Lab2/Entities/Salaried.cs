using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Salaried : Employee
    {
        private double salary;
        public double Salary { get => salary; }
        
        public Salaried(string id, string name, string address, double salary)// :base(id,name,address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
        }
    }
}
