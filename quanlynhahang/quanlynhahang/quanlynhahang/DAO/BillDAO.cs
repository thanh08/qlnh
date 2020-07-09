using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
   public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return BillDAO.instance;
               
            }

            private set
            {
                BillDAO.instance = value;
            }
        }

        private BillDAO(
            ) { }

        public int laybillbangid(int id)
        {
            DataTable data = dataprovider.Instance.ExecuteQuery("select * from dbo.bill where idtable= "+id+" and status = 0");
            if(data.Rows.Count >0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }
        public void CheckOut(int id)
        {
            string query = "update dbo.bill set status = 1 where id = " + id;
            dataprovider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            dataprovider.Instance.ExecuteNonQuery("exec usp_vaobill @idtable", new object[] { id });
        }
        public int Laybill()
        {
            try
            {
                return (int)dataprovider.Instance.ExecuteScalar("select max(id) from dbo.bill");

            }
            catch
            {
                return 1;
            }
        }
    }
}
