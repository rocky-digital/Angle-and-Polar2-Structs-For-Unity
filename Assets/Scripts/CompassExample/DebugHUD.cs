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
    private Label fpsLabel;
    

    // Dependent variables
    private float secondsPerLabelUpdate;
    private float currentSecondsBeforeLabelUpdate;

    private void OnEnable()
    {
        angle1 = new();
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        fpsLabel = rootVisualElement.Q<Label>("FPS_Label");
        secondsPerLabelUpdate = 1 / (float)labelUpdatesPerSecond;
        currentSecondsBeforeLabelUpdate = 0;
    }

    private void Update()
    {
        Debug.Log("degrees: " + compass.degrees);
        Debug.Log("lookAngle: " + compass.lookAngle);
        currentSecondsBeforeLabelUpdate -= Time.deltaTime;
        if (currentSecondsBeforeLabelUpdate <= 0)
        {
            fpsLabel.text = "Angle Measurements:\n" +
                "Degrees: " + compass.lookAngle.Degrees.ToString() + "\n" +
                "Radians: " + compass.lookAngle.Radians.ToString() + "\n";
            currentSecondsBeforeLabelUpdate %= secondsPerLabelUpdate;
            currentSecondsBeforeLabelUpdate += secondsPerLabelUpdate;
        }
    }
}
