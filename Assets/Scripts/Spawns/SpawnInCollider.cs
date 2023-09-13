using UnityEngine;

public class SpawnInCollider : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.1f;
    public static int currentEnemies;

    
    
    private Collider2D spawnArea;
    

    private void Start()
    {
        // Получаем коллайдер объекта, представляющего зону спавна
        spawnArea = GetComponent<Collider2D>();

        // Запускаем метод SpawnEnemy каждые spawnInterval секунд
        
    }

    void Update()
    {

    }

    private void SpawnEnemy()
    {
  
        if (currentEnemies <= 15)
        {
            // Генерируем случайную точку внутри коллайдера зоны спавна
            Vector2 randomPoint = GetRandomPointInBounds(spawnArea.bounds);

            // Создаем врага в случайной точке
            Instantiate(enemyPrefab, randomPoint, Quaternion.identity, GameObject.Find("LightObject").transform);

            // Увеличиваем счетчик текущих врагов
            currentEnemies++;
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
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