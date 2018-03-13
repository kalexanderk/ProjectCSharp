// Fig. 9.4: line.cpp
// Member functions for class Point
#include "stdafx.h"
#include <iostream>
#include "Line.h"

// Constructor for class Point
Line::Line( Point * p1, Point *p2  ) { 
 if (p1.getX() != p2.getX())
 {
	 slope = (p2.getY() - p1.getY())/ (p2.getX() - p1.getX());
	 isVertical = false;
	 isLine = true;
}
 else if (p1.getY() == p2.getY())
	 isLine = false;
 else
 {
	 isLine = true;
	 isVertical = false;
 }
}
/*
 bool Line::isthisaLine ()
 {
	 return isLine;
 }

 bool Line::isthisVertical () {
	 return isVertical;
 }
*/

// Output Line (with overloaded stream insertion operator)
ostream &operator<<( ostream &output, const Line &l )
{
	if (l.isLine) {
	if (!l.isVertical)
		output << "Equation: y - "<< l.slope << "x +  " << 
		l.slope * l.getP1().getX() - l.getP1().getY() << " = 0";
	else
		output << "Equation: x = " << l.getP1().getX();
	}
	else
		output << "This is not a line\n"; 

   return output;   // enables cascaded calls
}



/**************************************************************************
 * (C) Copyright 2000 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
