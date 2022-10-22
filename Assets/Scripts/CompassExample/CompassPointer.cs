using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompassPointer : MonoBehaviour
{
    PlayerInput playerInput;
    public Polar2 polar;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 look = new(
            playerInput.actions.FindAction("Look").ReadValue<Vector2>().x,
            playerInput.actions.FindAction("Look").ReadValue<Vector2>().y);
        Vector2 lookProcessed = look;
        lookProcessed.x -= Screen.width / 2f;
        lookProcessed.y -= Screen.height / 2f;
        lookProcessed = lookProcessed / (Screen.width / 2f);

        // Vector to Polar 2 conversion operator
        polar = lookProcessed;
        // Angle to Quaternion conversion operator
        transform.rotation = polar.Angle;
    }
}
