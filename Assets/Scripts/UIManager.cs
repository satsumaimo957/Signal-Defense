using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI resultText; // 勝敗表示（中央）

    public GameObject resultPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void UpdateHP(int hp)
    {
        hpText.text = "HP: " + hp;
    }

    public void ShowResult(string message)
    {
        resultPanel.SetActive(true);
        resultText.text = message;
    }
}