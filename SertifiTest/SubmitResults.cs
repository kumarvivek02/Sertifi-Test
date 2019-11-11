using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public bool SubmitTestResults(int highestAttendanceYear, int highestGPAYear, List<int> top10HighestGPAStudents, int mostInconsistentStudentId)
        {
            var payload = CreatePayload(highestAttendanceYear, highestGPAYear, top10HighestGPAStudents, mostInconsistentStudentId);

            string json = JsonConvert.SerializeObject(payload, Formatting.Indented);
            Console.WriteLine("*************JSON PAYLOAD BEING SUBMITTED*************");
            Console.WriteLine(json);
            Console.WriteLine("*************End of JSON PAYLOAD*************");

            return PerformPUToperation(json).Result;
        }

        public async Task<bool> PerformPUToperation(string json)
        {
            HttpClient client = new HttpClient();
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage= new HttpResponseMessage();

            try
            {
                responseMessage = await client.PutAsync(URL, data);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception {0}",ex.Message);
                responseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;

            }            
            return responseMessage.IsSuccessStatusCode;
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
