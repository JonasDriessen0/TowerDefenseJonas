using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
}
