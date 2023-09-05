using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    

    
    

    public float LifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestoyOnTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    IEnumerator DestoyOnTime()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}