using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SertifiTest
{
    class Program
    {
        const string urlGET = "http://apitest.sertifi.net/api/Students";
        const string urlPUT = " http://apitest.sertifi.net/api/StudentAggregate";

        static void Main(string[] args)
        {
           

            IStudentProfile studentProfile = new StudentProfile();


            IFetchData fetchData = new FetchData(urlGET);

            var studentProfiles = ReadDataFromSertifiAsync(fetchData).Result;

            //Year of highest attendance
            IAnalyzeHighestAttendanceYear analyzeData = new AnalyzeHighestAttendanceYear();
            var yearOfHighestAttendance = analyzeData.GetYearOfHighestAttendance(studentProfiles);

            //Year of highest overall GPA
            IAnalyzeHighestGPAYear analyzeHighestGPAYear = new AnalyzeHighestGPAYear();
            var yearOfHighestGPA = analyzeHighestGPAYear.YearOfHighestGPA(studentProfiles);

            //Top 10 Student Id's with highest overall GPA
            IAnalyzeStudentsWithHighestGPA analyzeStudentsWithHighestGPA = new AnalyzeStudentsWithHighestGPA();
            var listOfStudentIdsWithHighestGPA = analyzeStudentsWithHighestGPA.StudentsWithHighestOverallGPA(studentProfiles);

            //Largest GPA diff
            IAnalyzeLargestGPADifference analyzeLargestGPADifference = new AnalyzeLargestGPADifference();
            var mostInconsistentStudentId = analyzeLargestGPADifference.StudentIdWithLargestMinMaxGPADifference(studentProfiles);

            //Submit
            SubmitResults submitResults = new SubmitResults(urlPUT);
            submitResults.SubmitTestResults(yearOfHighestAttendance, yearOfHighestGPA, listOfStudentIdsWithHighestGPA, mostInconsistentStudentId);

        }

        public static async Task<IEnumerable<StudentProfile>> ReadDataFromSertifiAsync(IFetchData fetchData)
        {
            var studentProfiles = await fetchData.GetStudentProfilesAsync();

            return studentProfiles;
        }
          



        //TODO:
        // make method name end in async if they are async
    }
}
