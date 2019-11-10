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
            var response = await client.GetAsync(URL);

            var responseAsString = await ReadHttpResponseAsString(response);

            var studentProfiles = DeserializeInputStringToStudentProfile(responseAsString);

            return studentProfiles;
        }

        private async Task<string> ReadHttpResponseAsString(HttpResponseMessage httpResponseMessage)
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
