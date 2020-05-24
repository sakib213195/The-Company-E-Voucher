using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Company_E_Voucher
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment_Voucher openForm = new Payment_Voucher();
            openForm.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Contra_Sub_Menu openForm = new Contra_Sub_Menu();
            openForm.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receipt_Voucher openForm = new Receipt_Voucher();
            openForm.Show();
            Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expense_Voucher openForm = new Expense_Voucher();
            openForm.Show();
            Visible = false;

        }
    }
}
