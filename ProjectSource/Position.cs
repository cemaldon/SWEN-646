//------------------------------------------------------------------------------
// Position.cs
// Implementation of class Position
//------------------------------------------------------------------------------
using System;

// Class Position is implemented as a composition of IntegerValue objects for
// representing coordinates on a graphic display.
public class Position
{
    // IntegerValue object representing the first coordinate of a point on
    // a two dimensional grid.
    public IntegerValue x;

    // Integer Value object representing the second coordinate of a point
    // on a two dimensional grid.
    public IntegerValue y;

    // Constructor for initializing the x and y value members of a new
    // Position object with corresponding given integer values.
    //
    // Input: Int initialization values corresponding to Position members x
    // and y respectively.
    public Position(int x, int y)
    {
        this.x = new IntegerValue(x); // Initialize this.x

        this.y = new IntegerValue(y); // Initialize this.y
    }

    // Constructor for initializing the x and y value members of a new
    // Position object with corresponding given IntegerValues.
    //
    // Input: IntegerValue initialization values corresponding to Position
    // members x and y respectively.
    public Position(IntegerValue x, IntegerValue y)
    {
        this.x = new IntegerValue(x);

        this.y = new IntegerValue(y);
    }

    // Constructor for initializing the x and y value members of a new
    // Position object with the corresponding members of a given
    // Position.
    //
    // Input: Initialization Position object.
    public Position(Position position)
    {
        this.x = new IntegerValue(position.x);

        this.y = new IntegerValue(position.y);
    }

    // Method rotate outputs a position object which is the result of a
    // geometric two dimensional rotation of this Position object around a
    // given Position object by a given angle. Angle is input as a float.
    // All values are converted to double values for accuracy, and are
    // again converted back to int for the resulting Position. System
    // support for language specific mathematical functions for computing 
    // the sine and cosine is assumed.
    //
    // Input: A Position object to rotate this Position object around, and
    // a float value which represents the desired angle of rotation in degrees.
    // Output: A position object which is the rotation of this Position
    // object by the given angle.
    public Position rotate(Position position, float angle)
    {
        angle = (float)(angle * Math.PI / 180); // Convert angle to Radians

	    double f1 = new double();
        f1 = Convert.ToDouble(position.x.val());

	    double f2 = new double();
        f2 = Convert.ToDouble(position.y.val());

	    double f3 = new double();
        f3 = Convert.ToDouble(x.val());

	    double f4 = new double();
        f4 = Convert.ToDouble(y.val());

	    this.x = new IntegerValue((int)(Math.Cos((double)(angle)) * (f3 - f1) 
                            - Math.Sin((double)(angle)) * (f4-f2) + f1));

        this.y = new IntegerValue((int)(Math.Sin((double)(angle)) * (f3 - f1)
                            + Math.Cos((double)(angle)) * (f4-f2) + f2));

	    return new Position(this);
    }

    // Method translate adds the given integer values to the corresponding
    // x and y components of this Position object. It sets the x and y
    // of this Position to the corresponding results and returns a copy.
    //
    // Input: A Position object to translate this Position by.
    // Output: A position object which is the translation of this Position
    // object by the given position object.
    public Position translate(int x, int y)
    {
        this.x = new IntegerValue(this.x.val() + x);

        this.y = new IntegerValue(this.y.val() + y);

        return new Position(this);
    }

    // Method translate adds the corresponding x and y components of a
    // given Position object to this Position object. It sets the x and y
    // of this Position to the corresponding results and returns a copy.
    //
    // Input: A Position object to translate this Position by.
    // Output: A position object which is the translation of this Position
    // object by the given position object.
    public Position translate(Position position)
    {
        return translate(position.x.val(), position.y.val());
    }

} // End of class Position

