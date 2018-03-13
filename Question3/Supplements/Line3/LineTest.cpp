// Line1Test.cpp
#include "stdafx.h"
#include <iostream>
#include "Line1.h"

#using <mscorlib.dll>
using namespace std;

int _tmain () {

	// instantitate one line
	double dis;

//	Line1 *line = new Line1 (2 ,3 , 1.0); // create a line of slope 1.0 through (2, 3)
	Point *A = new Point (2, 3), *B = new Point (4, 5);
	Line1 *line = new Line1 (A, B);
	line->print ();

	dis = A->distance (A, B);
    cout << "Distance of A and B is " << dis << endl;
}