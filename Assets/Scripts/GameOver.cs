using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI Timer;

    private void Update()
    {
        Timer.text = "TIMER\n<mspace=.75em>" + PlayerController.datTime;
    }
    public void btn_Home(int sceneID)
    {
        OnServerInitialized(sceneID);
    }

    public void btn_Retry(int sceneID)
    {
        OnServerInitialized(sceneID);
    }

    public void OnServerInitialized(int sceneID)
    {
        SpawnManager.wave2 = false;
        SpawnManager.wave3 = false;
        SpawnManager.wave4 = false;
        SpawnManager.boss = false;
        StartScreen.highScore = Score.playerScore;
        Score.playerScore = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        PlayerController.datTime = "00:00";
    }
}