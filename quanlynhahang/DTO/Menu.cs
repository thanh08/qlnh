using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Menu
    {
        public Menu (string foodname, int count, float prive,float totalprive = 0 )
        {
        this.Foodname = foodname;
            this.Count = count;
            this.Prive = prive;
            this.Totalprive = totalprive;

        }
        public Menu(DataRow row)
        {
            this.Foodname = row["ten"].ToString();
            this.Count =(int) row["count"];
            this.Prive = (float)Convert.ToDouble(row["price"].ToString());
            this.Totalprive = (float)Convert.ToDouble(row["tonggia"].ToString());
        }
        private string foodname;
        private float totalprive;
        private float prive;

        private int count;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public float Prive
        {
            get
            {
                return prive;
            }

            set
            {
                prive = value;
            }
        }

        public float Totalprive
        {
            get
            {
                return totalprive;
            }

            set
            {
                totalprive = value;
            }
        }

        public string Foodname
        {
            get
            {
                return foodname;
            }

            set
            {
                foodname = value;
            }
        }
    }
}
