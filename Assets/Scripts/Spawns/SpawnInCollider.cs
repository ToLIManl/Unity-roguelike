using UnityEngine;
using System.Collections.Generic;

public class SpawnInCollider : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;
    public static int currentEnemies;
    public static int EnemyKillsInRoom = -1;
    public static int EnemyRandom;
    
    public Sprite WallSprite; 
    
    public bool TempP = false;
    
    public GameObject secondObject;
    
    
    
    private Collider2D spawnArea;
    

    private void Start()
    {
        spawnArea = GetComponent<Collider2D>();
        EnemyRandom = Random.Range(10, 15);
    }


    
    private void SpawnEnemy()
    {
  
        if (currentEnemies <= EnemyRandom)
        {
            // Генерируем случайную точку внутри коллайдера зоны спавна
            Vector2 randomPoint = GetRandomPointInBounds(spawnArea.bounds);

            // Создаем врага в случайной точке
            Instantiate(enemyPrefab, randomPoint, Quaternion.identity, GameObject.Find("LightObject").transform);
            
            currentEnemies++;
        }
        else
        {
            CancelInvoke("SpawnEnemy");
            TempP = true;
            currentEnemies = 0;

        }
    }
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && TempP == false)
        {
            Collider2D collider = secondObject.GetComponent<Collider2D>();
            collider.isTrigger = false;
            SpriteRenderer spriteRenderer = secondObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = WallSprite;
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }


        

    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyKillsInRoom++;
            if (EnemyKillsInRoom >= EnemyRandom)
            {
                Collider2D collider = secondObject.GetComponent<Collider2D>();
                collider.isTrigger = true;
                SpriteRenderer spriteRenderer = secondObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = null;
            }
        }
    }
    
    
    
    
    

    
    
    private Vector2 GetRandomPointInBounds(Bounds bounds)
    {
        // Генерируем случайные координаты внутри границ bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        // Возвращаем случайную точку
        return new Vector2(randomX, randomY);
    }
}