using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourlyCheck.model
{
    public class Hc
    {
        public int Id { get; set; }
        DateTime dt = new DateTime();
        public DateTime Dt {
            get { return dt; }
            set { dt = value; }
        }
        public string Initials { get; set; }
        int tc = 0;

        public int Tc {
            get
            {
                return tc;
            }
            set
            {
                tc = value;
            } 
        }
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string H3 { get; set; }
        public string H4 { get; set; }
        public string H5 { get; set; }
        public string H6 { get; set; }
        public string H7 { get; set; }
        public string H8 { get; set; }
        public string H9 { get; set; }
        public string H10 { get; set; }
        public string H11 { get; set; }
        public string H12 { get; set; }
        public string H13 { get; set; }
        public string H14 { get; set; }
        public string H15 { get; set; }
        public string H16 { get; set; }
        public string H17 { get; set; }
        public string H18 { get; set; }
        public string H19 { get; set; }
        public string H20 { get; set; }
        public string H21 { get; set; }
        public string H22 { get; set; }
        public string H23 { get; set; }
        public string H24 { get; set; }
    }
}
