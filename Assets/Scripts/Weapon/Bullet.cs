using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 20;
    public int RSpeed;
    public float bulletLifeTime = 5;
    public LayerMask destroyableObjectsLayer;
    public GameObject impactEffect;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        RSpeed = Random.Range(18, 22);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * RSpeed;

        StartCoroutine(DestroyBulletOnTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyableObjectsLayer == (destroyableObjectsLayer | (1 << collision.gameObject.layer)))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
        // Add any impact effects if needed, e.g., instantiate impactEffect at the bullet's position
    }

    IEnumerator DestroyBulletOnTime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        DestroyBullet();
    }
}

















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 20;

    public Rigidbody2D rb;
    private Vector3 target;
    public GameObject trailBullet;
    public float bulletLifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
        var lastTrail = Instantiate(trailBullet,gameObject.transform.position,Quaternion.identity);
        lastTrail.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestorBulletOnTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

      if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
      
      if (collision.gameObject.tag == "SpeciallWall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestorBulletOnTime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
*/