using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
    public class taikhoanDAO 
    {
        private static taikhoanDAO instance;

        public static taikhoanDAO Instance
        {
            get
            {
                if (instance == null) instance = new taikhoanDAO(); return instance;
            
            }

            private set
            {
                instance = value;
            }

            
        }

        private taikhoanDAO() { }

        public bool dangnhap(string username,string password)
        {
            string query = "usp_kiemtrataikhoan @username , @password";
            DataTable result = DTO.dataprovider.Instance.ExecuteQuery(query, new object[] {username, password
            });

            return result.Rows.Count> 0;
        }
    }
}
