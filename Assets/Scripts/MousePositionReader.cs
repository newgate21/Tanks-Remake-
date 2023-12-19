using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionReader : MonoBehaviour
{
    // Mouse position in world space reference
    public Vector3 MousePosition { get; set; }
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Read mouse position 
        Vector3 mp = Input.mousePosition;
        mp.z = cam.nearClipPlane;

        // Convert in world space reference
        MousePosition = cam.ScreenToWorldPoint(mp);
    }
}
