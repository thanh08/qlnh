using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Monan
    {
        public Monan( int id,string ten, int iddanhmuc, float price)
        {
            this.Id = id;
            this.Ten = ten;
            this.Iddanhmuc = iddanhmuc;
            this.Price = price;
        }
        public Monan(DataRow row)
        {
            this.id = (int)row ["id"];
            this.Ten = row["ten"].ToString();
            this.Iddanhmuc = (int)row["iddanhmuc"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int id;
        private string ten;
        private int iddanhmuc;
        private float price;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        public int Iddanhmuc
        {
            get
            {
                return iddanhmuc;
            }

            set
            {
                iddanhmuc = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
