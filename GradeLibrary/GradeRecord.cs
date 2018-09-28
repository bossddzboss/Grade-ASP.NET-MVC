using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeLibrary
{
    public class GradeRecord
    {
        private double _i;
        public string Grade { get; set; }
        public Range Range { get; set; }

        //public void SetupGrade(double i)
        //{
        //    _i = i;
        //}

        public GradeRecord()
        {
            // 1 = บวกเกรดที่ละ 1
            // 0.1 = บวกเกรดที่ละ 0.1
            _i = 1;
        }

        public GradeRecord(double i)
        {
            _i = i;
        }

        public bool ValidateOverlapping(Range r)
        {
            return validateOverlapping(this.Range, r);
        }

        private bool validateOverlapping(Range l, Range r)
        {
            var result = false;

            if (l.Max < r.Min)
            {
                result = true;
            }

            else
            {
                result = false;
            }
            return result;
        }

        public bool CheckRange(Range l)
        {
            return checkRange(this.Range, l);
        }

        private bool checkRange(Range r, Range l)
        {

            var result = false;
            //IsChecked();
            if (r.Max == l.Min - _i)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
