using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Representation of a 3D polar coordinate, specifically, a non-conventional spherical coordinate.
/// Use object initializers to define the Yaw and Pitch Angles.
/// Be wary using arithmetic operators without acessing properties.
/// Use properties to obtain unique coordinates. Loosely modeled after Unity's Vector2 struct for best practices. </summary>
public struct Polar3
{
    // Constructors:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public Polar3(float length, Angle yaw, Angle pitch)
    {
        Length = length;
        Yaw = yaw;
        Pitch = pitch;
    }

    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> The magnitude, radius, or radial distance of the polar coordinate. </summary>
    public float Length { get; set; }

    /// <summary> Yaw Angle of the polar coordinate. Not a property due to CS1612. </summary>
    public Angle Yaw;

    /// <summary> Pitch Angle of the polar coordinate. Not a property due to CS1612. </summary>
    public Angle Pitch;

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> If the Length is negative, this returns an effectively equivalent Polar3 with a Length in the positive interval [0, infinity) and adds 180 degrees to the Yaw (Read Only). </summary>
    public Polar3 Positive
    {
        get
        {
            Polar3 polar = this;
            polar.MapMagnitudeToPositiveIntervalAndChangeAngle();
            return polar;
        }
    }

    /// <summary> Returns an effectively equivalent Polar3 with a Yaw in the signed interval (-180, 180] degrees (Read Only). </summary>
    public Polar3 SignedYaw
    {
        get
        {
            Polar3 polar = this;
            polar.Yaw.MapToSignedInterval();
            return polar;
        }
    }

    /// <summary> Returns an effectively equivalent Polar3 with a Yaw in the unsigned interval [0, 360) degrees (Read Only). </summary>
    public Polar3 UnsignedYaw
    {
        get
        {
            Polar3 polar = this;
            polar.Yaw.MapToUnsignedInterval();
            return polar;
        }
    }

    /// <summary> If the Signed Pitch > 90 degrees or < -90 degrees, this returns a Polar3 with a Pitch in the signed interval [-90, 90] degrees and adds 180 degrees to the Yaw (Read Only). </summary>
    public Polar3 SignedPitch
    {
        get
        {
            Polar3 polar = this;
            polar.MapPitchToSignedIntervalAndChangeYaw();
            return polar;
        }
    }

    /// <summary> If the Signed Pitch > 90 degrees or < -90 degrees, this returns a Polar3 with a Pitch in the unsigned interval [0, 90], [270, 360) degrees and adds 180 degrees to the Yaw (Read Only). </summary>
    public Polar3 UnsignedPitch
    {
        get
        {
            Polar3 polar = this;
            polar.MapPitchToUnsignedIntervalAndChangeYaw();
            return polar;
        }
    }

    // Static Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Shorthand for writing new Polar3(0, new() { Degrees = 0f }, new() { Degrees = 0f }); </summary>
    public static Polar3 Zero
    { get => new(0, new() { Degrees = 0f }, new() { Degrees = 0f }); }

    /// <summary> Shorthand for writing new Polar3(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }, new() { Degrees = float.PositiveInfinity }); </summary>
    public static Polar3 PositiveInfinity
    { get => new(float.PositiveInfinity, new() { Degrees = float.PositiveInfinity }, new() { Degrees = float.PositiveInfinity }); }

    /// <summary> Shorthand for writing new Polar3(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }, new() { Degrees = float.NegativeInfinity }); </summary>
    public static Polar3 NegativeInfinity
    { get => new(float.NegativeInfinity, new() { Degrees = float.NegativeInfinity }, new() { Degrees = float.NegativeInfinity }); }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Adds an addend Polar3 to an augend Polar3, component-wise. </summary>
    public static Polar3 operator +(Polar3 augend, Polar3 addend)
    {
        return new()
        {
            Length = augend.Length + addend.Length,
            Yaw = augend.Yaw + addend.Yaw,
            Pitch = augend.Pitch + addend.Pitch
        };
    }

    /// <summary> Subtracts a subtrahend Polar3 from a minuend Polar3, component-wise. </summary>
    public static Polar3 operator -(Polar3 minuend, Polar3 subtrahend)
    {
        return new()
        {
            Length = minuend.Length - subtrahend.Length,
            Yaw = minuend.Yaw - subtrahend.Yaw,
            Pitch = minuend.Pitch - subtrahend.Pitch
        };
    }

