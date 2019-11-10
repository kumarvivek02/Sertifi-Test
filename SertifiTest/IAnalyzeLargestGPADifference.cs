using System.Collections.Generic;

namespace SertifiTest
{
    public interface IAnalyzeLargestGPADifference
    {
        int StudentIdWithLargestMinMaxGPADifference(IEnumerable<StudentProfile> studentProfiles);
    }
}