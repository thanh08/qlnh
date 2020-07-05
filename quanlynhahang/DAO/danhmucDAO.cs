using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
    public class danhmucDAO
    {
        private static danhmucDAO instance;

        public static danhmucDAO Instance
        {
            get
            {
                if (instance == null) instance = new danhmucDAO();
                return danhmucDAO.instance;
                
            }

            private set
            {
                danhmucDAO.instance = value;

                
            }
        }


        private danhmucDAO() { }
        public List<Danhmuc> Laydanhmuc()
        {
            List<Danhmuc> list = new List<Danhmuc>();
            string query = "select * from danhmucmonan";
            DataTable data = dataprovider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Danhmuc danhmuc = new Danhmuc(item);
                list.Add(danhmuc);
            }
            return list;

        }
    }
}
