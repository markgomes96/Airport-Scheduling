
using System;
using System.Collections.Generic;


public class main {

	static public void Main() {
		List<Passenger> people = getPassengers();
		foreach (Passenger p in people) {
			Console.WriteLine(p);
		}
	}

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
}


