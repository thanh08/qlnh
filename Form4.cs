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
    }
}
