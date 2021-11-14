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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            int lineCounter = 0;
            foreach (var line in lines)
            {
                lineCounter++;
            }
            switch (lineCounter)
            {
                case 0:
                    logger.LogError("0 lines read from input file");
                    break;
                case 1:
                    logger.LogError("1 line read from input file");
                    break;
                default:
                    logger.LogInfo($"Lines: {lines[0]}");
                    break;
            }


            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();


            logger.LogInfo("Lets start parsing...");
            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            double distance = 0;
            var zeroPoint = new Point() { Latitude = 0, Longitude = 0 };
            var tacoBell1 = new TacoBell() { Name = null, Location = zeroPoint };
            var tacoBell2 = new TacoBell() { Name = null, Location = zeroPoint };


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            logger.LogInfo($"Checking {lineCounter} locations...");
            for (var i=0;i<lineCounter;i++)
            {
                logger.LogInfo($"look at line {lines[i]}");
                var startName = new StoreLocation().GetStoreLocation(lines[i]);
                var startLatitude = new Latitude().GetLatitude(lines[i]);
                var startLongitude = new Longitude().GetLongitude(lines[i]);
                for (var r = 0; r < lineCounter; r++)
                {
                    if (i!=r)
                    {
                        logger.LogInfo($"compair to line {lines[r]}");
                        var endName = new StoreLocation().GetStoreLocation(lines[r]);
                        var endLatitude = new Latitude().GetLatitude(lines[r]);
                        var endLongitude = new Longitude().GetLongitude(lines[r]);


                        var sCoord = new GeoCoordinate(startLatitude, startLongitude);
                        var eCoord = new GeoCoordinate(endLatitude, endLongitude);
                        var localDistance = sCoord.GetDistanceTo(eCoord);

                        logger.LogInfo($"compute the distance i={i}r={r}:  ({startLatitude},{startLongitude} x {endLatitude},{endLongitude})  distance={localDistance}");

                        if (localDistance > distance)
                        {
                            distance = localDistance;
                            tacoBell1.Name = startName;
                            tacoBell2.Name = endName;

                            var tempPoint = new Point();
                            tempPoint.Latitude = startLatitude;
                            tempPoint.Longitude = startLongitude;
                            tacoBell1.Location = tempPoint;

                            tempPoint.Latitude = endLatitude;
                            tempPoint.Longitude = endLongitude;
                            tacoBell2.Location = tempPoint;
                            logger.LogInfo($"Save new farthest pair");
                        }

                    }
                }
            }
            logger.LogInfo($"The 2 locations farthest from each other are {tacoBell1.Name} and {tacoBell2.Name}");

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            Console.WriteLine("");
            Console.WriteLine($"The farthest distance computed was {distance}");
            Console.WriteLine($"This is the distance from {tacoBell1.Name} at coordinates ({tacoBell1.Location.Latitude},{tacoBell1.Location.Longitude}) to");
            Console.WriteLine($"{tacoBell2.Name} at coordinates ({tacoBell2.Location.Latitude},{tacoBell2.Location.Longitude}).");

        }
    }
}
