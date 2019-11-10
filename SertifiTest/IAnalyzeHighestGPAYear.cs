using System.Collections.Generic;

namespace SertifiTest
{
    public interface IAnalyzeHighestGPAYear
    {
        int YearOfHighestGPA(IEnumerable<StudentProfile> studentProfiles);
    }
}