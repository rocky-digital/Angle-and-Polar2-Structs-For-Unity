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
    public void PropertyUnsigned()
    {
        Angle angle1 = new() { Degrees = -90f };
        Assert.AreEqual(270f, angle1.Unsigned.Degrees);

        angle1.Degrees = 1080f;
        Assert.AreEqual(0, angle1.Unsigned.Degrees);
    }

    [Test]
    public void PropertySigned()
    {
        Angle angle1 = new() { Degrees = 315f };
        Assert.AreEqual(-45, angle1.Signed.Degrees);

        angle1.Degrees = 720f;
        Assert.AreEqual(0, angle1.Unsigned.Degrees);
    }

    [Test]
    public void MethodToString()
    {
        Angle angle1 = new() { Degrees = 360f };
        Assert.AreEqual("360 degrees", angle1.ToString());
    }



}
