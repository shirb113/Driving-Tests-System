using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Address
    {
        /// <summary>
        /// Street - רחוב
        /// HouseNumber - מספר בית
        /// City - עיר
        /// </summary>
        /// 
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        

        public Address() { }
        public Address(string c, string s, int hn)
        {
            City = c;
            Street = s;
            HouseNumber = hn;
        }
        public Address(Address add)
        {
            City = add.City;
            Street = add.Street;
            HouseNumber = add.HouseNumber;
        }
        public override string ToString()
        {
            string str = "";
            str += City + "," + Street + "," + HouseNumber;
            return str;
        }
        public static Address Parse (string s)
        {
            Address myAddress = new Address();
            string[] values = s.Split(',');
            myAddress = new Address(values[0], values[1], int.Parse(values[2]));
            return myAddress;
        }
            
    }
}


