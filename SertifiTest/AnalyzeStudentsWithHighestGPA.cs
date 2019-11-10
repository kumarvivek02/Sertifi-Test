using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SertifiTest
{
    public class AnalyzeStudentsWithHighestGPA : IAnalyzeStudentsWithHighestGPA
    {
        public List<int> StudentsWithHighestOverallGPA(IEnumerable<StudentProfile> studentProfiles)
        {
            return studentProfiles.Select(s => new
            {
                ID = s.Id,
                AvgGPA = s.GPARecord.Count() > 0 ? s.GPARecord.Average() : 0,
            }).OrderByDescending(s => s.AvgGPA)
             .Take(10).Select(s => s.ID).ToList();
        }
    }
}
