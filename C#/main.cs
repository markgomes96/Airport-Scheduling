
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
      static public void userInput() {
            bool flight = true;
            string choice;
            Passenger user = new Passenger();
            Console.WriteLine("Flight Itinerary Builder Program \n");
            while(flight == true)
            {
                  Console.Write("Do you want to add a passenger to your itinerary list (Y/N)? ");
                  choice = Console.ReadLine();
                  if(choice == "Y" || choice == "y")  //User wants to add passenger
                  {
                        Console.Write("First Name: ");
                        user.firstname = Console.ReadLine();
                        Console.Write("Last Name: ");
                        user.lastname = Console.ReadLine();
                        Console.Write("Origination City: ");
                        user.origin.city = Console.ReadLine();
                        Console.Write("Origination State (two letter code): ");
                        user.origin.state = Console.ReadLine();
                        Console.Write("Destination City: ");
                        user.destination.city = Console.ReadLine();
                        Console.Write("Destination State (two letter code): ");
                        user.destination.state = Console.ReadLine();
                        Console.WriteLine();
                  }
                  else if(choice == "N" || choice == "n")  //User done adding passengers
                  {
                        flight = false;
                        Console.WriteLine();
                        Console.WriteLine("** Generating Itinerary **");
                  }
                  else  //User input is wrong
                  {
                        Console.WriteLine("\t *** Please Type Y or N ***");
                  }
            }
      }
}

