using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class Longitude
    {
        public double GetLongitude(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return 0;
            } else
            {
                return double.Parse(cells[1]);
            }
        }
    }

    public class Latitude
    {
        public double GetLatitude(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return 0;
            }
            else
            {
                return double.Parse(cells[0]);
            }
        }
    }
    public class StoreLocation
    {
        public string GetStoreLocation(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return "";
            }
            else
            {
                return cells[2].Trim();
            }
        }
    }

}
