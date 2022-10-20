using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AngleTests
{
    // Try not to repeat the same numbers across tests right next to eachother. Doing so will vastly improve readability.

    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    // This tolerance was chosen because most angles will be displayed on the HUD with two decimal places.
    public float tolerance = 0.01f;

    [Test] public void PropertyRadians()
    {
        Angle angle1 = new() { Radians = 2f * Mathf.PI };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(6.28f, angle1.Radians, tolerance);
    }

    [Test] public void PropertyArcminutes()
    {
        Angle angle1 = new() { Arcminutes = 21600f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(21600f, angle1.Arcminutes, tolerance);
    }

    [Test] public void PropertyArcseconds()
    {
        Angle angle1 = new() { Arcseconds = 1296000f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(1296000f, angle1.Arcseconds, tolerance);
    }

    [Test] public void PropertyGrads()
    {
        Angle angle1 = new() { Grads = 400f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(400f, angle1.Grads, tolerance);
    }

    [Test] public void PropertyTurns()
    {
        Angle angle1 = new() { Turns = 1f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(1f, angle1.Turns, tolerance);
    }

    [Test] public void PropertyHourAngles()
    {
        Angle angle1 = new() { HourAngles = 24f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(24f, angle1.HourAngles, tolerance);
    }

    [Test] public void PropertyWinds()
    {
        Angle angle1 = new() { Winds = 32f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(32f, angle1.Winds, tolerance);
    }

    [Test] public void PropertyMilliradians()
    {
        Angle angle1 = new() { Milliradians = 2000f * Mathf.PI };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(6283.19f, angle1.Milliradians, tolerance);
    }
    
    [Test] public void PropertyBinaryDegrees()
    {
        Angle angle1 = new() { BinaryDegrees = 256f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(256f, angle1.BinaryDegrees, tolerance);
    }

    [Test] public void PropertyQuadrants()
    {
        Angle angle1 = new() { Quadrants = 4f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(4f, angle1.Quadrants, tolerance);
    }
    
    [Test] public void PropertySextants()
    {
        Angle angle1 = new() { Sextants = 6f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(6f, angle1.Sextants, tolerance);
    }

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void PropertySigned()
    {
        // Test setting positive angles
        Angle angle1 = new() { Degrees = 10f };
        Assert.AreEqual(10f, angle1.Signed.Degrees);

        // Test setting negative angles
        angle1.Degrees = 315f;
        Assert.AreEqual(-45f, angle1.Signed.Degrees);

        // Test setting angles greater than 360 degrees
        angle1.Degrees = 765f;
        Assert.AreEqual(45f, angle1.Unsigned.Degrees);
    }

    [Test] public void PropertyUnsigned()
    {
        // Test setting positive angles
        Angle angle1 = new() { Degrees = 30f };
        Assert.AreEqual(30f, angle1.Unsigned.Degrees);

        // Test setting negative angles
        angle1.Degrees = -90f;
        Assert.AreEqual(270f, angle1.Unsigned.Degrees);

        // Test setting angles greater than 360 degrees
        angle1.Degrees = 1080f;
        Assert.AreEqual(0, angle1.Unsigned.Degrees);
    }

    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void MethodApproximatelyEquals()
    {
        Angle angle1 = new() { Degrees = 92f }; 
        Angle other = new() { Degrees = 92.1f };
        Angle tolerance = new() { Degrees = 0.1f };
        Assert.IsTrue(angle1.ApproximatelyEquals(other, tolerance));

        angle1.Degrees = 45f;
        other.Degrees = -44.9f;
        Assert.IsFalse(angle1.ApproximatelyEquals(other, tolerance));

        // You can use this method to check if an angle is within a certain angle range of another.
        angle1.Degrees = 60f;
        other.Degrees = 80f;
        tolerance.Degrees = 20f;
        Assert.IsTrue(angle1.ApproximatelyEquals(other, tolerance));
    }

    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void OperatorAdd()
    {
        Angle a = new() { Degrees = 1f };
        Angle b = new() { Degrees = 2f };
        Assert.AreEqual(3f, (a + b).Degrees);
    }

    [Test] public void OperatorSubtract()
    {
        Angle a = new() { Degrees = 3f };
        Angle b = new() { Degrees = 4f };
        Assert.AreEqual(-1f, (a - b).Degrees);
    }

    [Test] public void OperatorNegate()
    {
        Angle a = new() { Degrees = 5f };
        Assert.AreEqual(-5f, -a.Degrees);
    }

    [Test]
    public void OperatorMultiplyAngleByAngle()
    {
        Angle a = new() { Degrees = 6f };
        Angle b = new() { Degrees = 7f };
        Assert.AreEqual(42f, (a * b).Degrees);
    }

    [Test] public void OperatorMultiplyAngleByNumber()
    {
        Angle a = new() { Degrees = 8f };
        Assert.AreEqual(72f, (a * 9f).Degrees);
    }

    [Test] public void OperatorMultiplyNumberByAngle()
    {
        Angle b = new() { Degrees = 1f };
        Assert.AreEqual(2f, (2f * b).Degrees);
    }

    [Test] public void OperatorDivideAngleByAngle()
    {
        Angle a = new() { Degrees = 3f };
        Angle b = new() { Degrees = 4f };
        Assert.AreEqual(0.75f, (a / b).Degrees);
    }

    [Test] public void OperatorDivideAngleByNumber()
    {
        Angle a = new() { Degrees = 5f };
        Assert.AreEqual(0.25f, (a / 20f).Degrees);
    }

    [Test] public void OperatorRemainder()
    {
        Angle a = new() { Degrees = 6f };
        Angle b = new() { Degrees = 7f };
        Assert.AreEqual(6f, (a % b).Degrees);
    }

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Conversion Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Static Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test]
    public void StaticMethodSmallestSignedDifference()
    {
        Angle minuend = new();
        Angle subtrahend = new();
        // Positive result
        minuend.Degrees = 2f;
        subtrahend.Degrees = 1f;
        Assert.AreEqual(1f, Angle.SmallestSignedDifference(minuend, subtrahend).Degrees);
        // Negative result
        minuend.Degrees = 3f;
        subtrahend.Degrees = 6f;
        Assert.AreEqual(-3f, Angle.SmallestSignedDifference(minuend, subtrahend).Degrees);
        // Smallest signed difference should be 4f
        minuend.Degrees = 180f;
        subtrahend.Degrees = -184f;
        Assert.AreEqual(4f, Angle.SmallestSignedDifference(minuend, subtrahend).Degrees);
        // Smallest signed difference should be -7f
        minuend.Degrees = -5f;
        subtrahend.Degrees = 722f;
        Assert.AreEqual(-7f, Angle.SmallestSignedDifference(minuend, subtrahend).Degrees);
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