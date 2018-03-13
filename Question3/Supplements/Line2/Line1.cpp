// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"
#include <iostream>
#include "Line1.h"
using namespace std;

Line1::Line1 () {
}

Line1::Line1 (int xValue, int yValue, double slopeValue) {
	x = xValue;
	y = yValue;
	slope = slopeValue;
}

void Line1::setSlope (double slopeValue) {
 
	slope = slopeValue;

}

double Line1::getSlope () {
	return slope;
}

void Line1::print () {  // print the line
	cout << "Line thru ( " << x << ", " << y << ") with slope " << slope << endl;
}

