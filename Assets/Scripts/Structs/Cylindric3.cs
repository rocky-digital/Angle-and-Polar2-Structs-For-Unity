using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Representation of a 3D cylindrical coordinate. 
/// Use object initializers to define the Angle component.
/// Be wary using arithmetic operators without acessing properties.
/// Use properties to obtain unique coordinates. Loosely modeled after Unity's Vector2 struct for best practices. </summary>
public struct Cylindric3
{
    // Constructors:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public Cylindric3(float length, float height, Angle angle)
    {
        Length = length;
        Height = height;
        Angle = angle;
    }

    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> The magnitude, radius, or radial distance of the Cylindric3. </summary>
    public float Length { get; set; }

    /// <summary> The height of the Cylindric3. </summary>
    public float Height { get; set; }

    /// <summary> Angular component of the Cylindric3. Not a property due to CS1612. </summary>
    public Angle Angle;

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> If the Length is negative, this returns an effectively equivalent Cylindric3 with a Length in the positive interval [0, infinity) and adds 180 degrees to the angle (Read Only). </summary>
    public Cylindric3 Positive
    {
        get
        {
            Cylindric3 cylindric = this;
            cylindric.MapMagnitudeToPositiveIntervalAndChangeAngle();
            return cylindric;
        }
    }

    /// <summary> Returns an effectively equivalent Cylindric3 with an Angle in the unsigned interval [0, 360) degrees (Read Only). </summary>
    public Cylindric3 Unsigned
    {
        get
        {
            Cylindric3 cylindric = this;
            cylindric.Angle.MapToUnsignedInterval();
            return cylindric;
        }
    }

    /// <summary> Returns an effectively equivalent Cylindric3 with an Angle in the signed interval (-180, 180] degrees (Read Only). </summary>
    public Cylindric3 Signed
    {
        get
        {
            Cylindric3 cylindric = this;
            cylindric.Angle.MapToSignedInterval();
            return cylindric;
        }
    }

    // Static Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Shorthand for writing new Cylindric3(0, 0, new() { Degrees = 0f } ); </summary>
    public static Cylindric3 Zero
    { get => new(0, 0, new() { Degrees = 0f }); }

