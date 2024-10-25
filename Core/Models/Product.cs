using Core.Helpers.Exceptions;
using Core.Helpers.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product
    {

        static int no = 1;
        public int No { get; set; }
        public string Name { get; set; }
        public Types Type { get; set; }
        private double _price;

        public Product( string name, double price, Types type)
        {
            No = no++;
            Name = name;
            _price = price;
            Type = type;
        }





        public double Price
        {
            get { return Price; }
            set
            {
                if (value < 0)
                {
                    throw new PriceMustBeGratherThanZeroException("Productun price deyeri menfi ola bilmez. ");
                }
            }
        }
    }
}