using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosionPrefab_Wheelstinger;
    public GameObject explosionPrefab_Generic;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Wheelstinger"))
        {
            Destroy(collisionInfo.gameObject);
            Instantiate(explosionPrefab_Wheelstinger, collisionInfo.gameObject.transform.position, Quaternion.identity);
        }
        if (collisionInfo.collider.CompareTag("Rock"))
        {
            PlayerController.speed = 15f;
        }
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Ouch"))
        {
            Destroy(collisionInfo.gameObject);
            Instantiate(explosionPrefab_Generic, collisionInfo.gameObject.transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Rock"))
        {
            PlayerController.speed = 30f;
        }
    }
}