    /// <summary> Multiplies a multiplicand Polar3 by a multiplier Polar3, component-wise. </summary>
    public static Polar3 operator *(Polar3 multiplicand, Polar3 multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier.Length,
            Yaw = multiplicand.Yaw * multiplier.Yaw,
            Pitch = multiplicand.Pitch * multiplier.Pitch
        };
    }

    /// <summary> Multiplies a multiplicand Polar3 by a multiplier number, component-wise. </summary>
    public static Polar3 operator *(Polar3 multiplicand, float multiplier)
    {
        return new()
        {
            Length = multiplicand.Length * multiplier,
            Yaw = multiplicand.Yaw * multiplier,
            Pitch = multiplicand.Pitch * multiplier
        };
    }

    /// <summary> Multiplies a multiplicand number by a multiplier Polar3, component-wise. </summary>
    public static Polar3 operator *(float multiplicand, Polar3 multiplier)
    {
        return new()
        {
            Length = multiplicand * multiplier.Length,
            Yaw = multiplicand * multiplier.Yaw,
            Pitch = multiplicand * multiplier.Pitch
        };
    }

    /// <summary> Divides a dividend Polar3 by a divisor Polar3, component-wise. </summary>
    public static Polar3 operator /(Polar3 dividend, Polar3 divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor.Length,
            Yaw = dividend.Yaw / divisor.Yaw,
            Pitch = dividend.Pitch / divisor.Pitch
        };
    }

    /// <summary> Divides an dividend Polar3 by a divisor number, component-wise. </summary>
    public static Polar3 operator /(Polar3 dividend, float divisor)
    {
        return new()
        {
            Length = dividend.Length / divisor,
            Yaw = dividend.Yaw / divisor,
            Pitch = dividend.Pitch / divisor
        };
    }

    /// <summary> Computes the remainder of a division by a dividend Polar3 by an divisor Polar3, component-wise. </summary>
    public static Polar3 operator %(Polar3 dividend, Polar3 divisor)
    {
        return new()
        {
            Length = dividend.Length % divisor.Length,
            Yaw = dividend.Yaw % divisor.Yaw,
            Pitch = dividend.Pitch % divisor.Pitch
        };
    }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Returns true if the Polar3s are equal. </summary>
    public static bool operator ==(Polar3 lhs, Polar3 rhs)
    { return (lhs.Length == rhs.Length) && (lhs.Yaw == rhs.Yaw) && (lhs.Pitch == rhs.Pitch); }

    /// <summary> Returns true if the Polar3s are not equal. </summary>
    public static bool operator !=(Polar3 lhs, Polar3 rhs)
    { return (lhs.Length != rhs.Length) || (lhs.Yaw != rhs.Yaw) || (lhs.Pitch != rhs.Pitch); }

    // Conversion Operators:
    // Don't include dependencies on non-UnityEngine classes here. The Polar3 class should be able to be imported with only itself and the other related coordinate structs.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Converts a Vector2 to a Polar3. </summary>
    public static implicit operator Polar3(Vector2 vector)
    {
        return new()
        {
            Length = vector.magnitude,
            Yaw = new() { Radians = Mathf.Atan2(vector.y, vector.x) },
            Pitch = new()
        };
    }

    /// <summary> Converts a Polar3 to a Vector2. </summary>
    public static implicit operator Vector2(Polar3 polar)
    {
        return new Vector2(
            polar.Length * Mathf.Cos(polar.Yaw.Radians),
            polar.Length * Mathf.Sin(polar.Yaw.Radians));
    }

    /// <summary> Converts a Polar3 to a Vector3 in Unity's space. </summary>
    public static implicit operator Vector3(Polar3 polar)
    {
        return new Vector3(
            polar.Length * Mathf.Cos(-polar.Yaw.Radians),
            0,
            polar.Length * Mathf.Sin(-polar.Yaw.Radians));
    }

    // TODO: quaternion conversion

    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Maps this Length to the interval [0, infinity) and adds 180 degrees to the Angle. </summary>
    public void MapMagnitudeToPositiveIntervalAndChangeAngle()
    {
        if (Length < 0)
        {
            Length = Mathf.Abs(Length);
            Yaw.Degrees += 180f;
        }
    }

    public void MapPitchToSignedIntervalAndChangeYaw()
    {
        Pitch.MapToSignedInterval();
        if (Pitch.Degrees > 90f)
        {
            Pitch.Degrees = 180f - Pitch.Degrees;
            Yaw.Degrees += 180f;
        }
        else if (Pitch.Degrees < -90f)
        {
            Pitch.Degrees = -180f - Pitch.Degrees;
            Yaw.Degrees += 180f;
        }
    }

    public void MapPitchToUnsignedIntervalAndChangeYaw()
    {
        Pitch.MapToSignedInterval();
        if (Pitch.Degrees > 90f)
        {
            Pitch.Degrees = 180f - Pitch.Degrees;
            Yaw.Degrees += 180f;
        }
        else if (Pitch.Degrees < -90f)
        {
            Pitch.Degrees = -180f - Pitch.Degrees;
            Yaw.Degrees += 180f;
        }
        Pitch.MapToUnsignedInterval();
    }


    /// <summary> Returns true if the Polar3s are equal. Use this comparison method for better performance. </summary>
    public bool Equals(Polar3 other)
    {
        return (Length == other.Length) && (Yaw == other.Yaw) && (Pitch == other.Pitch);
    }

    /// <summary> Returns true if the Polar3s are equal, but false if the other is not a Polar3. </summary> 
    public override bool Equals(object other)
    {
        if (!(other is Polar3))
            return false;
        else
            return Equals((Polar3)other);
    }

    /// <summary> GetHashCode was generated to supress a warning. </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Length, Yaw, Pitch);
    }

    /// <summary> As a string, this returns the Length and Angle in degrees instead of the class name. Useful for Unity Test output. Otherwise, use properties to obtain the other angular units for your string. </summary>
    public override string ToString()
    {
        return Length + " length, " + Yaw.Degrees + " yaw degrees" + Pitch.Degrees + " pitch degrees";
    }

    // Static Methods:
    // Don't include dependencies on non-UnityEngine classes here. The Polar3 class should be able to be imported with only itself and the other related coordinate structs.
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary> Linearly interpolates between two Polar3s, component-wise. </summary>
    public static Polar3 Lerp(Polar3 fromPoint, Polar3 toPoint, float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        return fromPoint + (alpha * (toPoint - fromPoint));
    }

    /// <summary> Linearly interpolates between two Polar3s, component-wise, without clamping the alpha to [0, 1]. </summary>
    public static Polar3 LerpUnclamped(Polar3 fromPoint, Polar3 toPoint, float alpha)
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