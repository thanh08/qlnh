using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
    public class BillinfoDAO
    {
        private static BillinfoDAO instance;

        public static BillinfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillinfoDAO();return BillinfoDAO.instance;

            }

            private set
            {
               BillinfoDAO.instance = value;
            }
        }
        private BillinfoDAO()
        {

        }
        public List<Billinfo> Laydsthongtinbill(int id)
        {
            List<Billinfo> listBillinfo = new List<Billinfo>();
            DataTable data = dataprovider.Instance.ExecuteQuery("select * from dbo.thongtinbill where idbill="+id);
            foreach(DataRow item in data.Rows)
            {
                Billinfo info = new Billinfo(item);
                listBillinfo.Add(info);

            }
            return listBillinfo;
        }
        public void InsertBillInfo(int idbill, int idmonan, int count)
        {
            dataprovider.Instance.ExecuteNonQuery("usp_thongtinbill @idbill , @idmonan , @count", new object[] {idbill,idmonan,count});
        }
    }
}
