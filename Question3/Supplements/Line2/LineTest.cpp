// Line1Test.cpp
#include "stdafx.h"
#include "Line1.h"

#using <mscorlib.dll>

int _tmain () {

	// instantitate one line

//	Line1 *line = new Line1 (2 ,3 , 1.0); // create a line of slope 1.0 through (2, 3)
	Point *A = new Point (2, 3), *B = new Point (4, 5);
//	Line1 *line = new Line1 (A, B);
	Line1 *line = new Line1 (A, B, 1.0);
	line->print ();

}