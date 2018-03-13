// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"
#include <iostream>
#include "Line1.h"
using namespace std;

Line1::Line1 () {
}
/*
Line1::Line1 (int xValue, int yValue, double slopeValue) {
	x = xValue;
	y = yValue;
	slope = slopeValue;
}
*/

Line1::Line1 (Point *A, Point *B) {
	P1 = A;
	P2 = B;
	if (P2->X != P1->X) 
		slope = (P2->Y - P1->Y) / (P2->X - P1->X);
	else 
		cout << "Slope undefined";
}

void Line1::setSlope (double slopeValue) {
 
	slope = slopeValue;

}

double Line1::getSlope () {
	return slope;
}

void Line1::print () {  // print the line
	cout << "Line thru ( " << P1->X << ", " << P1->Y << ") with slope " << slope << endl;
}

