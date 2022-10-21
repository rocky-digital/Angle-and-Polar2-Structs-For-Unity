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

    [Test] public void OperatorAdd()
    {
        Polar2 a = new(2f, new() { Degrees = 2f });
        a += a;
        Polar2 result = new(4f, new() { Degrees = 4f });
        Assert.AreEqual(result, a);
    }

    [Test] public void OperatorSubtract()
    {
        Polar2 a = new(3f, new() { Degrees = 3f });
        a -= a;
        Polar2 result = new(0f, new() { Degrees = 0f });
        Assert.AreEqual(result, a);
    }

    [Test] public void OperatorMultiplyPolar2ByPolar2()
    {
        Polar2 a = new(5f, new() { Degrees = 5f });
        a *= a;
        Polar2 result = new(25f, new() { Degrees = 25f });
        Assert.AreEqual(result, a);
    }
    [Test] public void OperatorMultiplyPolar2ByNumber()
    {
        Polar2 a = new(6f, new() { Degrees = 6f });
        Polar2 result = new(42f, new() { Degrees = 42f });
        Assert.AreEqual(result, a * 7f);
    }
    [Test] public void OperatorMultiplyNumber2ByPolar2()
    {
        Polar2 a = new(8f, new() { Degrees = 8f });
        Polar2 result = new(72f, new() { Degrees = 72f });
        Assert.AreEqual(result, 9 * a);
    }
    [Test] public void OperatorDividePolar2ByPolar2()
    {
        Polar2 a = new(1f, new() { Degrees = 1f });
        a /= a;
        Polar2 result = new(1f, new() { Degrees = 1f });
        Assert.AreEqual(result, a);
    }
    [Test] public void OperatorDividePolar2ByNumber()
    {
        Polar2 a = new(2f, new() { Degrees = 2f });
        Polar2 result = new(0.5f, new() { Degrees = 0.5f });
        Assert.AreEqual(result, a / 4f);
    }
    [Test] public void OperatorRemainder()
    {
        Polar2 a = new(6f, new() { Degrees = 6f });
        a %= a;
        Polar2 result = new(0, new() { Degrees = 0 });
        Assert.AreEqual(result, a);
    }


    // Comparison Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void OperatorEqualTo()
    {
        Polar2 a = new(1f, new() { Degrees = 1f });
        Polar2 b = new(1f, new() { Degrees = 1f });
        Assert.IsTrue(a == b);
    }

    [Test] public void OperatorNotEqualTo()
    {
        Polar2 a = new(1f, new() { Degrees = 1f });
        Polar2 b = new(2f, new() { Degrees = 2f });
        Assert.IsTrue(a != b);
    }


    // Conversion Operators:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    [Test] public void OperatorVector2ToPolar2()
    {
        Vector2 vector = new(0f, 1f);
        Polar2 polar1 = vector;
        Polar2 polar2 = new(1f, new() { Degrees = 90f });
        Assert.AreEqual(polar1, polar2);
    }

    [Test] public void OperatorPolar2ToVector2()
    {
        Polar2 polar = new(1f, new() { Radians = Mathf.PI / 4f });
        Vector2 vector1 = polar;
        Vector2 vector2 = new(Mathf.Cos(Mathf.PI / 4f), Mathf.Sin(Mathf.PI / 4f));
        Assert.AreEqual(vector1, vector2);
    }

    [Test] public void OperatorPolar2ToVector3()
    {
        Polar2 polar = new(1f, new() { Radians = Mathf.PI / 4f });
        Vector3 vector1 = polar;
        Vector3 vector2 = new(Mathf.Cos(Mathf.PI / 4f), 0,  Mathf.Sin(Mathf.PI / 4f));
        Assert.AreEqual(vector1, vector2);
    }

    // Static Methods:
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}

/*
Original Author: James Roquelara
Start Date: 9/14/2022

Resources:
Angles: https://en.wikipedia.org/wiki/Angle
Polar Coordinates: https://en.wikipedia.org/wiki/Polar_coordinate_system
C# Conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
Linear Interpolation: https://en.wikipedia.org/wiki/Linear_interpolation 
Use Ctrl+F to find words on Firefox. You can quickly learn about the names used throughout this class.
*/