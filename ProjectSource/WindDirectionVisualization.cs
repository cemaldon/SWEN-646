//------------------------------------------------------------------------------
// WindDirectionVisualization.cs
// Implementation of class WindDirectionVisualization
//------------------------------------------------------------------------------
using System;

// Class WindDirectionVisualization extends Visualization adding a rectangle
// outline region, a circular compass region, and a vector representing the
// compass direction, to the display. WindDirectionVisualization is useful
// for generating a visualization of data from a wind direction sensor.
// Members are provided to store the graphical attributes of the needed
// display elements and, to update wind direction compass pointer direction.
// Method draw is overridden to render the needed elements to a GPU.
public class WindDirectionVisualization : Visualization
{
	// A Rectangle object representing the outline of the wind direction
    // visualization.
	private Rectangle border;

    // A Circle object representing the outline of the wind direction
    // compass.
	private Circle compassOutline;

	// A Position object representing the lower left position of the wind
	// direction visualization.
	private Position lowerLeftPosition;

	// A Position object representing the center position of the wind
	// direction visualization.
	private Position centerPosition;

	// An IntegerValue object representing the length of the square border
    // of the wind direction visualization.
	private IntegerValue size;

	// An IntegerValue object representing the radius of the wind direction
	// compass.
	private IntegerValue radius;

	// An IntegerValue representing the pixel thickness used for drawing
	// graphical objects of the visualization.
	private IntegerValue thickness;

	// A float value representing the current angle of wind direction
    private float angle;

    // Constructor for initializing the visualization and compass outline
    // members of new WindDirectionVisualization objects. The direction
    // point and line are initialized to point north (0 degree) by default.
    public WindDirectionVisualization(Position lowerLeftPosition,
                                     IntegerValue size, 
                                     float angle,
                                     IntegerValue thickness)
    {
        // Initialize angle to the angle given.
	    this.angle = angle;

        // Set border to square with given position, side size, and
        // thickness.

        this.thickness = new IntegerValue(thickness);

        this.size = size;

        this.lowerLeftPosition = lowerLeftPosition;

        this.border = new Rectangle(lowerLeftPosition, size, size,
                                    thickness);

        // Set compass circle to Circle with position centered in the
        // border, having radius 1/3 of the side size, and having
        // the given thickness. Use double values in calculating radius
        // for accuracy.

        this.radius = new IntegerValue((int)((double)(size.val())/3.0));

        int s = (int)((double)(size.val())/2.0);

        centerPosition = new Position(lowerLeftPosition);

        centerPosition.translate(s, s);

        this.compassOutline = new Circle(centerPosition, radius, thickness);
    }

    // Method setAngularDirection sets the wind direction angle
    public void setAngularDirection(float angle)
    {
	    this.angle = angle;
    }

	// Method drawLetter displays a given character on the wind direction
	// compass at the desired angle from point north (0 degree).
    // It is used for labeling the compass.
	public void drawLetter(char letter, float angle, GPU gpu)
	{
		// Using double precision conversions for accuracy

		int s = (int)((double)(size.val())/3.0);

		Position p = new Position(0, radius.val() + size.val()/16);

        p.translate(centerPosition);

		p.rotate(centerPosition, angle);

        // Draw the letter appropriately sized at the rotated point 
        // translated slightly in the direction of the angle so it is 
        // outside the compass outline and inside the square
        // visualization border.

        gpu.drawCharacter(new CharacterValue(letter), 
                        p, 
                        new IntegerValue(size.val()/8), 
                        thickness);
	}

    // Method draw calculates the position of the wind direction pointer
    // based on the current angular direction, and renders the graphical
    // display objects for this wind direction visualization to the given
    // GPU.
	public override void draw(GPU gpu)
	{
        Position p = new Position(size.val()/2, size.val() + size.val()/16);

        gpu.drawStringLiteral("Wind Direction", p, new IntegerValue(size.val() / 8), thickness);

        border.render(gpu);

        compassOutline.render(gpu);

        p = new Position(0, radius.val());

        p.translate(centerPosition);
        
        p.rotate(centerPosition, angle);

        // Draw the direction point with a slightly larger thickness
        Point direction = new Point(p, thickness.addOne());

		direction.render(gpu); 

        Line directionLine = new Line(centerPosition, p, thickness);

        directionLine.render(gpu);

        // Draw letters for north (0 degree), west (90 degree) south(180
        // degree), and east (270 degree).

        drawLetter('N', (float)(0.0), gpu);

        drawLetter('W', (float)(90.0), gpu);

        drawLetter('S', (float)(180.0), gpu);

        drawLetter('E', (float)(270.0), gpu);
	}

} // End class WindDirectionVisualization
