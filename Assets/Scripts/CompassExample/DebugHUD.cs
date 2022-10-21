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
    public Angle lookAngle;
    private Label angleNamesLabel;
    private Label unsignedAnglesLabel;
    private Label signedAnglesLabel;


    // Dependent variables
    private float secondsPerLabelUpdate;
    private float currentSecondsBeforeLabelUpdate;

    private void OnEnable()
    {
        lookAngle = new();
        lookAngle = GetComponent<CompassPointer>().lookAngle;
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
        lookAngle = GetComponent<CompassPointer>().lookAngle;
        currentSecondsBeforeLabelUpdate -= Time.deltaTime;
        if (currentSecondsBeforeLabelUpdate <= 0)
        {
            unsignedAnglesLabel.text =
                "Unsigned\n" +
                lookAngle.Unsigned.Degrees.ToString("F2") + "\n" +
                lookAngle.Unsigned.Radians.ToString("F2") + "\n" +
                lookAngle.Unsigned.Arcminutes.ToString("F2") + "\n" +
                lookAngle.Unsigned.Arcseconds.ToString("F2") + "\n" +
                lookAngle.Unsigned.Grads.ToString("F2") + "\n" +
                lookAngle.Unsigned.Turns.ToString("F2") + "\n" +
                lookAngle.Unsigned.HourAngles.ToString("F2") + "\n" +
                lookAngle.Unsigned.Winds.ToString("F2") + "\n" +
                lookAngle.Unsigned.Milliradians.ToString("F2") + "\n" +
                lookAngle.Unsigned.BinaryDegrees.ToString("F2") + "\n" +
                lookAngle.Unsigned.Quadrants.ToString("F2") + "\n" +
                lookAngle.Unsigned.Sextants.ToString("F2");
            signedAnglesLabel.text =
                "Signed\n" +
                lookAngle.Signed.Degrees.ToString("F2") + "\n" +
                lookAngle.Signed.Radians.ToString("F2") + "\n" +
                lookAngle.Signed.Arcminutes.ToString("F2") + "\n" +
                lookAngle.Signed.Arcseconds.ToString("F2") + "\n" +
                lookAngle.Signed.Grads.ToString("F2") + "\n" +
                lookAngle.Signed.Turns.ToString("F2") + "\n" +
                lookAngle.Signed.HourAngles.ToString("F2") + "\n" +
                lookAngle.Signed.Winds.ToString("F2") + "\n" +
                lookAngle.Signed.Milliradians.ToString("F2") + "\n" +
                lookAngle.Signed.BinaryDegrees.ToString("F2") + "\n" +
                lookAngle.Signed.Quadrants.ToString("F2") + "\n" +
                lookAngle.Signed.Sextants.ToString("F2");
            currentSecondsBeforeLabelUpdate %= secondsPerLabelUpdate;
            currentSecondsBeforeLabelUpdate += secondsPerLabelUpdate;
        }
    }
}
