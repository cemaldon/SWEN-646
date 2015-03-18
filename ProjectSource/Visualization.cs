//------------------------------------------------------------------------------
// Visualization.cs
// Implementation of class Visualization
//------------------------------------------------------------------------------
using System;

// Class Visualization is a virtual class providing the basic functionality
// of a graphical region within a display. Classes extend Visualization by
// overriding the draw method, providing graphical functionality.
public class Visualization
{
    // Method draw renders the desired graphical content to a display.
    // Override draw in derived classes to provide an implementation of the
    // desired drawing functionality.
    //
    // Input: A reference to a GPU object for performing the desired drawing.
    // operations, and a reference to a Oosition representing the lower left 
    // position offset of this visualization on the display
    public virtual void draw(GPU gpu)
    {
        // Virtual function not implemented
    }
} // End class Visualization


