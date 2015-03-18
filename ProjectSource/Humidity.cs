//------------------------------------------------------------------------------
// Humidity.cs
// Implementation of class Humidity
//------------------------------------------------------------------------------
using System;

// Class Humidity: Humidity wraps the functionality of reading sensor values 
// from a humididity sensor device. Method read of parent class WeatherSensor 
// is overriden. A default constructor is provided, which initializes the string 
// representing a name for this type of object. For simulation, the current 
// implementation generates a random number for each call to method read() 
// based on a random walk, which is between the values of 0.0 and 100.0, 
// providing a baseline representation of actual real-time data read from a 
// humidity sensor.
public class Humidity: WeatherSensor
{
    // Device Specific Data
    Random random_0_1; // Random number generator for simulation values.
    float dataValue, step; // Data values used in number generation.

	// Method override from weather sensor: Reads sensor data.
	public override SensorValue read()
	{
        // Device specific data read processing: Sensor data is assumed
        // to be available continuously in the form of discrete floating 
        // point values. A single value is read and returned as a new
        // SensorValue. For simulation we generate a random number between
        // 0.0 and 100.0.

        // Generate random walk for data and write each step to the file.

        // Generate a random number between -3 and 3
        step = (float)(random_0_1.NextDouble() * 6 - 3);

        // Add step increment to dataValue, ensure dataValue stays within range 
        // of 0.0 and 100.0, and return to caller.

        dataValue = Math.Min(Math.Max(dataValue + step, (float)0.0), (float)100.00);

        return new SensorValue(dataValue);
	}

	// Default Humidity Constructor
	public Humidity()
	{
		setName("Humidity");

        // Device specific initialization

        // Seed a random number generator to be used in generating the
        // simulation data.
        random_0_1 = new Random();

        // Initialize dataValue to a random number between 0.0 and 100.0
        dataValue = (float)(random_0_1.NextDouble() * (100.0 - 0.0) + 0.0);
	}

} //End class Humidity

