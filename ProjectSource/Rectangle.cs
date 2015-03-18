//------------------------------------------------------------------------------
// Rectangle.cs
// Implementation of class Rectangle
//------------------------------------------------------------------------------
using System;

// Class Rectangle is a base class used by the low level weather display
// graphics system to display the outline of a rectangular area. A method 
// render is provided for displaying the rectangular outline when called. 
// Routines to assist with the physical drawing of the rectangular outline 
// are provided to render() through an argument of type GPU. A constructor 
// is provided for specifying the lower left position, width, height, and 
// pixel thickness of a rectangular outline on a two dimensional display.
public class Rectangle
{
    // An IntegerValue object representing the pixel thickness of the
    // outline of a rectangular region on a two dimensional grid.
    public IntegerValue thickness;

    // A Position object representing the horizontal and vertical (x and y
    // respectively) components of a rectangle on a two dimensional grid.
    public Position lowerLeftPosition;

    // An IntegerValue object representing the horizontal length of the
    // outline of a rectangular region on a two dimensional grid.
    public IntegerValue width;

    // An IntegerValue object representing the vertical length of the
    // outline of a rectangular region on a two dimensional grid.
    public IntegerValue height;

    // Constructor for initializing the position, width, height, and
    // thickness of new Rectangle objects.
    //
    // Input: A Position object corresponding to the rectangle outline’s
    // position, and IntegerValue objects corresponding to the rectangle
    // outline’s pixel width, height, and pixel thickness. 
    public Rectangle(Position position, IntegerValue width, IntegerValue
    height, IntegerValue thickness)
    {
        // Initialize the lower left position of this Rectangle object.
        this.lowerLeftPosition = new Position(position);

        // Initialize the width and height of this Rectangle object.
        this.width = new IntegerValue(width);
        this.height = new IntegerValue(height);

        // Initialize the pixel thickness of this Rectangle object.
        this.thickness = new IntegerValue(thickness);
    }

    // Method render calls the drawRectangle method on a given GPU object,
    // passing it the lower left position, width, height, and thickness of
    // this Rectangle object.
    //
    // Input: A GPU object to be used by calling it's drawRectangle method
    public void render(GPU gpu)
    {
        gpu.drawRectangle(lowerLeftPosition, width, height, thickness);
    }

} // End of class Rectangle
