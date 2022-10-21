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
    private Label fpsLabel;
    private int framesPerSecond;

    // Dependent variables
    private float secondsPerLabelUpdate;
    private float currentSecondsBeforeLabelUpdate;

    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        fpsLabel = rootVisualElement.Q<Label>("FPS_Label");
        framesPerSecond = 0;
        secondsPerLabelUpdate = 1 / (float)labelUpdatesPerSecond;
        currentSecondsBeforeLabelUpdate = 0;
    }

    private void Update()
    {
        framesPerSecond = (int) (1 / Time.deltaTime);
        currentSecondsBeforeLabelUpdate -= Time.deltaTime;
        if (currentSecondsBeforeLabelUpdate <= 0)
        {
            fpsLabel.text = $"FPS: {framesPerSecond}\n";
            currentSecondsBeforeLabelUpdate %= secondsPerLabelUpdate;
            currentSecondsBeforeLabelUpdate += secondsPerLabelUpdate;
        }
    }
}
