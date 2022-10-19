using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AngleTests
{
    [Test]
    public void PropertyDegrees()
    {
        Angle angle1 = new() { Degrees = 90f };
        Assert.AreEqual(90f, angle1.Degrees);
    }

    [Test]
    public void MethodToString()
    {
        Angle angle1 = new() { Degrees = 360f };
        Assert.AreEqual("360 degrees", angle1.ToString());
    }



}
