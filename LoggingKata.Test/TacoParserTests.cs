using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.556383, -86.889051, Taco Bell Birmingha...", -86.889051)]
        [InlineData("34.095209,-84.011894,Taco Bell Bufor...", -84.011894)]
        [InlineData("31.440529,-86.953648,Taco Bell Evergreen...", -86.953648)]
        [InlineData("34.719613,-86.578994,Taco Bell Huntsville...", -86.578994)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        public void ShouldParseLongitude(string line, double expected)
        {
           
            var tacoParse = new TacoParser();
          
            var actual = tacoParse.Parse(line);

            Assert.Equal(expected, actual.Location.Longitude);
        }


        


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.556383, -86.889051, Taco Bell Birmingha...", 33.556383)]
        [InlineData("34.095209,-84.011894,Taco Bell Bufor...", 34.095209)]
        [InlineData("31.440529,-86.953648,Taco Bell Evergreen...", 31.440529)]
        [InlineData("34.719613,-86.578994,Taco Bell Huntsville...", 34.719613)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }


    }
}
