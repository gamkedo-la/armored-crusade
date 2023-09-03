using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StartScreen : MonoBehaviour
{
    public AudioClip forwardSound;
    public AudioClip backwardSound;
    private AudioSource menuSoundSource;

    public GameObject TheCreditsScreen;

    public TextMeshProUGUI highScoreText;

    public static int highScore;

    void Start()
    {
        menuSoundSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (highScoreText) highScoreText.text = " SCORE\n<mspace=.75em>" + highScore.ToString("000000");
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