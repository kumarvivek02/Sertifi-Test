using NUnit.Framework;
using SertifiTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SertifiUnitTests
{
    public class AnalyzeHighestGPAYearTests
    {
        [Test]
        public   void YearOfHighestGPA_ShouldReturn0_WhenInputListIsNullOrEmpty()
        {
            //Arrange
            AnalyzeHighestGPAYear analyzeHighestGPAYear = new AnalyzeHighestGPAYear();
            IEnumerable<StudentProfile> studentProfilesNull = null;
            IEnumerable<StudentProfile> studentProfilesEmpty = new List<StudentProfile>();
            
            //Act
            var resultsWhenInputIsNull = analyzeHighestGPAYear.YearOfHighestGPA(studentProfilesNull);
            var resultWhenInputIs0 = analyzeHighestGPAYear.YearOfHighestGPA(studentProfilesEmpty);

            //Assert
            Assert.AreEqual(resultsWhenInputIsNull, 0);
            Assert.AreEqual(resultWhenInputIs0, 0);
        }
    }
}
