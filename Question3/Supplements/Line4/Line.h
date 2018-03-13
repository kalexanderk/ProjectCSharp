#ifndef LINE_H
#define LINE_H

#include <iostream>
#include "Point.h"

using std::ostream;

// class Line {
class Line : Point{
   friend ostream &operator<<( ostream &, const Line & );
public:
   Line( Point *, Point * );      // default constructor
   // bool isthisaLine ();
   // bool isthisVertical ();
   Point getP1() const { return P1; }  // get x coordinate
   Point getP2() const { return P2; }  // get y coordinate
protected:         // accessible by derived classes
   Point P1;       // x and y coordinates of the Point
   Point P2; 
   double slope; // slope of line connecting P1 and P2
   bool isLine; // Check if P1 and P2 form a line, or they do not coincide
   bool isVertical; // Check if the line is paralle to y axis or has infinite slope
};

#endif
