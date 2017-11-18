using System;

public class Airplane
{
  
  //help gotten from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects
  public int Speed {get; set;}
  public double Miles_Flown {get; set;}
  public double Miles_Before_Refill {get; set;}
  public int Runway_Len {get; set;}
  public string[] Surfaces {get; set;}
  public int Num_Passengers {get; set;}
  public int Capacity {get; set;}
  public string[] Passengers {get; set;}
  
  public Airplane(int speed, double miles_flown, double miles_before_refill, int runway_len, string[] surfaces, int num_passengers, int capacity, string[] passengers)
  {
  
    this.Speed = speed; //cruising speed of plane in mph
    this.Miles_Flown = miles_flown; //miles flown in a day
    this.Miles_Before_Refill = miles_before_refill; //miles left before plane needs to refill
    this.Runway_Len = runway_len; //length of runway needed (minimum)
    this.Surfaces = surfaces; //array of surfaces plane can land on
    this.Num_Passengers = num_passengers; //number of passengers on board
    this.Capacity = capacity; //maximum amount of passengers
    this.Passengers = passengers; //array of passengers currently on board
  
  }

}
