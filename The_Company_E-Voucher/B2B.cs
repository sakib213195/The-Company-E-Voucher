using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace The_Company_E_Voucher
{
    public partial class B2B : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public B2B()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =D:\The_Company_DB.accdb; Persist Security Info = False;";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main_Menu openForm1 = new Main_Menu();
            openForm1.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            autogen();
        }

        public void autogen()
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdigit = 9;
            string finaldigit;
            int getindex;

            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }

            textBox18.Text = (otp);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            string fileName = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                      @"\Payment_Voucher" + "_" +
                      DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".jpeg");

            bitmap.Save(fileName);


            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 1, 2, s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if ((!int.TryParse(textBox5.Text, out parsedValue)) && (!int.TryParse(textBox13.Text, out parsedValue)) && (!int.TryParse(textBox14.Text, out parsedValue)))
            {
                MessageBox.Show("Please Enter Taka");
            }

            //-----------------------------
            if ((int.TryParse(textBox5.Text, out parsedValue)) && (!int.TryParse(textBox13.Text, out parsedValue)) && (!int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text)).ToString();
            }

            if ((int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (!int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox13.Text)).ToString();
            }

            if ((int.TryParse(textBox5.Text, out parsedValue)) && (!int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }
            //-----------------------------

            //-----------------------------
            if ((!int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (!int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox13.Text)).ToString();
            }

            if ((int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (!int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox13.Text)).ToString();
            }

            if ((!int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox13.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }
            //-----------------------------

            //-----------------------------
            if ((!int.TryParse(textBox5.Text, out parsedValue)) && (!int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox14.Text)).ToString();
            }

            if ((int.TryParse(textBox5.Text, out parsedValue)) && (!int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }

            if ((!int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox13.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }
            //-----------------------------


            if ((int.TryParse(textBox5.Text, out parsedValue)) && (int.TryParse(textBox13.Text, out parsedValue)) && (int.TryParse(textBox14.Text, out parsedValue)))
            {
                textBox12.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox13.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }

            int i = 0;

            textBox10.Text = NumberToWords(Convert.ToInt32(Int32.TryParse(((textBox12.Text)), out i) ? i : (int?)null));


        }

        public static String NumberToWords(int number)

        {

            if (number == 0) return "Zero";

            if (number < 0) return "-" + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundered";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += " and";

                var unitsMap = new[] { " Zero", " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine", " Ten", " Eleven", " Twelve", " Thirteen", " Fourteen", " Fifteen", " Sixteen", " Seventeen", " Eighteen", " Nineteen" };
                var tensMap = new[] { " Zero", " Ten", " Twenty", " Thirty", " Fourty", " Fifty", " Sixty", " Seventy", " Eighty", " Ninety" };

                if (number < 20) words += unitsMap[number];

                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += "-" + unitsMap[number % 10];
                }

            }

            return words;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [B2B_DB] (Date_,Vr_No,Company,Voucher_Type,Bank_To,Bank_From,SL_1,Details_1,Taka_1,SL_2,Details_2,Taka_2,SL_3,Details_3,Taka_3,Total,Prepared_By)values('" + DateTime.Today + "','" + textBox18.Text + "','" + label14.Text + "','" + label7.Text + "','" + txtbox1.Text + "','" + txtBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox13.Text + "','" + textBox11.Text + "','" + textBox9.Text + "','" + textBox14.Text + "','" + textBox12.Text + "','" + comboBox3.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            CaptureScreen();
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }

}
