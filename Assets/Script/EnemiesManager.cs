using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject goblin;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] float spawnGoblin;
    float timerGoblin;
    [SerializeField] GameObject player;
    [SerializeField] float timerShorter;
    float timer;
    
    bool hasSpawnTimerBeenReducedAt15 = false;
    bool hasSpawnTimerBeenReducedAt30 = false;
    bool hasSpawnTimerBeenReducedAt45 = false;
    bool hasSpawnTimerBeenReducedAt59 = false;
    private void Update()
    {
        int gameSeconds = (int)Time.timeSinceLevelLoad % 60;
        int gameSeconds2 = (int)Time.timeSinceLevelLoad;
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
        timerGoblin -= Time.deltaTime;
        if(timerGoblin < 0f && gameSeconds2 >= 60)
        {
            SpawnEnemy2();
            timerGoblin = spawnGoblin;
        }
        // Oyunun süresini al ve saniye cinsinden dönüştür
        

        // Eğer oyunun süresi 15, 30, 45 veya 59. saniye ise
        if (gameSeconds == 15 && !hasSpawnTimerBeenReducedAt15)
        {
            // spawnTimer'ı 1.1'e böl
            spawnTimer /= timerShorter;
            if(gameSeconds2 >= 60){spawnGoblin /= timerShorter;}
            hasSpawnTimerBeenReducedAt15 = true;
        }
        else if (gameSeconds == 30 && !hasSpawnTimerBeenReducedAt30)
        {
            spawnTimer /= timerShorter;
            if(gameSeconds2 >= 60){spawnGoblin /= timerShorter;}
            hasSpawnTimerBeenReducedAt30 = true;
        }
        else if (gameSeconds == 45 && !hasSpawnTimerBeenReducedAt45)
        {
            spawnTimer /= timerShorter;
            if(gameSeconds2 >= 60){spawnGoblin /= timerShorter;}
            hasSpawnTimerBeenReducedAt45 = true;
        }
        else if (gameSeconds == 59 && !hasSpawnTimerBeenReducedAt59)
        {
            spawnTimer /= timerShorter;
            if(gameSeconds2 >= 60){spawnGoblin /= timerShorter;}
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

        GameObject newEnemy = Instantiate(skeleton);
        newEnemy.transform.position = position;
    }
    private void SpawnEnemy2()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy2 = Instantiate(goblin);
        newEnemy2.transform.position = position;
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
