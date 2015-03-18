//------------------------------------------------------------------------------
// DateTime.cs
// Implementation of class DateTime
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Class DateTime is implemented as a composition of IntegerValue objects
// useful for representing the date and time in month, day, year, hour,
// minute, and second format.
public class DateTime
{
    // IntegerValue object representing the month of a 12 month year
    private IntegerValue month;

    // IntegerValue object representing the day of a month [1-31]
    private IntegerValue day;

    // IntegerValue object representing the year of a date
    private IntegerValue year;

    // IntegerValue object representing the hour of a 24 hour day
    private IntegerValue hour;

    // IntegerValue object representing the minute of a 60 minute hour
    private IntegerValue minute;

    // IntegerValue object representing the second of a 60 second minute
    private IntegerValue second;

    // Constructor for initializing a new DateTime object to all zeros
    public DateTime()
    {
        this.month = new IntegerValue(0);
        this.day = new IntegerValue(0);
        this.year = new IntegerValue(0);
        this.hour = new IntegerValue(0);
        this.minute = new IntegerValue(0);
        this.second = new IntegerValue(0);
    }

    // Constructor for initializing the month, day, year, hour, minute, and
    // second value members of a new DateTime object to the corresponding
    // member values of a given DateTime object.
    //
    // Input: DateTime object representing the new initialization values
    // for each of the corresponding month, day, year, hour, minute, and
    // second values of the new DateTime object.
    public DateTime(DateTime dateTime)
    {
        this.month = new IntegerValue(dateTime.month);
        this.day = new IntegerValue(dateTime.day);
        this.year = new IntegerValue(dateTime.year);
        this.hour = new IntegerValue(dateTime.hour);
        this.minute = new IntegerValue(dateTime.minute);
        this.second = new IntegerValue(dateTime.second);
    }

    // Constructor for initializing the month, day, year, hour, minute, and
    // second values of a new DateTime object to corresponding given int 
    // values. 
    //
    // Input: Int initialization values for each of the corresponding
    // month, day, year, hour, minute, and second values of the new
    // DateTime object.
    public DateTime(int month, int day, int year, int hour, int minute,
    int second)
    {
        this.month = new IntegerValue(month);
        this.day = new IntegerValue(day);
        this.year = new IntegerValue(year);
        this.hour = new IntegerValue(hour);
        this.minute = new IntegerValue(minute);
        this.second = new IntegerValue(second);
    }

    // Method stringDate formats the month, day, and year of a DateTime
    // object into a display string in mm/dd/yyyy format.
    //
    // Output: String value representing the date components of
    // this DateTime object in mm/dd/yyyy format
    public string stringDate()
    {
        int i;
        string months, days;

        i = month.val();
        months = i.ToString();
        if(i < 10)
            months = "0" + months;

        i = day.val();
        days = i.ToString();
        if(i < 10)
            days = "0" + days;


        return months + "/" + days + "/" + year.val().ToString();
    }
        
    // Method stringTime formats the hour, minute, and second of a DateTime
    // object into a display string in hh:mm:ss format
    //
    // Output: String value representing the time components of
    // this DateTime object in hh:mm:ss format
    public string stringTime()
    {
        int i;
        string hours, minutes, seconds;

        i = hour.val();
        hours = i.ToString();
        if (i < 10)
            hours = "0" + hours;

        i = minute.val();
        minutes = i.ToString();
        if (i < 10)
            minutes = "0" + minutes;

        i = second.val();
        seconds = i.ToString();
        if (i < 10)
            seconds = "0" + seconds;

        return hours + ":" + minutes + ":" + seconds;
    }

    // Method addOneSecond increments the current second value of this
    // DateTime object by positive one, moving it one second into the
    // future. 
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneSecond()
    {
        if (this.second.lessThan(new IntegerValue(60)))
            this.second.addOne();
        else
        {
            this.second = new IntegerValue(0);
            addOneMinute();
        }

        return new DateTime(this);
    }

    // Method addOneMinute increments the current minute value of this
    // DateTime object by positive one, moving it one minute into the 
    // future. 
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneMinute()
    {
        if (this.minute.lessThan(new IntegerValue(60)))
            this.minute.addOne();
        else
        {
            this.minute = new IntegerValue(0);
            addOneHour();
        }

        return new DateTime(this);
    }

    // Method addOneHour increments the current hour value of this DateTime
    // object by positive one, moving it one hour into the future. 
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneHour()
    {
        if (this.hour.lessThan(new IntegerValue(24)))
            this.hour.addOne();
        else
        {
            this.hour = new IntegerValue(0);
            addOneDay();
        }

        return new DateTime(this);
    }

    // Method addOneDay increments the current day value of this DateTime
    // object by positive one, moving it one day into the future.
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneDay()
	{
		IntegerValue days;
		// Is it February?
		if(this.month.equals(new IntegerValue(2)))	
		{
			if(leapYear())
				days = new IntegerValue(29);
			else
				days = new IntegerValue(28);
		}

		// Is it April, June, September, or November?
		else if(this.month.equals(new Value(4)) ||
				this.month.equals(new IntegerValue(6)) ||
				this.month.equals(new IntegerValue(9)) ||
				this.month.equals(new IntegerValue(11)))
			days = new IntegerValue(30);

		// Is it January, March, May, July, August, October, or December?
		else
			days = new IntegerValue(31);

		if(this.day.lessThan(days))
			this.day.addOne();
        else
        {
            this.day = new IntegerValue(0);
            addOneMonth();
        }

        return new DateTime(this);
	}

    // Method addOneMonth increments the current month value of this
    // DateTime object by positive one, moving it one month into the
    // future. 
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneMonth()
    {
        if (this.month.lessThan(new IntegerValue(12)))
            this.month.addOne();
        else
        {
            this.month = new IntegerValue(0);
            addOneYear();
        }

        return new DateTime(this);
    }


    // Method addOneYear increments the current year value of this
    // DateTime object by positive one, moving it one year into the
    // future. 
    //
    // Output: Reference to a copy of the new DateTime object.
    public DateTime addOneYear()
    {
        this.year.addOne();

        return new DateTime(this);
    }

    // Method equals determines whether or not the month, day, year, hour,
    // minute, and second of this DateTime object are all equal to the
    // corresponding member values of a given DateTime object.
    //
    // Input: DateTime object to compare to this DateTime object for
    // equality.
    // Output: Returns true if all member values of this DateTime object
    // are equal to the corresponding value of the input DateTime object;
    // returns false if any one of the member values of this DateTime
    // object is not equal to the corresponding value of the input DateTime
    // object.
    public bool equals(DateTime dateTime)
    {
        return month.equals(dateTime.month) &&
                day.equals(dateTime.day) &&
                year.equals(dateTime.year) &&
                hour.equals(dateTime.hour) &&
                minute.equals(dateTime.minute) &&
                second.equals(dateTime.second);
    }

    // Method leapYear determines whether or not the year of this DateTime
    // object represents a leap year.
    //
    // Output: Returns true if the year represents a leap year; false
    // otherwise. 
    public bool leapYear()
    {
        // Algorithm to determine whether a year is a leap year (has 366
        // days) adapted from: http://support.microsoft.com/kb/214019.
        // In a leap year February has 29 days. Otherwise it has 28.

        if (this.year.divides(new IntegerValue(4)))
            if (this.year.divides(new IntegerValue(100)))
            {
                if (this.year.divides(new IntegerValue(400)))
                    return true;
            }
            else
                return true;
        return false;

    }
} // End of class DateTime

