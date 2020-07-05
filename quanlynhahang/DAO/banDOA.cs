

using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
    public class banDOA
    {
        private static banDOA instance;

        public static banDOA Instance
        {
            get
            {
                if (instance == null)
                 instance = new banDOA();
                    return banDOA.instance;
                        
                
            }

            private set
            {
                banDOA.instance = value;
            }
        }
        public static int Chieudaiban = 80;
        public static int Chieurongban = 80;

        private banDOA() { }
        public  List<Ban> Hienthids()
        {
            List<Ban> tableList = new List<Ban>();
            DataTable data = dataprovider.Instance.ExecuteQuery("usp_laydanhsachban");
                foreach (DataRow item in data.Rows)
            {
                Ban table = new Ban(item);
                    tableList.Add(table);
            }
           return tableList;
        }
    }
}
