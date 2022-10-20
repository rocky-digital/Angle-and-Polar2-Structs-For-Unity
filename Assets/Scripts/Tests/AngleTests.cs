using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
// using UnityEngine.Assertions;

public class AngleTests
{
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
    
    /*
    [Test] public void PropertyRadians()
    {
        Angle angle1 = new() { Grads = 400f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(6.28f, angle1.Radians, tolerance);
    }

    [Test] public void PropertyRadians()
    {
        Angle angle1 = new() { Grads = 400f };
        UnityEngine.Assertions.Assert.AreApproximatelyEqual(6.28f, angle1.Radians, tolerance);
    }




    */

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test]
    public void PropertySigned()
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

    [Test]
    public void PropertyUnsigned()
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


    [Test]
    public void MethodToString()
    {
        Angle angle1 = new() { Degrees = 360f };
        Assert.AreEqual("360 degrees", angle1.ToString());
    }


    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Conversion Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Static Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



}
