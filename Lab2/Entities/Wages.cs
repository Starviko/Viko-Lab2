using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Wages:Employee
    {
        private double rate;
        private double hour;


        public double Rate { get => rate; }
        public double Hour { get => hour; }

        public Wages(string id, string name, string address,double rate,double hour)// when the fields elements in superclass are private using ":base(id,name,address)"
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hour = hour;
        }
        public double CalcPay()
        {
            double wagePay;
            if (hour <= 40)
            {
                wagePay = rate * hour;
            }
            else
            {
                wagePay = (rate * 40) + rate * (hour % 40 * 1.5);
            }
            return wagePay;
        }
    }
}
