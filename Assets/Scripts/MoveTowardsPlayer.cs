using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        transform.LookAt(playerPos);

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
}
