// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"
#include "Line1.h"

Line1::Line1 () {
}

Line1::Line1 (int xValue, int yValue, double slopeValue) {
	x = xValue;
	y = yValue;
	slope= slopeValue;
}

void Line1::setSlope (double slopeValue) {
 
	slope = slopeValue;

}

double Line1::getSlope () {
	return slope;
}

