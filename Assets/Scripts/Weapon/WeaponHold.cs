using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour
{
    public bool hold;
    public float distance = 2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    

    
    
    public Transform targetFolder; // Перетащите в инспекторе объект-папку, в которую хотите переместить
    public Transform player; // Перетащите в инспекторе объект игрока

    public Vector3 offset; // Смещение относительно игрока
    public float zRotation; // Угол поворота по оси Z

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hold)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if (hit.collider != null)
                {
                    hold = true;

                }
            }
        }

        if (hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }
    
    
    
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
