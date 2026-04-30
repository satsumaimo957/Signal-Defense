using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public int enemyCount = 5;
    public float spawnInterval = 1.0f;

    public bool isFinished = false;

    // void Start()
    // {
    //     StartCoroutine(SpawnEnemies());
    // }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemyPrefab, spawn.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float interval;
    }

    public Wave[] waves;

    public void StartSpawning()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int w = 0; w < waves.Length; w++)
        {
            UIManager.Instance.UpdateWave(w + 1);
            Wave wave = waves[w];

            for (int i = 0; i < wave.enemyCount; i++)
            {
                Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(enemyPrefab, spawn.position, Quaternion.Euler(0, 180, 0));

                yield return new WaitForSeconds(wave.interval);
            }

            yield return new WaitForSeconds(3f); // ウェーブ間
        }

        isFinished = true;

        GameManager.Instance.CheckClear();
    }
}