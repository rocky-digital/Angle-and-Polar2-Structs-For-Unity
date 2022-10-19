using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Polar2Tests
{
    [Test]
    public void PropertyPositive()
    {
        Polar2 polar2 = new() { Length = -1f, Angle = new() { Degrees = 90f } };
        Assert.AreEqual(270f, polar2.Positive.Angle.Degrees);
    }
}
