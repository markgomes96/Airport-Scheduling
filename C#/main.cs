
// Referenced:
//     https://stackoverflow.com/questions/10826260/is-there-a-way-to-read-from-a-website-one-line-at-a-time
//

using System;
using System.IO;
using System.Net;


public class reader {
	static public void Main() {

		Airplane a = new Airplane(500, 0, 3000, 3000, new[] {""}, 0, 10, new[] {""});

		Console.WriteLine(a.Speed);


		Console.WriteLine("Finding coordinates of 'Memphis, TN'...");
		Console.WriteLine(Geolocator.findCoords("Memphis", "TN"));

	}
}

