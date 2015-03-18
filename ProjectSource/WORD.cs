//------------------------------------------------------------------------------
// Word.cs
// Implementation of class Word
//------------------------------------------------------------------------------
using System;


// Class WORD is a generic wrapper class for the system defined data word.
// This implementation uses a single precision floating point number to store
// converted int, char, and float values. Methods are provided to access
// these stored values.
public class WORD
{
    // Member value word is used to store and convert between int, char, and 
    // float values.
    Single word;

    // Constructor for initializing word with an int value converted to Single.
    // 
    // Input: Integer argument value to be converted to Single and stored.
    public WORD(int value)
    {
        // Implementation: Convert int value to Single using ConvertTo.Single,
        // and store this result in word.
        word = Convert.ToSingle(value);
    }

    // Constructor for initializing word with a char value converted to Single.
    // 
    // Input: Character argument value to be converted to Single and stored.
    public WORD(char value)
    {
        // Implementation: Convert char value to Single using Convert.ToSingle,
        // and store this result in word.
        // We must convert char value to int first, since direct conversion
        // between char and float is invalid, and convert this int to
        // float to store in word.
        word = Convert.ToSingle(Convert.ToInt32(value));
    }

    // Constructor for initializing word with a float value converted to Single.
    // 
    // Input: Float argument value to be converted to Single and stored.
    public WORD(float value)
    {
        // Implementation: Convert float value to Single using Convert.ToSingle,
        // and store this result in word.
        word = Convert.ToSingle(value);
    }

    // Method asInt converts the Single value stored in word to an int and
    // returns this result to the method caller.
    //
    // Output: An int value representing Single word converted to type int.
    public int asInt()
    {
        // Implementation: Convert Single word to type int using 
        // Convert.ToInt32, and return this result.
        return Convert.ToInt32(word);
    }

    // Method asChar converts the Single value stored in word to a char and
    // returns this result to the method caller.
    //
    // Output: A char value representing Single word converted to type char.
    public char asChar()
    {
        // Implementation: Convert Single word to type char using 
        // Convert.ToChar, and return this result.
        // We must convert word to int first, since direct conversion
        // between float and char is invalid, and convert this int to
        // char for the result.
        return Convert.ToChar(Convert.ToInt32(word));
    }

    // Method asFloat converts the Single value stored in word to a float and
    // returns this result to the method caller.
    //
    // Output: A float value representing Single word converted to type float.
    public float asFloat()
    {
        // Implementation: Convert Single word to type float using 
        // Convert.ToFloat, and return this result.
        return (float)(word);
    }

} // End of class WORD


