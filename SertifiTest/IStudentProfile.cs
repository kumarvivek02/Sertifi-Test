using System.Collections.Generic;

namespace SertifiTest
{
    public interface IStudentProfile
    {
        int EndYear { get; set; }
        List<float> GPARecord { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int StartYear { get; set; }
    }
}