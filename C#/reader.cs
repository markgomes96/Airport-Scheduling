
// Referenced:
//     https://stackoverflow.com/questions/10826260/is-there-a-way-to-read-from-a-website-one-line-at-a-time
//

using System;
using System.IO;
using System.Net;


public class reader {
	static public void Main() {
		string url = "http://theochem.mercer.edu/csc330/data/airports.csv";
		var client = new WebClient();
		var stream = client.OpenRead(url);
		var webfile = new StreamReader(stream);
		string line;
	    while ((line = webfile.ReadLine()) != null)  {
			Console.WriteLine(line);
   	 	}
	}
}

