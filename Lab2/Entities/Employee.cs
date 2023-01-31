using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;

        public string Id { get { return id; } } //this same as {get => id;}
        public string Name { get { return name; } }
        public string Address { get { return address; } }
        public Employee()
        { }
        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            
        }
    }
}
