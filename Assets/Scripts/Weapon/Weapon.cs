using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float offset;
    
    private float nextFireTime = 0f;
    
    public bool facingRight = true;

    public static float TempFire;

    public float firerate = 1f;
    public float canfire;
    public static int damage;
    public static bool isCRIT = false;


    private void Start()
    {
        TempFire = firerate;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
        
    }
    
    
    
    void flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            // Move the weapon to the left side of the player
            transform.localPosition = new Vector3(-0.6f, transform.localPosition.y, transform.localPosition.z);
            // Flip the weapon to face left

            transform.localScale = new Vector3(1.428571f, 1.428571f, 1f);
            facingRight = false;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            // Move the weapon to the right side of the player
            transform.localPosition = new Vector3(0.6f, transform.localPosition.y, transform.localPosition.z);
            // Flip the weapon to face right

            transform.localScale = new Vector3(1.428571f, 1.428571f, 1f);
            facingRight = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        flip();
        
        if (Time.timeScale == 0)
            return;
        damage = Random.Range(20, 25); 
        
        bool isCritical = Random.Range(0f, 1f) <= 0.25f;
        
        if (isCritical)
        {
            damage *= 2;
            isCRIT = true;
        }
        else
        {
            isCRIT = false;
        }

        
        transform.position = new Vector3(transform.position.x, transform.position.y, -3);

        new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 3);

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (1f / firerate); // Calculate the next allowed shooting time based on the firerate /////CHATGPT
            Shoot();
            
            /*if (Input.GetButton("Fire1") && Time.time > canfire) это человек сделал
            {
                canfire = Time.time + firerate;
                
  
        */}
    }

    


    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.parent = GameObject.Find("Bullet parent").transform;


        if (TempFire != firerate)
        {
            firerate = TempFire;
        }

    }
}