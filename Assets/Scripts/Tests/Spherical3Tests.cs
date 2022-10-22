using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Spherical3Tests
{
    [Test] public void PropertyUnsignedZenith()
    {
        Spherical3 spherical = new(1, new() { Degrees = 180f }, new() { Degrees = 190f });
        Assert.AreEqual(170f, spherical.UnsignedZenith.Zenith.Degrees);
        spherical.Zenith.Degrees = -10f;
        Assert.AreEqual(10f, spherical.UnsignedZenith.Zenith.Degrees);
    }
}
