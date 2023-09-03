using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock_ON : MonoBehaviour
{

    void Start()
    {
        // Lock the mouse cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Release the mouse cursor when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
