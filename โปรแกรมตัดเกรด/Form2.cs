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
    public partial class Form2 : Form
    {
        GradeRecord[] grades = new GradeRecord[] {
            new GradeRecord
            {
                Grade = "A",
                Range = new Range
                {
                    Min = 80,
                    Max = 100,
                }
            },
            new GradeRecord
            {
                Grade = "B+",
                Range = new Range
                {
                    Min = 75,
                    Max = 79,
                }
            },
            new GradeRecord
            {
                Grade = "B",
                Range = new Range
                {
                    Min = 70,
                    Max = 74,
                }
            },
             new GradeRecord
            {
                Grade = "C+",
                Range = new Range
                {
                    Min = 65,
                    Max = 69,
                }
            },
              new GradeRecord
            {
                Grade = "C",
                Range = new Range
                {
                    Min = 60,
                    Max = 64,
                }
            },
               new GradeRecord
            {
                Grade = "D+",
                Range = new Range
                {
                    Min = 55,
                    Max = 59,
                }
            },
                new GradeRecord
            {
                Grade = "D",
                Range = new Range
                {
                    Min = 50,
                    Max = 54,
                }
            },
                 new GradeRecord
            {
                Grade = "F",
                Range = new Range
                {
                    Min = 0,
                    Max = 49,
                }
            },
        };


        public Form2()
        {



            InitializeComponent();


            showDataInForm();

            radioButton3.Checked = true;
        }

        private double _i = 0;
        public void IsChecked()
        {

            if (radioButton2.Checked)
            {
                _i = 0.1;
            }
            else if (radioButton3.Checked)
            {
                _i = 1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        //public double GetI() {
        //    return i;
        //}


        //แสดงข้อมูล ใน textbox
        public void showDataInForm()
        {
            var gradeA = grades.FirstOrDefault(g => g.Grade == "A");
            var gradeBB = grades.FirstOrDefault(g => g.Grade == "B+");
            var gradeB = grades.FirstOrDefault(g => g.Grade == "B");
            var gradeCC = grades.FirstOrDefault(g => g.Grade == "C+");
            var gradeC = grades.FirstOrDefault(g => g.Grade == "C");
            var gradeDD = grades.FirstOrDefault(g => g.Grade == "D+");
            var gradeD = grades.FirstOrDefault(g => g.Grade == "D");
            var gradeF = grades.FirstOrDefault(g => g.Grade == "F");

            if (gradeA != null)
            {
                an.Text = gradeA.Range.Min.ToString();
                am.Text = gradeA.Range.Max.ToString();
            }
            if (gradeBB != null)
            {
                bbn.Text = gradeBB.Range.Min.ToString();
                bbm.Text = gradeBB.Range.Max.ToString();
            }
            if (gradeB != null)
            {
                bn.Text = gradeB.Range.Min.ToString();
                bm.Text = gradeB.Range.Max.ToString();
            }
            if (gradeCC != null)
            {
                ccn.Text = gradeCC.Range.Min.ToString();
                ccm.Text = gradeCC.Range.Max.ToString();
            }
            if (gradeC != null)
            {
                cn.Text = gradeC.Range.Min.ToString();
                cm.Text = gradeC.Range.Max.ToString();
            }
            if (gradeDD != null)
            {
                ddn.Text = gradeDD.Range.Min.ToString();
                ddm.Text = gradeDD.Range.Max.ToString();
            }
            if (gradeD != null)
            {
                dn.Text = gradeD.Range.Min.ToString();
                dm.Text = gradeD.Range.Max.ToString();
            }
            if (gradeF != null)
            {
                fn.Text = gradeF.Range.Min.ToString();
                fm.Text = gradeF.Range.Max.ToString();
            }
        }

        private GradeRecord createGrage(string grade, string min, string max)
        {

            var result = new GradeRecord(_i);

            if (!string.IsNullOrEmpty(min) && !string.IsNullOrEmpty(max))
            {
                result.Grade = grade;
                result.Range = new Range();
                result.Range.Min = double.Parse(min);
                result.Range.Max = double.Parse(max);


                if (!result.Range.ValidateRange())
                {
                    throw new NullReferenceException(grade);

                }
            }

            else
            {
                throw new NullReferenceException(grade);
            }

            return result;
        }

        public GradeRecord[] insertDataInArrary()
        {
            //var results = new List<GradeRecord>();

            IsChecked();

            var grades = new GradeRecord[8];
            grades[0] = createGrage("A", an.Text, am.Text);
            grades[1] = createGrage("B+", bbn.Text, bbm.Text);
            grades[2] = createGrage("B", bn.Text, bm.Text);
            grades[3] = createGrage("C+", ccn.Text, ccm.Text);
            grades[4] = createGrage("C", cn.Text, cm.Text);
            grades[5] = createGrage("D+", ddn.Text, ddm.Text);
            grades[6] = createGrage("D", dn.Text, dm.Text);
            grades[7] = createGrage("F", fn.Text, fm.Text);
            //var gradeA = createGrage("A", an.Text, am.Text);
            //results.Add(gradeA);
            //var gradeBB = createGrage("B+", bbn.Text, bbm.Text);
            //results.Add(gradeBB);
            //var gradeB = createGrage("B", bn.Text, bm.Text);
            //results.Add(gradeB);
            //var gradeCC = createGrage("C+", ccn.Text, ccm.Text);
            //results.Add(gradeCC);
            //var gradeC = createGrage("C", cn.Text, cm.Text);
            //results.Add(gradeC);
            //var gradeDD = createGrage("D+", ddn.Text, ddm.Text);
            //results.Add(gradeDD);
            //var gradeD = createGrage("D", dn.Text, dm.Text);
            //results.Add(gradeD);
            //var gradeF = createGrage("F", fn.Text, fm.Text);
            //results.Add(gradeF);

            for (int i = 1; i < grades.Length; i++)
            {
                var gradeR = grades[i - 1];
                var gradeL = grades[i];

                if (!gradeL.ValidateOverlapping(gradeR.Range))
                {
                    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeR.Grade} และ {gradeL.Grade}.");
                }
                if (!gradeL.CheckRange(gradeR.Range))
                {
                    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeR.Grade} และ {gradeL.Grade}");
                }
            }

            //var g = results.Where(r => r.Range.Min >= 0 & r.Range.Max < 10);

            //if (!gradeBB.ValidateOverlapping(gradeA.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeA.Grade} และ {gradeBB.Grade}.");
            //}
            //else if (!gradeB.ValidateOverlapping(gradeBB.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeBB.Grade} และ {gradeB.Grade}.");
            //}
            //else if (!gradeCC.ValidateOverlapping(gradeB.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeB.Grade} และ {gradeCC.Grade}.");
            //}
            //else if (!gradeC.ValidateOverlapping(gradeCC.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeCC.Grade} และ {gradeC.Grade}.");
            //}
            //else if (!gradeDD.ValidateOverlapping(gradeC.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeC.Grade} และ {gradeDD.Grade}.");
            //}
            //else if (!gradeD.ValidateOverlapping(gradeDD.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeDD.Grade} และ {gradeDD.Grade}.");
            //}
            //else if (!gradeF.ValidateOverlapping(gradeD.Range))
            //{
            //    throw new NullReferenceException($"คะแนนมีการทับซ้อนกัน {gradeD.Grade} และ {gradeF.Grade}.");
            //}
            //else if (!gradeBB.CheckRange(gradeA.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeA.Grade} และ {gradeBB.Grade}");
            //}
            //else if (!gradeB.CheckRange(gradeBB.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeBB.Grade} และ {gradeB.Grade}");
            //}
            //else if (!gradeCC.CheckRange(gradeB.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeB.Grade} และ {gradeCC.Grade}");
            //}
            //else if (!gradeC.CheckRange(gradeCC.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeCC.Grade} และ {gradeC.Grade}");
            //}
            //else if (!gradeDD.CheckRange(gradeC.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeC.Grade} และ {gradeDD.Grade}");
            //}
            //else if (!gradeD.CheckRange(gradeDD.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeDD.Grade} และ {gradeD.Grade}");
            //}
            //else if (!gradeF.CheckRange(gradeD.Range))
            //{
            //    throw new NullReferenceException($"เกณฑ์คะแนนมีระยะการขาดช่วงกันระหว่างช่วงเกรด {gradeD.Grade} และ {gradeF.Grade}");
            //}
            //else
            //{
            //    MessageBox.Show("เกณฑ์คะแนนถูกต้องตามเงื่อนไข", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.None);
            //}
            MessageBox.Show("เกณฑ์คะแนนถูกต้องตามเงื่อนไข", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.None);
            return grades;

        }

        private void an_TextChanged(object sender, EventArgs e)
        {

        }

        private GradeRecord[] _grades = null;

        private void Check_Click(object sender, EventArgs e)
        {

            try
            {

                _grades = insertDataInArrary();
                buttonCheckWasClicked = true;
                button2.Visible = true;

            }
            catch (NullReferenceException ex)
            {
                button2.Visible = false;
                MessageBox.Show($"คุณใส่ข้อมูล {ex.Message} ไม่ถูกต้อง กรุณาตรวจสอบ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool buttonCheckWasClicked = false;

        private Form1 f1 = null;

        private void button2_Click(object sender, EventArgs e)
        {
            check.PerformClick();

            if (!buttonCheckWasClicked)
            {
                MessageBox.Show("กรุณากด ตรวจสอบคะแนน ก่อนทำการคำนวณ ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (buttonCheckWasClicked)
            {
                if(f1 == null)
                {
                    f1 = new Form1();
                    f1.Owner = this;
                }
                //f1 = new Form1();

                //f1.Parent = this;
                f1.Grades = _grades;



                f1.Show();
                this.Hide();
            }


        }
        //กำหนดให้ textbox ไม่สามารถพิมข้อมูลอื่นลงในช่องได้นอกจาก "ตัวเลข"
        private void forNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_i == 1)

            {
                if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                //else if (!char.IsNumber(e.KeyChar))
                //{
                //    MessageBox.Show("รูปแบบผิด");
                //}
            }

            else

            {
                if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar) & (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                //else if (!char.IsNumber(e.KeyChar))
                //{
                //    MessageBox.Show("รูปแบบผิด");
                //}
            }
        }



        //public bool ValidateOverlapping(Range l, Range r)
        //{
        //    var result = false;

        //    if (l.Max < r.Min)
        //    {
        //        result = true;
        //    }

        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        //public bool CheckRange(Range r, Range l)
        //{

        //    var result = false;
        //    IsChecked();
        //    if (r.Max == l.Min - _i)
        //    {
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            an.Text = string.Empty;
            am.Text = string.Empty;
            bbn.Text = string.Empty;
            bbm.Text = string.Empty;
            bn.Text = string.Empty;
            bm.Text = string.Empty;
            ccn.Text = string.Empty;
            ccm.Text = string.Empty;
            cn.Text = string.Empty;
            cm.Text = string.Empty;
            ddn.Text = string.Empty;
            ddm.Text = string.Empty;
            dn.Text = string.Empty;
            dm.Text = string.Empty;
            fn.Text = string.Empty;
            fm.Text = string.Empty;

        }


        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                MessageBox.Show("คุณเลือกรูปแบบ ระยะห่าง 0.1 คะแนน");
                return;
            }
            else
            {

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                MessageBox.Show("คุณเลือกรูปแบบ ระยะห่าง 1 คะแนน");
                return;
            }
            else { }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void am_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
