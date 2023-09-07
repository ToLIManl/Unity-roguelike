using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public static int maxHP = 1002;
    public static int TempCurrentHp;
    public static int currentHP;
    public bool facingRight = true;
    public bool isInShop = false;
    public static TMP_Text HP_Text;

    public static bool gameOver = false;

    public static bool IsShield = false;
    

    
    

    public GameObject shopPanel;
    public GameObject weapon;

    private Rigidbody2D rb;
    public static HPbar hpBar;
    public TMP_Text gameoverText;
    
    
    private Vector2 moveDirection;
    private float currentSpeed;
    
    public GameObject floatingDamage;
    
    
    
    private bool isBeingPushed = false;
    


    void Start()
    {
        TempCurrentHp = currentHP;
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
        
        HP_Text = GetComponent<TMP_Text>();
        GetComponent<TMP_Text>();
        
        currentHP = maxHP;
        hpBar = GetComponent<HPbar>();
        hpBar.SetMaxHealth(maxHP);
    }

    void Update()
    {

            // Get input axis values for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

            // Calculate movement direction and normalize it
        moveDirection = new Vector2(moveX, moveY).normalized;

        currentSpeed = moveDirection.magnitude * speed;
        

    }

    void FixedUpdate()
    {
        //if (!isBeingPushed) // Если игрок не отталкивается
        {
            rb.velocity = moveDirection * currentSpeed; // Позволяем игроку двигаться
        }
    }



    public void ChooseBlock(string choise)
    {
        // Handle the shop choices here
    }

    public static void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        hpBar.SetHealth(currentHP);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && IsShield == false)
        {
            
            //isBeingPushed = true;
            //Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            //float combinedSpeed = rb.velocity.magnitude + collision.rigidbody.velocity.magnitude;
            //float pushForceFactor = Mathf.Clamp(combinedSpeed, 0.5f, 5f); // Подберите значения по вашему усмотрению
            //rb.AddForce(pushDirection * pushForce * pushForceFactor, ForceMode2D.Impulse);

            //StartCoroutine(StopBeingPushed());
            
            

            
            currentHP -= Random.Range(6, 13);
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            hpBar.SetHealth(currentHP);
            
            TempCurrentHp = currentHP;
            
            // Instantiate(floatingDamage, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 3), Quaternion.identity, GameObject.Find("Effects").transform);
            
            if (currentHP <= 0)
            {
                gameOver = true;
                Time.timeScale = 0;
                gameoverText.gameObject.SetActive(true);
            }
            
            
        }
    }

    private void OnCollisionExit(Collision other)
    {
        
    }


    /*private IEnumerator StopBeingPushed()
    {
        yield return new WaitForSeconds(waitSec); // Подберите подходящее значение задержки
        isBeingPushed = false; // Отключаем отталкивание
    }*/


    public static void UpdateBars()
    {
        hpBar.slider.maxValue = maxHP;
        HP_Text.text = TempCurrentHp.ToString();
    }
    
}





















/*


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public bool facingRight;
    public bool isInShop = false;
    public float speed = 1f;
    public bool isMoving;

    public GameObject shopPanel;
    public GameObject weapon;

    public string shopChoise;

    public int HP;

    private int MaxHP;
    private int MaxXP;
    public HPbar HPbar;
    public TMP_Text gameoverText;

    Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
        HPbar.SetHealth(HP);
       
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        //open shop
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            isInShop = !isInShop;

            if (isInShop)
            {
                shopChoise = "green stuff";
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider.gameObject.tag == "Grid")
            {
                hit.collider.gameObject.GetComponent<OnMouseScript>().OnMouseExit();
                hit.collider.gameObject.GetComponent<OnMouseScript>().OnMouseEnter();
            }

        }
        /*
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.W)) moveY = +1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
        */
/*
    }


    private void FixedUpdate()
    {/*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);*/
/*
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.W)) moveY = +1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }


    void flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = false;
            //weapon.transform.position = new Vector3(weapon.transform.position.x,weapon.transform.position.y, -1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = true;
            //weapon.transform.position = new Vector3(weapon.transform.position.x,weapon.transform.position.y, -1);
        }
    }

    public void ChooseBlock(string choise)
    {
        if (choise == "alt")
        {
            shopChoise = "alt";
        }
        else if (choise == "green stuff")
        {
            shopChoise = "green stuff";
        }
        else if(choise == "4x4 shit")
        {
            shopChoise = "4x4 shit";
        }
        else print(choise);
        
    }
    
    
    public void Heal(int amount)
    {
        HP += amount;
        HPbar.SetHealth(HP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HP -= Random.Range(6,13); 
            HPbar.SetHealth(HP);
        }
        
        
        
        if (HP <= 0)
        {
            HP = 0;
            HPbar.SetHealth(HP);
            Time.timeScale = 0;
            gameoverText.gameObject.SetActive(true);
        }
    }
    
}

*/