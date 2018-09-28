using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace โปรแกรมตัดเกรด
{
    public class Range
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double IsChecked { get; set; }

        public bool CheckRange()
        {
            var result = false;

            if (Min == Max + IsChecked)
            {

            }
            else
            {
                result = true;
            }
            return result;
        }

        public bool ValidateRange()
        {
            var result = false;

            if (Min >= Max)
            {
                //MessageBox.Show("มีช่วงคะแนนที่ทับซ้อนกัน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // min < max
                result = true;
            }

            return result;

        }

        
    }
}
