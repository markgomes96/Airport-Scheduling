
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

	/*---------------------------------------------------------
	 * Method: CreateAirportDatabase
	 *
	 * Purpose: Find all usable airports
	 *
	 * Returns: A list of all usable airport objects
	 *--------------------------------------------------------*/
/*	public static List<Airport> CreateAirportDatabase()
	{
		List<Airport> apdb = new List<Airport>();    //list of airport objects to store all usable airports

		string url_airports = "http://theochem.mercer.edu/csc330/data/airports.csv";
		WebReader wr = new WebReader(url_airports);              //reads in the airport file
		string line = wr.getLine();
		String[] apdata;

		while(line != null)       //iterates through the airport file
		{
			line = line.Replace('"',' ');        //manipulates the data by splitting it up into an array
			apdata = line.Split(',');
			//Goes through multiple checks so only relavent data is processed
			if(apdata[8].Trim().Equals("US", StringComparison.Ordinal) || apdata[8].Trim().Equals("PR", StringComparison.Ordinal) || apdata[8].Trim().Equals("AS", StringComparison.Ordinal))
			{
				if(apdata[2].Trim().Equals("small_airport", StringComparison.Ordinal) || apdata[2].Trim().Equals("large_airport", StringComparison.Ordinal))
				{
					if(apdata[11].Trim().Equals("no", StringComparison.Ordinal))
					{
						//adds a new airport object with all relevant data from airport file
						apdb.Add(new Airport(Int32.Parse(apdata[0].Trim()), apdata[3].Trim(), Convert.ToDouble(apdata[4].Trim()), Convert.ToDouble(apdata[5].Trim()), 
									apdata[8].Trim(), apdata[9].Substring(4,2), apdata[10].Trim(), apdata[12].Trim(), 0, " ", 0));
					}
				}
			}
			line = wr.getLine();
		}

		string url_runways = "http://theochem.mercer.edu/csc330/data/runways.csv";
		wr = new WebReader(url_runways);        //reads in the runway file
		line = wr.getLine();    line = wr.getLine();      //skips header line
		int index = -1;

		while(line != null)       //iterates throught runway file
		{
			line = line.Replace('"',' ');
			apdata = line.Split(',');
			index = apdb.FindIndex(x => x.Id == Int32.Parse(apdata[1].Trim()));    //check if runway Id matches any airport Id
			if(index != -1)
			{
				//adds relevant data from runway file to objects created from airport file
				apdb[index].RW_length = Int32.Parse(apdata[3].Trim());
				apdb[index].RW_surface = apdata[5].Trim();
				apdb[index].Lighted = Int32.Parse(apdata[6].Trim());
			}
			line = wr.getLine();
		}

		for(int i = 0; i < apdb.Count; i++)        //displays all airport objects and some of their data
		{
			Console.WriteLine(i + " : " + apdb[i].Name + " : " + apdb[i].Country + " : " + apdb[i].State + " : " + apdb[i].RW_length);
		}
		return apdb;
	}
*/

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
