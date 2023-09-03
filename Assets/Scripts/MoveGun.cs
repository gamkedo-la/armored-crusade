using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public float speed = 50.0f; // Speed of rotation
    private float verticalInput; // Vertical input from mouse

    void Update()
    {
        // Get vertical input from mouse movement
        verticalInput = Input.GetAxis("Mouse Y");

        // Rotate object around X-axis based on vertical mouse movement
        transform.Rotate(-1 * verticalInput * speed * Time.deltaTime, 0.0f, 0.0f);
    }
}