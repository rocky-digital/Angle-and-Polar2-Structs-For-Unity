using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AngleTests
{
    // Component Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test]
    public void PropertyDegrees()
    {
        Angle angle1 = new() { Degrees = 1f };
        Assert.AreEqual(1f, angle1.Degrees);
        angle1.Degrees = -1f;
        Assert.AreEqual(-1f, angle1.Degrees);
    }

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


    [Test]
    public void MethodToString()
    {
        Angle angle1 = new() { Degrees = 360f };
        Assert.AreEqual("360 degrees", angle1.ToString());
    }



}
