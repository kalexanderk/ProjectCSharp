// Fig. 9.5: Point.cpp
// Member function definitions for class Point.

#include "stdafx.h"
#include "Point.h"

// default (no-argument) constructor
Point::Point()
{
   // implicit call to Object constructor occurs here
}

// constructor
Point::Point( int xValue, int yValue )
{
   // implicit call to Object constructor occurs here
   x = xValue;
   y = yValue;
}

// return string representation of Point
String *Point::ToString()
{
   return String::Concat( S"[", x.ToString(), S", ",
      y.ToString(), S"]" );
} 

/*************************************************************************
* (C) Copyright 1992-2004 by Deitel & Associates, Inc. and               *
* Pearson Education, Inc. All Rights Reserved.                           *
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