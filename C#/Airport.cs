using System;
using System.Collections.Generic;

/*---------------------------------------------------------
 * The Airport class holds data about its location and
 * passengers departing from or arriving to the airport. 
 * 
 * The 'position' should store the city and state name
 * it has been found to be nearest to, and the actual 
 * lat and long that belong to the airport.
 *--------------------------------------------------------*/
public class Airport {

	public string name;
	public Location position;
	public List<Passenger> departing;
	public List<Passenger> arriving;
	public bool lighted;

	public Airport(string name = null, Location pos = new Location(), bool lighted = false) {
		this.name = name;
		this.position = pos;
		this.departing = new List<Passenger>();
		this.arriving = new List<Passenger>();
		this.lighted = false;
	}

}

