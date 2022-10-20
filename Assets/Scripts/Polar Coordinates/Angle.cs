using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Representation of a 1D angle, stored as degrees in the range (-infinity, infinity). 
/// Use object initializers to define an Angle because there is no constructor.
/// Use properties to obtain unique signed and unsigned angles. 
/// Loosely modeled after Unity's Vector2 struct for best practices. </summary>
public struct Angle : IEquatable<Angle>
{
    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> 360 degrees is a revolution. Degrees are typically user-defined as rational numbers. Angles are stored in degrees because of this property. </summary>
    public float Degrees { get; set; }

    /// <summary> ~6.28 radians is a revolution. Radians are typically user-defined as irrational numbers, i.e. pi times a multiplier, which leads to information loss with floats. </summary>
    public float Radians
    { get => Degrees * Mathf.Deg2Rad;           set => Degrees = value * Mathf.Rad2Deg; }

    /// <summary> 21,600 arcminutes is a revolution. The minute of arc (or MOA, arcminute, or just minute) is 1/60 of a degree. Not a unit of time. </summary>
    public float Arcminutes
    { get => Degrees * 60f;                     set => Degrees = value / 60f; }

    /// <summary> 1,296,000 arcseconds is a revolution. The second of arc (or arcsecond, or just second) is 1/60 of a minute of arc and 1/3600 of a degree. Not a unit of time. </summary>
    public float Arcseconds
    { get => Degrees * 3600f;                   set => Degrees = value / 3600f; }

    /// <summary> 400 grads is a revolution. The grad, also called grade, gradian, or gon. It is a decimal subunit of the quadrant. </summary>
    public float Grads
    { get => Degrees * 10f / 9f;                set => Degrees = value * 0.9f; }

    /// <summary> 1 turn is a revolution. The turn, also cycle, revolution, and rotation, is one complete circular movement or measure. </summary>
    public float Turns
    { get => Degrees / 360f;                    set => Degrees = value * 360f; }

    /// <summary> 24 hour angles is a revolution. An astronomical unit. </summary>
    public float HourAngles
    { get => Degrees / 15f;                     set => Degrees = value * 15f; }

    /// <summary> 32 winds is a revolution. The wind or point is used in navigation. </summary>
    public float Winds
    { get => Degrees * 4f / 45f;                set => Degrees = value * 11.25f; }

    /// <summary> 2000pi milliradians is a revolution. The true milliradian is defined as a thousandth of a radian. </summary>
    public float Milliradians
    { get => Degrees * Mathf.Deg2Rad * 2000f;   set => Degrees = value * Mathf.Rad2Deg / 2000f; }

    /// <summary> 256 binary degrees is a revolution. The binary degree is also known as the binary radian or brad or binary angular measurement (BAM). </summary>
    public float BinaryDegrees
    { get => Degrees * 32f / 45f;               set => Degrees = value * 1.40625f; }

    /// <summary> 4 quadrants is a revolution. One quadrant is also known as a right angle. </summary>
    public float Quadrants
    { get => Degrees / 90f;                     set => Degrees = value * 90f; }

    /// <summary> 6 sextants is a revolution. The sextant is the angle of the equilateral triangle. </summary>
    public float Sextants
    { get => Degrees / 60f;                      set => Degrees = value * 60f; }

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns an effectively equivalent Angle in the signed interval (-180, 180] degrees or (-pi, pi] radians (Read Only). 
    /// Be wary using this with arithmetic operators. For example, -90 and 270 are equivalent degrees when Signed, but -90 * 2 is not equal to 270 * 2. </summary>
    public Angle Signed
    {
        get
        {
            Angle signedAngle = this;
            signedAngle.MapToSignedInterval();
            return signedAngle;
        }
    }

    /// <summary> Returns an effectively equivalent Angle in the unsigned interval [0, 360) degrees (Read Only). 
    /// Be wary using this with arithmetic operators. For example, -90 and 270 are equivalent degrees when Unsigned, but -90 * 2 is not equal to 270 * 2. </summary>
    public Angle Unsigned
    {
        get
        {
            Angle unsignedAngle = this;
            unsignedAngle.MapToUnsignedInterval();
            return unsignedAngle;
        }
    }

    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Maps this Angle to the signed interval (-180, 180] degrees or (-pi, pi] radians. </summary> 
    public void MapToSignedInterval()
    {
        Degrees %= 360f;
        if (Degrees <= -180f)
            Degrees += 360f;
        else if (Degrees > 180f)
            Degrees -= 360f;
    }

    /// <summary> Maps this Angle in to the interval [0, 360) degrees or [0, 2pi) radians. </summary>
    public void MapToUnsignedInterval()
    {
        Degrees %= 360f;
        if (Degrees < 0)
            Degrees += 360f;
    }

    /// <summary> Returns true if the Angles are equal. Use this comparison method for better performance. </summary>
    public bool Equals(Angle other)
    {
        return Degrees == other.Degrees;
    }

    /// <summary> Returns true if the Angles are equal. </summary> 
    public override bool Equals(object other)
    {
        if (!(other is Angle))
            return false;
        else
            return Equals(other);
    }
    
