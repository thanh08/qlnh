using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Ban
    {
        public Ban(int id, string ten, string status)
        {
            this.Id = id;
            this.Ten = ten;
            this.Status = status;
        }
        public Ban(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Ten = row["ten"].ToString();
            this.Status = row["status"].ToString();

        }
        private int id;

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
        private string ten;

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
        private string status;

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        

       

    }
}
