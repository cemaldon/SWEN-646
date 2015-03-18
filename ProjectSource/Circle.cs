//------------------------------------------------------------------------------
// Circle.cs
// Implementation of class Circle
//------------------------------------------------------------------------------
using System;

// Class Circle is a base class used by the low level weather display
// graphics system to display the outline of a circular area. A method render 
// is provided for displaying the circle outline when called. Routines to 
// assist with the physical drawing of the circle outline are provided to
// render() through an argument of type GPU. A constructor is provided for 
// specifying the center position, radius, and outline pixel thickness of a 
// circle on a two dimensional display.
public class Circle
{
    // An IntegerValue object representing the pixel thickness of the
    // outline of a circular region on a two dimensional grid.
    public IntegerValue thickness;

    // A Position object representing the horizontal and vertical (x and y
    // respectively) components of the center position of a circle on a two
    // dimensional grid.
    public Position center;

    // An IntegerValue object representing the radius of a circular region
    // on a two dimensional grid.
    public IntegerValue radius;

    // Constructor for initializing the center position, radius, and
    // outline pixel thickness of new Circle objects.
    //
    // Input: A Position object corresponding to the circular region’s
    // center position, and IntegerValue objects corresponding to the
    // circular region’s radius and outline pixel thickness. 
    public Circle(Position center, IntegerValue radius, 
                IntegerValue thickness)
    {
        // Initialize the pixel thickness for this circle object.
        this.thickness = new IntegerValue(thickness);

        // Initialize the center position for this circle object.
        this.center = new Position(center);

        // Initialize the radius for this circle object.
        this.radius = new IntegerValue(radius);
    }

    // Method render calls the drawCircle method on a given GPU object,
    // passing it the center position, radius, and thickness of this Circle object.
    //
    // Input: A GPU object to be used by calling it's drawCircle method
    public void render(GPU gpu)
    {
        gpu.drawCircle(center, radius, thickness);
    }

} // End of class Circle
