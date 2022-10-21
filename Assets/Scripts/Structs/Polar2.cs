using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Representation of a 2D polar coordinate. 
/// Use object initializers to define the Angle component.
/// These coordinates do not exactly represent Cartesian coordinates, so be wary using arithmetic operators without acessing properties.
/// Use properties to obtain unique coordinates. Loosely modeled after Unity's Vector2 struct for best practices. </summary>
public struct Polar2
{
    // Constructors:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public Polar2(float length, Angle angle)
    {
        Length = length;
        Angle = angle;
    }

    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> The magnitude, radius, or radial distance of the polar coordinate. </summary>
    public float Length { get; set; }

    /// <summary> Angular component of the polar coordinate. Not a property due to CS1612. </summary>
    public Angle Angle;

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> If the Length is negative, this returns an effectively equivalent Polar2 with a Length in the positive interval [0, infinity) and adds 180 degrees to the angle (Read Only). </summary>
    public Polar2 Positive
    {
        get
        {
            Polar2 polarCoordinate = this;
            polarCoordinate.MapMagnitudeToPositiveIntervalAndChangeAngle();
            return polarCoordinate;
        }
    }

    /// <summary> Returns an effectively equivalent Polar2 with an Angle in the unsigned interval [0, 360) degrees (Read Only). </summary>
    public Polar2 Unsigned
    {
        get
        {
            Polar2 polarCoordinate = this;
            polarCoordinate.Angle.MapToUnsignedInterval();
            return polarCoordinate;
        }
    }

    /// <summary> Returns an effectively equivalent Polar2 with an Angle in the signed interval (-180, 180] degrees (Read Only). </summary>
    public Polar2 Signed
    {
        get
        {
            Polar2 polar2 = this;
            polar2.Angle.MapToSignedInterval();
            return polar2;
        }
    }

    // Static Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Shorthand for writing new Polar2(0, new() { Degrees = 0f } ); </summary>
    public static Polar2 Zero
    {
        get => new (0, new() { Degrees = 0f });
    }

