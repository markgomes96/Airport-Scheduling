using System;

public class Airplane
{
  
  //help gotten from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects
  public int Speed {get; set;}
  public double Miles_Flown {get; set;}
  public double Miles_Before_Refill {get; set;}
  public int Runway_Len {get; set;}
  public string[] Surfaces {get; set;}
  public int Passengers {get; set;}
  public int Capacity {get; set;}
  public string[] Passengers {get; set;}
  
  public Airplane(int speed, double miles_flown, double miles_before_refill, int runway_len, string[] surfaces, int passengers, int capacity, string[] passengers)
  {
  
    int Speed = speed; //cruising speed of plane in mph
    double Miles_Flown = miles_flown; //miles flown in a day
    double Miles_Before_Refill = miles_before_refill; //miles left before plane needs to refill
    int Runway_Len = runway_len; //length of runway needed (minimum)
    string[] Surfaces = surfaces; //array of surfaces plane can land on
    int Passengers = passengers; //number of passengers on board
    int Capacity = capacity; //maximum amount of passengers
    string[] Passengers = passengers; //array of passengers currently on board
  
  }

}