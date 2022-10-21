using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DebugHUD : MonoBehaviour
{
    // User-defined variables
    [Range(1, 15)] public int labelUpdatesPerSecond = 15;

    // Private variables
    public CompassPointer compass;
    public Angle angle1;
    private Label angleNamesLabel;
    

    // Dependent variables
    private float secondsPerLabelUpdate;
    private float currentSecondsBeforeLabelUpdate;

    private void OnEnable()
    {
        angle1 = new();
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
        secondsPerLabelUpdate = 1 / (float)labelUpdatesPerSecond;
        currentSecondsBeforeLabelUpdate = 0;
    }

    private void Update()
    {
        currentSecondsBeforeLabelUpdate -= Time.deltaTime;
        if (currentSecondsBeforeLabelUpdate <= 0)
        {
            currentSecondsBeforeLabelUpdate %= secondsPerLabelUpdate;
            currentSecondsBeforeLabelUpdate += secondsPerLabelUpdate;
        }
    }
}
