#pragma once
#include "Point.h"
public __gc class Line1 : public Point
{
public:
	Line1 ();
	Line1 (int, int, double);
	void setSlope (double);
	double getSlope ();
private:
	double slope;
};
