using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Danhmuc
    {

        public Danhmuc(int Id,string ten)
        {
            this.Id = id;
            this.Ten = ten;
        }
        public Danhmuc(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Ten = row["ten"].ToString();

        }
        private int id;
        private string ten;

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
    }
}
