//------------------------------------------------------------------------------
// Line.cs
// Implementation of class Line
//------------------------------------------------------------------------------
using System;

// Class Line is a base class used by the low level weather display
// graphics system to display a line. A method render 
// is provided for displaying the line when called. Routines to 
// assist with the physical drawing of the line are provided to
// render() through an argument of type GPU. A constructor is provided for 
// specifying the endpoints and pixel thickness of a line on a two 
// dimensional display. 
public class Line
{
    // An IntegerValue object representing the pixel thickness of a point
    // on a two dimensional grid.
    public IntegerValue thickness;

    // A Position object representing the horizontal and vertical (x and y
    // respectively) components of the first endpoint of a line on a two
    // dimensional grid.
    public Position position1;

    // A Position object representing the horizontal and vertical (x and y
    // respectively) components of the second endpoint of a line on a two
    // dimensional grid.
    public Position position2;

    // Constructor for initializing the thickness and endpoints of new
    // Line objects.
    //
    // Input: Position objects corresponding to the line’s endpoints, and
    // an IntegerValue object corresponding to the line’s pixel thickness 
    public Line(Position position1, Position position2, IntegerValue
    thickness)
    {
        // Initialize the endpoints for drawing this Line object
        this.position1 = new Position(position1);
        this.position2 = new Position(position2);

        // Initialize the pixel thickness for drawing this Line object
        this.thickness = new IntegerValue(thickness);
    }

    // Method render calls the drawLine method on a given GPU object,
    // passing it the endpoint positions and the thickness of this Line
    // object.    
    //
    // Input: A GPU object to be used by calling it's drawLine method
    public void render(GPU gpu)
    {
        gpu.drawLine(position1, position2, thickness);
    }

} // End of class Line
