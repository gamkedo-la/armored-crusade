using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurret : MonoBehaviour
{
    public float speed = 10.0f; // Speed of rotation
    private float horizontalInput; // Horizontal input from mouse

    void Update()
    {
        // Get horizontal input from mouse movement
        horizontalInput = Input.GetAxis("Mouse X");

        // Rotate object around Y-axis based on mouse movement
        transform.Rotate(0.0f, horizontalInput * speed * Time.deltaTime, 0.0f);
    }
}
