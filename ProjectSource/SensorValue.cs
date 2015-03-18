//------------------------------------------------------------------------------
// SensorValue.cs
// Implementation of class SensorValue.
//------------------------------------------------------------------------------
using System;

// Class SensorValue extends class Value providing function overrides
// for greaterThan and lessThan. SensorValue is intended to allow flexibility
// in choice of format for the input data from real-time sensors to
// be used in the weather tracking system, providing constructors for WORD
// and language specific float values. It is assumed that data input from
// sensors is in WORD data quantities formatted as floating point numbers.
// SensorValue assists with storing this data in protected Value member
// variable value, and with comparing this data to other float values.
public class SensorValue : Value
{
    // Constructor for creating SensorValue objects based on float.
    //
    // Input: Value of type float for initializing this SensorValue
    // object’s value member with.
    public SensorValue(float value)
    {
        // Initialize this Value object with the given float value.
        this.value = new WORD(value);
    }

    // Constructor for initializing the derived data WORD value 
    // to the WORD integer value member of a given SensorValue.
    //
    // Input: IntegerValue initialization object.
    public SensorValue(SensorValue value)
	{
        // Initialize this Value object with that of the given 
        // SensorValue.
        this.value = new WORD(value.value.asFloat());
	}

    // Method greaterThan determines whether or not this SensorValue
    // object’s value member is greater than a given Value object
    // argument’s value member. Both values are viewed as float value
    // types.
    //
    // Input: Reference to a Value object to compare to this SensorValue.
    // Output: Returns true if this SensorValue is greater than the input
    // Value; false if this SensorValue is not greater than the input
    // Value.
    public override bool greaterThan(Value value)
    {
        return this.value.asFloat() > value.val().asFloat();
    }

    // Method lessThan determines whether or not this SensorValue object’s
    // value member is less than a given Value object argument’s value
    // member. Both values are viewed as float value types. 
    //
    // Input: Reference to a Value object to compare to this SensorValue.
    // Output: true if this SensorValue is less than the input Value;
    // false if this SensorValue is not less than the input Value.

    public override bool lessThan(Value value)
    {
        return this.value.asFloat() < value.val().asFloat();
    }

    // Method setToMax determines the maximum of this sensor value and a
    // given sensor value, and sets this sensor value to it.
    public void setToMax(SensorValue value)
    {
        if (lessThan(value))
            this.value = value.value;
    }

    // Method setToMin determines the minimum of this sensor value and a
    // given sensor value, and sets this sensor value to it.
    public void setToMin(SensorValue value)
    {
        if (greaterThan(value))
            this.value = value.value;
    }

    // Method val returns the numerical value of this SensorValue object.
    //
    // Output: Returns the numerical value of this SensorValue as float.
    public new float val()
    {
        return this.value.asFloat();
    }

} // End of class SensorValue
