
using System;
using System.IO;
using System.Collections.Generic;


public class main {

	static public void Main(string[] args) {

		double MONIES = 0;
		List<Passenger> people;
		List<Airport> airports = new List<Airport>();
		if(args.Length > 0)
			people = readCSV(args[0]);
		else
			people = getPassengers();

		Console.WriteLine("--------------------------------");		
		Console.WriteLine("PASSENGERS");		
		Console.WriteLine("--------------------------------");		
		foreach (Passenger p in people) {
			Console.WriteLine("\t" + p);
		} 

		airports = getAirports(people, airports);

		Console.WriteLine("--------------------------------");		
		Console.WriteLine("AIRPORTS");		
		Console.WriteLine("--------------------------------");		
		foreach (Airport port in airports) {
			Console.WriteLine(port);
		}


		// get the starting airport
		Airport next = airports[0];
		foreach(Airport port in airports) {
			if(port.departing.Count > next.departing.Count) {
				next = port;
			}
		}
		Console.WriteLine("STARTING AIRPORT: " + next.name);

		// instantiate plane at the starting airport
		Airplane airplane = new Airplane(next.position);

		Console.WriteLine("--------------------------------");		
		Console.WriteLine("ITINERARY");		
		Console.WriteLine("--------------------------------");		
		while(airplane.timeElapsed < 15 && airports.Count > 0) {// && airplane.passengers.Count>0) {

			// add new passengers
			for(int i = 0; i < next.departing.Count; i++) {
				airplane.passengers.Add(next.departing[i]);
				Console.WriteLine("\tBoarding: " + next.departing[i].firstname);
				next.departing.Remove(next.departing[i]);
				i--;
			}

			// kick out passengers
			for(int i = 0; i < next.arriving.Count; i++) {
				if(airplane.passengers.Contains(next.arriving[i])) {
					airplane.passengers.Remove(next.arriving[i]);
					Console.WriteLine("\tUnloading: " + next.arriving[i].firstname);
					MONIES += next.arriving[i].price;
					next.arriving.Remove(next.arriving[i]);
					i--;
				}
			}

			// print status of plane
			Console.WriteLine(airplane);

			// remove useless airports
			if(next.arriving.Count < 1 && next.departing.Count < 1) {
				airports.Remove(next);
			}

			// pick and travel to the next airport
			Airport current = next;
			double distance = 3000;
			foreach(Airport port in airports) {
				double tmp = Geolocator.getDistance(current.position, port.position);
			 	List<Passenger> common = checkItBeach(port.arriving, airplane.passengers);
				if(tmp > 0 && tmp < distance && (common.Count > 0 || port.departing.Count > 0)) {
					next = port;
					distance = tmp;
				}
			}

			if(next != current) {	
				Console.WriteLine("GOING TO --> " + next.position.city + ", " + next.position.state + " | " + next.name + " at " + next.position.latitude + ", " + next.position.longitude);
				Console.WriteLine(distance + " miles away");
				airplane.travel(next.position);
			}
	
		}

		Console.WriteLine("--------------------------------");		
		Console.WriteLine("RESULTS");		
		Console.WriteLine("--------------------------------");
		Console.WriteLine(airplane);
		Console.WriteLine("INCOME = " + MONIES);
		Console.WriteLine("LOSS = " + airplane.cost);
		Console.WriteLine("PROFIT = " + (MONIES - airplane.cost));

	}

    /*---------------------------------------------------------
     * Method: readCSV
     *
     * Purpose: Reads in passengers via CSV file
     *
     * Returns: List of Passenger objects
     *--------------------------------------------------------*/
	static public List<Passenger> readCSV(string filename) {

		List<Passenger> people = new List<Passenger>();

		if(!File.Exists(filename)) {
			Console.WriteLine("File: '" + filename + "' not found!\nQuitting...");
			return people;
		}
		Console.WriteLine("Reading possible customers from '" + filename +"'");

		System.IO.StreamReader infile = new System.IO.StreamReader(filename);
		string line;
		while( (line = infile.ReadLine()) != null) {
			string[] attrib = line.Split(',');
			people.Add( new Passenger(attrib[0], attrib[1], attrib[2], attrib[3], attrib[4], attrib[5]) );
		}

		return people;
	}

