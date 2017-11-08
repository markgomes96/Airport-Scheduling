#!/usr/bin/perl
#This code will perform calculations for the uber plane project
use POSIX;
use Math::Trig;

      distance();
      sub distance()
      {
            #Latitude coordinates
            $lat1 = 32.828819;
            $lat2 = 29.951061;
            #Longitude coordinates
            $longit1 = -83.649777;
            $longit2 = -90.081244;
            #Delta lat. and delta longit.
            $dlat = $lat2 - $lat1;
            $dlongit = $longit2 - $longit1;
            #Given equitorial radius constant in miles
            $R = 3959.999;
            #Had to convert to Radians
            $temp = ((sin(($dlat / 2) * (pi / 180.0)))**2) + ((cos($lat1 * (pi / 180.0))) * 
                          (cos($lat2 * (pi / 180.0))) * ((sin(($dlongit / 2) * (pi / 180.0)))**2));
            $radian = asin(sqrt($temp));
            #Calculates the distance between geographic coordinates
            $d = 2 * $R * $radian;
            print("delta Lat = $dlat\n");
            print("delta Long = $dlongit\n");
            print("Temp = $temp\n");
            print("Distance = $d\n");
            print("Distance should be appr. 428.09 miles\n");
      }
