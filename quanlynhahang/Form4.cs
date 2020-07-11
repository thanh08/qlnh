using quanlynhahang.DAO;
using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhahang
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            loadtaikhoanlist();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dataGridView1.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void loadtaikhoanlist ()
        {

            string query = "exec dbo.usp_laytaikhoanbangusername @username";

            dataGridView5.DataSource = dataprovider.Instance.ExecuteQuery(query, new object[] { "thanh" });

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }
    }
}
