using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SertifiTest
{
    public class AnalyzeHighestAttendanceYear : IAnalyzeHighestAttendanceYear
    {
        public int GetYearOfHighestAttendance(IEnumerable<IStudentProfile> studentProfiles)
        {
            if (studentProfiles == null || studentProfiles.Count() == 0) { return 0; }

            var attendanceDictionary = PopulateAttendanceDictionary(studentProfiles);

            var yearOfHighestAttendance = YearOfHighestAttendance(attendanceDictionary);

            return yearOfHighestAttendance;
        }

        private IDictionary<int, int> PopulateAttendanceDictionary(IEnumerable<IStudentProfile> studentProfiles)
        {
            var attendanceDictionary = new Dictionary<int, int>();

            foreach (var profile in studentProfiles)
            {               
                for (int year = profile.StartYear; year <= profile.EndYear; year++)
                {
                    if (attendanceDictionary.ContainsKey(year))
                    {
                        attendanceDictionary[year]++;
                    }
                    else
                    {
                        attendanceDictionary.Add(year, 1); 
                    }
                }             
            }
            return attendanceDictionary;
        }

        private int YearOfHighestAttendance(IDictionary<int, int> attendanceDictionary)
        {
            var res = attendanceDictionary.Max(x => x.Value);
            return attendanceDictionary.Where(x => x.Value == res).Select(x => x.Key).First();
        }
    }
}
