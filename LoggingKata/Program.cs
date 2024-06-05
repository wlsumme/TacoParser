using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            

            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            if(lines.Length == 0)
            {
                logger.LogError("Not enough info");
            }
            else if (lines.Length == 1) 
            {
                logger.LogWarning("warning only one line has been added");
            }


           
            logger.LogInfo($"Lines: {lines[0]}");

            
            var parser = new TacoParser();

            
            var locations = lines.Select(parser.Parse).ToArray();

  
            
            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;
            
           
            double distance = 0;

            
            for(int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for(int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var distanceBetween = corA.GetDistanceTo(corB);  

                    if(distanceBetween > distance)
                    {
                        distance = distanceBetween;
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
            }

            

            logger.LogInfo($"{tacoBellOne.Name} and {tacoBellTwo.Name} has the greatest distance between them. they are {distance} meters apart, or {Math.Round(distance * 0.00062)} miles");


            
        }
    }
}
