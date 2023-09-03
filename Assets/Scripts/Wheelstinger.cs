using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelstinger : MonoBehaviour
{
    public float speed = 150.0f;
    public float boundary = -1200.0f;

    private GameObject target;
    private Vector3 targetPos;

    private float initialXPos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player_Bottom");
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        targetPos = target.transform.position;
        transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;
        // transform.LookAt(target.transform.position);
    }
    void CheckBounds()
    {
        if (transform.localPosition.z < boundary)
        {
            Destroy(gameObject);
        }
    }
}
