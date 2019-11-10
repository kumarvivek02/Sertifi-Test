using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SertifiTest
{
    public class AnalyzeLargestGPADifference : IAnalyzeLargestGPADifference
    {
        public int StudentIdWithLargestMinMaxGPADifference(IEnumerable<StudentProfile> studentProfiles)
        {
            return studentProfiles.Select(profile => new
            {
                Id = profile.Id,
                LargestGPADiff = profile.GPARecord.Max() - profile.GPARecord.Min()
            }).OrderByDescending(x => x.LargestGPADiff)
            .First().Id;
        }
    }
}
