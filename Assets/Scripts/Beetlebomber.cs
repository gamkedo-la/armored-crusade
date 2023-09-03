using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetlebomber : MonoBehaviour
{
    public float speed = 150.0f;
    public float zStop = 150.0f;
    public float boundary = -1200.0f;

    void Start()
    {

    }

    void Update()
    {
        if (gameObject != null)
        {
            Move();
            CheckBounds();
        }
    }

    void Move()
    {
        var actualSpeed = speed;
        transform.position += Vector3.back * actualSpeed * Time.deltaTime;
    }
    void CheckBounds()
    {
        if (transform.localPosition.z < boundary)
        {
            Destroy(gameObject);
        }
    }
}
