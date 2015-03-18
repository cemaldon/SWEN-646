//------------------------------------------------------------------------------
// Point.cs
// Implementation of calss Point
//------------------------------------------------------------------------------
using System;

// Class Point is a base class used by the low level weather display
// graphics system to display the representation of a point on the screen. 
// A method render is provided for displaying the point representation when 
// called. Routines to assist with the physical drawing of the point 
// representation are provided to render() through an argument of type GPU. 
// A constructor is provided for specifying the center position and pixel 
// thickness of a point on a two dimensional display.
public class Point
{
    // A Position object representing the horizontal and vertical (x and y
    // respectively) components of a point on a two dimensional grid.
    public Position position;

    // An IntegerValue object representing the pixel thickness of a point
    // on a two dimensional grid.
    public IntegerValue thickness;

    // Constructor for initializing the thickness and position of new Point
    // objects.
    //
    // Input: A Position object corresponding to the point’s position, and
    // an IntegerValue object corresponding to the point’s pixel thickness. 
    public Point(Position position, IntegerValue thickness)
    {
        // Initialize the position for drawing this point object.
        this.position = new Position(position);

        // Initialize the pixel thickness for drawing this point object.
        this.thickness = new IntegerValue(thickness);
    }

    // Method render calls the drawPoint method on a given GPU object,
    // passing it the position and thickness of this Point object.
    //
    // Input: A GPU object to be used by calling it's drawPoint method
    public void render(GPU gpu)
    {
        gpu.drawPoint(position, thickness);
    }

} // End of class Point
