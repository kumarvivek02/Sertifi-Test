using System.Collections.Generic;

namespace SertifiTest
{
    public interface IAnalyzeStudentsWithHighestGPA
    {
        List<int> StudentsWithHighestOverallGPA(IEnumerable<StudentProfile> studentProfiles);
    }
}