using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlacing = true;

    public GameObject placementUI; // UIまとめ

    public EnemySpawner spawner;

    public bool isGameOver = false;

    public GoalArea goalArea;

    public int maxHP = 10;
    private int currentHP;  

    void Start()
    {
        Instance = this;
        Time.timeScale = 0f; // 最初は停止

        currentHP = maxHP;
        Debug.Log("初期HP: " + currentHP);
        
        UIManager.Instance.UpdateHP(currentHP);
    }

    public void StartGame()
    {
        isPlacing = false;
        Time.timeScale = 1f;

        if (placementUI != null)
            placementUI.SetActive(false);

        if (spawner != null)
            spawner.StartSpawning();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        Time.timeScale = 0f;

        UIManager.Instance.ShowResult("GAME OVER");
    }

    public void CheckClear()
    {
        if (isGameOver) return;

        UIManager.Instance.ShowResult("CLEAR!");
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (isGameOver) return;

        if (spawner != null && spawner.isFinished)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                CheckClear();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("ダメージ受けた: " + damage);
        if (isGameOver) return;

        currentHP -= damage;

        UIManager.Instance.UpdateHP(currentHP);

        if (currentHP <= 0)
        {
            GameOver();
        }
    }
}