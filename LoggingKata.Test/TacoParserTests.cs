using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tester = new StoreLocation();

            //Act
            var actual = tester.GetStoreLocation("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.Equal("Taco Bell Acwort...", actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
                var tester = new Longitude();
            //Act
                var actual = tester.GetLongitude(line);
            //Assert
                Assert.Equal(expected, actual);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tester = new Latitude();
            //Act
            var actual = tester.GetLatitude(line);
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
