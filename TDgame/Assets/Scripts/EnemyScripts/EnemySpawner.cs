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

    public bool canSpawnTank;
    public bool canSpawnCyborg;

    private float spawnSpeed = 1;
    private int waveNumber = 0;
    private int soldiersToSpawn = 6;
    private int remainingSoldiers = 0;

    void Start()
    {
        StartNewWave();
        enemyScript.speed = 1.5f;
        canSpawnTank = false;
        canSpawnCyborg = false;
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
        soldiersToSpawn += 3 * waveNumber;

        if(spawnSpeed >= 0.3f)
            spawnSpeed -= (0.02f * waveNumber);

        if(enemyScript.speed <= 20f)
            enemyScript.speed += (0.08f * waveNumber);
    }

    IEnumerator SpawnSoldiers()
    {
        for (int i = 0; i < remainingSoldiers; i++)
        {
            Instantiate(soldierPrefab);
            remainingSoldiers--;
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(soldierPrefab);
        remainingSoldiers--;
    }
}