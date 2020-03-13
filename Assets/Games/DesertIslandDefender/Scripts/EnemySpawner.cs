using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<WaveSO> waves;
    List<Transform> spawnPoints;
    int spawnPointCount;
    int waveNumber;
    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new List<Transform>();

        foreach (Transform child in transform) {
            spawnPoints.Add(child);
        }

        spawnPointCount = spawnPoints.Count;
        enemyCount = 0;
        waveNumber = 0;
    }

    // Update is called once per frame
    void Update() {
        if ( enemyCount < 1 ) {
            StartCoroutine(spawnWave(waveNumber++));
        }
    }

    IEnumerator spawnWave(int index) {
        WaveSO wave = waves[index];
        for (int i=0; i<wave.waveElements.Count; i++) {
            wavePart element = wave.waveElements[i];
            int delay = element.delay;

            for (int j=0; j< element.amount; j++) {
                enemyCount++;
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPointCount)];
                Instantiate(enemyPrefab, spawnPoint);
                yield return new WaitForSeconds(delay);
            }
        }

    }
}
