using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grade.Web.Models
{
    public class GradeModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Grade")]
        [Required (ErrorMessage = "กรุณาใส่ข้อมูล")]        
        public string GradeName { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public int? Min { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        public int? Max { get; set; }

        public GradeModel()
        {
            Min = 0;
            Max = 0;
        }

        public GradeModel(string gradeName, int min, int max)
        {
            GradeName = gradeName;
            Min = min;
            Max = max;
        }
    }
}