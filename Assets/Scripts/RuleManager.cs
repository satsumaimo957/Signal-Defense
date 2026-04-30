using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class RuleManager : MonoBehaviour
{
    public GameObject[] rulePages;
    //public Image displayImage;

    public TextMeshProUGUI pageText; // ← 追加
    public Button prevButton;        // ← 追加
    public Button nextButton;        // ← 追加

    private int currentIndex = 0;

    void Start()
    {
        UpdateUI();
    }

    public void NextImage()
    {
        if (currentIndex < rulePages.Length - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }

    public void PrevImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // 全部非表示
        for (int i = 0; i < rulePages.Length; i++)
        {
            rulePages[i].SetActive(false);
        }

        // 今のページだけ表示
        rulePages[currentIndex].SetActive(true);

        // ページ表示
        if (pageText != null)
        {
            pageText.text = (currentIndex + 1) + " / " + rulePages.Length;
        }

        // ボタン制御
        if (prevButton != null)
        {
            prevButton.interactable = currentIndex > 0;
        }

        if (nextButton != null)
        {
            nextButton.interactable = currentIndex < rulePages.Length - 1;
        }
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}