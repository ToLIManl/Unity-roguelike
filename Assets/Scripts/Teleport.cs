using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleport : MonoBehaviour
{
    public Transform teleport2;
    public GameObject Player;

    public static bool IsTeleport2 = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Teleport2.IsTeleport1 == false)
        {
            Vector3 targetPosition = teleport2.position; // Получение позиции (координат) объекта
            Player.transform.position = targetPosition;
            IsTeleport2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Teleport2.IsTeleport1 = false;
    }
    
}
