using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
    public class monanDAO
    {
        private static monanDAO instance;

        public static monanDAO Instance
        {
            get
            {
                if (instance == null) instance = new monanDAO();
                return monanDAO.instance;
            }

            private set
            {
                monanDAO.instance = value;
            }
        }


        private monanDAO() { }

        public List<Monan> Laydsmonan(int id)
        {
            List< Monan> list = new List<Monan>();
            string query = "select * from monan where iddanhmuc = " + id;
            DataTable data = dataprovider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Monan food = new Monan(item);
                list.Add(food);

            }
            return list;
        }


    }

}
