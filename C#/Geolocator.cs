
using System;
using System.Collections;


/*---------------------------------------------------------
* The Geolocator class provides several static methods
* used for finding the average coordinates of cities
* and finding distances between coordinates.
*--------------------------------------------------------*/
public class Geolocator {

	/*---------------------------------------------------------
	* Method: getDistance
	*
	* Purpose: Calculates the distance between two given coords
	*
	* Returns: A 'double' value of the distance
	*--------------------------------------------------------*/
	public static double getDistance(double lat1, double long1, double lat2, double long2) {
		//
		// TODO:
		//   Implement this method using the equation 
		//   given to us by Dr. Pounds.
		//   Refer to 'calculation.cs' for a working demo
		//
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
	* Returns: A string with the lat and long separated
	*          by a comma.
	*--------------------------------------------------------*/
	public static string findCoords(string city, string statecode) {

		// 2 ArrayLists to store the coordinates
		// for every zip code in the requested city
		ArrayList lats = new ArrayList();
		ArrayList longs = new ArrayList();

		// read through the .csv file
		// and save the coordinates where the
		// city and statenames match
		string url = "http://theochem.mercer.edu/csc330/data/zip_codes_states.csv";
		WebReader reader = new WebReader(url);
		string line = reader.getLine();
		while(line != null) {
			string[] columns = line.Split(',');
			if(columns[3].Contains(city) && columns[4].Contains(statecode)) {
				lats.Add( Double.Parse(columns[1]) );
				longs.Add( Double.Parse(columns[2]) );
			}
			line = reader.getLine();
		}

		// average the lats and longs
		double latSum = 0.0;
		double longSum = 0.0;
		foreach(double x in lats) {
			latSum += x;
		}
		foreach(double x in longs) {
			longSum += x;
		}

		return (latSum/lats.Count) + ", " + (longSum/longs.Count);
	}

}

