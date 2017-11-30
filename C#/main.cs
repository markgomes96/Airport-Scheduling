
using System;
using System.IO;
using System.Net;


public class reader {
    static public void Main() {

		Passenger p = new Passenger("Jules", "Winnfield", "Memphis", "TN", "Atlanta", "GA");
        Console.WriteLine("name:");
        Console.WriteLine("\t" + p.firstname + " " + p.lastname);
        Console.WriteLine("origin:");
        Console.WriteLine("\t" + p.origin.city + ", " + p.origin.state);
        Console.WriteLine("\t" + p.origin.latitude + ", " + p.origin.longitude);
        Console.WriteLine("destination:");
        Console.WriteLine("\t" + p.destination.city + ", " + p.destination.state);
        Console.WriteLine("\t" + p.destination.latitude + ", " + p.destination.longitude);
        Console.WriteLine("ticket:");
        Console.WriteLine("\tdistance: " + p.distance + " miles");
        Console.WriteLine("\tprice: $" + p.price);
    }
}

