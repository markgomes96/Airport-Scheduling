
# Group Participation
12/13/17 | 12:00pm - 3:00pm | The group as a whole was present and we worked off of one person's Cobra account.

# How to Use

The program can read passenger info from the keyboard or from some specified CSV inputfile as a commandline argument.
Input CSV files are of the form `Firstname,Lastname,OriginCity,OriginStateCode,DestCity,DestStateCode`.
To compile and run the program:
```
$ cd C#
$ make
$ mono main.exe inputfile.csv
```

At present, the program delivers all passengers to their destinations, but it does not ensure that the pilot makes a profit.
