#include <iostream>

using std::cout;
using std::endl;

#include <iomanip>

#include "point.h"
#include "Line.h"

int main () {
	Point p1(1,1), p2 (2,2);
	Line l(p1, p2);

	cout << "Point p1 " << p1 << endl;
	cout << "Point p2 " << p2 << endl;
	cout << "Line l " << l << endl;
}