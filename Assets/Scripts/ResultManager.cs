using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public void BackToTitle()
    {
        Time.timeScale = 1f; // 停止解除
        SceneManager.LoadScene("TitleScene");
    }
}