    /// <summary> Shorthand for writing new(float.PositiveInfinity, float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }); </summary>
    public static Cylindric3 PositiveInfinity
    { get => new(float.PositiveInfinity, float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }); }

    /// <summary> Shorthand for writing new(float.NegativeInfinity, float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }); </summary>
    public static Cylindric3 NegativeInfinity
    { get => new(float.NegativeInfinity, float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }); }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Adds an addend Cylindric3 to an augend Cylindric3, component-wise. </summary>
    public static Cylindric3 operator +(Cylindric3 augend, Cylindric3 addend)
    {
        return new()
        {
            Length = augend.Length + addend.Length,
            Height = augend.Height + addend.Height,
            Angle = augend.Angle + addend.Angle
        };
    }

    /// <summary> Subtracts a subtrahend Cylindric3 from a minuend Cylindric3, component-wise. </summary>
    public static Cylindric3 operator -(Cylindric3 minuend, Cylindric3 subtrahend)
    {
        return new()
        {
            Length = minuend.Length - subtrahend.Length,
            Height = minuend.Height - subtrahend.Height,
            Angle = minuend.Angle - subtrahend.Angle
        };
    }

    /// <summary> Multiplies a multiplicand Cylindric3 by a multiplier Cylindric3, component-wise. </summary>
    public static Cylindric3 operator *(Cylindric3 multiplicand, Cylindric3 multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier.Length,
            Height = multiplicand.Height * multiplier.Height,
            Angle = multiplicand.Angle * multiplier.Angle
        };
    }

    /// <summary> Multiplies a multiplicand Cylindric3 by a multiplier number, component-wise. </summary>
    public static Cylindric3 operator *(Cylindric3 multiplicand, float multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier,
            Height = multiplicand.Height * multiplier,
            Angle = multiplicand.Angle * multiplier
        };
    }

    /// <summary> Multiplies a multiplicand number by a multiplier Cylindric3, component-wise. </summary>
    public static Cylindric3 operator *(float multiplicand, Cylindric3 multiplier)
    {
        return new()
        {
            Length = multiplicand * multiplier.Length,
            Height = multiplicand * multiplier.Height,
            Angle = multiplicand * multiplier.Angle
        };
    }

    /// <summary> Divides a dividend Cylindric3 by a divisor Cylindric3, component-wise. </summary>
    public static Cylindric3 operator /(Cylindric3 dividend, Cylindric3 divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor.Length,
            Height = dividend.Height / divisor.Height,
            Angle = dividend.Angle / divisor.Angle
        };
    }

    /// <summary> Divides an dividend Cylindric3 by a divisor number, component-wise. </summary>
    public static Cylindric3 operator /(Cylindric3 dividend, float divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor,
            Height = dividend.Height / divisor,
            Angle = dividend.Angle / divisor
        };
    }

    /// <summary> Computes the remainder of a division by a dividend Cylindric3 by an divisor Cylindric3, component-wise. </summary>
    public static Cylindric3 operator %(Cylindric3 dividend, Cylindric3 divisor)
    {
        return new()
        {
            Length = dividend.Length % divisor.Length,
            Height = dividend.Length % divisor.Height,
            Angle = dividend.Angle % divisor.Angle
        };
    }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns true if the polar coordinates are equal. </summary>
    public static bool operator ==(Cylindric3 lhs, Cylindric3 rhs)
    { return (lhs.Length == rhs.Length) && (lhs.Height == rhs.Height) && (lhs.Angle == rhs.Angle); }

    /// <summary> Returns true if the polar coordinates are not equal. </summary>
    public static bool operator !=(Cylindric3 lhs, Cylindric3 rhs)
    { return (lhs.Length != rhs.Length) || (lhs.Height != rhs.Height) || (lhs.Angle != rhs.Angle); }

    // Conversion Operators:
    // Don't include dependencies on non-UnityEngine classes here. The Cylindric3 class should be able to be imported with only itself and the Angle class.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Converts a Vector2 to a Cylindric3. The XY components derive the Length and Angle components. </summary>
    public static implicit operator Cylindric3(Vector2 vector)
    {
        return new()
        {
            Length = vector.magnitude,
            Angle = new() { Radians = Mathf.Atan2(vector.y, vector.x) }
        };
    }

    /// <summary> Converts a Cylindric3 to a Vector2. The Length and Angle derive the XY components. </summary>
    public static implicit operator Vector2(Cylindric3 cylindric)
    {
        return new Vector2(
            cylindric.Length * Mathf.Cos(cylindric.Angle.Radians),
            cylindric.Length * Mathf.Sin(cylindric.Angle.Radians));
    }

    /// <summary> Converts a Cylindric3 to a Vector3 in Unity's space. The Height equals the Y component, and the Length and Angle derive the XZ components. </summary>
    public static implicit operator Vector3(Cylindric3 cylindric)
    {
        return new Vector3(
            cylindric.Length * Mathf.Cos(-cylindric.Angle.Radians),
            cylindric.Height,
            cylindric.Length * Mathf.Sin(-cylindric.Angle.Radians));
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
    public bool Equals(Cylindric3 other)
    {
        return (Length == other.Length) && (Height == other.Height) && (Angle == other.Angle);
    }

    /// <summary> Returns true if the polar coordinates are equal, but false if the other is not a Cylindric3. </summary> 
    public override bool Equals(object other)
    {
        if (!(other is Cylindric3))
            return false;
        else
            return Equals((Cylindric3)other);
    }

    /// <summary> GetHashCode was generated to supress a warning. </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Length, Height, Angle);
    }

    /// <summary> As a string, this returns the Length and Angle in degrees instead of the class name. Useful for Unity Test output. Otherwise, use properties to obtain the other angular units for your string. </summary>
    public override string ToString()
    {
        return Length + " length, " + Height + " height, " + Angle.Degrees + " degrees";
    }

    // Static Methods:
    // Don't include dependencies on non-UnityEngine classes here. The Cylindric3 class should be able to be imported with only itself and the Angle class.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Linearly interpolates between two Cylindric3s, component-wise. </summary>
    public static Cylindric3 Lerp(Cylindric3 fromPoint, Cylindric3 toPoint, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        return fromPoint + (alpha * (toPoint - fromPoint));
    }

    /// <summary> Linearly interpolates between two Cylindric3s, component-wise, without clamping the alpha to [0, 1]. s</summary>
    public static Cylindric3 LerpUnclamped(Cylindric3 fromPoint, Cylindric3 toPoint, float alpha)
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
Cylindrical Coordinates: https://en.wikipedia.org/wiki/Cylindrical_coordinate_system
C# Conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
Linear Interpolation: https://en.wikipedia.org/wiki/Linear_interpolation 
Unity's Vector2: https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Vector2.cs
Use Ctrl+F to find words on Firefox. You can quickly learn about the names used throughout this class.
*/