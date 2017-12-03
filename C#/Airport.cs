using System;
using System.Collections.Generic;

public class Airport {

	public Location position;
	public string name;
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

