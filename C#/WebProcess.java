import java.net.URL;
import java.io.IOException;
import java.util.Scanner;

    public class WebProcess {
        public static void main (String args[]) {
            try{
                URL reader = new URL("http://theochem.mercer.edu/csc330/data/airports.csv");;
                Scanner in = new Scanner(reader.openStream());
                int lineCount=0;
                while (in.hasNextLine()) {
                    String line = in.nextLine().trim();
                    System.out.println(line);
                    lineCount++; 
                } 
            }
            catch (IOException ex) {
                System.out.println("WEB URL NOT FOUND.");
            }
   }
}
