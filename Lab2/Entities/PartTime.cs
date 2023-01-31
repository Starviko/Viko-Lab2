using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hour;
        public double Rate { get => rate; }
        public double Hour { get => hour; }
        public PartTime(string id, string name, string address, double rate,double hour)// :base(id,name,address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hour = hour;
        }
    }
}
