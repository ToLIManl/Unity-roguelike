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
    public static int maxHP = 100;
    public static int TempCurrentHp;
    public static int currentHP;
    public bool facingRight = true;
    public bool isInShop = false;
    public static TMP_Text HP_Text;

    public static bool gameOver = false;

    public static bool IsShield = false;

    public static int AllEnemyKills;
    public static int EnemyKills10;
    public static int BossKills10;
    public int TempEnemyKills10;
    

    
    public GameObject shopPanel;
    public GameObject weapon;

    private Rigidbody2D rb;
    public static HPbar hpBar;
    public TMP_Text gameoverText;
    
    
    private Vector2 moveDirection;
    private float currentSpeed;
    
    public GameObject floatingDamage;
    
    public float dashForce = 10f; // Сила рывка
    public float dashSpeed = 5f; 
    public float dashTime = 0.5f; 
    
    
    
    private bool isBeingPushed = false;
    private bool isDashing = false;
    
    
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10;
    public float dashStaminaCost = 30;
    public StaminaSlider staminaSlider; // Перетащите сюда ваш StaminaSlider из сцены
    

    void Start()
    {
        TempCurrentHp = currentHP;
        currentStamina = maxStamina;
        
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

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(moveX, moveY).normalized;

        currentSpeed = moveDirection.magnitude * speed;
        
        
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && currentStamina >= dashStaminaCost)
        {
            // Нормализуем направление рывка и умножаем на силу рывка и скорость рывка
            Vector2 dashDirection = moveDirection.normalized * dashForce *+ dashSpeed;
            rb.AddForce(dashDirection, ForceMode2D.Impulse);
            isDashing = true; // Указываем, что игрок в рывке

            // Вычитаем стамину после рывка
            currentStamina -= dashStaminaCost;

            // Отключаем рывок через 0.5 секунды (или другое нужное время)
            Invoke("StopDashing", dashTime);
        }
        
        if(currentStamina <= 99.99f)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        
            staminaSlider.UpdateStamina(currentStamina, maxStamina);
        }

    }
    
    

    void FixedUpdate()
    {
        
        if (!isDashing)
        {
            rb.velocity = moveDirection * currentSpeed;
        }

    }



    void StopDashing()
    {
        isDashing = false;
    }
    
    
    
    
    

    public static void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        hpBar.SetHealth(currentHP);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentHP <= 0)
        {
            gameOver = true;
            Time.timeScale = 0;
            currentHP = 0;
            gameoverText.gameObject.SetActive(true);
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        
    }





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