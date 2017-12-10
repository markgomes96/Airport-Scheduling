
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*---------------------------------------------------------
 * The Geolocator class provides several static methods
 * used for finding the average coordinates of cities
 * and finding distances between coordinates.
 *--------------------------------------------------------*/
public class Geolocator {


    /*---------------------------------------------------------
     * Method: findNearestAirport
     *
     * Purpose: Finds the nearest usable airport to some location
     *
     * Returns: Location of the nearest usable airport
     *--------------------------------------------------------*/
    public static Airport findNearestAirport(Location target){
		Location l = new Location(-1, -1, target.city, target.state);
		Airport result = new Airport("", l, false);
		result.position.city = target.city;
		result.position.state = target.state;

		double mindist = 5000;

		WebReader reader = new WebReader("http://theochem.mercer.edu/csc330/data/airports.csv");
		String line = reader.getLine();
		while(line != null) {

			Regex regex = new Regex("\".*?\"");
			line = regex.Replace(line, m => m.Value.Replace(',',' '));
			line = line.Replace("\"", "");
			String[] columns = line.Split(',');

			if(columns[2].Contains("airport")) {
				double lat = Double.Parse(columns[4]);
				double lon = Double.Parse(columns[5]);

				double dist = getDistance(target.latitude, target.longitude, lat, lon);
				if(dist < mindist) {
					mindist = dist;
					result.position.latitude = lat;
					result.position.longitude = lon;
					result.name = columns[3];
				}
			}

			line = reader.getLine();
		}

		return result;
    }
	/*---------------------------------------------------------
	 * Method: getDistance
	 *
	 * Purpose: Calculates the distance between two given coords
	 *
	 * Returns: A 'double' value of the distance in miles
	 *--------------------------------------------------------*/
	public static double getDistance(double lat1, double long1, double lat2, double long2) {

		// delta lat and delta longit
		double dlat = lat2 - lat1;
		double dlongit = long2 - long1;
		// Equitorial radius constant in miles
		double R = 3959.999;
		// Convert to radians
		double temp = Math.Pow((Math.Sin((dlat / 2) * (Math.PI / 180.0))), 2) + ((Math.Cos(lat1 * (Math.PI / 180.0))) * 
				(Math.Cos(lat2 * (Math.PI / 180.0))) * Math.Pow((Math.Sin((dlongit / 2) * (Math.PI / 180.0))), 2));
		double radian = Math.Asin(Math.Sqrt(temp));
		//Calculates the distance between geographic coordinates
		double d = 2 * R * radian;
		return d;
	}
	public static double getDistance(Location pos1, Location pos2) {
		return getDistance(pos1.latitude, pos1.longitude, pos2.latitude, pos2.longitude);
	}

	/*---------------------------------------------------------
	 * Method: findCoords
	 * 
	 * Purpose: Finds the averaged coordinates of a city
	 *          using the .csv file containing coordinates 
	 *          for various zip codes.
	 *
	 * Parameters: 
	 *   city - a string containing the name of the city
	 *   statecode - the 2-letter abbreviation for the state
	 * 
	 * Returns: A Location object.
	 *          Returns '-1, -1' as coords if the city 
	 *          is not found.
	 *--------------------------------------------------------*/
	public static Location findCoords(string city, string statecode) {

		double latSum = 0.0;
		double longSum = 0.0;
		int count = 0;

		// read through the .csv file
		// and sum the coordinates where the
		// city and statenames match
		string url = "http://theochem.mercer.edu/csc330/data/zip_codes_states.csv";
		WebReader reader = new WebReader(url);
		string line = reader.getLine();
		while(line != null) {
			string[] columns = line.Split(',');
			if(columns[3].Contains(city) && columns[4].Contains(statecode)) {
				try {
					latSum += Double.Parse(columns[1]);
					longSum += Double.Parse(columns[2]);
					count++;
				} catch (FormatException) {}
			}
			line = reader.getLine();
		}

		if(count==0) 
			return new Location(-1.0, -1.0, city, statecode);
		return new Location((latSum/count), (longSum/count), city, statecode);
	}

}

public struct Location {
    public double latitude, longitude;
    public string city, state;

    public Location(double lat, double lon, string city, string state) {
        this.latitude = lat;
        this.longitude = lon;
        this.city = city;
        this.state = state;
    }
}
