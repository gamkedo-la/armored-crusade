using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private float speed = 30;
    private float boundary = -1200.0f;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        CheckBounds();
    }

    void CheckBounds()
    {
        if (transform.localPosition.z < boundary)
        {
            Destroy(gameObject);
        }
    }
}
