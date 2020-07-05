using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DAO
{
  public  class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new MenuDAO();
              return  MenuDAO. instance;
            }

            private set
            {
               MenuDAO.instance = value;
            }
        }
        public MenuDAO() { }


        public List<Menu> Laydsmenura(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            DataTable data = dataprovider.Instance.ExecuteQuery("select f.ten, bi.count, f.price, f.price*bi.count as tonggia from dbo.thongtinbill as bi, dbo.bill as b, dbo.monan as f where bi.idbill = b.id and bi.idmonan = f.id and b.status= 0 and b.idtable = " + id);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
