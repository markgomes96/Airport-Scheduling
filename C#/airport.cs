using System;

public class Airport
{
	public int Id {get; set;}
	public string Name {get; set;}
	public double Latitude {get; set;}
	public double Longitude {get; set;}
	public string Country {get; set;}
	public string State {get; set;}
	public string Manicipality {get; set;}
	public string GPScode {get; set;}
	public int RW_length {get; set;}
	public string RW_surface {get; set;}
	public int Lighted {get; set;}

	public Airport(int id, string name, double latitude, double longitude, string country, string state, string manicipality, string gpscode, int rw_length, string rw_surface, int lighted)
	{
		this.Id = id;                      //identifies the airport, connects them between airport and runway datasheets
		this.Name = name;                  //name of the airport
		this.Latitude = latitude;          //coordinates of the airport
		this.Longitude = longitude;
		this.Country = country;            //country of operation for airport
		this.State = state;              //state or area of the airport
		this.Manicipality = manicipality;  //city or location of the airport
		this.GPScode = gpscode;    
		this.RW_length = rw_length;        //length of the runway [feet]
		this.RW_surface = rw_surface;      //surface type of the runway -> ASPH-G, GRVL, TURF, GRASS, CONC
		this.Lighted = lighted;            //whether or not the runway is lighted -> 0:no, 1:yes
	}
}

