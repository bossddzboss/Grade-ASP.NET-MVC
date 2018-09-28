using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradeLibrary;

namespace โปรแกรมตัดเกรด
{
    public partial class Form1 : Form
    {

        //Form2 f2 = new Form2();
        
        public GradeRecord[] Grades {get;set;}

        double number;
        string Grade;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text != "")

                {


                    if (!Double.TryParse(textBox1.Text, out number))
                    {
                        MessageBox.Show("ข้อมูลที่กรอกต้องเป็นตัวเลขเท่านั้น", "ตรวจสอบความถูกต้องของข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.None);

                        textBox1.Clear();
                        label3.Text = null;
                    }
                    else
                    {
                        number = Convert.ToDouble(textBox1.Text);
                      
                        var grade = Grades.FirstOrDefault(g => g.Range.Min <= number && g.Range.Max >= number);

                        if (grade == null)
                        {
                            label3.Text = "ไม่ตรงตามเงื่อนไข";
                        }
                        else
                        {
                            label3.Text = grade.Grade;
                        }
                        //if (number >= 80 && number <= 100) { Grade = "A"; }
                        //else if (number >= 75 && number <= 79) { Grade = "B+"; }
                        //else if (number >= 70 && number <= 74) { Grade = "B"; }
                        //else if (number >= 65 && number <= 69) { Grade = "C+"; }
                        //else if (number >= 60 && number <= 64) { Grade = "C"; }
                        //else if (number >= 55 && number <= 59) { Grade = "D+"; }
                        //else if (number >= 50 && number <= 54) { Grade = "D"; }
                        //else if(number >= 0 && number <= 49) { Grade = "F"; }
                        //else { Grade = "ไม่ตรงตามเงื่อนไข";}
                        //label3.Text = Grade;
                    }
                }
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("Error reading from", ex.Message, MessageBoxIcon.Stop);
            }
            finally
            {
                if (Double.TryParse(textBox1.Text, out number))
                {
                    MessageBox.Show("ขอบคุณที่ใช้บริการ", "การให้บริการ", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
              
                else   {
                    MessageBox.Show("ไม่ตรงตามเงื่อนไข กรุณากรอกตัวเลขเพื่อคำนวณคะแนน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

   

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();

            //f2.Show();
            Owner.Show();
        }
        
        
    }
}