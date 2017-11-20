
// Referenced:
//     https://stackoverflow.com/questions/10826260/is-there-a-way-to-read-from-a-website-one-line-at-a-time
//

using System;
using System.IO;
using System.Net;


public class WebReader {

	private string url;
	private StreamReader webfile;

	public WebReader(string url) {
		this.url = url;
		var client = new WebClient();
		var stream = client.OpenRead(this.url);
		this.webfile = new StreamReader(stream);
	}

	public string getLine() {
		return webfile.ReadLine();
	}

}

