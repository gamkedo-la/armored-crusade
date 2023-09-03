using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health = 3;
    public TextMeshPro healthHUD;
    public GameObject damage;
    public GameObject explosionPrefab_Generic;
    public GameObject player;
    public GameObject projectile;
    public AudioSource audioSource;
    public AudioClip explosion;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Ouch"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        audioSource.PlayOneShot(explosion);


        health--;
        if (health == 2)
        {
            StartCoroutine(DamageOverlay_Short());
            healthHUD.color = new Color32(204, 207, 62, 255);
            healthHUD.text = "██";
        }
        if (health == 1)
        {
            StartCoroutine(DamageOverlay_Short());
            healthHUD.color = new Color32(207, 104, 81, 255);
            healthHUD.text = "█";
        }
        if (health == 0)
        {
            StartCoroutine(LoadSceneWithDelay());
            StartCoroutine(DamageOverlay_Long());
            Instantiate(explosionPrefab_Generic, player.transform.position, Quaternion.identity);
            player.transform.position = new Vector3(player.transform.position.x, -500, player.transform.position.z);
        }
    }

    private IEnumerator DamageOverlay_Short()
    {
        Time.timeScale = 0.5f;
        damage.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        damage.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private IEnumerator DamageOverlay_Long()
    {
        Time.timeScale = 0.25f;
        damage.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        damage.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSecondsRealtime(4.5f);
        SceneManager.LoadScene(2);
    }
}
