using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SertifiTest
{
    public class SubmitResults
    {
        const string Name = "Vivek Kumar";
        const string Email = "kumarvivek02@gmail.com";

        public SubmitResults(string url)
        {
            URL = url;
        }

        public string URL { get; private set; }
         

        public void SubmitTestResults(int highestAttendanceYear, int highestGPAYear, List<int> top10HighestGPAStudents, int mostInconsistentStudentId)
        {
            var payload = CreatePayload(highestAttendanceYear, highestGPAYear, top10HighestGPAStudents, mostInconsistentStudentId);

            string json = JsonConvert.SerializeObject(payload, Formatting.Indented);
            Console.WriteLine(json);

            PerformPUToperation(json);
        }

        private async void PerformPUToperation(string json)
        {
            HttpClient client = new HttpClient();
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(URL,data).Result;

            var success = await response.Content.ReadAsStringAsync();
        }

        private TestSubmissionProfile CreatePayload(int highestAttendanceYear, int highestGPAYear, List<int> top10HighestGPAStudents, int mostInconsistentStudentId)
        {
           return new TestSubmissionProfile
            {
                YourName = Name,
                YourEmail = Email,
                YearWithHighestAttendance = highestAttendanceYear,
                YearWithHighestOverallGpa = highestGPAYear,
                Top10StudentIdsWithHighestGpa = top10HighestGPAStudents,
                StudentIdMostInconsistent = mostInconsistentStudentId

            };
        }
    }
}
