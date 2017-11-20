
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


		string url = "http://theochem.mercer.edu/csc330/data/airports.csv";
		WebReader wr = new WebReader(url);
		string line = wr.getLine();
		while(line != null) {
			Console.WriteLine(line);
			line = wr.getLine();
		}


	}
}

