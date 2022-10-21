using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Polar2Tests
{
    // Read Only Properties:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void PropertyPositive()
    {
        Polar2 polar1 = new(-1f, new() { Degrees = 90f });
        Assert.AreEqual(270f, polar1.Positive.Angle.Degrees);
    }


    // Public Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void MethodEquals()
    {
        Polar2 polar1 = new(1f, new() { Degrees = 1f });
        Polar2 polar2 = new(1f, new() { Degrees = 1f });
        Assert.IsTrue(polar1.Equals(polar2));

        float number = 1f;
        Assert.IsFalse(polar1.Equals(number));
    }


    // Arithmetic Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void Operator()
    {
        Polar2 a = new(2f, new() { Degrees = 2f });
        Polar2 b = new(2f, new() { Degrees = 2f });
        Polar2 c = a + b;
        Polar2 result = new(4f, new() { Degrees = 4f });
        Assert.AreEqual(result, c);
    }

    /*


    */

    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Conversion Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}
