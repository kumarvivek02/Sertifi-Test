using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SertifiTest
{
    public class AnalyzeHighestGPAYear : IAnalyzeHighestGPAYear
    {
        public int YearOfHighestGPA(IEnumerable<StudentProfile> studentProfiles)
        {
            var gpaDictionary = new Dictionary<int, double>();

            foreach (var profile in studentProfiles)
            {
                for (int year = profile.StartYear; year <= profile.EndYear; year++)
                {
                    int index = profile.GPARecord.Count() - (profile.EndYear - year) - 1;
                    if (gpaDictionary.ContainsKey(year))
                    {
                        gpaDictionary[year] += profile.GPARecord.ElementAt(index);
                    }
                    else
                    {
                        gpaDictionary.Add(year, profile.GPARecord.ElementAt(index));
                    }

                }
            }
            return gpaDictionary.Select(x => new { x.Key, x.Value }).OrderByDescending(x => x.Value).First().Key;
        }

    }
}