    /// <summary> Shorthand for writing new(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }); </summary>
    public static Polar2 PositiveInfinity
    {
        get => new(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity });
    }

    /// <summary> Shorthand for writing new(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }); </summary>
    public static Polar2 NegativeInfinity
    {
        get => new(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity });
    }

    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Maps this Length to the interval [0, infinity) and adds 180 degrees to the Angle. </summary>
    public void MapMagnitudeToPositiveIntervalAndChangeAngle()
    {
        if (Length < 0)
        {
            Length = Mathf.Abs(Length);
            Angle.Degrees += 180f;
        }
    }

    /// <summary> Returns true if the polar coordinates are equal. Use this comparison method for better performance. </summary>
    public bool Equals(Polar2 other)
    {
        return (Length == other.Length) && (Angle == other.Angle);
    }

    /// <summary> Returns true if the polar coordinates are equal, but false if the other is not a Polar2. </summary> 
    public override bool Equals(object other)
    {
        if (!(other is Polar2))
            return false;
        else
            return Equals((Polar2)other);
    }

    /// <summary> GetHashCode was generated to supress a warning. </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Length, Angle);
    }

    /// <summary> As a string, this returns the Length and Angle in degrees instead of the class name. Useful for Unity Test output. Otherwise, use properties to obtain the other angular units for your string. </summary>
    public override string ToString()
    {
        return Length + " length, " + Angle.Degrees + " degrees";
    }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Adds an addend Polar2 to an augend Polar2, component-wise. </summary>
    public static Polar2 operator +(Polar2 augend, Polar2 addend)
    { return new() { 
        Length = augend.Length + addend.Length, 
        Angle = augend.Angle + addend.Angle }; }

    /// <summary> Subtracts a subtrahend Polar2 from a minuend Polar2, component-wise. </summary>
    public static Polar2 operator -(Polar2 minuend, Polar2 subtrahend)
    { return new() { 
        Length = minuend.Length - subtrahend.Length, 
        Angle = minuend.Angle - subtrahend.Angle }; }

    /// <summary> Multiplies a multiplicand Polar2 by a multiplier Polar2, component-wise. </summary>
    public static Polar2 operator *(Polar2 multiplicand, Polar2 multiplier)
    { return new() { 
        Length = multiplicand.Length * multiplier.Length, 
        Angle = multiplicand.Angle * multiplier.Angle }; }

    /// <summary> Multiplies a multiplicand Polar2 by a multiplier number, component-wise. </summary>
    public static Polar2 operator *(Polar2 multiplicand, float multiplier)
    { return new() { 
        Length = multiplicand.Length * multiplier, 
        Angle = multiplicand.Angle * multiplier }; }

    /// <summary> Multiplies a multiplicand number by a multiplier Polar2, component-wise. </summary>
    public static Polar2 operator *(float multiplicand, Polar2 multiplier)
    { return new() { 
        Length = multiplicand * multiplier.Length, 
        Angle = multiplicand * multiplier.Angle }; }

    /// <summary> Divides a dividend Polar2 by a divisor Polar2, component-wise. </summary>
    public static Polar2 operator /(Polar2 dividend, Polar2 divisor)
    { return new() { 
        Length = dividend.Length / divisor.Length, 
        Angle = dividend.Angle / divisor.Angle }; }

    /// <summary> Divides an dividend Polar2 by a divisor number, component-wise. </summary>
    public static Polar2 operator /(Polar2 dividend, float divisor)
    { return new() { 
        Length = dividend.Length / divisor, 
        Angle = dividend.Angle / divisor }; }

    /// <summary> Computes the remainder of a division by a dividend Polar2 by an divisor Polar2, component-wise. </summary>
    public static Polar2 operator %(Polar2 dividend, Polar2 divisor)
    { return new() { 
        Length = dividend.Length % divisor.Length, 
        Angle = dividend.Angle % divisor.Angle }; }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns true if the polar coordinates are equal. </summary>
    public static bool operator ==(Polar2 lhs, Polar2 rhs)
    { return (lhs.Length == rhs.Length) && (lhs.Angle == rhs.Angle); }

    /// <summary> Returns true if the polar coordinates are not equal. </summary>
    public static bool operator !=(Polar2 lhs, Polar2 rhs)
    { return (lhs.Length != rhs.Length) || (lhs.Angle != rhs.Angle); }

    // Conversion Operators:
    // Don't include dependencies on non-UnityEngine classes here. The Polar2 class should be able to be imported with only itself and the Angle class.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Converts a Vector2 to a Polar2. </summary>
    public static implicit operator Polar2(Vector2 vector)
    {
        return new()
        {
            Length = vector.magnitude,
            Angle = new() { Radians = Mathf.Atan2(vector.y, vector.x) }
        };
    }

    /// <summary> Converts a Polar2 to a Vector2. </summary>
    public static implicit operator Vector2(Polar2 polarCoordinate)
    {
        return new Vector2(
            polarCoordinate.Length * Mathf.Cos(polarCoordinate.Angle.Radians),
            polarCoordinate.Length * Mathf.Sin(polarCoordinate.Angle.Radians));
    }

    /// <summary> Converts a Polar2 to a Vector3 on the XZ plane as viewed from above. Useful for top-down games. </summary>
    public static implicit operator Vector3(Polar2 polarCoordinate)
    {
        return new Vector3(
            polarCoordinate.Length * Mathf.Cos(polarCoordinate.Angle.Radians),
            0,
            polarCoordinate.Length * Mathf.Sin(polarCoordinate.Angle.Radians));
    }

    // Static Methods:
    // Don't include dependencies on non-UnityEngine classes here. The Polar2 class should be able to be imported with only itself and the Angle class.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Linearly interpolates between two Polar2s, component-wise. Lerp formula derived from: https://en.wikipedia.org/wiki/Linear_interpolation </summary>
    public static Polar2 Lerp(Polar2 fromPoint, Polar2 toPoint, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        return fromPoint + (alpha * (toPoint - fromPoint));
    }

    /// <summary> Linearly interpolates between two Polar2s, component-wise, without clamping the alpha to [0, 1]. Lerp formula derived from: https://en.wikipedia.org/wiki/Linear_interpolation </summary>
    public static Polar2 LerpLerpUnclamped(Polar2 fromPoint, Polar2 toPoint, float alpha)
    {
        return fromPoint + (alpha * (toPoint - fromPoint));
    }



}

/*
Original Author: James Roquelara
Start Date: 9/14/2022

Resources:
Angles: https://en.wikipedia.org/wiki/Angle
Polar Coordinates: https://en.wikipedia.org/wiki/Polar_coordinate_system
C# Conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
Linear Interpolation: https://en.wikipedia.org/wiki/Linear_interpolation 
Use Ctrl+F to find words on Firefox. You can quickly learn about the names used throughout this class.
*/