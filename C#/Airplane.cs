using System;
using System.Collections.Generic;

public class Airplane {

	public double landingTime, refuelTime;
	public double speed;
	public double distance, fuel;
	public double timeElapsed;
	public double rate, cost;
	public List<Passenger> passengers;
	public Location position;

	public Airplane(Location start) {
		this.landingTime = 0.5;
		this.refuelTime = 0.25;
		this.speed = 515;
		this.distance = 0;
		this.fuel = 3000;
		this.rate = 2.75;
		this.timeElapsed = 0;
		this.passengers = new List<Passenger>();
		this.position = start;
	}

	/*---------------------------------------------------------
	 * Method: land
	 *
	 * Purpose: 'land' the plane and step the timer
	 *--------------------------------------------------------*/
	public void land() {
		this.timeElapsed += this.landingTime;
	}

	/*---------------------------------------------------------
	 * Method: refuel
	 *
	 * Purpose: 'refuel' the plane and step the timer
	 *--------------------------------------------------------*/
	public void refuel() {
		this.fuel = 3000;
		this.timeElapsed += this.refuelTime;
	}

	/*---------------------------------------------------------
	 * Method: travel
	 *
	 * Purpose: move the plane to another location
	 * 
	 * Returns: true if the plane is able to reach destination
	 *          false if the plane does not have enough fuel
	 *--------------------------------------------------------*/
	public bool travel(Location dest) {
		double difference = Geolocator.getDistance(this.position, dest);
		if(this.fuel - difference < 0) {
			this.refuel();
		}
		this.fuel -= difference;
		this.distance += difference;
		this.cost += difference*rate;
		this.timeElapsed += difference/speed;
		this.position = dest;
		this.land();
		return true;
	}

	/*---------------------------------------------------------
	 * Method: addPassenger
	 *
	 * Purpose: Load a passenger into the plane
	 *
	 * Returns: true if the passenger will fit
	 *          false if the plane is already full
	 *--------------------------------------------------------*/
/*	public bool addPassenger(Passenger p) {
		for(int i = 0; i < 10; i++) {
			if(this.passengers[i] == null) {
				this.passengers[i] = p;
				return true;
			}
		}
		return false;
	}

	/*---------------------------------------------------------
	 * Method: unload
	 *
	 * Purpose: remove all passengers who have arrived at dest
	 *--------------------------------------------------------*/
/*	public void unload() {
		for(int i = 0; i < 10; i++) {
			if(this.passengers[i].destination.city == this.position.city)
				if(this.passengers[i].destination.state == this.position.state)
					this.passengers[i] = null;
		}
	}
*/


	public override string ToString() {
		string result = "Plane at: " + this.position.latitude + ", " + this.position.longitude + "\n";
		result += "\tFuel remaining: " + this.fuel  + "\n";
		result += "\tDistance travelled: " + this.distance  + "\n";
		result += "\tTime elapsed: " + this.timeElapsed  + "\n";
		result += "\tTotal cost: " + this.cost  + "\n";
		result += "\tPlane contains:\n\t\t";
		foreach(Passenger p in passengers) {
			result += p.firstname + ", ";
		}
		return result;
	}
}
