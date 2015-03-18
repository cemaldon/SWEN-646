//------------------------------------------------------------------------------
// WeatherSystem.cs
// Implementation of class WeatherSystem
//------------------------------------------------------------------------------
using System;

// Class WeatherSystem provides a top level implementation of the desired  
// weather tracking functionality. We assume there is system defined
// functionality for reading the current date and time.
public class WeatherSystem
{
	// Sensors
	private WindSpeed windSpeed;
	private WindDirection windDirection;
	private Temperature temperature;
	private BarometricPressure barometricPressure;
	private Humidity humidity;

	// Display
	private Display display;

	// Wrapper for system defined method for obtaining date and time:
    // System date and time are obtained and returned as a new DateTime.
	private DateTime readSystemDateTime()
    {
	    // System specific date time processing ...
        System.DateTime systemDateTime = System.DateTime.Now;
        return new DateTime(systemDateTime.Month,
                            systemDateTime.Day,
                            systemDateTime.Year,
                            systemDateTime.Hour,
                            systemDateTime.Minute,
                            systemDateTime.Second);
    }

	// Method updateWeatherDisplay refreshes the screen and displays the
    // date, time, and current sensor values and visualization. It is
    // assumed that there is an external timer calling this method once a 
    // second.
	public virtual void updateWeatherDisplay(GPU gpu)
	{
		DateTime dt = readSystemDateTime();

		// Clear the display
        display.clear(gpu);

		// Update date and time on display
		display.displayDateTime(gpu, dt);

        // Update sensors on display

        windSpeed.update(dt);
        display.displaySensorValues(gpu, windSpeed, 0);

        temperature.update(dt);
        display.displaySensorValues(gpu, temperature, 1);

        barometricPressure.update(dt);
        display.displaySensorValues(gpu, barometricPressure, 2);

        humidity.update(dt);
        display.displaySensorValues(gpu, humidity, 3);

        // Update wind speed visualization on display

        windDirection.update(dt);
        display.displayVisualization(gpu, windDirection, 0);
	}

    // Constructor for WeatherSystem objects
    // Responsible for initializing the sensor and disply objects
    //
    // Input: Integer value representing the display size
	public WeatherSystem(int displaySize)
	{
        // Note: the startDateTime associated with each sensor is
        // initialized to 00/00/0000. The first call to a sensor update 
        // will then set the start date and time to the current, as 24
        // hours will certainly have passed. We don’t need to initialize 
        // the start date time to the current.

        // Initialize sensors
        windSpeed = new WindSpeed();
        windDirection = new WindDirection();
        temperature = new Temperature();
        barometricPressure = new BarometricPressure();
        humidity = new Humidity();

        // Initialize display
        display = new Display(displaySize);
	}

} // End of class WeatherSystem


