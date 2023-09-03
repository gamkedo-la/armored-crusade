using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public GameObject explosionPrefab_Beetlebomber;
    public GameObject explosionPrefab_Mechoid;
    public GameObject explosionPrefab_Wheelstinger;
    public GameObject explosionPrefab_Generic;

    private AudioSource audioSource;
    public AudioClip explosionEnemy;
    // public AudioClip explosionGeneric;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Mechoid_1"))
        {
            audioSource.PlayOneShot(explosionEnemy);
            Score.playerScore = Score.playerScore + 50;
            Vector3 newPosition = collisionInfo.gameObject.transform.position;
            newPosition.y += 30f;
            newPosition.z += 30f;
            Instantiate(explosionPrefab_Mechoid, newPosition, Quaternion.identity);
            Destroy(collisionInfo.transform.parent.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("Wheelstinger"))
        {
            audioSource.PlayOneShot(explosionEnemy);
            Score.playerScore = Score.playerScore + 100;
            Vector3 newPosition = collisionInfo.gameObject.transform.position;
            Instantiate(explosionPrefab_Wheelstinger, newPosition, Quaternion.identity);
            Destroy(collisionInfo.transform.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("Beetlebomber"))
        {
            audioSource.PlayOneShot(explosionEnemy);
            Score.playerScore = Score.playerScore + 150;
            Vector3 newPosition = collisionInfo.gameObject.transform.position;
            Instantiate(explosionPrefab_Beetlebomber, newPosition, Quaternion.identity);
            Destroy(collisionInfo.transform.gameObject);
        }
        if (collisionInfo.gameObject.CompareTag("Mechoid_2"))
        {
            audioSource.PlayOneShot(explosionEnemy);
            Score.playerScore = Score.playerScore + 200;
            Vector3 newPosition = collisionInfo.gameObject.transform.position;
            newPosition.y += 30f;
            newPosition.z += 30f;
            Instantiate(explosionPrefab_Mechoid, newPosition, Quaternion.identity);
            Destroy(collisionInfo.transform.parent.gameObject);
        }
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Generic"))
        {
            //not working for some reason
            // audioSource.PlayOneShot(explosionGeneric);
            Instantiate(explosionPrefab_Generic, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
