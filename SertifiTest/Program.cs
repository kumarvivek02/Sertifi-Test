using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SertifiTest
{
    public class Program
    {
        const string urlGET = SertifiURLs.urlGET;
        const string urlPUT = SertifiURLs.urlPUT;

        static void Main(string[] args)
        { 
            IStudentProfile studentProfile = new StudentProfile();
            IFetchData fetchData = new FetchData(urlGET);

            var studentProfiles = ReadDataFromSertifiAsync(fetchData).Result;

            //Year of highest attendance
            var yearOfHighestAttendance = CalculateYearOfHighestAttendance(studentProfiles);           

            //Year of highest overall GPA
            var yearOfHighestGPA = CalculateYearOfHighestOverallGPA(studentProfiles);
           
            //Top 10 Student Id's with highest overall GPA
            var listOfStudentIdsWithHighestGPA = Top10StudentIdsWithHighestOverallGPA(studentProfiles);

            //Largest GPA diff            
            var mostInconsistentStudentId = StudentWithLargestGPADifference(studentProfiles);
           
            //Submit
            var isSuccess = SubmitTestResults(yearOfHighestAttendance, yearOfHighestGPA, listOfStudentIdsWithHighestGPA, mostInconsistentStudentId);
            Console.WriteLine();
            Console.WriteLine(" Value of \"isSuccess\" following PUT operation was {0}", isSuccess);
        }

        public static async Task<IEnumerable<StudentProfile>> ReadDataFromSertifiAsync(IFetchData fetchData)
        {
            return await fetchData.GetStudentProfilesAsync();            
        }

        public static int StudentWithLargestGPADifference(IEnumerable<StudentProfile> studentProfiles)
        {
            IAnalyzeLargestGPADifference analyzeLargestGPADifference = new AnalyzeLargestGPADifference();
            return analyzeLargestGPADifference.StudentIdWithLargestMinMaxGPADifference(studentProfiles);
        }

        public static List<int> Top10StudentIdsWithHighestOverallGPA(IEnumerable<StudentProfile> studentProfiles)
        {
            IAnalyzeStudentsWithHighestGPA analyzeStudentsWithHighestGPA = new AnalyzeStudentsWithHighestGPA();
            return analyzeStudentsWithHighestGPA.StudentsWithHighestOverallGPA(studentProfiles);
        }

        public static int CalculateYearOfHighestAttendance(IEnumerable<StudentProfile> studentProfiles)
        {
            IAnalyzeHighestAttendanceYear analyzeData = new AnalyzeHighestAttendanceYear();
            return analyzeData.GetYearOfHighestAttendance(studentProfiles);
        }

        public static int CalculateYearOfHighestOverallGPA(IEnumerable<StudentProfile> studentProfiles)
        {
            IAnalyzeHighestGPAYear analyzeHighestGPAYear = new AnalyzeHighestGPAYear();
            return analyzeHighestGPAYear.YearOfHighestGPA(studentProfiles);
        }

        public static bool SubmitTestResults(int yearOfHighestAttendance, int yearOfHighestGPA, List<int> listOfStudentIdsWithHighestGPA, int mostInconsistentStudentId)
        {
            bool isSuccess = false;
            try
            {
                SubmitResults submitResults = new SubmitResults(urlPUT);
                isSuccess = submitResults.SubmitTestResults(yearOfHighestAttendance, yearOfHighestGPA, listOfStudentIdsWithHighestGPA, mostInconsistentStudentId);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return isSuccess;
        }

    }
}
