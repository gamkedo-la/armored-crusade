using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShieldPowerup : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sfx_forcefield;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 100 * Time.deltaTime;
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        if (transform.position.x >= 400)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Missile"))
        {
            GameObject forcefield = GameObject.Find("Forcefield");
            Vector3 targetPosition = new Vector3(-3f, -17f, -12f);
            forcefield.transform.localPosition = targetPosition;
            audioSource.PlayOneShot(sfx_forcefield);
            Vector3 newPos = transform.position;
            newPos.x = -5000;
            newPos.y = -5000;
            transform.position = newPos;
            Destroy(collisionInfo.gameObject);
            StartCoroutine(ResetForcefieldPosition(forcefield));
        }
    }

    private IEnumerator ResetForcefieldPosition(GameObject forcefield)
    {
        yield return new WaitForSeconds(7f);
        forcefield.transform.position = new Vector3(-2, -85, -12);
    }



}
