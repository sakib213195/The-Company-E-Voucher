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
    public partial class Contra_Sub_Menu : Form
    {
        public Contra_Sub_Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main_Menu openForm = new Main_Menu();
            openForm.Show();
            Visible = false;
        }
    }
}
