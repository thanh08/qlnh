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
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource dmList = new BindingSource();
        BindingSource banList = new BindingSource();
        public Form4()
        {
            
            InitializeComponent();
            dataGridView2.DataSource = foodList;
            dataGridView5.DataSource = accountList;
            dataGridView3.DataSource = dmList;
            dataGridView4.DataSource = banList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadListFood();
            LoadAccount();
            Loaddanhmuc();
            Loaban();
            LoadCategoryIntoCombobox(comboBox1);
            LoadStatusIntoCombobox(comboBox2);
            AddFoodBinding();
            AddAccountBinding();
            Adddanhmuc();
            Addban();
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
       
        void AddAccountBinding()
        {
            textBox9.DataBindings.Add(new Binding("Text", dataGridView5.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            textBox8.DataBindings.Add(new Binding("Text", dataGridView5.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Text", dataGridView5.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = taikhoanDAO.Instance.GetListAccount();
        }
        void AddFoodBinding()
        {
            textBox3.DataBindings.Add(new Binding("Text", dataGridView2.DataSource, "Ten" , true, DataSourceUpdateMode.Never));
            textBox2.DataBindings.Add(new Binding("Text", dataGridView2.DataSource, "ID" , true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dataGridView2.DataSource, "Price" , true, DataSourceUpdateMode.Never));
        }

        void Adddanhmuc()
        {
            textBox5.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Add(new Binding("Text", dataGridView3.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            
        }
        void Addban()
        {
            textBox7.DataBindings.Add(new Binding("Text", dataGridView4.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox6.DataBindings.Add(new Binding("Text", dataGridView4.DataSource, "Ten", true, DataSourceUpdateMode.Never));

        }
        //load combobox danh mục
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = danhmucDAO.Instance.Laydanhmuc();
            cb.DisplayMember = "Ten";
        }
        //load combobox trạng thái bàn
        void LoadStatusIntoCombobox(ComboBox b)
        {
            b.DataSource = banDOA.Instance.Hienthiban();
            b.DisplayMember = "status";
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //thống kê bill
        private void button1_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }


        void LoadListFood()
        {
            foodList.DataSource = monanDAO.Instance.GetListFood();
        }
        void Loaddanhmuc()
        {
            dmList.DataSource = danhmucDAO.Instance.Laydanhmuc();
        }
       
        void Loaban()
        {
            banList.DataSource = banDOA.Instance.Hienthiban();
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int id = (int)dataGridView2.SelectedCells[0].OwningRow.Cells["iddanhmuc"].Value;

                Danhmuc cateogory = danhmucDAO.Instance.GetCategoryByID(id);

                comboBox1.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Danhmuc item in comboBox1.Items)
                {
                    if (item.Id == cateogory.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                comboBox1.SelectedIndex = index;
            }
        
    }
        //Thêm món
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int categoryID = (comboBox1.SelectedItem as Danhmuc).Id;
            float price = (float)numericUpDown1.Value;

            if (monanDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món ăn");
            }
        }
        //Sửa món
        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int categoryID = (comboBox1.SelectedItem as Danhmuc).Id;
            float price = (float)numericUpDown1.Value;
            int id = Convert.ToInt32(textBox2.Text);

            if (monanDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn");
            }
        }
        //Xóa món
        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox2.Text);

            if (monanDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa món ăn");
            }
        }

        //them tai khoan
        private void button18_Click(object sender, EventArgs e)
        {
            string userName = textBox9.Text;
            string displayName = textBox8.Text;
            int type = (int)numericUpDown2.Value;
            if (taikhoanDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

           
            
        }
        //xóa tài khoản
        private void button17_Click(object sender, EventArgs e)
        {
            string userName = textBox9.Text;
            if (taikhoanDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

           

        }
        //sửa tài khoản
        private void button16_Click(object sender, EventArgs e)
        {
            string userName = textBox9.Text;
            string displayName = textBox8.Text;
            int type = (int)numericUpDown2.Value;
            if (taikhoanDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

           
           
        }
        //reset lại mật khẩu về mặc định = 0
        private void button19_Click(object sender, EventArgs e)
        {
            string userName = textBox9.Text;
            if (taikhoanDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            

            if (danhmucDAO.Instance.InsertDm(name))
            {
                MessageBox.Show("Thêm danh muc thành công");
                Loaddanhmuc();

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danhmuc");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);

            if (danhmucDAO.Instance.DeleteDm(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                Loaddanhmuc();

            }
            else
            {
                MessageBox.Show("Có lỗi khi danh mục món ăn");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            
            int id = Convert.ToInt32(textBox5.Text);

            if (danhmucDAO.Instance.UpdateDm(name,id))
            {
                MessageBox.Show("Sửa danh mục thành công");
                Loaddanhmuc();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục món ăn");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;


            if (banDOA.Instance.InsertBan(name))
            {
                MessageBox.Show("Thêm bàn ăn thành công");
                Loaban();

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn ăn");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox7.Text);

            if (banDOA.Instance.DeleteBan(id))
            {
                MessageBox.Show("Xóa bàn ăn thành công");
                Loaban();

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn ăn");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;

            int id = Convert.ToInt32(textBox7.Text);

            if (banDOA.Instance.UpdateBan(name, id))
            {
                MessageBox.Show("Sửa bàn ăn thành công");
                Loaban();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn ăn");
            }
        }
        
    }
}
