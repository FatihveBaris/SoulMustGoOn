using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    float timer;
    bool hasSpawnTimerBeenReducedAt15 = false;
    bool hasSpawnTimerBeenReducedAt30 = false;
    bool hasSpawnTimerBeenReducedAt45 = false;
    bool hasSpawnTimerBeenReducedAt59 = false;
    [SerializeField] float timerShorter;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }

        // Oyunun süresini al ve saniye cinsinden dönüştür
        int gameSeconds = (int)Time.timeSinceLevelLoad % 60;

        // Eğer oyunun süresi 15, 30, 45 veya 59. saniye ise
        if (gameSeconds == 15 && !hasSpawnTimerBeenReducedAt15)
        {
            // spawnTimer'ı 1.1'e böl
            spawnTimer /= timerShorter;
            hasSpawnTimerBeenReducedAt15 = true;
        }
        else if (gameSeconds == 30 && !hasSpawnTimerBeenReducedAt30)
        {
            spawnTimer /= timerShorter;
            hasSpawnTimerBeenReducedAt30 = true;
        }
        else if (gameSeconds == 45 && !hasSpawnTimerBeenReducedAt45)
        {
            spawnTimer /= timerShorter;
            hasSpawnTimerBeenReducedAt45 = true;
        }
        else if (gameSeconds == 59 && !hasSpawnTimerBeenReducedAt59)
        {
            spawnTimer /= timerShorter;
            hasSpawnTimerBeenReducedAt59 = true;
        }
        else if (gameSeconds != 15 && gameSeconds != 30 && gameSeconds != 45 && gameSeconds != 59)
        {
            hasSpawnTimerBeenReducedAt15 = false;
            hasSpawnTimerBeenReducedAt30 = false;
            hasSpawnTimerBeenReducedAt45 = false;
            hasSpawnTimerBeenReducedAt59 = false;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }
}
