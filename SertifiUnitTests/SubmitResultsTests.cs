using NUnit.Framework;
using SertifiTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SertifiUnitTests
{
    public class SubmitResultsTests
    {
        [Test]
        [TestCase("http://api")]
        public async Task PerformPUToperation_ShouldAssert_WhenUrlIsNotRight(string givenURL)
        {
            //Arrange                       
            var expectedURL = SertifiURLs.urlPUT;
            SubmitResults submitResults = new SubmitResults(givenURL);
            string jsonPayload = "";

            //Act
            var isSuccess = await submitResults.PerformPUToperation(jsonPayload);


            //Assert
            Assert.IsFalse(isSuccess);
            Assert.AreNotEqual(expectedURL, givenURL);
        }
    }
}
