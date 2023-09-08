using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    
    public GameObject bossPrefab;

    public int HowMuchNeedToSpawnKill = 10;
    private bool CanSpawnBoss = false;
    
    private Transform playerTransform;
    
    
    
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Player.EnemyKills10 >= HowMuchNeedToSpawnKill)
        {
            CanSpawnBoss = true;
            SpawnBosses();
        }
    }
    
    
    private void SpawnBosses()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
            

        if (CanSpawnBoss == true)
        {
                Player.EnemyKills10 = 1;
                CanSpawnBoss = false;
                Instantiate(bossPrefab, spawnPosition, Quaternion.identity, GameObject.Find("LightObject").transform);
                bossPrefab.GetComponent<Boss>().RecalculateBar();
            
            
            
        }
        
    }
    
    
    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;

        // Генерируем случайную позицию
        do
        {
            spawnPosition = new Vector3(Random.Range(-20 / 2f, 20 / 2f),
                Random.Range(-20 / 2f, 20 / 2f), 0f);
        } while (Vector3.Distance(spawnPosition, playerTransform.position) < 2f); // Проверяем расстояние до игрока

        return spawnPosition;
    }
    
    
    
    
}
