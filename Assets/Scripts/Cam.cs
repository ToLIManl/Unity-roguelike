using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    public int sensX;
    public int sensY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + (Input.mousePosition.x - 1920 / 2) / sensX,
                                         player.transform.position.y + (Input.mousePosition.y - 1080 / 2) / sensY,
                                         transform.position.z);

    }
}
