using Unity.VisualScripting;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    
    public Transform targetObject;  // Объект, который вы хотите переместить
    public Vector3 targetPosition = new Vector3(-4.87f, -1.17f, 0.04561596f);
    public Vector3 targetPosition2 = new Vector3(-22.6f, 0.71f, 0.04561596f);// Целевая позиция, куда вы хотите переместить объект
    void OnTriggerEnter2D(Collider2D collision)
    {
        TeleportDoor();
    }
    
    void TeleportDoor()
    {
        targetObject.position = targetPosition;
    }

    void Update()
    {
        if (Player.EnemyKills10 >= 10)
        {
            targetObject.position = targetPosition2;
        }
        
        
    }
    
}