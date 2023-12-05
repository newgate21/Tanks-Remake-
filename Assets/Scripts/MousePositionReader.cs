using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionReader : MonoBehaviour
{
    // Mouse position in world space reference
    public Vector3 MousePosition { get; set; }

    void Update()
    {
        // Read mouse position and convert in world space reference
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
