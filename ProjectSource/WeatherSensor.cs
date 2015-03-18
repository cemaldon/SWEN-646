//------------------------------------------------------------------------------
// WeatherSensor.cs
// Implementation for class weather sensor
//------------------------------------------------------------------------------
using System;
using System.IO;

// Class WeatherSensor
public class WeatherSensor
{
	private string name; // A descriptor for the sensor

	private SensorValue currentValue; // The current sensor value

	private SensorValue lowValue; // The 24 hour Low

	private SensorValue highValue; // The 24 hour high

    bool initializing;

	private DateTime startDateTime; // Initiated as start of 24 hour period
	// Constructor: Initialize sensor values to 0.0
	public WeatherSensor()
	{
		currentValue = new SensorValue((float)0.0);
        lowValue = new SensorValue((float)0.0);
        highValue = new SensorValue((float)0.0);
        startDateTime = new DateTime();

        initializing = true;
	}

    // Method read reads real-time sensor data. Implement in derived 
    // classes to provide device specific functionality.
	public virtual SensorValue read() 
	{
        return new SensorValue((float)-1);
	}

	// Method update uses a given date and time to update
	// the 24 hour high and low sensor values. The current value is read 
	// and updated. If the 24 hour period has been reached, the high and
	// low values are reset to current value and the given time and date
    // becomes the startDateTime.
    //
    // Input: Updated date and time value
	public void update(DateTime valueDateTime)
	{
		currentValue = read();

		DateTime plusOneDay = new DateTime(startDateTime).addOneDay();
        if(initializing || valueDateTime.equals(plusOneDay))
        {
            lowValue = new SensorValue(currentValue);
            highValue = new SensorValue(currentValue);
            startDateTime = valueDateTime;
            initializing = false;
        }
        else
        {
            lowValue.setToMin(currentValue);
            highValue.setToMax(currentValue);
        };
	}

	// Input: New string to assign to name
	public void setName(string value)
	{
		name = value;
	}

    // Output: New string with value of name
	public string getName()
	{
		return name;
	}

	// Output: Current sensor value
	public SensorValue getCurrentValue()
	{
        return new SensorValue(currentValue);
	}

	// Output: 24 hour high value
	public SensorValue get24HourHigh()
	{
        return new SensorValue(highValue);
	}

    // Output: 24 hour low value
	public SensorValue get24HourLow()
	{
		return new SensorValue(lowValue);
	}

} // End class WeatherSensor


