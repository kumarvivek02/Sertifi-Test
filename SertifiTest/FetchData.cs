using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SertifiTest
{
    public class FetchData : IFetchData
    {
        public FetchData(string url)
        {
            URL = url;
        }

        public string URL { get; private set; }

        public async Task<IEnumerable<StudentProfile>> GetStudentProfilesAsync()
        {
            HttpClient client = new HttpClient();
            IEnumerable<StudentProfile> studentProfiles = new List<StudentProfile>();
            try
            {
                var response = await client.GetAsync(URL);

                var responseAsString = await ReadHttpResponseAsStringAsync(response);

                studentProfiles = DeserializeInputStringToStudentProfile(responseAsString);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return studentProfiles;
        }

        private async Task<string> ReadHttpResponseAsStringAsync(HttpResponseMessage httpResponseMessage)
        {
            return await httpResponseMessage.Content.ReadAsStringAsync();          
        }

        private  IEnumerable<StudentProfile> DeserializeInputStringToStudentProfile(string inputResponse)
        {
            var result =  JsonConvert.DeserializeObject<IEnumerable<StudentProfile>>(inputResponse);
            return result;
        }        

        public bool ValidateUrl()
        {
            return URL.Contains(".com"); //Add some validation logic
        }
    }
}
