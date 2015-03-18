//------------------------------------------------------------------------------
// Display.cs
// Implementation of class Display
//------------------------------------------------------------------------------
using System;

// Class Display provides methods which facilitate the GPU rendering 
// of data from the weather sensors.
public class Display
{
	// Pixel thickness used for drawing
	IntegerValue thickness;

    // Fixed Display size
    private int displaySize;

	// Constructor for initialization.
	public Display(int size)
	{
        displaySize = size;
		
		// Use a pixel thickness of 1 for all drawing.
		thickness = new IntegerValue(1);
    }

    // Method clear clears the display.
    //
    // Input: A GPU objrct to which to send the request to clear the 
    // contents of the screen.
    public void clear(GPU gpu)
    {
        gpu.clear();
    }

    // Method displayDateTime displays the date and time to the upper left 
    // corner of the gpu.
    //
    // Input: A DateTime object representing the date and time to display
	public void displayDateTime(GPU gpu, DateTime value)
	{
		int size = gpu.displaySize();

        int x = size/2 + 1;

		int y = size - size/8;

        string stringDateTime = value.stringDate() + " " + value.stringTime();

        gpu.drawStringLiteral(stringDateTime, 
                                new Position(x, y), 
                                new IntegerValue(size/16), 
					            thickness);
	}

    // Method displaySensorValue displays the given WeathorSensor values at // the given offset. Sensors are positioned in a row slightly 
    // below the date and time.
	public virtual void displaySensorValues(GPU gpu,
                                            WeatherSensor sensor, 
                                            int offset)
	{
		// Compute drawing position from the given offset.

		int size = gpu.displaySize();

        int x = (offset * size/4) + 3*size/32 + 1;

		int y = size - (2 * size/8 + 1);

		Position position = new Position(x, y);

		// Display the sensor’s name
		gpu.drawStringLiteral(sensor.getName(), 
                            position, 
                            new IntegerValue(gpu.displaySize()/64),
							thickness);

		// Display the sensor’s 24 hour current value, high value, and 
		// low value directly below the sensor name. The name of the
        // value: current, low or high, is displayed in a column. Each 
        // value is displayed below its name.

		y = size - (2 *size/8 + size/32 + 2);

		position = new Position(x, y);

		gpu.drawStringLiteral("Current", 
                             position, 
                             new IntegerValue(gpu.displaySize()/64), 
                             thickness);

		y = size - (2 *size/8 + 2*size/32 + 2);

		position = new Position(x, y);

		gpu.drawSensorValue(sensor.getCurrentValue(), 
                            position, 
						    new IntegerValue(gpu.displaySize()/64), 
                            thickness);

		y = size - (2 *size/8 + 3*size/32 + 2);

		position = new Position(x, y);

		gpu.drawStringLiteral("High", 
                            position, 
                            new IntegerValue(gpu.displaySize()/64), 
                            thickness);

		y = size - (2 *size/8 + 4*size/32 + 2);

		position = new Position(x, y);

		gpu.drawSensorValue(sensor.get24HourHigh(), 
                            position,
                            new IntegerValue(gpu.displaySize()/64), 
                            thickness);

		y = size - (2 *size/8 + 5*size/32 + 2);

		position = new Position(x, y);

		gpu.drawStringLiteral("Low", 
                            position, 
                            new IntegerValue(gpu.displaySize()/64), 
                             thickness);

		y = size - (2 *size/8 + 6*size/32 + 2);

		position = new Position(x, y);

		gpu.drawSensorValue(sensor.get24HourLow(), 
                            position,
                            new IntegerValue(gpu.displaySize()/64), 
                            thickness);
	}

	// Method displayVisualization draws a given visualization
	//
	// Input: A visualization and position for displaying
	public virtual void displayVisualization(GPU gpu,
                                            WindDirection sensorWindDirection,
                                            int offset)
	{
		// For now there is only one visualization to display. We will
        // draw it at the bottom left. The position argument shall be
        // ignored. 
        WindDirectionVisualization visualizeWindDirection
            = new WindDirectionVisualization(new Position(0, 0),
                                    new IntegerValue(gpu.displaySize()/4),
                                    sensorWindDirection.getCurrentValue().val(),
                                    thickness);
        visualizeWindDirection.draw(gpu);
	}

} // End class Display


