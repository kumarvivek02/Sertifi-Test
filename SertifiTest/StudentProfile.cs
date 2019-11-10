using System;
using System.Collections.Generic;
using System.Text;

namespace SertifiTest
{
    public class StudentProfile : IStudentProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public List<float> GPARecord { get; set; }
    }
}
