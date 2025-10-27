using System.Collections;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(7.0f);
        }
    }
    

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
