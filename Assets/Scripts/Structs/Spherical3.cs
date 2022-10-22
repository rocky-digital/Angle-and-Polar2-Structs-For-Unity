// Spherical3
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Representation of a 3D spherical coordinate, adhering to the azimuth and zenith conventions.
/// Use object initializers to define the Azimuth and Zenith Angles.
/// Be wary using arithmetic operators without acessing properties.
/// Use properties to obtain unique coordinates. Loosely modeled after Unity's Vector2 struct for best practices. </summary>
public struct Spherical3
{
    // Constructors:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public Spherical3(float length, Angle azimuth, Angle zenith)
    {
        Length = length;
        Azimuth = azimuth;
        Zenith = zenith;
    }

    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> The magnitude, radius, or radial distance of the polar coordinate. </summary>
    public float Length { get; set; }

    /// <summary> Azimuth Angle of the polar coordinate. Not a property due to CS1612. </summary>
    public Angle Azimuth;

    /// <summary> Zenith Angle of the polar coordinate. Not a property due to CS1612. </summary>
    public Angle Zenith;

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> If the Length is negative, this returns an effectively equivalent Spherical3 with a Length in the positive interval [0, infinity) and adds 180 degrees to the Azimuth (Read Only). </summary>
    public Spherical3 Positive
    {
        get
        {
            Spherical3 polar = this;
            polar.MapMagnitudeToPositiveIntervalAndChangeAngle();
            return polar;
        }
    }

    /// <summary> Returns an effectively equivalent Spherical3 with a Azimuth in the signed interval (-180, 180] degrees (Read Only). </summary>
    public Spherical3 SignedAzimuth
    {
        get
        {
            Spherical3 polar = this;
            polar.Azimuth.MapToSignedInterval();
            return polar;
        }
    }

    /// <summary> Returns an effectively equivalent Spherical3 with a Azimuth in the unsigned interval [0, 360) degrees (Read Only). </summary>
    public Spherical3 UnsignedAzimuth
    {
        get
        {
            Spherical3 polar = this;
            polar.Azimuth.MapToUnsignedInterval();
            return polar;
        }
    }

    /// <summary> If the Zenith is less than 0 degrees or greater than 180 degrees, 
    /// this returns an effectively equivalent Spherical3 with a Zenith in the unsigned interval [0, 180] degrees 
    /// and adds 180 degrees to the Azimuth (Read Only). </summary>
    public Spherical3 UnsignedZenith
    {
        get
        {
            Spherical3 polar = this;
            polar.MapZenithToUnsignedInterval();
            return polar;
        }
    }


    // Static Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Shorthand for writing new Spherical3(0, new() { Degrees = 0f }, new() { Degrees = 0f }); </summary>
    public static Spherical3 Zero
    { get => new(0, new() { Degrees = 0f }, new() { Degrees = 0f }); }

