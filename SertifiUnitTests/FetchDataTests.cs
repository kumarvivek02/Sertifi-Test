using NUnit.Framework;
using SertifiTest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class FetchDataTests
    {          

        [SetUp]
        public void Setup()
        {     
            
        }

        [Test]
        public async Task GetStudentProfilesAsync_ShouldReturnValidList_WhenURLIsValid()
        {
            //Arrange
            FetchData fetchData = new FetchData(SertifiURLs.urlGET);
            
            //Act
            var results = await fetchData.GetStudentProfilesAsync();

            //Assert
            Assert.That(results, Is.InstanceOf<List<StudentProfile>>());
        }

        [Test]
        [TestCase("http://apitest.sertifi.net/api/Students")]
        public    void GetStudentProfilesAsync_ShouldAssert_WhenURLDoesNotMatch(string givenURL)
        {
            //Arrange                       
            var expectedURL = SertifiURLs.urlGET;


            //Act


            //Assert
            Assert.AreEqual(givenURL, expectedURL);           
        }
    }
}