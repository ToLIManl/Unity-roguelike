using Unity.VisualScripting;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    
    public Transform targetObject;  // Объект, который вы хотите переместить
    public Vector3 targetPosition = new Vector3(-4.87f, -1.17f, 0.1f);
    public Vector3 targetPosition2 = new Vector3(-4.962f, -0.211f, 0.1f);// Целевая позиция, куда вы хотите переместить объект
    
    public float moveSpeed = 3f; // Скорость перемещения
    private bool isMoving = false;
    private bool TempP = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isMoving = true;
            TempP = true;
        }
        
    }
    
    void TeleportDoor()
    {
        targetObject.position = targetPosition;
    }
    
    void MoveTowardsTarget()
    {
        // Интерполируем позицию объекта к целевой позиции
        targetObject.position = Vector3.MoveTowards(targetObject.position, targetPosition, moveSpeed * Time.deltaTime);

        // Проверяем, достиг ли объект целевой позиции
        if (Vector3.Distance(targetObject.position, targetPosition) < 0.01f)
        {
            // Достигли цели, завершаем перемещение
            isMoving = false;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
        //if (SpawnInCollider.EnemyKillsInRoom >= SpawnInCollider.EnemyRandom)
        {
            isMoving = true;
            targetPosition = targetPosition2;
            //targetObject.position = targetPosition2;
            //SpawnInCollider.EnemyKillsInRoom = 0;

        }
        
        
    }
    
}