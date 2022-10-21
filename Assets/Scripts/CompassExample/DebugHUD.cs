using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugHUD : MonoBehaviour
{
    // User-defined variables
    [Range(1, 144)] public int labelUpdatesPerSecond = 60;

    // Private variables
    public CompassPointer compass;
    public Polar2 polar;
    private Label angleNamesLabel;
    private Label unsignedAnglesLabel;
    private Label signedAnglesLabel;


    // Dependent variables
    private float secondsPerLabelUpdate;
    private float currentSecondsBeforeLabelUpdate;

    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        angleNamesLabel = rootVisualElement.Q<Label>("AngleNamesLabel");
        angleNamesLabel.text =
            "Angle Unit\n" +
            "Degrees\n" +
            "Radians\n" +
            "Arcminutes\n" +
            "Arcseconds\n" +
            "Grads\n" +
            "Turns\n" +
            "HourAngles\n" +
            "Winds\n" +
            "Milliradians\n" +
            "BinaryDegrees\n" +
            "Quadrants\n" +
            "Sextants";
        unsignedAnglesLabel = rootVisualElement.Q<Label>("UnsignedAnglesLabel");
        signedAnglesLabel = rootVisualElement.Q<Label>("SignedAnglesLabel");
        secondsPerLabelUpdate = 1 / (float)labelUpdatesPerSecond;
        currentSecondsBeforeLabelUpdate = 0;
    }

    private void Update()
    {
        secondsPerLabelUpdate = 1 / (float)labelUpdatesPerSecond;
        polar = GetComponent<CompassPointer>().polar;
        currentSecondsBeforeLabelUpdate -= Time.deltaTime;
        if (currentSecondsBeforeLabelUpdate <= 0)
        {
            unsignedAnglesLabel.text =
                "Unsigned\n" +
                polar.Angle.Unsigned.Degrees.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Radians.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Arcminutes.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Arcseconds.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Grads.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Turns.ToString("F2") + "\n" +
                polar.Angle.Unsigned.HourAngles.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Winds.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Milliradians.ToString("F2") + "\n" +
                polar.Angle.Unsigned.BinaryDegrees.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Quadrants.ToString("F2") + "\n" +
                polar.Angle.Unsigned.Sextants.ToString("F2");
            signedAnglesLabel.text =
                "Signed\n" +
                polar.Angle.Signed.Degrees.ToString("F2") + "\n" +
                polar.Angle.Signed.Radians.ToString("F2") + "\n" +
                polar.Angle.Signed.Arcminutes.ToString("F2") + "\n" +
                polar.Angle.Signed.Arcseconds.ToString("F2") + "\n" +
                polar.Angle.Signed.Grads.ToString("F2") + "\n" +
                polar.Angle.Signed.Turns.ToString("F2") + "\n" +
                polar.Angle.Signed.HourAngles.ToString("F2") + "\n" +
                polar.Angle.Signed.Winds.ToString("F2") + "\n" +
                polar.Angle.Signed.Milliradians.ToString("F2") + "\n" +
                polar.Angle.Signed.BinaryDegrees.ToString("F2") + "\n" +
                polar.Angle.Signed.Quadrants.ToString("F2") + "\n" +
                polar.Angle.Signed.Sextants.ToString("F2");
            currentSecondsBeforeLabelUpdate %= secondsPerLabelUpdate;
            currentSecondsBeforeLabelUpdate += secondsPerLabelUpdate;
        }
    }
}