    /*---------------------------------------------------------
     * Method: getPassengers
     *
     * Purpose: Reads in passengers via keyboard input
     *
     * Returns: List of Passenger objects
     *--------------------------------------------------------*/
	static public List<Passenger> getPassengers() {
		List<Passenger> people = new List<Passenger>();

		Console.Clear();
		Console.WriteLine("Flight Itinerary Builder Program \n");
		Console.Write("Do you want to add a passenger to your itinerary list (Y/N)? ");
		string line = Console.ReadLine();
		while(line.ToLower().Equals("y")) {
			Console.Write("First Name: ");
			string fname = Console.ReadLine();
			Console.Write("Last Name: ");
			string lname = Console.ReadLine();

			Location opos = new Location(-1, -1, "", "");
			while(opos.latitude == -1) {
				Console.Write("Origination City: ");
				string ocity = Console.ReadLine();
				Console.Write("Origination State (two letter code): ");
				string ostate = Console.ReadLine();
				opos = Geolocator.findCoords(ocity, ostate);
				if(opos.latitude == -1)
					Console.WriteLine("\t ***CITY NOT ON FILE***");
			} 

			Location dpos = new Location(-1, -1, "", "");
			while(dpos.latitude == -1) {
				Console.Write("Destination City: ");
				string dcity = Console.ReadLine();
				Console.Write("Destination State (two letter code): ");
				string dstate = Console.ReadLine();
				dpos = Geolocator.findCoords(dcity, dstate);
				if(dpos.latitude == -1)
					Console.WriteLine("\t ***CITY NOT ON FILE***");
			}

			Passenger p = new Passenger(fname, lname, opos, dpos);
			people.Add(p);

			Console.Write("Do you want to add a passenger to your itinerary list (Y/N)? ");
			line = Console.ReadLine();
		}
		Console.WriteLine("** GENERATING ITINERARY **");
		return people;
	}

    /*---------------------------------------------------------
     * Method: getAiports
     *
     * Purpose: Generates the list of airports needed by passengers
     *
     * Returns: List of relevant Airport objects
     *--------------------------------------------------------*/
	static public List<Airport> getAirports(List<Passenger> people, List<Airport> airports) {
		foreach (Passenger p in people) {
			bool depart = false;
			bool arrive = false;
			/*----------------------------------
			 * First check to see if the 
			 * airport has already been found.
			-----------------------------------*/
			foreach (Airport port in airports) {
				if(p.origin.city == port.position.city && p.origin.state == port.position.state) {
					port.departing.Add(p);
					depart = true;
				}
				if(p.destination.city == port.position.city && p.destination.state == port.position.state) {
					port.arriving.Add(p);
					arrive = true;
				}
			}
			/*----------------------------------
			 * If it was not found,
			 * find it and add to list.
			-----------------------------------*/
			if(!depart) {
				Airport a = Geolocator.findNearestAirport(p.origin);
				a.departing.Add(p);
				airports.Add(a);
			}
			if(!arrive) {
				Airport a = Geolocator.findNearestAirport(p.destination);
				a.arriving.Add(p);
				airports.Add(a);
			}
		}
		return airports;

	}

    /*---------------------------------------------------------
     * Method: checkItBeach
     *
     * Purpose: Find common elements of two lists
     *
     * Returns: List of common elements
     *--------------------------------------------------------*/
	static public List<Passenger> checkItBeach(List<Passenger> a, List<Passenger> b) {
		List<Passenger> result = new List<Passenger>();

		foreach(Passenger x in a) {
			if(b.Contains(x)) {
				result.Add(x);
			}
		}

		return result;
	}
}

