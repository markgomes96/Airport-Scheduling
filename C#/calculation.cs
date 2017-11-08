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
            double lat2 = 29.951061;
            //Longitude coordinates
            double longit1 = -83.649777;
            double longit2 = -90.081244;
            //Delta lat. and delta longit.
            double dlat = lat2 - lat1;
            double dlongit = longit2 - longit1;
            //Given equitorial radius constant in miles
            double R = 3959.999;
            //Had to convert to Radians
            double temp = Math.Pow((Math.Sin((dlat / 2) * (Math.PI / 180.0))), 2) + ((Math.Cos(lat1 * (Math.PI / 180.0))) * 
                          (Math.Cos(lat2 * (Math.PI / 180.0))) * Math.Pow((Math.Sin((dlongit / 2) * (Math.PI / 180.0))), 2));
            double radian = Math.Asin(Math.Sqrt(temp)); //* (180.0 / Math.PI);
            //Calculates the distance between geographic coordinates
            double d = 2 * R * radian;
            Console.WriteLine("delta Lat = " + dlat);
            Console.WriteLine("delta Long = " + dlongit);
            Console.WriteLine("Temp = " + temp);
            Console.WriteLine("Distance = " + d);
            Console.WriteLine("Distance should be appr. 428.09 miles");
      }
}
