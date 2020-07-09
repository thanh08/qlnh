using quanlynhahang.DAO;
using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace quanlynhahang
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            hienthiban();
            hienthidanhmuc();
        }
        void hienthidanhmuc()
        {
            List<Danhmuc> listdanhmuc = danhmucDAO.Instance.Laydanhmuc();
            comboBox1.DataSource = listdanhmuc;
            comboBox1.DisplayMember = "ten";

        }
        void hienthimonan(int id)
        {
            List<Monan> listmonan = monanDAO.Instance.Laydsmonan(id);
           comboBox2.DataSource = listmonan;
            comboBox2.DisplayMember = "ten";
        }
        void hienthiban()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Ban> tableList = banDOA.Instance.Hienthids();

            foreach(Ban item in tableList)
            {
                Button btn = new Button() { Width = banDOA.Chieudaiban, Height = banDOA.Chieurongban };
                btn.Text = item.Ten + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Green;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            listView1.Items.Clear();
            List<DTO.Menu> listBillinfo = MenuDAO.Instance.Laydsmenura(id);
            float tong = 0;
            foreach(DTO.Menu item in listBillinfo)
            {
                ListViewItem lsvitem = new ListViewItem(item.Foodname.ToString());
                lsvitem.SubItems.Add(item.Count.ToString());
                lsvitem.SubItems.Add(item.Prive.ToString());
                lsvitem.SubItems.Add(item.Totalprive.ToString());
                tong += item.Totalprive;
                listView1.Items.Add(lsvitem);
            }
            CultureInfo culter = new CultureInfo("vi-VN");
            textBox1.Text = tong.ToString("c", culter);
            

        }

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Ban).Id;
            listView1.Tag = (sender as Button).Tag;
            ShowBill(tableID);

        }
        #region 

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Danhmuc selected = cb.SelectedItem as Danhmuc;
            id = selected.Id;
            hienthimonan(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ban table = listView1.Tag as Ban;
            int idbill = BillDAO.Instance.laybillbangid(table.Id);
            int foodid = (comboBox2.SelectedItem as Monan).Id;
            int soluong = (int)numericUpDown1.Value;


            if(idbill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
            BillinfoDAO.Instance.InsertBillInfo(BillDAO.Instance.Laybill(), foodid, soluong);
        }
            else
            {
                BillinfoDAO.Instance.InsertBillInfo(idbill, foodid, soluong);
            }
            ShowBill(table.Id);
            hienthiban();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ban table = listView1.Tag as Ban;
            int idBill = BillDAO.Instance.laybillbangid(table.Id);
            if(idBill != -1)
            {
                if(MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho " + table.Ten, "Thông báo" ,MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(table.Id);

                    hienthiban();

                }

            }
        }
    }

       
}
