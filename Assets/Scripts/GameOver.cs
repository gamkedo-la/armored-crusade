using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyButtonScript : MonoBehaviour
{
    public void btn_Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void btn_Retry(int sceneID)
    {
        Score.playerScore = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}