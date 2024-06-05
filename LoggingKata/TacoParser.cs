namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo($"Parsing {line}");


            var cells = line.Split(',');


            if (cells.Length < 3)
            {
                logger.LogError("There should be at least three lines.");
                return null;
            }

            var lat = double.Parse(cells[0]);


            var lon = double.Parse(cells[1]);




            var name = cells[2];





            var location = new Point(lat, lon);


            var tacoBell = new TacoBell(name, location);



            return tacoBell;
        }
    }
}
