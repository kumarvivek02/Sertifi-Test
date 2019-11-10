using System.Collections.Generic;

namespace SertifiTest
{
    public interface IAnalyzeHighestAttendanceYear
    {
        int GetYearOfHighestAttendance(IEnumerable<IStudentProfile> studentProfiles);
    }
}