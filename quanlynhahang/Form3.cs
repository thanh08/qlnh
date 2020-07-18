using quanlynhahang.DAO;
using quanlynhahang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhahang
{
    public partial class Form3 : Form
    {
        public Form3(Account acc )
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            textBox1.Text = LoginAccount.UserName;
            textBox2.Text = LoginAccount.DisplayName;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }
        void UpdateAccountInfo()
        {
            string displayName = textBox2.Text;
            string password = textBox3.Text;
            string newpass = textBox4.Text;
            string reenterPass = textBox5.Text;
            string userName = textBox1.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (taikhoanDAO.Instance.UpdateAccount1(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
}
