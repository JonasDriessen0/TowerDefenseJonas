using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public TMP_Text waveNumberText;
    public GameObject soldierPrefab;
    public GameObject tankPrefab;
    public GameObject cyborgPrefab;
    public WaypointFollower enemyScript;

    public float spawnSpeed = 1;
    private int waveNumber = 0;
    private int soldiersToSpawn = 6; // Initial number of soldiers
    private int remainingSoldiers = 0; // Number of remaining soldiers to spawn

    void Start()
    {
        StartNewWave(); // Start the first wave
    }

    void Update()
    {
        int remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (remainingEnemies <= 0)
        {
            StartNewWave();
        }

        waveNumberText.text = "Wave " + waveNumber;
    }

    void StartNewWave()
    {
        waveNumber++;
        remainingSoldiers = soldiersToSpawn;

        StartCoroutine(SpawnSoldiers());
        soldiersToSpawn += 3*waveNumber;
        if (spawnSpeed >= 0.3f)
        {
            spawnSpeed -= (0.02f * waveNumber);
        }
        if (enemyScript.speed <= 20f)
        {
            enemyScript.speed += (0.08f * waveNumber);
        }
    }

    IEnumerator SpawnSoldiers()
    {
        for (int i = 0; i < remainingSoldiers; i++)
        {
            SpawnEnemy(soldierPrefab);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        remainingSoldiers--;
    }
}
