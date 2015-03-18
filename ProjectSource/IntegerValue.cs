//------------------------------------------------------------------------------
// IntegerValue.cs
// Implementation of class IntegerValue
//------------------------------------------------------------------------------
using System;

// Class IntegerValue extends class Value providing function overrides
// for methods equals, greaterThan, and lessThan. IntegerValue is intended to
// provide integer specific operations to the basic functionality of class
// Value. A constructor is provided to initialize protected Value member
// variable value as type int.
public class IntegerValue : Value
{
    // Constructor for initializing the derived data WORD value 
    // to a given int value.
    //
    // Input: Int initialization value for the value member of this Value
    // object.
	public IntegerValue(int value)
	{
		this.value = new WORD(value);
	}

    // Constructor for initializing the derived data WORD value 
    // to the WORD integer value member of a given IntegerValue.
    //
    // Input: IntegerValue initialization object.
	public IntegerValue(IntegerValue value)
	{
        this.value = new WORD(value.value.asInt());
	}


	// Method addOne increments this IntegerValue object by positive one. 
 	//
	// Output: Reference to a copy of the result of incrementing this
    // IntegerValue object by one.
	public IntegerValue addOne()
	{
		this.value = new WORD(this.value.asInt() + 1); 
		return new IntegerValue(this);
	}

	// Method divides determines whether this IntegerValue object’s value
    // member (int) is evenly divisible by a given Value object’s
    // value member. 
    //
    // Input: Reference to an Value object.
    // Output: Returns true if this IntegerValue object’s int value member
    // is divisible by the given Value object’s value member.
    public bool divides(Value value)
    {
	    // Calculate the remainder on division of this.value by
	    // value.value.
        int remainder = this.value.asInt() % value.val().asInt();

        // If the remainder is zero then return true; otherwise return 
        // false
        if(remainder == 0)
            return true;

        return false;
    }

    // Method lessThan determines whether or not this IntegerValue object’s
    // value member is less than a given IntegerValue’s value member. Both // values are viewed as int value types. 
    //
    // Input: An IntegerValue object to compare to this IntegerValue.
    // Output: true if this IntegerValue is less than the input; false if 
    // this IntegerValue is not less than the input.
	public override bool lessThan(Value value)
	{ 
		return this.value.asInt() < value.val().asInt();
	}

    // Method greaterThan determines whether or not this IntegerValue
    // object’s value member is greater than a given IntegerValue’s value
    // member. Both values are viewed as int value types.
    //
    // Input: An IntegerValue to compare to this IntegerValue.
    // Output: true if this IntegerValue is greater than the input; false
    // if this IntegerValue is not greater than the input.
	public override bool greaterThan(Value value)
	{
		return this.value.asInt() > value.val().asInt();
	}

	// Method equals determines whether this IntegerValue object’s value
    // member is equal to a given IntegerValue’s value member. Both values
    // are viewed as int value types.
	//
	// Input: An IntegerValue object to compare to this IntegerValue.
	// Output: true if this IntegerValue object is equal to the input;
    // false if this IntegerValue is not equal to the input.
	public override bool equals(Value value)
	{
		return this.value.asInt() == value.val().asInt();
	}

	// Method val returns the numerical value of this IntegerValue object.
	//
	// Output: Returns the integer value of this IntegerValue as an int.
	public new int val()
	{
		return this.value.asInt();
	}	

} //End of class IntegerValue