    /// <summary> GetHashCode was generated to supress a warning. </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Degrees);
    }

    /// <summary> As a string, this returns the Angle in degrees instead of the class name. Useful for Unity Test output. Otherwise, use properties to obtain the other angular units for your string. </summary>
    public override string ToString()
    {
        return Degrees + " degrees";
    }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Adds an addend Angle to an augend Angle. </summary>
    public static Angle operator +(Angle augend, Angle addend)
    { return new() { Degrees = augend.Degrees + addend.Degrees }; }

    /// <summary> Subtracts a subtrahend Angle from a minuend Angle. </summary>
    public static Angle operator -(Angle minuend, Angle subtrahend)
    { return new() { Degrees = minuend.Degrees - subtrahend.Degrees }; }

    /// <summary> Negates an Angle, returning a counter rotation. Negating an unsigned Angle returns the conjugate Angle.  </summary>
    public static Angle operator -(Angle angle)
    { return new() { Degrees = -angle.Degrees }; }

    /// <summary> Multiplies a multiplicand Angle by a multiplier Angle. </summary>
    public static Angle operator *(Angle multiplicand, Angle multiplier)
    { return new() { Degrees = multiplicand.Degrees * multiplier.Degrees }; }

    /// <summary> Multiplies a multiplicand Angle by a multiplier number. </summary>
    public static Angle operator *(Angle multiplicand, float multiplier)
    { return new() { Degrees = multiplicand.Degrees * multiplier }; }

    /// <summary> Multiplies a multiplicand number by a multiplier Angle. </summary>
    public static Angle operator *(float multiplicand, Angle multiplier)
    { return new() { Degrees = multiplicand * multiplier.Degrees }; }

    /// <summary> Divides a dividend Angle by a divisor Angle. </summary>
    public static Angle operator /(Angle dividend, Angle divisor)
    { return new() { Degrees = dividend.Degrees / divisor.Degrees }; }

    /// <summary> Divides an dividend Angle by a divisor number. </summary>
    public static Angle operator /(Angle dividend, float divisor)
    { return new() { Degrees = dividend.Degrees / divisor }; }

    /// <summary> Computes the remainder of a division by a dividend Angle by an divisor Angle. </summary>
    public static Angle operator %(Angle dividend, Angle divisor)
    { return new() { Degrees = dividend.Degrees % divisor.Degrees }; }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns true if the Angles are equal. </summary>
    public static bool operator ==(Angle left, Angle right)
    { return (left.Degrees - right.Degrees) == 0; }

    /// <summary> Returns true if the Angles are not equal. </summary>
    public static bool operator !=(Angle left, Angle right)
    { return (left.Degrees - right.Degrees) != 0; }

    /// <summary> Returns true if the left-hand angle is less than the right-hand angle. </summary>
    public static bool operator <(Angle left, Angle right)
    { return left.Degrees < right.Degrees; }

    /// <summary> Returns true if the left-hand angle is less than or equal to the right-hand angle. </summary>
    public static bool operator <=(Angle left, Angle right)
    { return left.Degrees <= right.Degrees; }

    /// <summary> Returns true if the left-hand angle is greater than the right-hand angle. </summary>
    public static bool operator >(Angle left, Angle right)
    { return left.Degrees > right.Degrees; }

    /// <summary> Returns true if the left-hand angle is greater than or equal to the right-hand angle. </summary>
    public static bool operator >=(Angle left, Angle right)
    { return left.Degrees >= right.Degrees; }

    // Conversion Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    /// <summary> Converts a Vector2 to an Angle. </summary>
    public static implicit operator Angle(Vector2 vector)
    {
        return new() { Degrees = Mathf.Atan2(vector.y, vector.x) };
    }

    /// <summary> Converts an Angle to a Y-axis angle Quaternion in Unity's counterclockwise Y-axis space when viewed from top-down. </summary>
    public static implicit operator Quaternion(Angle angle)
    {
        return Quaternion.Euler(0, -angle.Degrees, 0);
    }

    // Static Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Shorthand for writing new Angle() { Degrees = 0 }; </summary>
    public static Angle Zero
    { get => new() { Degrees = 0 }; }

    /// <summary> Shorthand for writing new Angle() { Degrees = 90f }; </summary>
    public static Angle Right
    { get => new() { Degrees = 90f }; }

    /// <summary> Shorthand for writing new Angle() { Degrees = 180f }; </summary>
    public static Angle Straight
    { get => new() { Degrees = 180f }; }

    /// <summary> Shorthand for writing new Angle() { Degrees = 360f }; </summary>
    public static Angle Full
    { get => new() { Degrees = 360f }; }

    // Static Methods:
    // Don't include dependencies on other classes in static methods. The Angle class should be able to be imported by itself.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Lerp formula derived from: https://en.wikipedia.org/wiki/Linear_interpolation </summary>
    public static Angle Lerp(Angle from, Angle to, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        return from + (alpha * (to - from));
    }

    /// <summary> Subtracts a subtrahend Angle from a minuend Angle and returns the smallest signed Angle difference. </summary>
    public static Angle SmallestSignedDifference(Angle minuend, Angle subtrahend)
    {
        return (minuend - subtrahend).Signed;
    }
    
}

/*
Original Author: James Roquelara
Start Date: 9/14/2022

Resources:
Angles: https://en.wikipedia.org/wiki/Angle
Polar Coordinates: https://en.wikipedia.org/wiki/Polar_coordinate_system
C# Conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
Use Ctrl+F to find words on Firefox. You can quickly learn about the names used throughout this class.
*/