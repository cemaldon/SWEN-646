//------------------------------------------------------------------------------
// CharacterValue.cs
// Implementation of class CharacterValue
//------------------------------------------------------------------------------
using System;

// Class CharacterValue extends class Value providing function overrides for
// methods equals, greaterThan, and lessThan. CharacterValue is intended to
// provide character specific operations to the basic functionality of class
// Value. A constructor is provided to initialize protected Value member
// variable value as type char.
public class CharacterValue : Value
{
    // Constructor for initializing the inherited data WORD value 
    // to a given char value.
    //
    // Input: Char initialization value for the value member of this Value
    // object.
    public CharacterValue(char value)
    {
        this.value = new WORD(value);
    }

    // Constructor for initializing the inhereted data WORD value 
    // to the WORD character value member of a given CharacterValue.
    //
    // Input: CharacterValue initialization object.
    public CharacterValue(CharacterValue value)
    {
        this.value = new WORD(value.value.asChar());
    }

    // Method lessThan determines whether or not this CharacterValue
    // object’s value member is less than a given Value object argument’s
    // value member. Both values are viewed as char value types. 
    //
    // Input: CharacterValue object to compare to this CharacterValue.
    // Output: true if this CharacterValue is less than the input;
    // false if this CharacterValue is not less than the input Value.
    public override bool lessThan(Value value)
    {
        int order = this.value.asChar().CompareTo(value.val().asChar());

        return order < 0;
    }

    // Method greaterThan determines whether or not this CharacterValue
    // object’s value member is greater than a given CharacterValue’s value
    // member. Both values are viewed as char value types.
    //
    // Input: A CharacterValue object to compare to this CharacterValue.
    // Output: true if this CharacterValue is greater than the input; false
    // if this CharacterValue is not greater than the input.
    public override bool greaterThan(Value value)
    {
        int order = this.value.asChar().CompareTo(value.val().asChar());

        return order > 0;
    }

    // Method equals determines whether this CharacterValue object’s value
    // member is equal to a given CharacterValue’s value member. Both
    // values are viewed as char value types.
    //
    // Input: A CharacterValue object to compare to this CharacterValue.
    // Output: true if this CharacterValue object is equal to the input;
    // false if this CharacterValue is not equal to the input.
    public override bool equals(Value value)
    {
        int order = this.value.asChar().CompareTo(value.val().asChar());

        return order == 0;
    }

    // Method val returns the numerical value of this CharacterValue.
    //
    // Output: Returns the numerical value of this CharacterValue as char.
    public new char val()
    {
        return this.value.asChar();
    }

} // End of class CharacterValue

