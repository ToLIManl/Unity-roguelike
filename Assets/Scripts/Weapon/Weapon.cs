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
    
    public GameObject effects;
    
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
            
            transform.localPosition = new Vector3(-0.6f, transform.localPosition.y, transform.localPosition.z);

            transform.localScale = new Vector3(1.428571f, 1.428571f, 1f);
            facingRight = false;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            
            transform.localPosition = new Vector3(0.6f, transform.localPosition.y, transform.localPosition.z);
            
            transform.localScale = new Vector3(1.428571f, 1.428571f, 1f);
            facingRight = true;
        }
    }
    
    private void CalculateDamage()
    {
        damage = Random.Range(20, 25);
        isCRIT = Random.Range(0f, 1f) <= 0.25f;
        //if (AngryWarrior.IsAngry == true)
        {
            damage += 10;
        }
        
        if (isCRIT)
        {
            damage *= 2;
        }
        else
        {
            isCRIT = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        flip();
        
        if (Time.timeScale == 0)
            return;
        
        
        

        transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (1f / firerate); // Calculate the next allowed shooting time based on the firerate /////CHATGPT
            Shoot();
            }
    }

    


    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.parent = GameObject.Find("Bullet parent").transform;
        
        CalculateDamage();


        if (TempFire != firerate)
        {
            firerate = TempFire;
        }

    }
}