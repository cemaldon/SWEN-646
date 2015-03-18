//------------------------------------------------------------------------------
// GPU.cs
// Implementation of class GPU
//------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;

// Class GPU wraps the graphical processing functionality of the underlying
// weather display graphics system.
// We assume the low level system has basic character, string, and numerical 
// display capabilities, as well as the ability to display basic shapes such 
// as points, lines, and circles.
// We also assume that this interface wraps only the functionality of a 
// single color monochrome display of fixed size. Stubs for the required
// drawing routines and for obtaining size are shown here for reference. 
// The underlying Geometry is assumed to be oriented with the origin
// (position (0, 0)) at the lower left of the display.
public class GPU
{
    // Data Members

    // A .NET Graphics object to use as a drawing surface
    Graphics drawingSurface;

    // Representation of the fixed size of the drawing surface.
    int drawingSurfaceSize;

    // A .NET graphics brush object to use for rendering text and shapes
    // on the drawing surface.
    SolidBrush drawingBrush;

    // Constructor
    //
    // Input: A number which represents the size of the display window.
    public GPU(int surfaceSize)
    {
        drawingSurface = null;
        drawingSurfaceSize = surfaceSize;
        drawingBrush = new SolidBrush(Color.Black);
    }

    // Method BeginPaint initializes the graphics drawing surface for drawing
    // during the on paint message of a form. All drawing to the GPU must be done
    // After calling BeginPaint within the paint event, and when done EndPaint 
    // must be called to free the resources for the graphics drawing surface.
    //
    // Input: An object representing the arguments to the form paint event method
    public void BeginPaint(PaintEventArgs paint)
    {
        drawingSurface = paint.Graphics;
    }

    // Method EndPaint calls the dispose method of the drawing surface
    // to free the resources allocated by the graphics system for it. 
    // EndPaint must be called after calling BeginPaint in during the handling
    // of the paint message of a form.
    public void EndPaint()
    {
        drawingSurface.Dispose();
        drawingSurface = null;
    }

    // Method clear refreshes the screen by erasing it entirely
    public void clear()
    {
        // Device dependent implementation for clearing the display 
        // We fill the window drawing area with a solid white.
        drawingSurface.Clear(Color.White);
    }

    // Output: integer value representing the display size
    public int displaySize()
    {
        // Return the display size 
        return drawingSurfaceSize;
    }

    // Input: A position for the point’s location and a pixel thickness
    public void drawPoint(Position position, IntegerValue thickness)
    {
        // The current implementation represents points on the screen 
        // using a tiny circle centered around the desired position
        // on the screen.
        drawCircle(position, thickness, new IntegerValue(1));
    }

    // Input: Endpoint positions and a pixel thickness
    public void drawLine(Position position1, Position position2,
                        IntegerValue thickness)
    {
        // Device dependent implementation for drawing a line. ...

        Pen drawingPen = new Pen(drawingBrush, (float)(thickness.val()));
        PointF p1 = new PointF(position1.x.val(),
                                drawingSurfaceSize - position1.y.val());
        PointF p2 = new PointF(position2.x.val(),
                                drawingSurfaceSize - position2.y.val());
        drawingSurface.DrawLine(drawingPen, p1, p2);
    }

    // Input: The lower left position, width, height and pixel thickness of
    // a rectangle outline.
    public void drawRectangle(Position lowerLeftPosition,
                                IntegerValue width, IntegerValue height,
                                IntegerValue thickness)
    {
        // Device dependent implementation for drawing a rectangle. ...

        Pen drawingPen = new Pen(drawingBrush, (float)(thickness.val()));
        System.Drawing.Rectangle drawingBoundary;
        drawingBoundary = new System.Drawing.Rectangle(lowerLeftPosition.x.val(),
                                                    drawingSurfaceSize - (height.val() + lowerLeftPosition.y.val()),
                                                    width.val(), height.val());

        drawingSurface.DrawRectangle(drawingPen, drawingBoundary);
    }

    // Input: The center, radius, and pixel thickness of a circle outline.
    public void drawCircle(Position center, IntegerValue radius,
                            IntegerValue thickness)
    {
        // Device dependent implementation for drawing a circle. ...

        Pen drawingPen = new Pen(drawingBrush, (float)(thickness.val()));
        drawingSurface.DrawEllipse(drawingPen,
                                    center.x.val() - radius.val(),
                                    drawingSurfaceSize - (center.y.val() + radius.val()),
                                    2 * radius.val(), 2 * radius.val());
    }

    // Input: A value representing the character, its center position, its
    // size, and its pixel thickness.
    public void drawCharacter(CharacterValue value, Position center,
                                IntegerValue size, IntegerValue thickness)
    {
        // Device dependent implementation for drawing CharacterValue
        // objects with specified center position, size, and thickness
        // ...
        Font drawingFont = new Font(FontFamily.GenericSerif, (float)(size.val()));
        StringFormat alignmentCenter = new StringFormat();
        alignmentCenter.Alignment = StringAlignment.Center;
        alignmentCenter.LineAlignment = StringAlignment.Center;

        PointF p = new PointF((float)(center.x.val()), (float)(drawingSurfaceSize - center.y.val()));
        drawingSurface.DrawString(value.val().ToString(),
                                drawingFont,
                                drawingBrush,
                                p,
                                alignmentCenter);
    }

    // Input: A value representing the string, its center position, its
    // vertical size, and its pixel thickness.
    public virtual void drawStringLiteral(string value, Position center,
                                        IntegerValue size,
                                        IntegerValue thickness)
    {
        // Device dependent implementation for drawing string objects
        // with specified center position, size, and thickness
        // ...
        Font drawingFont = new Font(FontFamily.GenericSerif, (float)(size.val()));
        StringFormat alignmentCenter = new StringFormat();
        alignmentCenter.Alignment = StringAlignment.Center;
        alignmentCenter.LineAlignment = StringAlignment.Center;

        PointF p = new PointF((float)(center.x.val()), (float)(drawingSurfaceSize - center.y.val()));
        drawingSurface.DrawString(value,
                                drawingFont,
                                drawingBrush,
                                p,
                                alignmentCenter);
    }

    // Input: A value representing the integer number, its center position,
    // its size, and its pixel thickness.
    public virtual void drawNumber(IntegerValue value, Position center,
                                    IntegerValue size,
                                    IntegerValue thickness)
    {
        // Device dependent implementation for drawing IntegerValue
        // objects with specified center position, size, and thickness
        // ...
        drawStringLiteral(value.val().ToString(), center, size, thickness);
    }

    // Input: A value representing the sensor value, its center position,
    // its size, and its pixel thickness.
    public virtual void drawSensorValue(SensorValue value, Position center,
                                        IntegerValue size,
                                        IntegerValue thickness)
    {
        // Device dependent implementation for drawing SensorValue
        // objects with specified center position, size and thickness ...
        drawStringLiteral(value.val().ToString(), center, size, thickness);
    }
} // End of class GPU
