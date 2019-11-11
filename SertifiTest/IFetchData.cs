using System.Collections.Generic;
using System.Threading.Tasks;

namespace SertifiTest
{
    public interface IFetchData
    {
        string URL { get; }
        Task<IEnumerable<StudentProfile>> GetStudentProfilesAsync();
        bool ValidateUrl();
    }
}