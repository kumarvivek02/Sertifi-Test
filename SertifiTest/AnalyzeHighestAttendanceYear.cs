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
            var attendanceDictionary = PopulateAttendanceDictionary(studentProfiles);

            var yearOfHighestAttendance = YearOfHighestAttendance(attendanceDictionary);

            return yearOfHighestAttendance;
        }

        private IDictionary<int, int> PopulateAttendanceDictionary(IEnumerable<IStudentProfile> studentProfiles)
        {
            var attendanceDictionary = new Dictionary<int, int>();

            foreach (var profile in studentProfiles)
            {
                Console.Write("\t ID:{0}\t Name: {1}\t", profile.Id, profile.Name);
                String Year = "";
                String GPA = "";
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
                    Year += $"\t {year}";
                    GPA += $"\t {profile.GPARecord[profile.GPARecord.Count() - (profile.EndYear - year) - 1]}";
                    //Console.Write(" \t ID :{0} \t Name: {1}  ",profile.Id,profile.Name );
                }
                Console.Write("Year:{0}", Year);
                Console.WriteLine();
                Console.WriteLine("\t \t \t \tGPA:{0}",GPA);
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
