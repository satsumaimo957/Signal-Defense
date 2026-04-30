using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string gameSceneName = "MainScene";

    public void StartGame()
    {
        Time.timeScale = 1f; // 念のため
        SceneManager.LoadScene(gameSceneName);
    }

    public void RuleMove()
    {
        SceneManager.LoadScene("RuleScene");
    }

    public void QuitGame()
    {
        Debug.Log("ゲーム終了");

        Application.Quit();
    }
}