    /// <summary> Shorthand for writing new Spherical3(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }, new() { Degrees = float.PositiveInfinity }); </summary>
    public static Spherical3 PositiveInfinity
    { get => new(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }, new() { Degrees = float.PositiveInfinity }); }

    /// <summary> Shorthand for writing new Spherical3(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }, new() { Degrees = float.NegativeInfinity }); </summary>
    public static Spherical3 NegativeInfinity
    { get => new(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }, new() { Degrees = float.NegativeInfinity }); }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Adds an addend Spherical3 to an augend Spherical3, component-wise. </summary>
    public static Spherical3 operator +(Spherical3 augend, Spherical3 addend)
    {
        return new()
        {
            Length = augend.Length + addend.Length,
            Azimuth = augend.Azimuth + addend.Azimuth,
            Zenith = augend.Zenith + addend.Zenith
        };
    }

    /// <summary> Subtracts a subtrahend Spherical3 from a minuend Spherical3, component-wise. </summary>
    public static Spherical3 operator -(Spherical3 minuend, Spherical3 subtrahend)
    {
        return new()
        {
            Length = minuend.Length - subtrahend.Length,
            Azimuth = minuend.Azimuth - subtrahend.Azimuth,
            Zenith = minuend.Zenith - subtrahend.Zenith
        };
    }

    /// <summary> Multiplies a multiplicand Spherical3 by a multiplier Spherical3, component-wise. </summary>
    public static Spherical3 operator *(Spherical3 multiplicand, Spherical3 multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier.Length,
            Azimuth = multiplicand.Azimuth * multiplier.Azimuth,
            Zenith = multiplicand.Zenith * multiplier.Zenith
        };
    }

    /// <summary> Multiplies a multiplicand Spherical3 by a multiplier number, component-wise. </summary>
    public static Spherical3 operator *(Spherical3 multiplicand, float multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier,
            Azimuth = multiplicand.Azimuth * multiplier,
            Zenith = multiplicand.Zenith * multiplier
        };
    }

    /// <summary> Multiplies a multiplicand number by a multiplier Spherical3, component-wise. </summary>
    public static Spherical3 operator *(float multiplicand, Spherical3 multiplier)
    {
        return new()
        {
            Length = multiplicand * multiplier.Length,
            Azimuth = multiplicand * multiplier.Azimuth,
            Zenith = multiplicand * multiplier.Zenith
        };
    }

    /// <summary> Divides a dividend Spherical3 by a divisor Spherical3, component-wise. </summary>
    public static Spherical3 operator /(Spherical3 dividend, Spherical3 divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor.Length,
            Azimuth = dividend.Azimuth / divisor.Azimuth,
            Zenith = dividend.Zenith / divisor.Zenith
        };
    }

    /// <summary> Divides an dividend Spherical3 by a divisor number, component-wise. </summary>
    public static Spherical3 operator /(Spherical3 dividend, float divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor,
            Azimuth = dividend.Azimuth / divisor,
            Zenith = dividend.Zenith / divisor
        };
    }

    /// <summary> Computes the remainder of a division by a dividend Spherical3 by an divisor Spherical3, component-wise. </summary>
    public static Spherical3 operator %(Spherical3 dividend, Spherical3 divisor)
    {
        return new()
        {
            Length = dividend.Length % divisor.Length,
            Azimuth = dividend.Azimuth % divisor.Azimuth,
            Zenith = dividend.Zenith % divisor.Zenith
        };
    }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns true if the Polar3s are equal. </summary>
    public static bool operator ==(Spherical3 lhs, Spherical3 rhs)
    { return (lhs.Length == rhs.Length) && (lhs.Azimuth == rhs.Azimuth) && (lhs.Zenith == rhs.Zenith); }

    /// <summary> Returns true if the Polar3s are not equal. </summary>
    public static bool operator !=(Spherical3 lhs, Spherical3 rhs)
    { return (lhs.Length != rhs.Length) || (lhs.Azimuth != rhs.Azimuth) || (lhs.Zenith != rhs.Zenith); }

    // Conversion Operators:
    // Don't include dependencies on non-UnityEngine classes here. The Spherical3 class should be able to be imported with only itself and the other related coordinate structs.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Converts a Vector2 to a Spherical3. </summary>
    public static implicit operator Spherical3(Vector2 vector)
    {
        return new()
        {
            Length = vector.magnitude,
            Azimuth = new() { Radians = Mathf.Atan2(vector.y, vector.x) },
            Zenith = new()
        };
    }

    /// <summary> Converts a Spherical3 to a Vector2. </summary>
    public static implicit operator Vector2(Spherical3 polar)
    {
        return new Vector2(
            polar.Length * Mathf.Cos(polar.Azimuth.Radians),
            polar.Length * Mathf.Sin(polar.Azimuth.Radians));
    }

    /// <summary> Converts a Spherical3 to a Vector3 in Unity's space. The Length and Azimuth derive the XZ components, and the Length and Zenith derive the Y component. </summary>
    public static implicit operator Vector3(Spherical3 polar)
    {
        return new Vector3(
            polar.Length * Mathf.Cos(-polar.Azimuth.Radians),
            polar.Length * Mathf.Sin(polar.Zenith.Radians),
            polar.Length * Mathf.Sin(-polar.Azimuth.Radians));
    }

    /// <summary> Converts an Angle to a Y-axis angle Quaternion in Unity's counterclockwise Y-axis space as viewed from above. Useful for top-down games. </summary>
    public static implicit operator Quaternion(Spherical3 polar)
    {
        return Quaternion.Euler(polar.Zenith.Degrees, -polar.Azimuth.Degrees, 0);
    }

    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Maps this Length to the interval [0, infinity) and adds 180 degrees to the Angle. </summary>
    public void MapMagnitudeToPositiveIntervalAndChangeAngle()
    {
        if (Length < 0)
        {
            Length = Mathf.Abs(Length);
            Azimuth.Degrees += 180f;
        }
    }

    /// <summary> If the Zenith is less than 0 degrees or greater than 180 degrees, 
    /// this returns an effectively equivalent Spherical3 with a Zenith in the unsigned interval [0, 180] degrees 
    /// and adds 180 degrees to the Azimuth (Read Only). </summary>
    public void MapZenithToUnsignedInterval()
    {
        Zenith.MapToUnsignedInterval();
        if (Zenith.Degrees > 180f)
        {
            Zenith.Degrees = 360f - Zenith.Degrees;
            Azimuth.Degrees += 180f;
        }
        else if (Zenith.Degrees < 0)
        {
            Zenith.Degrees = -360f - Zenith.Degrees;
            Azimuth.Degrees += 180f;
        }
    }

    /// <summary> Returns true if the Polar3s are equal. Use this comparison method for better performance. </summary>
    public bool Equals(Spherical3 other)
    {
        return (Length == other.Length) && (Azimuth == other.Azimuth) && (Zenith == other.Zenith);
    }

    /// <summary> Returns true if the Polar3s are equal, but false if the other is not a Spherical3. </summary> 
    public override bool Equals(object other)
    {
        if (!(other is Spherical3))
            return false;
        else
            return Equals((Spherical3)other);
    }

    /// <summary> GetHashCode was generated to supress a warning. </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Length, Azimuth, Zenith);
    }

    /// <summary> As a string, this returns the Length and Angle in degrees instead of the class name. Useful for Unity Test output. Otherwise, use properties to obtain the other angular units for your string. </summary>
    public override string ToString()
    {
        return Length + " length, " + Azimuth.Degrees + " azimuth degrees," + Zenith.Degrees + " zenith degrees";
    }

    // Static Methods:
    // Don't include dependencies on non-UnityEngine classes here. The Spherical3 class should be able to be imported with only itself and the other related coordinate structs.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Linearly interpolates between two Polar3s, component-wise. </summary>
    public static Spherical3 Lerp(Spherical3 fromPoint, Spherical3 toPoint, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        return fromPoint + (alpha * (toPoint - fromPoint));
    }

    /// <summary> Linearly interpolates between two Polar3s, component-wise, without clamping the alpha to [0, 1]. </summary>
    public static Spherical3 LerpUnclamped(Spherical3 fromPoint, Spherical3 toPoint, float alpha)
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
Unity's Vector2: https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Vector2.cs
Use Ctrl+F to find words on Firefox. You can quickly learn about the names used throughout this class.
*/