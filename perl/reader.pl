#!/usr/bin/perl

use strict;
use warnings;

# Library for WWW in Perl (LWP)
use LWP::Simple;

my $url = "http://theochem.mercer.edu/csc330/data/airports.csv";
my $content = get($url);
print($content);


