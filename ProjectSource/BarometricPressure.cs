//------------------------------------------------------------------------------
// BarometricPressure.cs
// Implementation of class BarometricPressure
//------------------------------------------------------------------------------
using System;

// Class BarometricPressure: BarometricPressure wraps the functionality of
// reading sensor values from a generic barometric pressure device. Method
// read of parent class WeatherSensor is overriden. A default constructor
// is provided, which initializes the string representing a name for this
// type of object. For simulation, the current implementation generates
// a random number for each call to method read() based on a random walk, 
// which is between the values of 27.0 and 32.0, providing a baseline 
// representation of actual real-time data read from a barometric 
// pressure sensor.
public class BarometricPressure: WeatherSensor
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
        // 27.0 and 32.0.

        // Generate random walk for data and write each step to the file.

        // Generate a random number between -0.4 and 0.4
        step = (float)(random_0_1.NextDouble() * (0.4 - (-0.4)) + (-0.4));

        // Add step increment to dataValue, ensure dataValue stays within range 
        // of 27.0 and 32.0, and return to caller.

        dataValue = Math.Min(Math.Max(dataValue + step, (float)27.0), (float)32.00);

        return new SensorValue(dataValue);
	}

	// The default BarometricPressure constructor sets the name
    // representing the type of sensor associated with an object of
    // type BarometricPressure.
	public BarometricPressure()
	{
		setName("Barometric Pressure");

        // Device specific initialization

        // Seed a random number generator to be used in generating the
        // simulation data.
        random_0_1 = new Random();

        // Initialize dataValue to a random number between 27.0 and 32.0
        dataValue = (float)(random_0_1.NextDouble() * (32.0 - 27.0) + 27.0);
	}

} //End class BarometricPressure

