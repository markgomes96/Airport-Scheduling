using System;

public class Passenger {

	public string firstname, lastname;
	public Location origin, destination;

	public Passenger() {
		this.firstname = null;
		this.lastname = null;
		this.origin = new Location();
		this.destination = new Location();
	}

	/*---------------------------------------------------------
	 * Constructor
	 * Parameters:
	 *   f, l - first and lastnames
	 *   c0, s0 - origin city and statecode
	 *   c1, s1 - destination city and statecode
	 *
	 *--------------------------------------------------------*/
	public Passenger(string f, string l, string c0, string s0, string c1, string s1) {
		this.firstname = f;
		this.lastname = l;
		this.origin = Geolocator.findCoords(c0, s0);
		this.destination = Geolocator.findCoords(c1, s1);
	}
}
