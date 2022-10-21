using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Polar3Tests
{

    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test]
    public void PropertySignedPitch()
    {
        Polar3 polar = new(1f, Angle.Zero, new() { Degrees = 100f });
        Assert.AreEqual(80f, polar.SignedPitch.Pitch.Degrees);
        polar.Pitch.Degrees = -100f;
        Assert.AreEqual(-80f, polar.SignedPitch.Pitch.Degrees);
    }
}
