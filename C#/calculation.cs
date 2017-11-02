//This Program is for all calculations involved with uber project
using System;

public class Calc
{
      static public void Main()
      {
            distance();
      }
      static void distance()
      {
            //Latitude coordinates
            double lat1 = 32.828819;
            double lat2 = 29.951067;
            //Longitude coordinates
            double longit1 = -83.649777;
            double longit2 = -90.081260;
            //Delta lat. and delta longit.
            double dlat = lat2 - lat1;
            double dlongit = longit2 - longit1;
            //Given equitorial radius constant in miles
            double R = 3959.999;
            double temp = Math.Pow(Math.Sin(dlat / 2), 2) + (Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlongit / 2), 2));
            //Calculates the distance between geographic coordinates
            double d = 2 * R * Math.Asin(Math.Sqrt(temp));
            Console.WriteLine("delta Lat = " + dlat);
            Console.WriteLine("delta Long = " + dlongit);
            Console.WriteLine("Temp = " + temp);
            Console.WriteLine("Distance = " + d);
      }
}
