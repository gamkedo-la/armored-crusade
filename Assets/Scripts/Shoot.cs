using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject missile;
    public Transform muzzle;
    public GameObject muzzleFlashFX;
    public AudioClip mainFireSound;
    public AudioClip[] soundVariations;

    public float speed;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        speed = speed * 10;
    }

    IEnumerator RandStaggerCannonSnd() {
        yield return new WaitForSeconds(Random.Range(0.01f,0.4f));
        int randSnd = Random.Range(0,soundVariations.Length);
        audioSource.pitch = Random.Range(0.5f,1.0f);
        audioSource.PlayOneShot(soundVariations[randSnd]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale != 0f)
            {
                if (missile)
                {
                    audioSource.pitch = Random.Range(0.75f,1.0f);
                    audioSource.PlayOneShot(mainFireSound);
                    for(int i=0;i<3;i++) { // layering with staggered delays
                        StartCoroutine( RandStaggerCannonSnd() );
                    }
                    GameObject bullet = Instantiate(missile, muzzle.position, muzzle.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * speed;
                    Destroy(bullet, 3f);
                }

                if (muzzleFlashFX)
                {
                    Instantiate(muzzleFlashFX, muzzle.position, muzzle.rotation);
                }
            }
        }
    }
}
