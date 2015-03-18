//------------------------------------------------------------------------------
// Value.cs
// Implementation of class Value
//------------------------------------------------------------------------------
using System;

// Class Value is a virtual base class to wrap the functionality of class
// WORD, providing conversion constructors for int, char, and float. Virtual
// methods for comparing Value objects are also provided.
public class Value
{
    // A numerical data value representing this Value object. Access is
    // defined as protected so it is visible to derived class
    // implementations.
    protected WORD value;

    // Constructor for initializing the data value representing this Value
    // object to zero.
    public Value()
    {
        this.value = new WORD(0);
    }

    // Constructor for initializing the data value representing this Value
    // object to a given int value.
    //
    // Input: Int initialization value for the value member of this Value
    // object.
    public Value(int value)
    {
        this.value = new WORD(value);
    }

    // Constructor for initializing the data value representing this Value
    // object to a given char value.
    //
    // Input: Char initialization value for the value member of this Value
    // object.
    public Value(char value)
    {
        this.value = new WORD(value);
    }

    // Constructor for initializing the data value representing this Value
    // object to a given float value.
    //
    // Input: Float initialization value for the value member of this Value
    // object.
    public Value(float value)
    {
        this.value = new WORD(value);
    }

    // Method val returns the numerical value of this Value object.
    //
    // Output: Returns the numerical value of this SensorValue as float.
    public WORD val()
    {
        return value;
    }

    // Method lessThan determines whether or not this Value object is less 
    // than a given Value object argument. Override lessThan in derived 
    // classes to provide an implementation of the desired functionality.
    //
    // Input: Reference to a Value object to compare to this Value object.
    // Output: true if this Value is less than the input Value; false if
    // this Value is not less than the input Value.
    public virtual bool lessThan(Value value)
    {
        // Virtual method not implemented
        return false;
    }

    // Method greaterThan determines whether or not this Value object is 
    // greater than a given Value object argument. Override greaterThan in 
    // derived classes to provide an implementation of the desired 
    // functionality.
    //
    // Input: Reference to a Value object to compare to this Value object.
    // Output: Returns true if this Value is greater than the input Value;
    // false if this Value is not greater than the input Value.
    public virtual bool greaterThan(Value value)
    {
        // Virtual method not implemented	
        return false;
    }

    // Method equals determines whether this Value object is equal to a
    // given Value object. Override equals in derived classes to provide a
    // desired implementation.
    //
    // Input: Reference to a Value object to compare to this Value object
    // Output: Returns true if this Value object is equal to the input
    // Value object; returns false if this Value object is not equal to
    // the input Value object.
    public virtual bool equals(Value value)
    {
        // Virtual method not implemented
        return false;
    }

} // End of class Value


