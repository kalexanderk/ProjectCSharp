// Fig. 9.4: Point.h
// Point class represents an x-y coordinate pair.

#pragma once

#using <mscorlib.dll>

using namespace System;

// Point class definition implicitly inherits from Object
public __gc class Point
{
public: 
   Point();                       // default constructor
   Point( int, int );             // constructor

   // property X
   __property int get_X() 
   { 
      return x; 
   }

   __property void set_X( int value ) 
   { 
      x = value; 
   }
   
   // property Y
   __property int get_Y() 
   { 
      return y; 
   }

   __property void set_Y( int value ) 
   {
      y = value; 
   }

   String *ToString();   // return string representation of Point

protected:
   int x, y;             // point coordinates
};                       // end class Point

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
