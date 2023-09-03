using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public AudioClip forwardSound;
    public AudioClip backwardSound;
    private AudioSource menuSoundSource;

    public GameObject TheCreditsScreen;

    void Start()
    {
        menuSoundSource = gameObject.GetComponent<AudioSource>();
    }

    public void LoadScene(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void showCredits()
    {
        if (TheCreditsScreen)
        {
            TheCreditsScreen.SetActive(true);
            menuSoundSource.PlayOneShot(forwardSound);
        }
    }

    public void hideCredits()
    {
        if (TheCreditsScreen)
        {
            TheCreditsScreen.SetActive(false);
            menuSoundSource.PlayOneShot(backwardSound);
        }
    }

}