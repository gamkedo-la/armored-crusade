using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDrop : MonoBehaviour
{

    private GameObject player;
    public float playerPosZ;
    private Rigidbody rigidbody;
    public GameObject explosionPrefab_Generic;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosZ = player.transform.position.z;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= (playerPosZ + 225))
        {
            rigidbody.useGravity = true;
            rigidbody.AddForce(Vector3.down * 50f);
        }
    }
}
