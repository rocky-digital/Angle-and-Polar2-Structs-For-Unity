using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompassPointer : MonoBehaviour
{
    PlayerInput playerInput;
    public Angle lookAngle;

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
        lookProcessed = lookProcessed / (Screen.height / 2f);
        Angle lookAngle = lookProcessed;
        transform.rotation = lookAngle;
    }
}
