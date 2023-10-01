using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleport2 : MonoBehaviour
{
    public Transform Teleport1;
    public GameObject Player;

    public static bool IsTeleport1 = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Teleport.IsTeleport2 == false)
        {
            Vector3 targetPosition = Teleport1.position; // Получение позиции (координат) объекта
            Player.transform.position = targetPosition;
            IsTeleport1 = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Teleport.IsTeleport2 = false;
    }
    
}
