using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public TMP_Text waveNumberText;
    public GameObject soldierPrefab;
    public GameObject WaveButton;
    public WaypointFollower enemyScript;
    public EnemyHP ehp;

    private float spawnSpeed = 1.4f;
    private int waveNumber = 0;
    private int soldiersToSpawn = 6;
    private int remainingSoldiers = 0;

    void Start()
    {
        ehp.hp = 50;
        StartNewWave();
        enemyScript.speed = 1.5f;
    }

    void Update()
    {
        int remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (remainingEnemies <= 0)
        {
            WaveButton.SetActive(true);
        }

        waveNumberText.text = "Wave " + waveNumber;
    }

    public void StartNewWave()
    {
        WaveButton.SetActive(false);
        waveNumber++;
        remainingSoldiers = soldiersToSpawn;

        StartCoroutine(SpawnSoldiers());
        soldiersToSpawn += 3 * waveNumber;

        if(spawnSpeed >= 0.2f)
            spawnSpeed -= (0.013f * waveNumber);

        if(enemyScript.speed <= 30f)
            enemyScript.speed += (0.07f * waveNumber);

        if (ehp.hp <= 260)
            ehp.hp += (1.7f * waveNumber);
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
}